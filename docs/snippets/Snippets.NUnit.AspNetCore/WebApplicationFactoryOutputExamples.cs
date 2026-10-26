using System.Collections.Concurrent;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Snippets.NUnit.AspNetCore;

#region PreserveExecutionContextFactory
public sealed class TestWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        // Flow the calling test's ExecutionContext, and with it NUnit's test context,
        // into the in-memory server so that output written while handling a request
        // is attributed to the test that sent the request.
        builder.ConfigureServices(services =>
            services.Configure<TestServerOptions>(options => options.PreserveExecutionContext = true));
    }
}
#endregion

#region PreserveExecutionContextOneTimeSetUp
public class SharedFactoryTests
{
    private TestWebApplicationFactory _factory = null!;
    private HttpClient _client = null!;

    [OneTimeSetUp]
    public void CreateFactory()
    {
        _factory = new TestWebApplicationFactory();
        _client = _factory.CreateClient();
    }

    [OneTimeTearDown]
    public void DisposeFactory()
    {
        _client.Dispose();
        _factory.Dispose();
    }

    [Test]
    public async Task HandlerOutputAppearsUnderThisTest()
    {
        var body = await _client.GetStringAsync("/");

        // The Console.WriteLine and ILogger output written by the request handler
        // is part of this test's output, even though the factory is shared.
        Assert.That(body, Is.EqualTo("Hello from the application"));
    }

    [Test]
    public async Task HandlerOutputAppearsUnderThisOtherTest()
    {
        var body = await _client.GetStringAsync("/");

        Assert.That(body, Is.EqualTo("Hello from the application"));
    }
}
#endregion

public class FactoryPerTestTests
{
    #region PreserveExecutionContextProperty
    [Test]
    public async Task SetThePropertyOnTheServerBeforeCreatingAClient()
    {
        await using var factory = new WebApplicationFactory<Program>();
        factory.Server.PreserveExecutionContext = true;

        using var client = factory.CreateClient();
        var body = await client.GetStringAsync("/");

        Assert.That(body, Is.EqualTo("Hello from the application"));
    }
    #endregion
}

#region TextWriterLoggerProvider
/// <summary>
/// Forwards ILogger output to a TextWriter chosen by the test, such as TestContext.Out.
/// </summary>
public sealed class TextWriterLoggerProvider(TextWriter writer) : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName) => new TextWriterLogger(categoryName, writer);

    public void Dispose()
    {
    }

    private sealed class TextWriterLogger(string category, TextWriter writer) : ILogger
    {
        public IDisposable? BeginScope<TState>(TState state)
            where TState : notnull => null;

        public bool IsEnabled(LogLevel logLevel) => logLevel >= LogLevel.Information;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            writer.WriteLine($"{logLevel} {category}: {formatter(state, exception)}");
        }
    }
}
#endregion

public class RealServerTests
{
    #region KestrelCapturedWriter
    [Test]
    public async Task OutputFromARealServerGoesToTheWriterCapturedByTheTest()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseUrls("http://127.0.0.1:0"); // Kestrel on a free loopback port

        // Capture the writer here, while this test's context is current. The writer
        // stays bound to this test no matter which thread later writes to it.
        builder.Logging.ClearProviders();
        builder.Logging.AddProvider(new TextWriterLoggerProvider(TestContext.Out));

        await using var app = builder.Build();
        app.MapGet("/", (ILogger<RealServerTests> logger) =>
        {
            logger.LogInformation("Handled a request on a Kestrel thread");
            return "Hello from Kestrel";
        });
        await app.StartAsync();

        using var client = new HttpClient();
        var body = await client.GetStringAsync(app.Urls.First());

        Assert.That(body, Is.EqualTo("Hello from Kestrel"));
    }
    #endregion
}

// The fixtures below are not shown in the documentation. They prove the claims made there by
// recording which NUnit test is current when the application's ILogger is called.

public sealed class CurrentTestRecordingLoggerProvider : ILoggerProvider
{
    private readonly ConcurrentBag<(string Category, string TestName)> _entries = [];

    /// <summary>
    /// The NUnit test names that were current when the request handler's own logger was called.
    /// Host start-up messages are excluded because the host is built lazily by the first test
    /// and those messages are written in that test's context regardless of the setting.
    /// </summary>
    public IEnumerable<string> TestNamesSeenByHandlerLogger =>
        _entries.Where(e => e.Category == nameof(Program)).Select(e => e.TestName);

    public ILogger CreateLogger(string categoryName) => new RecordingLogger(this, categoryName);

    public void Dispose()
    {
    }

    private sealed class RecordingLogger(CurrentTestRecordingLoggerProvider owner, string category) : ILogger
    {
        public IDisposable? BeginScope<TState>(TState state)
            where TState : notnull => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            owner._entries.Add((category, TestContext.CurrentContext.Test.Name));
        }
    }
}

public class PreserveExecutionContextVerification
{
    private readonly CurrentTestRecordingLoggerProvider _recorder = new();
    private WebApplicationFactory<Program> _factory = null!;

    [OneTimeSetUp]
    public void CreateFactory()
    {
        _factory = new TestWebApplicationFactory().WithWebHostBuilder(builder =>
            builder.ConfigureLogging(logging => logging.AddProvider(_recorder)));
    }

    [OneTimeTearDown]
    public void DisposeFactory() => _factory.Dispose();

    [Test]
    public async Task FirstTestSeesItsOwnName()
    {
        using var client = _factory.CreateClient();
        await client.GetStringAsync("/");

        Assert.That(_recorder.TestNamesSeenByHandlerLogger, Does.Contain(nameof(FirstTestSeesItsOwnName)));
    }

    [Test]
    public async Task SecondTestSeesItsOwnName()
    {
        using var client = _factory.CreateClient();
        await client.GetStringAsync("/");

        Assert.That(_recorder.TestNamesSeenByHandlerLogger, Does.Contain(nameof(SecondTestSeesItsOwnName)));
    }
}

public class DefaultFactoryVerification
{
    private readonly CurrentTestRecordingLoggerProvider _recorder = new();
    private WebApplicationFactory<Program> _factory = null!;

    [OneTimeSetUp]
    public void CreateFactory()
    {
        _factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            builder.ConfigureLogging(logging => logging.AddProvider(_recorder)));
    }

    [OneTimeTearDown]
    public void DisposeFactory() => _factory.Dispose();

    [Test]
    public async Task WithoutPreserveExecutionContextTheHandlerRunsInAnAdHocContext()
    {
        using var client = _factory.CreateClient();
        await client.GetStringAsync("/");

        // NUnit's placeholder context reports a test called AdhocTestMethod.
        Assert.That(_recorder.TestNamesSeenByHandlerLogger, Is.EqualTo(new[] { "AdhocTestMethod" }));
    }
}

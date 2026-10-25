using NUnit.Framework;

namespace Snippets.NUnit.AssertIgnore;

#region AssertIgnoreInTest
public class ReportingDatabaseTests
{
    [Test]
    public void NightlyRollupMatchesLedger()
    {
        var connectionString = Environment.GetEnvironmentVariable("REPORTING_DB");
        if (string.IsNullOrEmpty(connectionString))
            Assert.Ignore("REPORTING_DB is not set; the reporting database is not available here.");

        // Nothing below this line runs when the test is ignored.
        Assert.That(connectionString, Does.StartWith("Server="));
    }
}
#endregion

#region AssertIgnoreInOneTimeSetUp
public class MessageQueueTests
{
    [OneTimeSetUp]
    public void ConnectToQueue()
    {
        if (Environment.GetEnvironmentVariable("MQ_HOST") is null)
            Assert.Ignore("MQ_HOST is not set; message queue tests need a reachable broker.");

        // Connect to the broker...
    }

    // Every test in this fixture is reported as ignored with the reason above.
    [Test]
    public void PublishesMessage() => Assert.Pass();

    [Test]
    public void ReceivesMessage() => Assert.Pass();
}
#endregion

#region WarningsThenIgnore
public class WarningsThenIgnoreExample
{
    [Test]
    public void WarnsThenIgnores()
    {
        Assert.Warn("The cache was cold, so timings below are not representative.");
        Warn.If(DateTime.UtcNow.Hour == 3, "Running during the nightly maintenance window.");

        Assert.Ignore("Results cannot be trusted on this run.");
    }
}
#endregion

#region IgnoreIfHelper
public static class Ignore
{
    public static void If(bool condition, string reason)
    {
        if (condition)
            Assert.Ignore(reason);
    }

    public static void Unless(bool condition, string reason)
    {
        if (!condition)
            Assert.Ignore(reason);
    }
}

public class ConditionalIgnoreTests
{
    [TestCase(41)]
    [TestCase(42)]
    public void Calculate(int input)
    {
        Ignore.If(input == 42, $"{input} is not supported on this platform yet.");
        Ignore.Unless(OperatingSystem.IsWindows() || OperatingSystem.IsLinux(), "Only verified on Windows and Linux.");

        Assert.That(input, Is.LessThan(100));
    }
}
#endregion

public class AssertIgnoreBehaviourTests
{
    [Test]
    public void AssertIgnoreThrowsIgnoreException()
    {
        Assert.That(() => Assert.Ignore("reason"), Throws.TypeOf<IgnoreException>().With.Message.EqualTo("reason"));
    }

    [Test]
    public void AssertIgnoreIsNotAllowedInsideMultipleAssertBlock()
    {
        Assert.That(() =>
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.Ignore("inside a multiple assert block");
            }
        }, Throws.TypeOf<Exception>().With.Message.Contains("may not be used in a multiple assertion block"));
    }
}

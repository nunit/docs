using NUnit.Framework;

#pragma warning disable CA1822
#pragma warning disable NUnit2045

namespace Snippets.NUnit.Constraints;

public class AsyncConstraintSnippets
{
    #region AsyncSampleService
    // A small service used by the examples below
    public class SampleService
    {
        private int _readyChecks;
        private readonly List<int> _cache = [];

        public Task<int> GetValueAsync() => Task.FromResult(42);

        public Task InitializeAsync() => Task.CompletedTask;

        public Task SafeMethodAsync() => Task.CompletedTask;

        public Task InvalidOperationAsync() => throw new InvalidOperationException("expected error");

        public async Task FailingMethodAsync()
        {
            await Task.Yield();
            throw new InvalidOperationException("expected error");
        }

        public Task FailingWithInnerExceptionAsync() =>
            Task.FromException(new AggregateException(new TimeoutException()));

        // Becomes ready on the third call
        public Task<bool> IsReadyAsync() => Task.FromResult(++_readyChecks >= 3);

        public Task<int> GetCountAsync()
        {
            _cache.Add(_cache.Count);
            return Task.FromResult(_cache.Count);
        }

        public async IAsyncEnumerable<int> GetItemsAsync()
        {
            foreach (var item in new[] { 50, 150, 250, 350, 450 })
            {
                await Task.Yield();
                yield return item;
            }
        }
    }

    public class Calculator
    {
        public Task<int> AddAsync(int a, int b) => Task.FromResult(a + b);
    }
    #endregion

    private readonly SampleService service = new();
    private readonly Calculator calculator = new();

    #region AsyncBasicAssertions
    [Test]
    public void BasicAsyncAssertions()
    {
        // Test async method return values
        Assert.That(async () => await service.GetValueAsync(), Is.EqualTo(42));

        // Test that async method completes without throwing
        Assert.That(async () => await service.InitializeAsync(), Throws.Nothing);

        // Test async exception throwing
        Assert.That(async () => await service.InvalidOperationAsync(),
            Throws.TypeOf<InvalidOperationException>());
    }
    #endregion

    #region AsyncTaskResults
    [Test]
    public async Task TestingTaskResults()
    {
        // Await first, then assert
        var result = await calculator.AddAsync(2, 3);
        Assert.That(result, Is.EqualTo(5));

        // Or use Assert.ThatAsync (NUnit 4.0+)
        await Assert.ThatAsync(async () => await calculator.AddAsync(2, 3), Is.EqualTo(5));
    }
    #endregion

    #region AsyncThrowsConstraint
    [Test]
    public void ThrowsConstraintWithAsync()
    {
        // Test for specific exception type
        Assert.That(async () => await service.FailingMethodAsync(),
            Throws.TypeOf<InvalidOperationException>());

        // Test exception message
        Assert.That(async () => await service.FailingMethodAsync(),
            Throws.TypeOf<InvalidOperationException>()
                .With.Message.Contains("expected error"));

        // Test inner exception
        Assert.That(async () => await service.FailingWithInnerExceptionAsync(),
            Throws.TypeOf<AggregateException>()
                .With.InnerException.TypeOf<TimeoutException>());
    }
    #endregion

    #region AsyncThrowsNothing
    [Test]
    public void ThrowsNothingWithAsync()
    {
        // Verify async method completes successfully
        Assert.That(async () => await service.SafeMethodAsync(), Throws.Nothing);
    }
    #endregion

    #region AsyncDelayedConstraint
    [Test]
    public void DelayedConstraintsWithAsync()
    {
        // Poll until condition is true (or timeout)
        Assert.That(async () => await service.IsReadyAsync(),
            Is.True.After(5).Seconds.PollEvery(100).MilliSeconds);

        // Wait for value to appear
        Assert.That(async () => await service.GetCountAsync(),
            Is.GreaterThan(0).After(2000, 100));
    }
    #endregion

    #region AsyncEnumerable
    [Test]
    public async Task CollectionConstraintsWithAsyncEnumerables()
    {
        // Convert to list first
        var items = await service.GetItemsAsync().ToListAsync();
        Assert.That(items, Has.Count.EqualTo(5));
        Assert.That(items, Is.All.Positive);

        // Or inline the conversion
        Assert.That(await service.GetItemsAsync().ToListAsync(), Has.Some.GreaterThan(100));
    }
    #endregion
}

using System.Diagnostics;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Snippets.NUnit;

public class RetryAttributeExamples
{
    #region Retry
    [TestFixture]
    public sealed class RetryTests
    {
        private readonly Random _random = new(42);

        [Test]
        [Retry(5)]
        public async Task OperationShouldPassIn1s()
        {
            var sw = Stopwatch.StartNew();
            string result = await ExpensiveOperation();
            sw.Stop();
            Assert.That(sw.ElapsedMilliseconds, Is.LessThan(1000), "Operation did not complete in time");
            Assert.That(result, Is.Not.Null);
        }

        private async Task<string> ExpensiveOperation()
        {
            // Simulate an expensive operation
            int duration = _random.Next(500, 1500);
            await Task.Delay(duration); // Simulate work
            return "Actual Result"; // Simulate a response
        }
    }
    #endregion

    #region RetryWithRetryExceptions
    [TestFixture]
    public sealed class Retry
    {
        private int _delayInMilliseconds;

        [OneTimeSetUp]
        public void Setup()
        {
            _delayInMilliseconds = 2500;
        }

        [Test]
        [Retry(5, RetryExceptions = [typeof(OperationCanceledException)])]
        [CancelAfter(2000)]
        public async Task QueryServiceAsync(CancellationToken cancellationToken)
        {
            string result = await CallExternalServiceAsync(cancellationToken);
            Assert.That(result, Is.Not.Null);
        }

        private async Task<string> CallExternalServiceAsync(CancellationToken cancellationToken)
        {
            // Call an external service that may time out
            int delayInMilliseconds = _delayInMilliseconds;
            if (_delayInMilliseconds > 1000)
                _delayInMilliseconds -= 1000; // Decrease delay for next attempt

            await Task.Delay(delayInMilliseconds, cancellationToken); // Simulate a delay that may exceed
            return "Actual Result"; // Simulate a response
        }
    }
    #endregion
}

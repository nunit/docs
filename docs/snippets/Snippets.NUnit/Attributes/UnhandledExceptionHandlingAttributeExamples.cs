using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    [TestFixture]
    public class UnhandledExceptionHandlingAttributeExamples
    {
        #region UnhandledExceptionError
        [Test]
        [UnhandledExceptionHandling(UnhandledExceptionHandling.Error)]
        public void TestWithErrorHandling()
        {
            // Any unhandled exception on background threads will cause this test to fail
            // This is the default behavior
            var task = Task.Run(() =>
            {
                // Work that completes successfully
                Thread.Sleep(10);
            });
            task.Wait();
            Assert.Pass();
        }
        #endregion

        #region UnhandledExceptionIgnore
        [Test]
        [UnhandledExceptionHandling(UnhandledExceptionHandling.Ignore)]
        public void TestIgnoringBackgroundExceptions()
        {
            // Background exceptions are ignored - use with caution!
            // This test will pass even if background threads throw
            using var cts = new CancellationTokenSource();
            var task = Task.Run(() =>
            {
                // Simulate work
                Thread.Sleep(10);
            }, cts.Token);

            task.Wait();
            Assert.Pass();
        }
        #endregion

        #region UnhandledExceptionSpecificTypes
        [Test]
        [UnhandledExceptionHandling(UnhandledExceptionHandling.Ignore, typeof(OperationCanceledException))]
        public void TestIgnoringSpecificExceptions()
        {
            // Only OperationCanceledException is ignored on background threads
            // Other exception types will still cause the test to fail

            _ = Task.Run(() =>
            {
                // This will throw on a background thread
                Thread.Sleep(10);
                throw new OperationCanceledException();
            });

            // The unhandled OperationCanceledException on the background thread
            // will be ignored by the attribute, so this test still passes
            Assert.Pass();
        }
        #endregion

        #region UnhandledExceptionFixtureLevel
        [TestFixture]
        [UnhandledExceptionHandling(UnhandledExceptionHandling.Ignore)]
        public class LegacyCodeTests
        {
            // All tests in this fixture will ignore unhandled exceptions
            // on background threads

            [Test]
            public void TestLegacyComponent()
            {
                // Legacy code that might throw on background threads
                Assert.Pass();
            }

            [Test]
            public void TestAnotherLegacyComponent()
            {
                // This test also ignores background exceptions
                Assert.Pass();
            }
        }
        #endregion

        #region UnhandledExceptionVerification
        [Test]
        public void VerifyUnhandledExceptionAttribute()
        {
            // Verify the attribute can be constructed with different modes
            var errorAttr = new UnhandledExceptionHandlingAttribute(UnhandledExceptionHandling.Error);
            var ignoreAttr = new UnhandledExceptionHandlingAttribute(UnhandledExceptionHandling.Ignore);
            var specificAttr = new UnhandledExceptionHandlingAttribute(
                UnhandledExceptionHandling.Ignore,
                typeof(InvalidOperationException),
                typeof(OperationCanceledException));

            Assert.Multiple(() =>
            {
                Assert.That(errorAttr.Properties.Keys, Does.Contain("UnhandledExceptionHandling"));
                Assert.That(ignoreAttr.Properties.Keys, Does.Contain("UnhandledExceptionHandling"));
                Assert.That(specificAttr.Properties.Keys, Does.Contain("UnhandledExceptionHandling"));
            });
        }
        #endregion
    }
}

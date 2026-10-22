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
            // An exception escaping this thread is not recorded against the test.
            // On .NET Framework the test then passes; on .NET Core and later the
            // runtime still terminates the process, so the thread procedure below
            // must not actually throw.
            var thread = new Thread(() => Thread.Sleep(10));
            thread.Start();
            thread.Join();

            Assert.Pass();
        }
        #endregion

        #region UnhandledExceptionSpecificTypes
        [Test]
        [UnhandledExceptionHandling(UnhandledExceptionHandling.Ignore, typeof(ObjectDisposedException))]
        public void TestIgnoringSpecificExceptions()
        {
            // Only ObjectDisposedException escaping a background thread is ignored.
            // Any other exception type is still recorded as a test error.
            var thread = new Thread(() => Thread.Sleep(10));
            thread.Start();
            thread.Join();

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

        #region UnhandledExceptionThreadAbort
        [Test]
        [UnhandledExceptionHandling(UnhandledExceptionHandling.Ignore, typeof(ThreadAbortException))]
        public void TestWithThreadAbort()
        {
            // Thread.Abort() is not supported on .NET 5+
            // This example demonstrates the pattern for .NET Framework
            if (!IsThreadAbortSupported())
            {
                Assert.Ignore("Thread.Abort() is not supported on this platform");
            }

            // This test uses Thread.Abort() which throws ThreadAbortException
            // Without this attribute, the test would be marked as "cancelled by user"
            var thread = new Thread(() => Thread.Sleep(1000));
            thread.Start();
            thread.Join(500);

#pragma warning disable SYSLIB0006 // Thread.Abort is obsolete
            thread.Abort();
#pragma warning restore SYSLIB0006

            Assert.Pass();
        }

        private static bool IsThreadAbortSupported()
        {
#if NETFRAMEWORK
            return true;
#else
            return false;
#endif
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

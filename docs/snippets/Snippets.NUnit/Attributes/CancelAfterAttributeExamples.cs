using NUnit.Framework;
#pragma warning disable NUnit1029  // Pending https://github.com/nunit/nunit.analyzers/issues/957

namespace Snippets.NUnit.Attributes
{
    public class CancelAfterAttributeExamples
    {
        #region TestWithCancellationToken
        [Test, CancelAfter(2_000)]
        public void RunningTestUntilCanceled(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                /* */
            }
        }
        #endregion

        #region TestCaseSourceWithCancellationToken
        private static int[] _simpleValues = [2, 4, 6, 8];

        [TestCaseSource(nameof(_simpleValues)), CancelAfter(1_000)]
        public void TestCaseSourceWithCancellationToken(int a, CancellationToken cancellationToken)
        {
            Assert.That(cancellationToken, Is.Not.Default);

            while (!cancellationToken.IsCancellationRequested)
            {
                /* */
            }
        }
        #endregion

        #region TestCaseWithCancellationToken
        [CancelAfter(2000)]
        [TestCase("http://example.com/1")]
        [TestCase("http://example.com/2")]
        public async Task PotentiallyLongRunningTest(string uri, CancellationToken token)
        {
            await Task.Delay(10, token);
            Assert.That(uri, Does.StartWith("http://"));
        }
        #endregion
    }
}

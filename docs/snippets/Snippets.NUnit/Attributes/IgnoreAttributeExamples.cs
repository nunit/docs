using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    public class IgnoreAttributeExamples
    {
        #region IgnoreFixtureExample
        [TestFixture]
        [Ignore("Ignored until dependency issue is resolved")]
        public class IgnoredFixture
        {
            [Test]
            public void FixtureTest()
            {
                Assert.Fail("Ignored fixture should not execute.");
            }
        }
        #endregion

        #region IgnoreTestExample
        [Test]
        [Ignore("Temporarily ignored while bug fix is in progress")]
        public void IgnoredTest()
        {
            Assert.Fail("Ignored test should not execute.");
        }
        #endregion

        #region IgnoreUntilExample
        [Test]
        [Ignore("Waiting for external fix", Until = "2099-12-31 00:00:00Z")]
        public void IgnoredUntilDate()
        {
            Assert.Fail("Test remains ignored until the specified date.");
        }
        #endregion
    }
}

using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    public class TestCaseAttributeExamples
    {
        #region BasicTestCase
        [TestCase(12, 3, 4)]
        [TestCase(12, 2, 6)]
        [TestCase(12, 4, 3)]
        public void DivideTest(int n, int d, int q)
        {
            Assert.That(n / d, Is.EqualTo(q));
        }
        #endregion

        #region TestCaseWithExpectedResult
        [TestCase(12, 3, ExpectedResult = 4)]
        [TestCase(12, 2, ExpectedResult = 6)]
        [TestCase(12, 4, ExpectedResult = 3)]
        public int DivideTest(int n, int d)
        {
            return n / d;
        }
        #endregion

        #region TestCaseWithIgnore
        [TestCase(1, 1)]
        [TestCase(0, 0, Ignore = "Only ignore this")]
        [TestCase(1, 3)]
        public void AddTestWithIgnore(int a, int b)
        {
            var result = a + b;
            Assert.That(result, Is.GreaterThan(1));
        }
        #endregion

        #region TestCaseWithExplicit
        [TestCase(1, 1)]
        [TestCase(0, 0, Explicit = true, Reason = "This will fail so only run explicitly")]
        [TestCase(1, 3)]
        public void AddTestWithExplicit(int a, int b)
        {
            var result = a + b;
            Assert.That(result, Is.GreaterThan(1));
        }
        #endregion

        #region TestCaseWithCategory
        [TestCase(1, 1)]
        [TestCase(2, 0, Category = "Crazy")]
        [TestCase(1, 3)]
        public void AddTestWithCategory(int a, int b)
        {
            var result = a + b;
            Assert.That(result, Is.GreaterThan(1));
        }
        #endregion
    }
}

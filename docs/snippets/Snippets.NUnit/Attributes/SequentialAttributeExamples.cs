using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    public class SequentialAttributeExamples
    {
        #region SequentialBasic
        [Test]
        [Sequential]
        public void MyTest(
            [Values(1, 2, 3)] int x,
            [Values("A", "B")] string s)
        {
            Assert.That(x, Is.GreaterThan(0));
            Assert.That(s is null || s.Length > 0);
        }
        #endregion
    }
}

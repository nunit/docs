using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    public class CombinatorialAttributeExamples
    {
        #region CombinatorialBasic
        [Test]
        [Combinatorial]
        public void MyTest(
            [Values(1, 2, 3)] int x,
            [Values("A", "B")] string s)
        {
            Assert.That(x, Is.GreaterThan(0));
            Assert.That(s, Is.Not.Null);
        }
        #endregion
    }
}

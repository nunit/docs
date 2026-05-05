using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    public class PairwiseAttributeExamples
    {
        #region PairwiseBasic
        [Test]
        [Pairwise]
        public void MyTest(
            [Values("a", "b", "c")] string a,
            [Values("+", "-")] string b,
            [Values("x", "y")] string c)
        {
            Assert.That(a, Is.Not.Null);
            Assert.That(b, Is.Not.Null);
            Assert.That(c, Is.Not.Null);
        }
        #endregion
    }
}

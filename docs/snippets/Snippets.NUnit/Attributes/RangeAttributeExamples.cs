using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    public class RangeAttributeExamples
    {
        #region RangeAttributeExample
        [Test]
        public void MyTest(
            [Values(1, 2, 3)] int x,
            [Range(0.2, 0.6, 0.2)] double d)
        {
            Assert.That(x, Is.GreaterThan(0));
            Assert.That(d, Is.GreaterThan(0.0));
        }
        #endregion
    }
}

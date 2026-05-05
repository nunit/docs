using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    public class SetUpAttributeExamples
    {
        private int _counter;

        #region SetUpExample
        [SetUp]
        public void Init()
        {
            _counter = 0;
        }

        [Test]
        public void TestMethod()
        {
            _counter++;
            Assert.That(_counter, Is.EqualTo(1));
        }
        #endregion
    }
}

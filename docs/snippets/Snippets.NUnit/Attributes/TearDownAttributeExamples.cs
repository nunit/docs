using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    public class TearDownAttributeExamples
    {
        private bool _testRan;

        #region TearDownExample
        [SetUp]
        public void Init()
        {
            _testRan = false;
        }

        [TearDown]
        public void Cleanup()
        {
            Assert.That(_testRan, Is.True);
        }

        [Test]
        public void Add()
        {
            _testRan = true;
            Assert.That(2 + 2, Is.EqualTo(4));
        }
        #endregion
    }
}

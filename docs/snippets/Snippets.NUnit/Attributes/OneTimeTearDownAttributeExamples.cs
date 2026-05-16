using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    [TestFixture]
    public class OneTimeTearDownAttributeExamples
    {
        private static bool _hasRun;

        #region OneTimeTearDownExample
        [Test]
        public void Add()
        {
            _hasRun = true;
            Assert.That(2 + 2, Is.EqualTo(4));
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            Assert.That(_hasRun, Is.True);
        }
        #endregion
    }
}

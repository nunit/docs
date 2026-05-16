using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    [TestFixture]
    public class OneTimeSetUpAttributeExamples
    {
        private static int _sharedValue;

        #region OneTimeSetUpExample
        [OneTimeSetUp]
        public void Init()
        {
            _sharedValue = 42;
        }

        [Test]
        public void UsesInitializedState()
        {
            Assert.That(_sharedValue, Is.EqualTo(42));
        }
        #endregion
    }
}

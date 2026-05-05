using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    public class ExplicitAttributeExamples
    {
        #region ExplicitFixtureExample
        [TestFixture]
        [Explicit("Manual verification fixture")]
        public class ExplicitFixture
        {
            [Test]
            public void FixtureExplicitTest()
            {
                Assert.Pass();
            }
        }
        #endregion

        #region ExplicitTestExample
        [Test]
        [Explicit("Run only when explicitly selected")]
        public void ExplicitTest()
        {
            Assert.Pass();
        }
        #endregion
    }
}

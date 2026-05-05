using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    public class DefaultFloatingPointToleranceAttributeExamples
    {
        #region DefaultFloatingPointToleranceFixture
        [TestFixture]
        [DefaultFloatingPointTolerance(1)]
        public class ToleranceFixtureTests
        {
            [Test]
            public void ComparisonUsingFixtureDefaultTolerance()
            {
                Assert.That(1f, Is.EqualTo(2));
            }

            [Test]
            public void ExplicitToleranceOverridesDefault()
            {
                Assert.That(1f, Is.EqualTo(1.2f).Within(0.3));
            }
        }
        #endregion

        #region DefaultFloatingPointToleranceMethodOverride
        [TestFixture]
        [DefaultFloatingPointTolerance(1)]
        public class ToleranceMethodOverrideTests
        {
            [Test]
            [DefaultFloatingPointTolerance(2)]
            public void MethodToleranceOverridesFixtureTolerance()
            {
                Assert.That(2f, Is.EqualTo(4));
            }
        }
        #endregion
    }
}

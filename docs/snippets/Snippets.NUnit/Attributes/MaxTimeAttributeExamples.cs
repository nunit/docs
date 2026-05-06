using System.Threading.Tasks;
using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    public class MaxTimeAttributeExamples
    {
        #region MaxTimeBasic
        [TestFixture]
        public class PerformanceTests
        {
            [Test]
            [MaxTime(1000)]
            public void OperationCompletesWithinOneSecond()
            {
                // This test fails if it takes more than 1000ms
                var result = PerformQuickCalculation();
                Assert.That(result, Is.Not.Null);
            }

            [Test]
            [MaxTime(5000)]
            public async Task AsyncOperationCompletesWithinFiveSeconds()
            {
                // MaxTime also works with async tests
                await Task.Delay(100);
                Assert.Pass();
            }

            private object PerformQuickCalculation()
            {
                // Simulate a quick calculation
                return new object();
            }
        }
        #endregion

        #region MaxTimeVsAssertions
        [TestFixture]
        public class MaxTimeVsAssertionTests
        {
            [Test]
            [MaxTime(2000)]
            public void AssertionFailuresTakePrecedence()
            {
                // If both assertion fails AND time exceeds,
                // the assertion failure is reported
                var result = 2 + 2;
                Assert.That(result, Is.EqualTo(4));
            }
        }
        #endregion
    }
}

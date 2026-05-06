using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    public class OrderAttributeExamples
    {
        #region OrderBasic
        [TestFixture]
        public class OrderedTests
        {
            private static int _executionOrder;

            [OneTimeSetUp]
            public void Setup() => _executionOrder = 0;

            [Test, Order(1)]
            public void FirstTest()
            {
                _executionOrder++;
                Assert.That(_executionOrder, Is.EqualTo(1));
            }

            [Test, Order(2)]
            public void SecondTest()
            {
                _executionOrder++;
                Assert.That(_executionOrder, Is.EqualTo(2));
            }

            [Test, Order(3)]
            public void ThirdTest()
            {
                _executionOrder++;
                Assert.That(_executionOrder, Is.EqualTo(3));
            }

            [Test]
            public void UnorderedTest()
            {
                // Tests without Order run after all ordered tests
                _executionOrder++;
                Assert.That(_executionOrder, Is.EqualTo(4));
            }
        }
        #endregion

        #region OrderOnFixtures
        [TestFixture, Order(1)]
        public class FirstFixture
        {
            [Test]
            public void Test() => Assert.Pass();
        }

        [TestFixture, Order(2)]
        public class SecondFixture
        {
            [Test]
            public void Test() => Assert.Pass();
        }
        #endregion

        #region OrderWithGaps
        [TestFixture]
        public class OrderWithGapsTests
        {
            // Using gaps allows inserting tests later without renumbering
            [Test, Order(10)]
            public void InitializationTest() => Assert.Pass();

            [Test, Order(20)]
            public void ProcessingTest() => Assert.Pass();

            [Test, Order(30)]
            public void CleanupTest() => Assert.Pass();
        }
        #endregion
    }
}

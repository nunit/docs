using System;
using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    public class RandomAttributeExamples
    {
        #region RandomBasic
        [TestFixture]
        public class RandomBasicTests
        {
            [Test]
            public void TestWithRandomInts([Random(5)] int value)
            {
                // Generates 5 random int values across the full int range
                TestContext.Out.WriteLine($"Testing with value: {value}");
                Assert.That(value, Is.TypeOf<int>());
            }

            [Test]
            public void TestWithRandomDoubles([Random(3)] double value)
            {
                // Generates 3 random doubles between 0.0 and 1.0
                TestContext.Out.WriteLine($"Testing with value: {value}");
                Assert.That(value, Is.InRange(0.0, 1.0));
            }
        }
        #endregion

        #region RandomWithRange
        [TestFixture]
        public class RandomRangeTests
        {
            [Test]
            public void TestWithIntRange([Random(1, 100, 5)] int value)
            {
                // Generates 5 random ints between 1 and 100 (exclusive)
                Assert.That(value, Is.InRange(1, 99));
            }

            [Test]
            public void TestWithDoubleRange([Random(-1.0, 1.0, 3)] double value)
            {
                // Generates 3 random doubles between -1.0 and 1.0
                Assert.That(value, Is.InRange(-1.0, 1.0));
            }
        }
        #endregion

        #region RandomDistinct
        [TestFixture]
        public class RandomDistinctTests
        {
            [Test]
            public void TestWithDistinctValues([Random(1, 10, 5, Distinct = true)] int value)
            {
                // Generates 5 distinct random ints - no value will repeat
                Assert.That(value, Is.InRange(1, 9));
            }
        }
        #endregion

        #region RandomGuid
        [TestFixture]
        public class RandomGuidTests
        {
            [Test]
            public void TestWithRandomGuid([Random(3)] Guid value)
            {
                // Generates 3 random GUIDs
                // Note: Guid does not support min/max range
                Assert.That(value, Is.Not.EqualTo(Guid.Empty));
            }
        }
        #endregion

        #region RandomCombined
        [TestFixture]
        public class RandomCombinedTests
        {
            [Test]
            public void TestWithMultipleRandomParams(
                [Values(1, 2, 3)] int x,
                [Random(-1.0, 1.0, 2)] double d)
            {
                // Creates 6 test cases: 3 x values * 2 random doubles
                Assert.That(d, Is.InRange(-1.0, 1.0));
            }
        }
        #endregion
    }
}

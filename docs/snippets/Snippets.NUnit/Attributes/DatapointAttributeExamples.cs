using System.Collections.Generic;
using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    public class DatapointAttributeExamples
    {
        #region DatapointBasic
        [TestFixture]
        public class SquareRootTests
        {
            // Individual datapoints for double arguments
            [Datapoint]
            public double Zero = 0;

            [Datapoint]
            public double Positive = 1;

            [Datapoint]
            public double Negative = -1;

            [Datapoint]
            public double Max = double.MaxValue;

            [Theory]
            public void SquareRootIsPositive(double value)
            {
                // NUnit will call this theory with each datapoint: 0, 1, -1, MaxValue
                Assume.That(value >= 0);
                Assert.That(Math.Sqrt(value), Is.GreaterThanOrEqualTo(0));
            }
        }
        #endregion

        #region DatapointWithEnum
        public enum Color
        {
            Red,
            Green,
            Blue
        }

        [TestFixture]
        public class EnumTheoryTests
        {
            // No need to define datapoints for enums - NUnit supplies them automatically
            [Theory]
            public void ColorIsValid(Color color)
            {
                // NUnit automatically tests with Red, Green, and Blue
                Assert.That(Enum.IsDefined(typeof(Color), color), Is.True);
            }

            // Override automatic enum values with specific datapoints
            [Datapoint]
            public Color OnlyRed = Color.Red;

            [Theory]
            public void TestOnlyRed(Color color)
            {
                // When datapoints are defined, automatic enum values are suppressed
                Assert.That(color, Is.EqualTo(Color.Red));
            }
        }
        #endregion

        #region DatapointSource
        [TestFixture]
        public class PrimeNumberTests
        {
            // DatapointSource on a field returning an array
            [DatapointSource]
            public int[] SmallPrimes = { 2, 3, 5, 7, 11, 13 };

            // DatapointSource on a property returning IEnumerable<T>
            [DatapointSource]
            public IEnumerable<int> MorePrimes
            {
                get
                {
                    yield return 17;
                    yield return 19;
                    yield return 23;
                }
            }

            // DatapointSource on a method
            [DatapointSource]
            public int[] GetPrimesUnder100()
            {
                return new[] { 29, 31, 37, 41, 43, 47 };
            }

            [Theory]
            public void PrimeIsOddOrTwo(int prime)
            {
                // NUnit combines all datapoint sources for int type
                Assert.That(prime == 2 || prime % 2 != 0);
            }
        }
        #endregion

        #region DatapointMultipleTypes
        [TestFixture]
        public class MultipleTypeTests
        {
            // Datapoints for string arguments
            [Datapoint]
            public string Empty = "";

            [Datapoint]
            public string NonEmpty = "hello";

            // Datapoints for int arguments
            [Datapoint]
            public int Zero2 = 0;

            [Datapoint]
            public int Positive2 = 42;

            [Theory]
            public void StringLengthMatchesCount(string value)
            {
                // Only uses string datapoints
                Assume.That(value, Is.Not.Null);
                Assert.That(value.Length, Is.GreaterThanOrEqualTo(0));
            }

            [Theory]
            public void IntIsNonNegative(int value)
            {
                // Only uses int datapoints
                Assume.That(value >= 0);
                Assert.That(value, Is.GreaterThanOrEqualTo(0));
            }
        }
        #endregion
    }
}

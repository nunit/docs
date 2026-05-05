using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    // Sample classes to test (for demonstration purposes)
    public class Calculator
    {
        public int Add(int a, int b) => a + b;
    }

    public class AdvancedCalculator : Calculator
    {
        public double SquareRoot(double value) => System.Math.Sqrt(value);
    }

    public class TestOfAttributeExamples
    {
        #region TestOfBasic
        [TestFixture]
        [TestOf(typeof(Calculator))]
        public class CalculatorTests
        {
            [Test]
            public void Add_TwoPositiveNumbers_ReturnsSum()
            {
                var calculator = new Calculator();
                Assert.That(calculator.Add(2, 3), Is.EqualTo(5));
            }

            [Test]
            [TestOf(typeof(AdvancedCalculator))]
            public void SquareRoot_PositiveNumber_ReturnsCorrectResult()
            {
                // This specific test is for AdvancedCalculator
                var calculator = new AdvancedCalculator();
                Assert.That(calculator.SquareRoot(4), Is.EqualTo(2.0));
            }
        }
        #endregion

        #region TestOfString
        [TestFixture]
        [TestOf("Snippets.NUnit.Attributes.Calculator")]
        public class CalculatorTestsWithStringName
        {
            [Test]
            [TestOf(nameof(AdvancedCalculator))]
            public void TestUsingNameof()
            {
                // Using nameof() provides compile-time safety
                var calculator = new AdvancedCalculator();
                Assert.That(calculator.Add(1, 1), Is.EqualTo(2));
            }
        }
        #endregion

        #region TestOfNamedParameter
        [TestFixture(TestOf = typeof(Calculator))]
        public class CalculatorTestsWithNamedParameter
        {
            [Test(TestOf = typeof(AdvancedCalculator))]
            public void TestUsingNamedParameterSyntax()
            {
                var calculator = new AdvancedCalculator();
                Assert.That(calculator.SquareRoot(9), Is.EqualTo(3.0));
            }
        }
        #endregion
    }
}

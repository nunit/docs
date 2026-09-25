using NUnit.Framework;

#pragma warning disable CA1822

namespace Snippets.NUnit;

public class WritingTestsGuideExamples
{
    public class Calculator
    {
        public int Add(int a, int b) => a + b;
        public int Multiply(int a, int b) => a * b;
    }

    #region OrdinaryTest
    public class CalculatorTests
    {
        [Test]
        public void Add_TwoNumbers_ReturnsSum()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Add(2, 3);

            // Assert
            Assert.That(result, Is.EqualTo(5));
        }
    }
    #endregion

    #region OrdinarySetUp
    public class CalculatorTestsWithSetUp
    {
        private Calculator _calculator = null!;

        [SetUp]
        public void CreateCalculator()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Add_ReturnsSum()
        {
            Assert.That(_calculator.Add(2, 3), Is.EqualTo(5));
        }

        [Test]
        public void Multiply_ReturnsProduct()
        {
            Assert.That(_calculator.Multiply(2, 3), Is.EqualTo(6));
        }
    }
    #endregion

    #region DataDrivenTestCase
    public class AddTests
    {
        [TestCase(1, 2, 3)]
        [TestCase(2, 3, 5)]
        [TestCase(-1, 1, 0)]
        public void Add_ReturnsSum(int a, int b, int expected)
        {
            var result = new Calculator().Add(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
    #endregion

    #region DataDrivenExpectedResult
    public class AddTestsWithExpectedResult
    {
        [TestCase(1, 2, ExpectedResult = 3)]
        [TestCase(2, 3, ExpectedResult = 5)]
        public int Add_ReturnsSum(int a, int b)
        {
            return new Calculator().Add(a, b);
        }
    }
    #endregion

    #region DataDrivenTestCaseSource
    public class AddTestsFromSource
    {
        private static IEnumerable<TestCaseData> AddCases()
        {
            yield return new TestCaseData(1, 2, 3).SetName("Small numbers");
            yield return new TestCaseData(1000, 2000, 3000).SetName("Large numbers");
            yield return new TestCaseData(-5, 5, 0).SetDescription("Opposites cancel out");
        }

        [TestCaseSource(nameof(AddCases))]
        public void Add_ReturnsSum(int a, int b, int expected)
        {
            Assert.That(new Calculator().Add(a, b), Is.EqualTo(expected));
        }
    }
    #endregion

    #region DataDrivenValueSource
    public class MultiplyByOneTests
    {
        private static readonly int[] Numbers = [0, 1, 42, -7];

        [Test]
        public void Multiply_ByOne_ReturnsSameNumber([ValueSource(nameof(Numbers))] int number)
        {
            Assert.That(new Calculator().Multiply(number, 1), Is.EqualTo(number));
        }
    }
    #endregion

    #region DataDrivenFixture
    [TestFixture(2)]
    [TestFixture(10)]
    public class MultiplierTests(int multiplier)
    {
        [Test]
        public void Multiply_ByZero_ReturnsZero()
        {
            Assert.That(new Calculator().Multiply(multiplier, 0), Is.Zero);
        }

        [Test]
        public void Multiply_ByOne_ReturnsMultiplier()
        {
            Assert.That(new Calculator().Multiply(multiplier, 1), Is.EqualTo(multiplier));
        }
    }
    #endregion

    #region AutomatingCombinatorial
    public class AddIsCommutativeTests
    {
        [Test]
        public void Add_IsCommutative([Values(-1, 0, 1)] int a, [Values(2, 3)] int b)
        {
            var calculator = new Calculator();
            Assert.That(calculator.Add(a, b), Is.EqualTo(calculator.Add(b, a)));
        }
    }
    #endregion

    #region AutomatingRange
    public class AddZeroTests
    {
        [Test]
        public void Add_Zero_ReturnsSameNumber([Range(-10, 10, 5)] int number)
        {
            Assert.That(new Calculator().Add(number, 0), Is.EqualTo(number));
        }
    }
    #endregion

    #region AutomatingRandom
    public class AddRandomTests
    {
        [Test]
        public void Add_IsCommutative_ForRandomNumbers(
            [Random(-1000, 1000, 5)] int a,
            [Random(-1000, 1000, 5)] int b)
        {
            var calculator = new Calculator();
            Assert.That(calculator.Add(a, b), Is.EqualTo(calculator.Add(b, a)));
        }
    }
    #endregion

    #region AutomatingPairwise
    public class FormattingTests
    {
        [Test, Pairwise]
        public void Format_HandlesAllOptions(
            [Values("en-US", "nb-NO", "ja-JP")] string culture,
            [Values(0, 1, -1)] int number,
            [Values(true, false)] bool useGrouping)
        {
            var format = useGrouping ? "N0" : "D";
            var text = number.ToString(format, new System.Globalization.CultureInfo(culture));
            Assert.That(text, Is.Not.Empty);
        }
    }
    #endregion
}

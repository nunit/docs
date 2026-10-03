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

    #region DependentTests
    public class OrderWorkflowTests
    {
        private static readonly List<string> Orders = [];

        [Test]
        public void CreateOrder()
        {
            Orders.Add("order-1");
            Assert.That(Orders, Has.Count.EqualTo(1));
        }

        [Test]
        [DependsOnTest(nameof(CreateOrder))]
        public void ShipOrder()
        {
            // Runs only after CreateOrder has passed. If CreateOrder fails, this test is skipped.
            Assert.That(Orders, Does.Contain("order-1"));
        }

        [Test]
        [DependsOnTest(nameof(ShipOrder), AllowFailure = true)]
        public void CleanUpOrders()
        {
            // Runs after ShipOrder even if it failed, so the cleanup always happens.
            Orders.Clear();
            Assert.That(Orders, Is.Empty);
        }
    }
    #endregion

    #region FlakyRetry
    public class ExternalServiceTests
    {
        [Test]
        [Retry(3)]
        public void Service_Responds()
        {
            // If the assertion fails, NUnit runs the test again, up to 3 attempts in total.
            Assert.That(CallService(), Is.EqualTo("OK"));
        }

        [Test]
        [Retry(3, RetryExceptions = [typeof(TimeoutException)])]
        public void Service_Responds_EvenAfterTimeouts()
        {
            // Also retried when the call throws a TimeoutException.
            Assert.That(CallService(), Is.EqualTo("OK"));
        }

        private static string CallService() => "OK";
    }
    #endregion

    #region FlakyRepeatThreshold
    public class RecommendationTests
    {
        [Test]
        [Repeat(20, RequiredPassPercentage = 90)]
        public void Recommendation_IsUsuallyRelevant()
        {
            // Passes when at least 18 of the 20 runs pass.
            Assert.That(GetRecommendation(), Is.Not.Empty);
        }

        private static string GetRecommendation() => "NUnit";
    }
    #endregion

    #region SlowMaxTime
    public class PerformanceTests
    {
        [Test]
        [MaxTime(2000, WarningTime = 500)]
        public void Search_IsFastEnough()
        {
            // A warning above 500 ms, a failure above 2 seconds. The test is never interrupted.
            var result = Enumerable.Range(1, 1000).Where(n => n % 7 == 0).ToList();
            Assert.That(result, Is.Not.Empty);
        }
    }
    #endregion

    #region SlowCancelAfter
    public class DownloadTests
    {
        [Test]
        [CancelAfter(5000)]
        public async Task Download_Completes(CancellationToken cancellationToken)
        {
            // NUnit cancels the token after 5 seconds. Pass it on so the work actually stops.
            var content = await DownloadAsync(cancellationToken);
            Assert.That(content, Is.Not.Empty);
        }

        private static async Task<string> DownloadAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(10, cancellationToken);
            return "content";
        }
    }
    #endregion

    #region OrganizingCategories
    [Category("Integration")]
    public class DatabaseTests
    {
        [Test]
        public void Connection_Opens()
        {
            Assert.Pass();
        }

        [Test]
        [Category("Slow")]
        public void Migration_Runs()
        {
            // This test is in both the "Integration" and the "Slow" category.
            Assert.Pass();
        }
    }
    #endregion

    #region OrganizingExplicitIgnore
    public class MaintenanceTests
    {
        [Test]
        [Explicit("Rebuilds the test database, run it on demand")]
        public void RebuildTestDatabase()
        {
            Assert.Pass();
        }

        [Test]
        [Ignore("Waiting for issue #123 to be fixed", Until = "2099-12-31")]
        public void Export_HandlesUnicode()
        {
            Assert.Fail("Not fixed yet");
        }
    }
    #endregion
}

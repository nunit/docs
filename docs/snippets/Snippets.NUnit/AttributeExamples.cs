using NUnit.Framework;

#pragma warning disable CA1822
#pragma warning disable NUnit2045
#pragma warning disable CS1998

namespace Snippets.NUnit;

public class AttributeExamples
{
    #region ValuesAttributeExample
    [Test]
    public void ValuesAttribute_BasicExample([Values(1, 2, 3)] int x, [Values("A", "B")] string s)
    {
        Assert.That(x, Is.GreaterThan(0));
        Assert.That(s, Is.Not.Null);
    }
    #endregion

    // ReSharper disable UnusedMember.Global
    #region ValuesAttributeEnumExample
    public enum MyEnumType
    {
        Value1,
        Value2,
        Value3
    }

    [Test]
    public void ValuesAttribute_EnumExample([Values] MyEnumType myEnumArgument)
    {
        Assert.That(myEnumArgument, Is.TypeOf<MyEnumType>());
    }
    #endregion
    // ReSharper restore UnusedMember.Global

    // ReSharper disable RedundantBoolCompare
    #pragma warning disable CS8794 // The input always matches the provided pattern.
    #region ValuesAttributeBoolExample
    [Test]
    public void ValuesAttribute_BoolExample([Values] bool value)
    {
        // This test will run twice: once with true, once with false
        Assert.That(value is true or false);
    }
    #endregion
    #pragma warning restore CS8794 // The input always matches the provided pattern.
    // ReSharper restore RedundantBoolCompare

    #region RangeAttributeExample
    [Test]
    public void RangeAttribute_Example(
        [Values(1, 2, 3)] int x,
        [Range(0.2, 0.6, 0.2)] double d)
    {
        Assert.That(x, Is.GreaterThan(0));
        Assert.That(d, Is.GreaterThan(0.0));
    }
    #endregion
}

[TestFixture]
[Category("LongRunning")]
public class CategoryAttributeExamples
{
    #region CategoryTestFixtureExample
    [Test]
    public void Test_InLongRunningCategory()
    {
        Assert.Pass("This test is in the LongRunning category");
    }
    #endregion

    #region CategoryTestExample
    [Test]
    [Category("Fast")]
    public void FastTest()
    {
        Assert.Pass("This is a fast test");
    }

    [Test]
    [Category("Slow")]
    [Category("Database")]
    public void SlowDatabaseTest()
    {
        Assert.Pass("This test has multiple categories");
    }
    #endregion

    // ReSharper disable RedundantAttributeUsageProperty
    // ReSharper disable MemberCanBePrivate.Global
    // ReSharper disable RedundantTypeDeclarationBody
    #region CustomCategoryAttribute
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class CriticalAttribute : CategoryAttribute
    { }

    [Test]
    [Critical]
    public void CriticalTest()
    {
        Assert.Pass("This test uses a custom category attribute");
    }
    #endregion
    // ReSharper restore RedundantAttributeUsageProperty
    // ReSharper restore MemberCanBePrivate.Global
    // ReSharper restore RedundantTypeDeclarationBody
}

[TestFixture]
public class SetupTeardownExamples
{
    private int _counter;

    #region SetUpExample
    [SetUp]
    public void Init()
    {
        _counter = 0;
        Console.WriteLine("SetUp method called before each test");
    }
    #endregion

    #region TearDownExample
    [TearDown]
    public void Cleanup()
    {
        Console.WriteLine("TearDown method called after each test");
    }
    #endregion

    [Test]
    public void TestMethod1()
    {
        _counter++;
        Assert.That(_counter, Is.EqualTo(1));
    }

    [Test]
    public void TestMethod2()
    {
        _counter++;
        Assert.That(_counter, Is.EqualTo(1));
    }
}

[TestFixture]
public class OneTimeSetupTeardownExamples
{
    private static int _staticCounter;

    #region OneTimeSetUpExample
    [OneTimeSetUp]
    public void OneTimeInit()
    {
        _staticCounter = 100;
        Console.WriteLine("OneTimeSetUp called once before all tests in the fixture");
    }
    #endregion

    #region OneTimeTearDownExample
    [OneTimeTearDown]
    public void OneTimeCleanup()
    {
        Console.WriteLine("OneTimeTearDown called once after all tests in the fixture");
    }
    #endregion

    [Test]
    public void Test1()
    {
        Assert.That(_staticCounter, Is.EqualTo(100));
    }

    [Test]
    public void Test2()
    {
        Assert.That(_staticCounter, Is.EqualTo(100));
    }
}

[TestFixture]
public class DescriptionAttributeExamples
{
    #region DescriptionTestFixtureExample
    [Test]
    [Description("This test validates the addition operation")]
    public void Add_TwoNumbers_ReturnsSum()
    {
        Assert.That(2 + 2, Is.EqualTo(4));
    }
    #endregion

    #region DescriptionTestExample
    [Test]
    [Description("This test should always pass")]
    public void AlwaysPassingTest()
    {
        Assert.Pass("Test passed as expected");
    }
    #endregion
}

[TestFixture]
public class IgnoreAttributeExamples
{
    #region IgnoreTestExample
    [Test]
    [Ignore("Test is not ready yet")]
    public void IgnoredTest()
    {
        Assert.Fail("This test is ignored and should not run");
    }
    #endregion

    #region IgnoreWithReasonExample
    [Test]
    [Ignore("Waiting for bug fix #1234")]
    public void TestWaitingForBugFix()
    {
        Assert.Fail("This test should not run");
    }
    #endregion
}

[TestFixture]
[Explicit("This fixture is for manual testing only")]
public class ExplicitAttributeExamples
{
    #region ExplicitTestExample
    [Test]
    [Explicit("Run this test manually when needed")]
    public void ManualTest()
    {
        Assert.Pass("This test runs only when explicitly requested");
    }
    #endregion

    [Test]
    public void AnotherManualTest()
    {
        Assert.Pass("This test is explicit because the fixture is marked explicit");
    }
}

[TestFixture]
public class TimeoutAttributeExamples
{
    #region TimeoutExample
    [Test]
    [Timeout(1000)] // 1 second timeout
    public void FastTest()
    {
        Thread.Sleep(500); // This should pass as it's under 1 second
        Assert.Pass();
    }
    #endregion

    #region TimeoutWithAsyncExample
    [Test]
    [Timeout(2000)] // 2 second timeout
    public async Task AsyncTestWithTimeout()
    {
        await Task.Delay(1000); // This should pass as it's under 2 seconds
        Assert.Pass();
    }
    #endregion
}

[TestFixture]
public class RepeatAttributeExamples
{
    private int repeatCounter = 0;

    #region RepeatExample
    [Test]
    [Repeat(3)]
    public void RepeatedTest()
    {
        repeatCounter++;
        Console.WriteLine($"Repeat iteration: {repeatCounter}");
        Assert.Pass();
    }
    #endregion
}

[TestFixture]
public class OrderAttributeExamples
{
    #region OrderExample
    [Test, Order(1)]
    public void FirstTest()
    {
        Console.WriteLine("This test should run first");
        Assert.Pass();
    }

    [Test, Order(2)]
    public void SecondTest()
    {
        Console.WriteLine("This test should run second");
        Assert.Pass();
    }

    [Test] // No order specified, will run after ordered tests
    public void UnorderedTest()
    {
        Console.WriteLine("This test has no specific order");
        Assert.Pass();
    }
    #endregion
}

[TestFixture]
public class TestOfAttributeExamples
{
    public class Calculator
    {
        public int Add(int a, int b) => a + b;
        public int Subtract(int a, int b) => a - b;
    }

    #region TestOfExample
    [Test]
    [TestOf(typeof(Calculator))]
    public void Calculator_Add_ReturnsCorrectSum()
    {
        var calculator = new Calculator();
        Assert.That(calculator.Add(2, 3), Is.EqualTo(5));
    }

    [Test]
    [TestOf(typeof(Calculator))]
    public void Calculator_Subtract_ReturnsCorrectDifference()
    {
        var calculator = new Calculator();
        Assert.That(calculator.Subtract(5, 3), Is.EqualTo(2));
    }
    #endregion
}

[TestFixture]
public class PropertyAttributeExamples
{
    #region PropertyExample
    [Test]
    [Property("Author", "John Doe")]
    [Property("Version", "1.0")]
    public void TestWithProperties()
    {
        Assert.Pass("This test has custom properties");
    }
    #endregion
}
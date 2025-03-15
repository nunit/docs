---
title: Data driven tests
---

## Data Driven Tests in NUnit

Data driven tests allow you to run the same test logic with different sets of input data. NUnit supports several attributes to facilitate this approach, making it easier to cover multiple cases without duplicating code.

In practice, these tests are implemented by parametrizing test methods and test fixtures—meaning you can supply different inputs or configurations either directly or via external sources, which enhances test coverage and reduces redundancy.

### Using [TestCase]

Use [TestCase] when the inline test data is limited and easily defined.

```csharp
// A simple example using TestCase
public class CalculatorTests
{
    [TestCase(1, 2, 3)]
    [TestCase(2, 3, 5)]
    public void AddTest(int a, int b, int expected)
    {
        var result = a + b;
        Assert.That(result, Is.EqualTo(expected));
    }
}
```

### Using [TestCaseSource]

Use [TestCaseSource] when your test data is complex, dynamic, or maintained externally.

```csharp
// An example using TestCaseSource with TestCaseData
public class CalculatorTests
{
    static IEnumerable<TestCaseData> AddTestCases
    {
        get
        {
            yield return new TestCaseData(1, 2, 3);
            yield return new TestCaseData(2, 3, 5);
            // ...additional test cases...
        }
    }

    [TestCaseSource(nameof(AddTestCases))]
    public void AddTestSource(int a, int b, int expected)
    {
        var result = a + b;
        Assert.That(result, Is.EqualTo(expected));
    }
}
```

**Note:**

Using TestCaseData here is advantageous because it lets you attach extra properties
(for example, Description, ExpectedResult, and more) to each test case. This additional
metadata clarifies test intent and improves debugging.

Remember, while any object can be
returned by the TestCaseSource method, using TestCaseData retains these useful features.

### Using [ValueSource]

Use [ValueSource] when you want to provide test data through a reusable property or method.

```csharp
// An example using ValueSource
public class CalculatorTests
{
    static int[] Values = { 1, 2, 3 };

    [Test]
    public void MultiplyTest([ValueSource(nameof(Values))] int value)
    {
        var result = value * 2;
        Assert.That(result, Is.EqualTo(value * 2));
    }
}
```

## Parameterized TestFixtures

Parameterized TestFixtures allow you to run the entire test fixture
with different constructor parameters. This is useful when your tests require
different configurations or contexts at the fixture level.

```csharp
[TestFixture(10)]
[TestFixture(20)]
public class ParameterizedTests(int multiplier)
{
    [Test]
    public void MultiplyTest()
    {
        var result = multiplier * 2;
        Assert.That(result, Is.EqualTo(multiplier * 2));
    }
}
```

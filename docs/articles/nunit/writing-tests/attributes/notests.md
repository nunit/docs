---
uid: notestsattribute
---

# NoTests

The `NoTestsAttribute` specifies the default status for a parameterized test method or test fixture when it contains no
executable child tests. This is useful when test cases are generated dynamically and may sometimes produce an empty
set.

By default, NUnit treats a `Theory` with no test cases as a failure. For other parameterized tests, the behavior may
vary. The `NoTestsAttribute` allows you to explicitly control what status should be reported when no test cases are
available.

> [!NOTE]
> This attribute was introduced in NUnit 4.6.

## Usage

The attribute accepts a `TestStatus` value that determines how the test should be reported when no child tests exist:

* `TestStatus.Skipped` - The test is marked as skipped
* `TestStatus.Inconclusive` - The test is marked as inconclusive
* `TestStatus.Passed` - The test is marked as passed (use with caution)
* `TestStatus.Failed` - The test is marked as failed (default for Theory)

## Test Fixture Syntax

Apply to a fixture to affect all parameterized tests within it:

[!code-csharp[NoTestsSkipped](~/snippets/Snippets.NUnit/Attributes/NoTestsAttributeExamples.cs#NoTestsSkipped)]

## Test Method Syntax

Apply directly to a test method:

[!code-csharp[NoTestsOnMethod](~/snippets/Snippets.NUnit/Attributes/NoTestsAttributeExamples.cs#NoTestsOnMethod)]

## Inconclusive Status

Use `TestStatus.Inconclusive` when empty test cases indicate an indeterminate state rather than a skip:

[!code-csharp[NoTestsInconclusive](~/snippets/Snippets.NUnit/Attributes/NoTestsAttributeExamples.cs#NoTestsInconclusive)]

## Common Scenarios

### Dynamic Test Data

When test cases come from external sources (databases, APIs, configuration files) that might be empty:

```csharp
[TestFixture]
[NoTests(TestStatus.Skipped)]
public class DataDrivenTests
{
    [TestCaseSource(typeof(ExternalDataSource))]
    public void ProcessData(DataRecord record)
    {
        // Test implementation
    }
}
```

### Conditional Test Execution

When test cases are only available under certain conditions:

```csharp
[NoTests(TestStatus.Inconclusive)]
[TestCaseSource(nameof(GetPlatformSpecificCases))]
public void PlatformSpecificTest(string testCase)
{
    // Test only runs when platform-specific cases are available
}
```

### Feature Flag Testing

When tests depend on feature flags that may not be enabled:

```csharp
[TestFixture]
[NoTests(TestStatus.Skipped)]
public class FeatureFlagTests
{
    [TestCaseSource(nameof(GetEnabledFeatures))]
    public void TestFeature(string featureName)
    {
        // Tests features that are currently enabled
    }
}
```

## Inheritance

The `NoTestsAttribute` can be applied at the assembly, class, or method level:

* **Assembly level**: Affects all parameterized tests in the assembly
* **Class level**: Affects all parameterized tests in the fixture
* **Method level**: Affects only the specific test method

When multiple levels specify the attribute, the most specific level (method) takes precedence.

## See Also

* [TestCaseSource Attribute](testcasesource.md)
* [TestCase Attribute](testcase.md)
* [Theory Attribute](theory.md)

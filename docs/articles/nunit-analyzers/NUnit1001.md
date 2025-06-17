# NUnit1001

## The individual arguments provided by a TestCaseAttribute must match the type of the corresponding parameter of the method

| Topic    | Value
| :--      | :--
| Id       | NUnit1001
| Severity | Error
| Enabled  | True
| Category | Structure
| Code     | [TestCaseUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.9.2/src/nunit.analyzers/TestCaseUsage/TestCaseUsageAnalyzer.cs)

## Description

The individual arguments provided by a TestCaseAttribute must match the type of the corresponding parameter of the
method.

## Motivation

To prevent tests that will fail at runtime due to improper construction.

## How to fix violations

### Example Violation

```csharp
[TestCase(true)]
public void SampleTest(int numberValue)
{
    Assert.That(numberValue, Is.EqualTo(1));
}

[TestCase<double>(42)]
public void SampleTest(int numberValue)
{
    Assert.That(numberValue, Is.EqualTo(1));
}
```

### Problem

In the test case above, `true` in the test case indicates that `numberValue` should be a boolean. However, the test
declares that `numberValue` is an integer. This will lead to a runtime failure.

### Fix

Ensure that the type of the test case and the input matches.

So, this fix would be acceptable:

```csharp
// TestCase input and parameter are both of type bool
[TestCase(true)]
public void SampleTest(bool booleanValue)
{
    Assert.That(booleanValue, Is.True);
}
```

And this would also work:

```csharp
// TestCase input and parameter are both of type int
[TestCase(1)]
public void SampleTest(int numberValue)
{
    Assert.That(numberValue, Is.EqualTo(1));
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit1001: The individual arguments provided by a TestCaseAttribute must match the type of the corresponding parameter of the method
dotnet_diagnostic.NUnit1001.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit1001 // The individual arguments provided by a TestCaseAttribute must match the type of the corresponding parameter of the method
Code violating the rule here
#pragma warning restore NUnit1001 // The individual arguments provided by a TestCaseAttribute must match the type of the corresponding parameter of the method
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit1001 // The individual arguments provided by a TestCaseAttribute must match the type of the corresponding parameter of the method
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Structure",
    "NUnit1001:The individual arguments provided by a TestCaseAttribute must match the type of the corresponding parameter of the method",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

# NUnit1035

## The 'step' parameter to Range cannot be zero

| Topic    | Value
| :--      | :--
| Id       | NUnit1035
| Severity | Error
| Enabled  | True
| Category | Structure
| Code     | [RangeUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.9.2/src/nunit.analyzers/RangeUsage/RangeUsageAnalyzer.cs)

## Description

The 'step' parameter to Range cannot be zero.

## Motivation

The `Range` attribute is used to specify a range of values for a parameter in a test method.
The `step` parameter defines the increment between each value in the range.
If the `step` is zero, it would create an infinite loop of the same value.
To prevent this NUnit will throw an exception at runtime.

```csharp
[TestFixture]
public class MyTests
{
    private const int Step = 10 / 100; // 10% step

    [Test]
    public void TestMethod([Range(0, 10, Step)] int value)
    {
        // Test code here
    }
}
```

## How to fix violations

Specify a non-zero value for the `step` parameter in the `Range` attribute.

```csharp
[TestFixture]
public class MyTests
{
    private const double Step = 10.0 / 100.0; // 10% step

    [Test]
    public void TestMethod([Range(0.0, 10.0, Step)] double value)
    {
        // Test code here
    }
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit1035: The 'step' parameter to Range cannot be zero
dotnet_diagnostic.NUnit1035.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit1035 // The 'step' parameter to Range cannot be zero
Code violating the rule here
#pragma warning restore NUnit1035 // The 'step' parameter to Range cannot be zero
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit1035 // The 'step' parameter to Range cannot be zero
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Structure",
    "NUnit1035:The 'step' parameter to Range cannot be zero",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

# NUnit1037

## The value for 'from' must be greater than 'to' when 'step' is negative

| Topic    | Value
| :--      | :--
| Id       | NUnit1037
| Severity | Error
| Enabled  | True
| Category | Structure
| Code     | [RangeUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.9.2/src/nunit.analyzers/RangeUsage/RangeUsageAnalyzer.cs)

## Description

Ensure that 'from' is greater than 'to' when 'step' is negative.

## Motivation

The `Range` attribute is used to specify a range of values for a parameter in a test method.
If the `from` value is less than the `to` value when the `step` is negative,
this would result in endless range. To prevent this NUnit will throw an exception at runtime.

```csharp
[Test]
public void TestMethod([Range(0, 10, -1)] int value)
{
    // Test code here
}
```

## How to fix violations

Either specify a `to` value that is less than the `from` value,
or use a positive `step` value if the intention is to generate values in ascending order.

```csharp
[Test]
public void TestMethod([Range(0, 10, 1)] int value)
{
    // Test code here
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit1037: The value for 'from' must be greater than 'to' when 'step' is negative
dotnet_diagnostic.NUnit1037.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit1037 // The value for 'from' must be greater than 'to' when 'step' is negative
Code violating the rule here
#pragma warning restore NUnit1037 // The value for 'from' must be greater than 'to' when 'step' is negative
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit1037 // The value for 'from' must be greater than 'to' when 'step' is negative
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Structure",
    "NUnit1037:The value for 'from' must be greater than 'to' when 'step' is negative",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

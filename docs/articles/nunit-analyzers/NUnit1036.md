# NUnit1036

## The value for 'from' must be less than 'to' when 'step' is positive

| Topic    | Value
| :--      | :--
| Id       | NUnit1036
| Severity | Error
| Enabled  | True
| Category | Structure
| Code     | [RangeUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.9.2/src/nunit.analyzers/RangeUsage/RangeUsageAnalyzer.cs)

## Description

Ensure that 'to' is greater than 'from' when 'step' is positive.

## Motivation

The `Range` attribute is used to specify a range of values for a parameter in a test method.
If the `from` value is greater than the `to` value when the `step` is positive,
this would result in no valid range. To prevent this NUnit will throw an exception at runtime.

```csharp
[Test]
public void TestMethod([Range(10, 0, 2)] int value)
{
    // Test code here
}
```

## How to fix violations

Either specify a `to` value that is greater than the `from` value,
or use a negative `step` value if the intention is to generate values in reverse order.

```csharp
[Test]
public void TestMethod([Range(0, 10, 2)] int value)
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
# NUnit1036: The value for 'from' must be less than 'to' when 'step' is positive
dotnet_diagnostic.NUnit1036.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit1036 // The value for 'from' must be less than 'to' when 'step' is positive
Code violating the rule here
#pragma warning restore NUnit1036 // The value for 'from' must be less than 'to' when 'step' is positive
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit1036 // The value for 'from' must be less than 'to' when 'step' is positive
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Structure",
    "NUnit1036:The value for 'from' must be less than 'to' when 'step' is positive",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

# NUnit1031

## The individual arguments provided by a ValuesAttribute must match the type of the corresponding parameter of the method

| Topic    | Value
| :--      | :--
| Id       | NUnit1031
| Severity | Error
| Enabled  | True
| Category | Structure
| Code     | [ValuesUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.4.0/src/nunit.analyzers/ValuesUsage/ValuesUsageAnalyzer.cs)

## Description

The individual arguments provided by a ValuesAttribute must match the type of the corresponding parameter of the method.

## Motivation

To prevent tests that will fail at runtime due to improper construction.

## How to fix violations

### Example Violation

```csharp
[Test]
public void SampleTest([Values(0.0, 1.0)] int numberValue)
{
    Assert.That(numberValue, Is.AnyOf(0, 1));
}
```

### Problem

In the test above, `numberValue` is declared as an integer. However, `[Values(0.0, 1.0)]` provides values as doubles.
This will lead to a runtime failure.

### Fix

Ensure that the type of the objects used by the `ValuesAttribute` matches that of the parameter.

So, this fix would be acceptable:

```csharp
// Both use type int.
[Test]
public void SampleTest([Values(0, 1)] int numberValue)
{
    Assert.That(numberValue, Is.AnyOf(0, 1));
}
```

And this would also work:

```csharp
// Both use type double
[Test]
public void SampleTest([Values(0.0, 1.0)] double numberValue)
{
    Assert.That(numberValue, Is.AnyOf(0, 1));
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit1031: The individual arguments provided by a ValuesAttribute must match the type of the corresponding parameter of the method
dotnet_diagnostic.NUnit1031.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit1031 // The individual arguments provided by a ValuesAttribute must match the type of the corresponding parameter of the method
Code violating the rule here
#pragma warning restore NUnit1031 // The individual arguments provided by a ValuesAttribute must match the type of the corresponding parameter of the method
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit1031 // The individual arguments provided by a ValuesAttribute must match the type of the corresponding parameter of the method
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Structure",
    "NUnit1031:The individual arguments provided by a ValuesAttribute must match the type of the corresponding parameter of the method",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

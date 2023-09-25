# NUnit2047

## Incompatible types for Within constraint

| Topic    | Value
| :--      | :--
| Id       | NUnit2047
| Severity | Warning
| Enabled  | True
| Category | Assertion
| Code     | [WithinUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/3.8.0//src/nunit.analyzers/WithinUsage/WithinUsageAnalyzer.cs)

## Description

The `Within` modifier should only be used for numeric or Date/Time arguments or tuples containing only these element types. Using it on other types will not have any effect.

## Motivation

To bring developers' attention to a scenario in which their code is actually having no effect and may reveal that their test is not doing what they expect.

## How to fix violations

### Example Violation

```csharp
[Test]
public void RecordsEqualsMismatch()
{
    var a = new Data(1, 1.0);
    var b = new Data(1, 1.1);

    Assert.That(a, Is.EqualTo(b).Within(0.2), $"{a} != {b}");
}

private sealed record Data(int number, double Value);
```

### Explanation

Using `Within` here doesn't make any sense, because NUnit cannot apply comparison with tolerance to the types we're comparing.

### Fix

Remove the errant call to `Within`:

```csharp
[Test]
public void RecordsEqualsMismatch()
{
    var a = new Data(1, 1.0);
    var b = new Data(1, 1.1);

    Assert.That(a, Is.EqualTo(b), $"{a} != {b}");
}

private sealed record Data(int number, double Value);
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see [MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2047: Incompatible types for Within constraint
dotnet_diagnostic.NUnit2047.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2047 // Incompatible types for Within constraint
Code violating the rule here
#pragma warning restore NUnit2047 // Incompatible types for Within constraint
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2047 // Incompatible types for Within constraint
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2047:Incompatible types for Within constraint",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

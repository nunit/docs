# NUnit2012

## Use StartsWithConstraint for better assertion messages in case of failure

| Topic    | Value
| :--      | :--
| Id       | NUnit2012
| Severity | Info
| Enabled  | True
| Category | Assertion
| Code     | [StringConstraintUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.4.0/src/nunit.analyzers/ConstraintUsage/StringConstraintUsageAnalyzer.cs)

## Description

Using constraints instead of boolean methods will lead to better assertion messages in case of failure.

## Motivation

Using `Does.StartWith` (or `Does.Not.StartWith`) constraint will lead to better assertion messages in case of failure,
so this analyzer marks all usages of string `StartsWith` method where it is possible to replace
with `Does.StartWith` constraint.

```csharp
[Test]
public void Test()
{
    string actual = "...";
    string expected = "...";
    ClassicAssert.True(actual.StartsWith(expected));
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `ClassicAssert.True(actual.StartWith(expected))` with
`Assert.That(actual, Does.StartWith(expected))`. So the code block above will be changed into

```csharp
[Test]
public void Test()
{
    string actual = "...";
    string expected = "...";
    Assert.That(actual, Does.StartWith(expected));
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2012: Use StartsWithConstraint for better assertion messages in case of failure
dotnet_diagnostic.NUnit2012.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2012 // Use StartsWithConstraint for better assertion messages in case of failure
Code violating the rule here
#pragma warning restore NUnit2012 // Use StartsWithConstraint for better assertion messages in case of failure
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2012 // Use StartsWithConstraint for better assertion messages in case of failure
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2012:Use StartsWithConstraint for better assertion messages in case of failure",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

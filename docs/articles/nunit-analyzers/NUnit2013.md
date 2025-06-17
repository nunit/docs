# NUnit2013

## Use EndsWithConstraint for better assertion messages in case of failure

| Topic    | Value
| :--      | :--
| Id       | NUnit2013
| Severity | Info
| Enabled  | True
| Category | Assertion
| Code     | [StringConstraintUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.9.2/src/nunit.analyzers/ConstraintUsage/StringConstraintUsageAnalyzer.cs)

## Description

Using constraints instead of boolean methods will lead to better assertion messages in case of failure.

## Motivation

Using `Does.EndWith` (or `Does.Not.EndWith`) constraint will lead to better assertion messages in case of failure,
so this analyzer marks all usages of string `EndsWith` method where it is possible to replace
with `Does.EndWith` constraint.

```csharp
[Test]
public void Test()
{
    string actual = "...";
    string expected = "...";
    ClassicAssert.True(actual.EndsWith(expected));
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `ClassicAssert.True(actual.EndsWith(expected))` with
`Assert.That(actual, Does.EndWith(expected))`. So the code block above will be changed into

```csharp
[Test]
public void Test()
{
    string actual = "...";
    string expected = "...";
    Assert.That(actual, Does.EndWith(expected));
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2013: Use EndsWithConstraint for better assertion messages in case of failure
dotnet_diagnostic.NUnit2013.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2013 // Use EndsWithConstraint for better assertion messages in case of failure
Code violating the rule here
#pragma warning restore NUnit2013 // Use EndsWithConstraint for better assertion messages in case of failure
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2013 // Use EndsWithConstraint for better assertion messages in case of failure
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2013:Use EndsWithConstraint for better assertion messages in case of failure",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

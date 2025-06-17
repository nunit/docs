# NUnit2043

## Use ComparisonConstraint for better assertion messages in case of failure

| Topic    | Value
| :--      | :--
| Id       | NUnit2043
| Severity | Info
| Enabled  | True
| Category | Assertion
| Code     | [ComparisonConstraintUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.9.2/src/nunit.analyzers/ConstraintUsage/ComparisonConstraintUsageAnalyzer.cs)

## Description

Using ComparisonConstraint will lead to better assertion messages in case of failure.

## Motivation

Using `Is.GreaterThan` constraint will lead to better assertion messages in case of failure,
so this analyzer marks all usages of a comparison operators `>`, `>=`, `<` and `<=`
where it is possible to replace with the appropriate comparison constraint.

```csharp
[Test]
public void Test()
{
    ClassicAssert.True(actual > expected);
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `ClassicAssert.True(actual > expected)` with
`Assert.That(actual, Is.GreaterThan(expected))`. So the code block above will be changed into

```csharp
[Test]
public void Test()
{
    Assert.That(actual, Is.GreaterThan(expected));
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2043: Use ComparisonConstraint for better assertion messages in case of failure
dotnet_diagnostic.NUnit2043.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2043 // Use ComparisonConstraint for better assertion messages in case of failure
Code violating the rule here
#pragma warning restore NUnit2043 // Use ComparisonConstraint for better assertion messages in case of failure
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2043 // Use ComparisonConstraint for better assertion messages in case of failure
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2043:Use ComparisonConstraint for better assertion messages in case of failure",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

# NUnit2051

## Consider using Assert.That(expr, Is.Positive) instead of ClassicAssert.Positive(expr)

| Topic    | Value
| :--      | :--
| Id       | NUnit2051
| Severity | Info
| Enabled  | True
| Category | Assertion
| Code     | [ClassicModelAssertUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.4.0/src/nunit.analyzers/ClassicModelAssertUsage/ClassicModelAssertUsageAnalyzer.cs)

## Description

Consider using the constraint model, `Assert.That(expr, Is.Positive)`, instead of the classic model,
`ClassicAssert.Positive(expr)`.

## Motivation

The classic Assert model contains less flexibility than the constraint model,
so this analyzer marks usages of `ClassicAssert.Positive` from the classic Assert model.

```csharp
[Test]
public void Test()
{
    ClassicAssert.Positive(expression);
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `ClassicAssert.Positive(expression)` with
`Assert.That(expression, Is.Positive)`. So the code block above will be changed into.

```csharp
[Test]
public void Test()
{
    Assert.That(expression, Is.Positive);
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2051: Consider using Assert.That(expr, Is.Positive) instead of ClassicAssert.Positive(expr)
dotnet_diagnostic.NUnit2051.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2051 // Consider using Assert.That(expr, Is.Positive) instead of ClassicAssert.Positive(expr)
Code violating the rule here
#pragma warning restore NUnit2051 // Consider using Assert.That(expr, Is.Positive) instead of ClassicAssert.Positive(expr)
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2051 // Consider using Assert.That(expr, Is.Positive) instead of ClassicAssert.Positive(expr)
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2051:Consider using Assert.That(expr, Is.Positive) instead of ClassicAssert.Positive(expr)",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

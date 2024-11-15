# NUnit2052

## Consider using Assert.That(expr, Is.Negative) instead of ClassicAssert.Negative(expr)

| Topic    | Value
| :--      | :--
| Id       | NUnit2052
| Severity | Info
| Enabled  | True
| Category | Assertion
| Code     | [ClassicModelAssertUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.4.0/src/nunit.analyzers/ClassicModelAssertUsage/ClassicModelAssertUsageAnalyzer.cs)

## Description

Consider using the constraint model, `Assert.That(expr, Is.Negative)`, instead of the classic model,
`ClassicAssert.Negative(expr)`.

## Motivation

The classic Assert model contains less flexibility than the constraint model,
so this analyzer marks usages of `ClassicAssert.Negative` from the classic Assert model.

```csharp
[Test]
public void Test()
{
    ClassicAssert.Negative(expression);
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `ClassicAssert.Negative(expression)` with
`Assert.That(expression, Is.Negative)`. So the code block above will be changed into.

```csharp
[Test]
public void Test()
{
    Assert.That(expression, Is.Negative);
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2052: Consider using Assert.That(expr, Is.Negative) instead of ClassicAssert.Negative(expr)
dotnet_diagnostic.NUnit2052.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2052 // Consider using Assert.That(expr, Is.Negative) instead of ClassicAssert.Negative(expr)
Code violating the rule here
#pragma warning restore NUnit2052 // Consider using Assert.That(expr, Is.Negative) instead of ClassicAssert.Negative(expr)
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2052 // Consider using Assert.That(expr, Is.Negative) instead of ClassicAssert.Negative(expr)
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2052:Consider using Assert.That(expr, Is.Negative) instead of ClassicAssert.Negative(expr)",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

# NUnit2001

## Consider using Assert.That(expr, Is.False) instead of ClassicAssert.False(expr)

| Topic    | Value
| :--      | :--
| Id       | NUnit2001
| Severity | Info
| Enabled  | True
| Category | Assertion
| Code     | [ClassicModelAssertUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.4.0/src/nunit.analyzers/ClassicModelAssertUsage/ClassicModelAssertUsageAnalyzer.cs)

## Description

Consider using the constraint model, `Assert.That(expr, Is.False)`, instead of the classic model,
`ClassicAssert.False(expr)`.

## Motivation

The classic Assert model contains less flexibility than the constraint model,
so this analyzer marks usages of `ClassicAssert.False` from the classic Assert model.

```csharp
[Test]
public void Test()
{
    ClassicAssert.False(expression);
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `ClassicAssert.False(expression)` with
`Assert.That(expression, Is.False)`. So the code block above will be changed into.

```csharp
[Test]
public void Test()
{
    Assert.That(expression, Is.False);
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2001: Consider using Assert.That(expr, Is.False) instead of ClassicAssert.False(expr)
dotnet_diagnostic.NUnit2001.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2001 // Consider using Assert.That(expr, Is.False) instead of ClassicAssert.False(expr)
Code violating the rule here
#pragma warning restore NUnit2001 // Consider using Assert.That(expr, Is.False) instead of ClassicAssert.False(expr)
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2001 // Consider using Assert.That(expr, Is.False) instead of ClassicAssert.False(expr)
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2001:Consider using Assert.That(expr, Is.False) instead of ClassicAssert.False(expr)",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

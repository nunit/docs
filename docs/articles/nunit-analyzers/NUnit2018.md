# NUnit2018

## Consider using Assert.That(expr, Is.Not.Null) instead of ClassicAssert.NotNull(expr)

| Topic    | Value
| :--      | :--
| Id       | NUnit2018
| Severity | Info
| Enabled  | True
| Category | Assertion
| Code     | [ClassicModelAssertUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.9.2/src/nunit.analyzers/ClassicModelAssertUsage/ClassicModelAssertUsageAnalyzer.cs)

## Description

Consider using the constraint model, `Assert.That(expr, Is.Not.Null)`, instead of the classic model,
`ClassicAssert.NotNull(expr)`.

## Motivation

The classic Assert model contains less flexibility than the constraint model,
so this analyzer marks usages of `ClassicAssert.NotNull` from the classic Assert model.

```csharp
[Test]
public void Test()
{
    object obj = null;
    ClassicAssert.NotNull(obj);
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `ClassicAssert.NotNull(expression)` with
`Assert.That(expression, Is.Not.Null)`. So the code block above will be changed into.

```csharp
[Test]
public void Test()
{
    object obj = null;
    Assert.That(obj, Is.Not.Null);
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2018: Consider using Assert.That(expr, Is.Not.Null) instead of ClassicAssert.NotNull(expr)
dotnet_diagnostic.NUnit2018.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2018 // Consider using Assert.That(expr, Is.Not.Null) instead of ClassicAssert.NotNull(expr)
Code violating the rule here
#pragma warning restore NUnit2018 // Consider using Assert.That(expr, Is.Not.Null) instead of ClassicAssert.NotNull(expr)
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2018 // Consider using Assert.That(expr, Is.Not.Null) instead of ClassicAssert.NotNull(expr)
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2018:Consider using Assert.That(expr, Is.Not.Null) instead of ClassicAssert.NotNull(expr)",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

# NUnit2032

## Consider using Assert.That(expr, Is.Zero) instead of Assert.Zero(expr).

| Topic    | Value
| :--      | :--
| Id       | NUnit2032
| Severity | Info
| Enabled  | True
| Category | Assertion
| Code     | [ClassicModelAssertUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/0.4.0/src/nunit.analyzers/ClassicModelAssertUsage/ClassicModelAssertUsageAnalyzer.cs)

## Description

Consider using the constraint model, Assert.That(expr, Is.Zero), instead of the classic model, Assert.Zero(expr).

## Motivation

The classic Assert model contains less flexibility than the constraint model,
so this analyzer marks usages of `Assert.Zero` from the classic Assert model.

```csharp
[Test]
public void Test()
{
    Assert.Zero(expression);
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `Assert.Zero(expression)` with
`Assert.That(expression, Is.Zero)`. So the code block above will be changed into.

```csharp
[Test]
public void Test()
{
    Assert.That(expression, Is.Zero);
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file.

Configure the severity per project, for more info see [MSDN](https://msdn.microsoft.com/en-us/library/dd264949.aspx).

### Via #pragma directive.

```csharp
#pragma warning disable NUnit2032 // Consider using Assert.That(expr, Is.Zero) instead of Assert.Zero(expr).
Code violating the rule here
#pragma warning restore NUnit2032 // Consider using Assert.That(expr, Is.Zero) instead of Assert.Zero(expr).
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2032 // Consider using Assert.That(expr, Is.Zero) instead of Assert.Zero(expr).
```

### Via attribute `[SuppressMessage]`.

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2032:Consider using Assert.That(expr, Is.Zero) instead of Assert.Zero(expr).",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

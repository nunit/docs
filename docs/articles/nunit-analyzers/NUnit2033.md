# NUnit2033

## Consider using Assert.That(expr, Is.Not.Zero) instead of Assert.NotZero(expr).

| Topic    | Value
| :--      | :--
| Id       | NUnit2033
| Severity | Info
| Enabled  | True
| Category | Assertion
| Code     | [ClassicModelAssertUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/0.4.0/src/nunit.analyzers/ClassicModelAssertUsage/ClassicModelAssertUsageAnalyzer.cs)

## Description

Consider using the constraint model, Assert.That(expr, Is.Not.Zero), instead of the classic model, Assert.NotZero(expr).

## Motivation

The classic Assert model contains less flexibility than the constraint model,
so this analyzer marks usages of `Assert.NotZero` from the classic Assert model.

```csharp
[Test]
public void Test()
{
    Assert.NotZero(expression);
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `Assert.NotZero(expression)` with
`Assert.That(expression, Is.Not.Zero)`. So the code block above will be changed into.

```csharp
[Test]
public void Test()
{
    Assert.That(expression, Is.Not.Zero);
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file.

Configure the severity per project, for more info see [MSDN](https://msdn.microsoft.com/en-us/library/dd264949.aspx).

### Via #pragma directive.

```csharp
#pragma warning disable NUnit2033 // Consider using Assert.That(expr, Is.Not.Zero) instead of Assert.NotZero(expr).
Code violating the rule here
#pragma warning restore NUnit2033 // Consider using Assert.That(expr, Is.Not.Zero) instead of Assert.NotZero(expr).
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2033 // Consider using Assert.That(expr, Is.Not.Zero) instead of Assert.NotZero(expr).
```

### Via attribute `[SuppressMessage]`.

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2033:Consider using Assert.That(expr, Is.Not.Zero) instead of Assert.NotZero(expr).",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

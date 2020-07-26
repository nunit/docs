# NUnit2006

## Consider using Assert.That(actual, Is.Not.EqualTo(expected)) instead of Assert.AreNotEqual(expected, actual).

| Topic    | Value
| :--      | :--
| Id       | NUnit2006
| Severity | Warning
| Enabled  | True
| Category | Assertion
| Code     | [ClassicModelAssertUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/0.4.0/src/nunit.analyzers/ClassicModelAssertUsage/ClassicModelAssertUsageAnalyzer.cs)

## Description

Consider using the constraint model, `Assert.That(actual, Is.Not.EqualTo(expected))`, instead of the classic model, `Assert.AreNotEqual(expected, actual)`.

## Motivation

The classic Assert model, `Assert.AreNotEqual(expected, actual)`, makes it easy to mix the `expected` and the `actual` parameter,
so this analyzer marks usages of `Assert.AreNotEqual` from the classic Assert model.

```csharp
[Test]
public void Test()
{
    Assert.AreNotEqual(expression1, expression2)
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `Assert.AreNotEqual(expression1, expression2)`
with `Assert.That(expression2, Is.Not.EqualTo(expression1))`. So the code block above will be changed into.

```csharp
[Test]
public void Test()
{
    Assert.That(expression2, Is.Not.EqualTo(expression1));
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file.

Configure the severity per project, for more info see [MSDN](https://msdn.microsoft.com/en-us/library/dd264949.aspx).

### Via #pragma directive.

```csharp
#pragma warning disable NUnit2006 // Consider using Assert.That(actual, Is.Not.EqualTo(expected)) instead of Assert.AreNotEqual(expected, actual).
Code violating the rule here
#pragma warning restore NUnit2006 // Consider using Assert.That(actual, Is.Not.EqualTo(expected)) instead of Assert.AreNotEqual(expected, actual).
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2006 // Consider using Assert.That(actual, Is.Not.EqualTo(expected)) instead of Assert.AreNotEqual(expected, actual).
```

### Via attribute `[SuppressMessage]`.

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2006:Consider using Assert.That(actual, Is.Not.EqualTo(expected)) instead of Assert.AreNotEqual(expected, actual).",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

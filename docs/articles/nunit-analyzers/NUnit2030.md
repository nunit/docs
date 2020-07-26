# NUnit2030

## Consider using Assert.That(actual, Is.LessThanOrEqualTo(expected)) instead of Assert.LessOrEqual(actual, expected).

| Topic    | Value
| :--      | :--
| Id       | NUnit2030
| Severity | Warning
| Enabled  | True
| Category | Assertion
| Code     | [ClassicModelAssertUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/0.4.0/src/nunit.analyzers/ClassicModelAssertUsage/ClassicModelAssertUsageAnalyzer.cs)

## Description

Consider using the constraint model, Assert.That(actual, Is.LessThanOrEqualTo(expected)), instead of the classic model, Assert.LessOrEqual(actual, expected).

## Motivation

The assert `Assert.LessOrEqual` from the classic Assert model makes it easy to confuse the `expected` and the `actual` argument,
so this analyzer marks usages of `Assert.LessOrEqual`.

```csharp
[Test]
public void Test()
{
    Assert.LessOrEqual(actual, expected);
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `Assert.LessOrEqual(actual, expected)` with
`Assert.That(actual, Is.LessThanOrEqualTo(expected))`. So the code block above will be changed into.

```csharp
[Test]
public void Test()
{
    Assert.That(actual, Is.SameAs(expected));
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file.

Configure the severity per project, for more info see [MSDN](https://msdn.microsoft.com/en-us/library/dd264949.aspx).

### Via #pragma directive.

```csharp
#pragma warning disable NUnit2030 // Consider using Assert.That(actual, Is.LessThanOrEqualTo(expected)) instead of Assert.LessOrEqual(actual, expected).
Code violating the rule here
#pragma warning restore NUnit2030 // Consider using Assert.That(actual, Is.LessThanOrEqualTo(expected)) instead of Assert.LessOrEqual(actual, expected).
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2030 // Consider using Assert.That(actual, Is.LessThanOrEqualTo(expected)) instead of Assert.LessOrEqual(actual, expected).
```

### Via attribute `[SuppressMessage]`.

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2030:Consider using Assert.That(actual, Is.LessThanOrEqualTo(expected)) instead of Assert.LessOrEqual(actual, expected).",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

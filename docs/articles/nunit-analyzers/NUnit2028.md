# NUnit2028

## Consider using Assert.That(actual, Is.GreaterThanOrEqualTo(expected)) instead of Assert.GreaterOrEqual(actual, expected).

| Topic    | Value
| :--      | :--
| Id       | NUnit2028
| Severity | Warning
| Enabled  | True
| Category | Assertion
| Code     | [ClassicModelAssertUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/0.4.0/src/nunit.analyzers/ClassicModelAssertUsage/ClassicModelAssertUsageAnalyzer.cs)

## Description

Consider using the constraint model, Assert.That(actual, Is.GreaterThanOrEqualTo(expected)), instead of the classic model, Assert.GreaterOrEqual(actual, expected).

## Motivation

The assert `Assert.GreaterOrEqual` from the classic Assert model makes it easy to confuse the `expected` and the `actual` argument,
so this analyzer marks usages of `Assert.GreaterOrEqual`.

```csharp
[Test]
public void Test()
{
    Assert.GreaterOrEqual(actual, expected);
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `Assert.GreaterOrEqual(actual, expected)` with
`Assert.That(actual, Is.GreaterThanOrEqualTo(expected))`. So the code block above will be changed into.

```csharp
[Test]
public void Test()
{
    Assert.That(actual, Is.GreaterThanOrEqualTo(expected));
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file.

Configure the severity per project, for more info see [MSDN](https://msdn.microsoft.com/en-us/library/dd264949.aspx).

### Via #pragma directive.

```csharp
#pragma warning disable NUnit2028 // Consider using Assert.That(actual, Is.GreaterThanOrEqualTo(expected)) instead of Assert.GreaterOrEqual(actual, expected).
Code violating the rule here
#pragma warning restore NUnit2028 // Consider using Assert.That(actual, Is.GreaterThanOrEqualTo(expected)) instead of Assert.GreaterOrEqual(actual, expected).
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2028 // Consider using Assert.That(actual, Is.GreaterThanOrEqualTo(expected)) instead of Assert.GreaterOrEqual(actual, expected).
```

### Via attribute `[SuppressMessage]`.

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2028:Consider using Assert.That(actual, Is.GreaterThanOrEqualTo(expected)) instead of Assert.GreaterOrEqual(actual, expected).",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

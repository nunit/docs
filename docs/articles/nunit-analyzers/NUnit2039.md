# NUnit2039

## Consider using Assert.That(actual, Is.Not.InstanceOf(expected)) instead of Assert.IsNotInstanceOf(expected, actual).

| Topic    | Value
| :--      | :--
| Id       | NUnit2039
| Severity | Info
| Enabled  | True
| Category | Assertion
| Code     | [ClassicModelAssertUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/0.4.0/src/nunit.analyzers/ClassicModelAssertUsage/ClassicModelAssertUsageAnalyzer.cs)

## Description

Consider using the constraint model, Assert.That(actual, Is.Not.InstanceOf(expected)), instead of the classic model, Assert.IsNotInstanceOf(expected, actual).

## Motivation

The assert `Assert.IsNotInstanceOf` from the classic Assert model makes it easy to confuse the `expected` and the `actual` argument,
so this analyzer marks usages of `Assert.IsNotInstanceOf`.

```csharp
[Test]
public void Test()
{
    Assert.IsNotInstanceOf(expected, actual);
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `Assert.IsNotInstanceOf(expected, actual)` with
`Assert.That(actual, Is.Not.InstanceOf(expected))`. So the code block above will be changed into.

```csharp
[Test]
public void Test()
{
    Assert.That(actual, Is.Not.InstanceOf(expected));
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file.

Configure the severity per project, for more info see [MSDN](https://msdn.microsoft.com/en-us/library/dd264949.aspx).

### Via #pragma directive.

```csharp
#pragma warning disable NUnit2039 // Consider using Assert.That(actual, Is.Not.InstanceOf(expected)) instead of Assert.IsNotInstanceOf(expected, actual).
Code violating the rule here
#pragma warning restore NUnit2039 // Consider using Assert.That(actual, Is.Not.InstanceOf(expected)) instead of Assert.IsNotInstanceOf(expected, actual).
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2039 // Consider using Assert.That(actual, Is.Not.InstanceOf(expected)) instead of Assert.IsNotInstanceOf(expected, actual).
```

### Via attribute `[SuppressMessage]`.

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2039:Consider using Assert.That(actual, Is.Not.InstanceOf(expected)) instead of Assert.IsNotInstanceOf(expected, actual).",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

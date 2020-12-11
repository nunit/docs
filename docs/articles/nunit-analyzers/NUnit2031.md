# NUnit2031

## Consider using Assert.That(actual, Is.Not.SameAs(expected)) instead of Assert.AreNotSame(expected, actual)

| Topic    | Value
| :--      | :--
| Id       | NUnit2031
| Severity | Warning
| Enabled  | True
| Category | Assertion
| Code     | [ClassicModelAssertUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/0.6.0/src/nunit.analyzers/ClassicModelAssertUsage/ClassicModelAssertUsageAnalyzer.cs)

## Description

Consider using the constraint model, `Assert.That(actual, Is.Not.SameAs(expected))`, instead of the classic model, `Assert.AreNotSame(expected, actual)`.

## Motivation

The assert `Assert.AreNotSame` from the classic Assert model makes it easy to confuse the `expected` and the `actual` argument,
so this analyzer marks usages of `Assert.AreNotSame`.

```csharp
[Test]
public void Test()
{
    Assert.AreNotSame(expected, actual);
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `Assert.AreNotSame(expected, actual)` with
`Assert.That(actual, Is.Not.SameAs(expected))`. So the code block above will be changed into.

```csharp
[Test]
public void Test()
{
    Assert.That(actual, Is.Not.SameAs(expected));
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see [MSDN](https://msdn.microsoft.com/en-us/library/dd264949.aspx).

### Via .editorconfig file

```ini
# NUnit2031: Consider using Assert.That(actual, Is.Not.SameAs(expected)) instead of Assert.AreNotSame(expected, actual)
dotnet_diagnostic.NUnit2031.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2031 // Consider using Assert.That(actual, Is.Not.SameAs(expected)) instead of Assert.AreNotSame(expected, actual)
Code violating the rule here
#pragma warning restore NUnit2031 // Consider using Assert.That(actual, Is.Not.SameAs(expected)) instead of Assert.AreNotSame(expected, actual)
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2031 // Consider using Assert.That(actual, Is.Not.SameAs(expected)) instead of Assert.AreNotSame(expected, actual)
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2031:Consider using Assert.That(actual, Is.Not.SameAs(expected)) instead of Assert.AreNotSame(expected, actual)",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

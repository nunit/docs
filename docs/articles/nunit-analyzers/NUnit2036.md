# NUnit2036

## Consider using Assert.That(collection, Is.Not.Empty) instead of Assert.IsNotEmpty(collection).

| Topic    | Value
| :--      | :--
| Id       | NUnit2036
| Severity | Info
| Enabled  | True
| Category | Assertion
| Code     | [ClassicModelAssertUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/0.4.0/src/nunit.analyzers/ClassicModelAssertUsage/ClassicModelAssertUsageAnalyzer.cs)

## Description

Consider using the constraint model, Assert.That(collection, Is.Not.Empty), instead of the classic model, Assert.IsNotEmpty(collection).

## Motivation

The classic Assert model contains less flexibility than the constraint model,
so this analyzer marks usages of `Assert.IsNotEmpty` from the classic Assert model.

```csharp
[Test]
public void Test()
{
    Assert.IsNotEmpty(collection);
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `Assert.IsNotEmpty(collection)` with
`Assert.That(collection, Is.Not.Empty)`. So the code block above will be changed into.

```csharp
[Test]
public void Test()
{
    Assert.That(collection, Is.Not.Empty);
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file.

Configure the severity per project, for more info see [MSDN](https://msdn.microsoft.com/en-us/library/dd264949.aspx).

### Via #pragma directive.

```csharp
#pragma warning disable NUnit2036 // Consider using Assert.That(collection, Is.Not.Empty) instead of Assert.IsNotEmpty(collection).
Code violating the rule here
#pragma warning restore NUnit2036 // Consider using Assert.That(collection, Is.Not.Empty) instead of Assert.IsNotEmpty(collection).
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2036 // Consider using Assert.That(collection, Is.Not.Empty) instead of Assert.IsNotEmpty(collection).
```

### Via attribute `[SuppressMessage]`.

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2036:Consider using Assert.That(collection, Is.Not.Empty) instead of Assert.IsNotEmpty(collection).",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

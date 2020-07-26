# NUnit2037

## Consider using Assert.That(collection, Does.Contain(instance)) instead of Assert.Contains(instance, collection).

| Topic    | Value
| :--      | :--
| Id       | NUnit2037
| Severity | Info
| Enabled  | True
| Category | Assertion
| Code     | [ClassicModelAssertUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/0.4.0/src/nunit.analyzers/ClassicModelAssertUsage/ClassicModelAssertUsageAnalyzer.cs)

## Description

Consider using the constraint model, Assert.That(collection, Does.Contain(instance)), instead of the classic model, Assert.Contains(instance, collection).

## Motivation

The assert `Assert.Contains` from the classic Assert model makes it easy to confuse the `instance` and the `collection` argument,
so this analyzer marks usages of `Assert.Contains`.

```csharp
[Test]
public void Test()
{
    Assert.Contains(instance, collection);
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `Assert.Contains(instance, collection)` with
`Assert.That(collection, Does.Contain(instance))`. So the code block above will be changed into.

```csharp
[Test]
public void Test()
{
    Assert.That(collection, Does.Contain(instance));
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file.

Configure the severity per project, for more info see [MSDN](https://msdn.microsoft.com/en-us/library/dd264949.aspx).

### Via #pragma directive.

```csharp
#pragma warning disable NUnit2037 // Consider using Assert.That(collection, Does.Contain(instance)) instead of Assert.Contains(instance, collection).
Code violating the rule here
#pragma warning restore NUnit2037 // Consider using Assert.That(collection, Does.Contain(instance)) instead of Assert.Contains(instance, collection).
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2037 // Consider using Assert.That(collection, Does.Contain(instance)) instead of Assert.Contains(instance, collection).
```

### Via attribute `[SuppressMessage]`.

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2037:Consider using Assert.That(collection, Does.Contain(instance)) instead of Assert.Contains(instance, collection).",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

# NUnit2035

## Consider using Assert.That(collection, Is.Empty) instead of Assert.IsEmpty(collection)

| Topic    | Value
| :--      | :--
| Id       | NUnit2035
| Severity | Info
| Enabled  | True
| Category | Assertion
| Code     | [ClassicModelAssertUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/0.6.0/src/nunit.analyzers/ClassicModelAssertUsage/ClassicModelAssertUsageAnalyzer.cs)

## Description

Consider using the constraint model, `Assert.That(collection, Is.Empty)`, instead of the classic model, `Assert.IsEmpty(collection)`.

## Motivation

The classic Assert model contains less flexibility than the constraint model,
so this analyzer marks usages of `Assert.IsEmpty` from the classic Assert model.

```csharp
[Test]
public void Test()
{
    Assert.IsEmpty(collection);
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `Assert.IsEmpty(collection)` with
`Assert.That(collection, Is.Empty)`. So the code block above will be changed into.

```csharp
[Test]
public void Test()
{
    Assert.That(collection, Is.Empty);
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see [MSDN](https://msdn.microsoft.com/en-us/library/dd264949.aspx).

### Via .editorconfig file

```ini
# NUnit2035: Consider using Assert.That(collection, Is.Empty) instead of Assert.IsEmpty(collection)
dotnet_diagnostic.NUnit2035.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2035 // Consider using Assert.That(collection, Is.Empty) instead of Assert.IsEmpty(collection)
Code violating the rule here
#pragma warning restore NUnit2035 // Consider using Assert.That(collection, Is.Empty) instead of Assert.IsEmpty(collection)
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2035 // Consider using Assert.That(collection, Is.Empty) instead of Assert.IsEmpty(collection)
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2035:Consider using Assert.That(collection, Is.Empty) instead of Assert.IsEmpty(collection)",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

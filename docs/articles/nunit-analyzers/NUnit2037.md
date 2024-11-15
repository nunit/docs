# NUnit2037

## Consider using Assert.That(collection, Does.Contain(instance)) instead of ClassicAssert.Contains(instance, collection)

| Topic    | Value
| :--      | :--
| Id       | NUnit2037
| Severity | Info
| Enabled  | True
| Category | Assertion
| Code     | [ClassicModelAssertUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.4.0/src/nunit.analyzers/ClassicModelAssertUsage/ClassicModelAssertUsageAnalyzer.cs)

## Description

Consider using the constraint model, `Assert.That(collection, Does.Contain(instance))`, instead of the classic model,
`ClassicAssert.Contains(instance, collection)`.

## Motivation

The assert `ClassicAssert.Contains` from the classic Assert model makes it easy to confuse the `instance` and the
`collection` argument, so this analyzer marks usages of `ClassicAssert.Contains`.

```csharp
[Test]
public void Test()
{
    ClassicAssert.Contains(instance, collection);
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `ClassicAssert.Contains(instance, collection)` with
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

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2037: Consider using Assert.That(collection, Does.Contain(instance)) instead of ClassicAssert.Contains(instance, collection)
dotnet_diagnostic.NUnit2037.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2037 // Consider using Assert.That(collection, Does.Contain(instance)) instead of ClassicAssert.Contains(instance, collection)
Code violating the rule here
#pragma warning restore NUnit2037 // Consider using Assert.That(collection, Does.Contain(instance)) instead of ClassicAssert.Contains(instance, collection)
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2037 // Consider using Assert.That(collection, Does.Contain(instance)) instead of ClassicAssert.Contains(instance, collection)
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2037:Consider using Assert.That(collection, Does.Contain(instance)) instead of ClassicAssert.Contains(instance, collection)",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

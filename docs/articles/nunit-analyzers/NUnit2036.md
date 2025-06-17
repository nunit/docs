# NUnit2036

## Consider using Assert.That(collection, Is.Not.Empty) instead of ClassicAssert.IsNotEmpty(collection)

| Topic    | Value
| :--      | :--
| Id       | NUnit2036
| Severity | Info
| Enabled  | True
| Category | Assertion
| Code     | [ClassicModelAssertUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.9.2/src/nunit.analyzers/ClassicModelAssertUsage/ClassicModelAssertUsageAnalyzer.cs)

## Description

Consider using the constraint model, `Assert.That(collection, Is.Not.Empty)`, instead of the classic model,
`ClassicAssert.IsNotEmpty(collection)`.

## Motivation

The classic Assert model contains less flexibility than the constraint model,
so this analyzer marks usages of `ClassicAssert.IsNotEmpty` from the classic Assert model.

```csharp
[Test]
public void Test()
{
    ClassicAssert.IsNotEmpty(collection);
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `ClassicAssert.IsNotEmpty(collection)` with
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

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2036: Consider using Assert.That(collection, Is.Not.Empty) instead of ClassicAssert.IsNotEmpty(collection)
dotnet_diagnostic.NUnit2036.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2036 // Consider using Assert.That(collection, Is.Not.Empty) instead of ClassicAssert.IsNotEmpty(collection)
Code violating the rule here
#pragma warning restore NUnit2036 // Consider using Assert.That(collection, Is.Not.Empty) instead of ClassicAssert.IsNotEmpty(collection)
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2036 // Consider using Assert.That(collection, Is.Not.Empty) instead of ClassicAssert.IsNotEmpty(collection)
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2036:Consider using Assert.That(collection, Is.Not.Empty) instead of ClassicAssert.IsNotEmpty(collection)",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

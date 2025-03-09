# NUnit2054

<!-- markdownlint-disable-next-line MD013 -->
## Consider using Assert.That(actual, Is.Not.AssignableFrom(expected)) instead of ClassicAssert.IsNotAssignableFrom(expected, actual)

| Topic    | Value
| :--      | :--
| Id       | NUnit2054
| Severity | Info
| Enabled  | True
| Category | Assertion
| Code     | [ClassicModelAssertUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.4.0/src/nunit.analyzers/ClassicModelAssertUsage/ClassicModelAssertUsageAnalyzer.cs)

## Description

Consider using the constraint model, `Assert.That(actual, Is.Not.AssignableFrom(expected))`, instead of the classic model,
`ClassicAssert.IsNotAssignableFrom(expected, actual)`.

## Motivation

The assert `ClassicAssert.IsNotAssignableFrom` from the classic Assert model makes it easy to confuse the `expected`
and the `actual` argument, so this analyzer marks usages of `ClassicAssert.IsNotAssignableFrom`.

```csharp
[Test]
public void Test()
{
    ClassicAssert.IsNotAssignableFrom(expected, actual);
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `ClassicAssert.IsNotAssignableFrom(expected, actual)` with
`Assert.That(actual, Is.Not.AssignableFrom(expected))`. So the code block above will be changed into.

```csharp
[Test]
public void Test()
{
    Assert.That(actual, Is.Not.AssignableFrom(expected));
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2054: Consider using Assert.That(actual, Is.Not.AssignableFrom(expected)) instead of ClassicAssert.IsNotAssignableFrom(expected, actual)
dotnet_diagnostic.NUnit2054.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2054 // Consider using Assert.That(actual, Is.Not.AssignableFrom(expected)) instead of ClassicAssert.IsNotAssignableFrom(expected, actual)
Code violating the rule here
#pragma warning restore NUnit2054 // Consider using Assert.That(actual, Is.Not.AssignableFrom(expected)) instead of ClassicAssert.IsNotAssignableFrom(expected, actual)
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2054 // Consider using Assert.That(actual, Is.Not.AssignableFrom(expected)) instead of ClassicAssert.IsNotAssignableFrom(expected, actual)
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2054:Consider using Assert.That(actual, Is.Not.AssignableFrom(expected)) instead of ClassicAssert.IsNotAssignableFrom(expected, actual)",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

# NUnit2053

## Consider using Assert.That(actual, Is.AssignableFrom(expected)) instead of ClassicAssert.IsAssignableFrom(expected, actual)

| Topic    | Value
| :--      | :--
| Id       | NUnit2053
| Severity | Info
| Enabled  | True
| Category | Assertion
| Code     | [ClassicModelAssertUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.9.2/src/nunit.analyzers/ClassicModelAssertUsage/ClassicModelAssertUsageAnalyzer.cs)

## Description

Consider using the constraint model, `Assert.That(actual, Is.AssignableFrom(expected))`, instead of the classic model,
`ClassicAssert.IsAssignableFrom(expected, actual)`.

## Motivation

The assert `ClassicAssert.IsAssignableFrom` from the classic Assert model makes it easy to confuse the `expected` and the
`actual` argument, so this analyzer marks usages of `ClassicAssert.IsAssignableFrom`.

```csharp
[Test]
public void Test()
{
    ClassicAssert.IsAssignableFrom(expected, actual);
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `ClassicAssert.IsAssignableFrom(expected, actual)` with
`Assert.That(actual, Is.AssignableFrom(expected))`. So the code block above will be changed into.

```csharp
[Test]
public void Test()
{
    Assert.That(actual, Is.AssignableFrom(expected));
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2053: Consider using Assert.That(actual, Is.AssignableFrom(expected)) instead of ClassicAssert.IsAssignableFrom(expected, actual)
dotnet_diagnostic.NUnit2053.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2053 // Consider using Assert.That(actual, Is.AssignableFrom(expected)) instead of ClassicAssert.IsAssignableFrom(expected, actual)
Code violating the rule here
#pragma warning restore NUnit2053 // Consider using Assert.That(actual, Is.AssignableFrom(expected)) instead of ClassicAssert.IsAssignableFrom(expected, actual)
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2053 // Consider using Assert.That(actual, Is.AssignableFrom(expected)) instead of ClassicAssert.IsAssignableFrom(expected, actual)
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2053:Consider using Assert.That(actual, Is.AssignableFrom(expected)) instead of ClassicAssert.IsAssignableFrom(expected, actual)",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

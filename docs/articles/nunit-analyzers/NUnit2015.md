# NUnit2015

## Consider using Assert.That(actual, Is.SameAs(expected)) instead of ClassicAssert.AreSame(expected, actual)

| Topic    | Value
| :--      | :--
| Id       | NUnit2015
| Severity | Warning
| Enabled  | True
| Category | Assertion
| Code     | [ClassicModelAssertUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.4.0/src/nunit.analyzers/ClassicModelAssertUsage/ClassicModelAssertUsageAnalyzer.cs)

## Description

Consider using the constraint model, `Assert.That(actual, Is.SameAs(expected))`, instead of the classic model,
`ClassicAssert.AreSame(expected, actual)`.

## Motivation

The assert `ClassicAssert.AreSame` from the classic Assert model makes it easy to confuse the `expected` and the
`actual` argument, so this analyzer marks usages of `ClassicAssert.AreSame`.

```csharp
[Test]
public void Test()
{
    ClassicAssert.AreSame(expected, actual);
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `ClassicAssert.AreSame(expected, actual)` with
`Assert.That(actual, Is.SameAs(expected))`. So the code block above will be changed into.

```csharp
[Test]
public void Test()
{
    Assert.That(actual, Is.SameAs(expected));
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2015: Consider using Assert.That(actual, Is.SameAs(expected)) instead of ClassicAssert.AreSame(expected, actual)
dotnet_diagnostic.NUnit2015.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2015 // Consider using Assert.That(actual, Is.SameAs(expected)) instead of ClassicAssert.AreSame(expected, actual)
Code violating the rule here
#pragma warning restore NUnit2015 // Consider using Assert.That(actual, Is.SameAs(expected)) instead of ClassicAssert.AreSame(expected, actual)
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2015 // Consider using Assert.That(actual, Is.SameAs(expected)) instead of ClassicAssert.AreSame(expected, actual)
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2015:Consider using Assert.That(actual, Is.SameAs(expected)) instead of ClassicAssert.AreSame(expected, actual)",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

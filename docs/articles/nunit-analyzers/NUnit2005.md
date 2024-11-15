# NUnit2005

## Consider using Assert.That(actual, Is.EqualTo(expected)) instead of ClassicAssert.AreEqual(expected, actual)

| Topic    | Value
| :--      | :--
| Id       | NUnit2005
| Severity | Warning
| Enabled  | True
| Category | Assertion
| Code     | [ClassicModelAssertUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.4.0/src/nunit.analyzers/ClassicModelAssertUsage/ClassicModelAssertUsageAnalyzer.cs)

## Description

Consider using the constraint model, `Assert.That(actual, Is.EqualTo(expected))`, instead of the classic model,
`ClassicAssert.AreEqual(expected, actual)`.

## Motivation

The classic Assert model, `ClassicAssert.AreEqual(expected, actual)`, makes it easy to mix the `expected` and the
`actual` parameter, so this analyzer marks usages of `ClassicAssert.AreEqual` from the classic Assert model.

```csharp
[Test]
public void Test()
{
    ClassicAssert.AreEqual(expression1, expression2);
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `ClassicAssert.AreEqual(expression1, expression2)` with
`Assert.That(expression2, Is.EqualTo(expression1))`. So the code block above will be changed into.

```csharp
[Test]
public void Test()
{
    Assert.That(expression2, Is.EqualTo(expression1));
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2005: Consider using Assert.That(actual, Is.EqualTo(expected)) instead of ClassicAssert.AreEqual(expected, actual)
dotnet_diagnostic.NUnit2005.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2005 // Consider using Assert.That(actual, Is.EqualTo(expected)) instead of ClassicAssert.AreEqual(expected, actual)
Code violating the rule here
#pragma warning restore NUnit2005 // Consider using Assert.That(actual, Is.EqualTo(expected)) instead of ClassicAssert.AreEqual(expected, actual)
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2005 // Consider using Assert.That(actual, Is.EqualTo(expected)) instead of ClassicAssert.AreEqual(expected, actual)
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2005:Consider using Assert.That(actual, Is.EqualTo(expected)) instead of ClassicAssert.AreEqual(expected, actual)",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

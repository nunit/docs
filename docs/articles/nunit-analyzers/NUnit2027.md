# NUnit2027

## Consider using Assert.That(actual, Is.GreaterThan(expected)) instead of ClassicAssert.Greater(actual, expected)

| Topic    | Value
| :--      | :--
| Id       | NUnit2027
| Severity | Info
| Enabled  | True
| Category | Assertion
| Code     | [ClassicModelAssertUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.1.0/src/nunit.analyzers/ClassicModelAssertUsage/ClassicModelAssertUsageAnalyzer.cs)

## Description

Consider using the constraint model, `Assert.That(actual, Is.GreaterThan(expected))`, instead of the classic model,
`ClassicAssert.Greater(actual, expected)`.

## Motivation

The assert `ClassicAssert.Greater` from the classic Assert model makes it easy to confuse the `expected` and the `actual`
argument, so this analyzer marks usages of `ClassicAssert.Greater`.

```csharp
[Test]
public void Test()
{
    ClassicAssert.Greater(actual, expected);
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `ClassicAssert.Greater(actual, expected)` with
`Assert.That(actual, Is.GreaterThan(expected))`. So the code block above will be changed into.

```csharp
[Test]
public void Test()
{
    Assert.That(actual, Is.GreaterThan(expected));
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2027: Consider using Assert.That(actual, Is.GreaterThan(expected)) instead of ClassicAssert.Greater(actual, expected)
dotnet_diagnostic.NUnit2027.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2027 // Consider using Assert.That(actual, Is.GreaterThan(expected)) instead of ClassicAssert.Greater(actual, expected)
Code violating the rule here
#pragma warning restore NUnit2027 // Consider using Assert.That(actual, Is.GreaterThan(expected)) instead of ClassicAssert.Greater(actual, expected)
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2027 // Consider using Assert.That(actual, Is.GreaterThan(expected)) instead of ClassicAssert.Greater(actual, expected)
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2027:Consider using Assert.That(actual, Is.GreaterThan(expected)) instead of ClassicAssert.Greater(actual, expected)",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

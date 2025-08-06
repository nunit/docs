# NUnit2030

## Consider using Assert.That(actual, Is.LessThanOrEqualTo(expected)) instead of ClassicAssert.LessOrEqual(actual, expected)

| Topic    | Value
| :--      | :--
| Id       | NUnit2030
| Severity | Info
| Enabled  | True
| Category | Assertion
| Code     | [ClassicModelAssertUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.9.2/src/nunit.analyzers/ClassicModelAssertUsage/ClassicModelAssertUsageAnalyzer.cs)

## Description

Consider using the constraint model, `Assert.That(actual, Is.LessThanOrEqualTo(expected))`, instead of the classic
model, `ClassicAssert.LessOrEqual(actual, expected)`.

## Motivation

The assert `ClassicAssert.LessOrEqual` from the classic Assert model makes it easy to confuse the `expected` and the
`actual` argument, so this analyzer marks usages of `ClassicAssert.LessOrEqual`.

```csharp
[Test]
public void Test()
{
    ClassicAssert.LessOrEqual(actual, expected);
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `ClassicAssert.LessOrEqual(actual, expected)` with
`Assert.That(actual, Is.LessThanOrEqualTo(expected))`. So the code block above will be changed into.

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
# NUnit2030: Consider using Assert.That(actual, Is.LessThanOrEqualTo(expected)) instead of ClassicAssert.LessOrEqual(actual, expected)
dotnet_diagnostic.NUnit2030.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2030 // Consider using Assert.That(actual, Is.LessThanOrEqualTo(expected)) instead of ClassicAssert.LessOrEqual(actual, expected)
Code violating the rule here
#pragma warning restore NUnit2030 // Consider using Assert.That(actual, Is.LessThanOrEqualTo(expected)) instead of ClassicAssert.LessOrEqual(actual, expected)
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2030 // Consider using Assert.That(actual, Is.LessThanOrEqualTo(expected)) instead of ClassicAssert.LessOrEqual(actual, expected)
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2030:Consider using Assert.That(actual, Is.LessThanOrEqualTo(expected)) instead of ClassicAssert.LessOrEqual(actual, expected)",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

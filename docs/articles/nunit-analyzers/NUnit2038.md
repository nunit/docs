# NUnit2038

## Consider using Assert.That(actual, Is.InstanceOf(expected)) instead of ClassicAssert.IsInstanceOf(expected, actual)

| Topic    | Value
| :--      | :--
| Id       | NUnit2038
| Severity | Info
| Enabled  | True
| Category | Assertion
| Code     | [ClassicModelAssertUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.4.0/src/nunit.analyzers/ClassicModelAssertUsage/ClassicModelAssertUsageAnalyzer.cs)

## Description

Consider using the constraint model, `Assert.That(actual, Is.InstanceOf(expected))`, instead of the classic model,
`ClassicAssert.IsInstanceOf(expected, actual)`.

## Motivation

The assert `ClassicAssert.IsInstanceOf` from the classic Assert model makes it easy to confuse the `expected` and the
`actual` argument, so this analyzer marks usages of `ClassicAssert.IsInstanceOf`.

```csharp
[Test]
public void Test()
{
    ClassicAssert.IsInstanceOf(expected, actual);
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `ClassicAssert.IsInstanceOf(expected, actual)` with
`Assert.That(actual, Is.InstanceOf(expected))`. So the code block above will be changed into.

```csharp
[Test]
public void Test()
{
    Assert.That(actual, Is.InstanceOf(expected));
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2038: Consider using Assert.That(actual, Is.InstanceOf(expected)) instead of ClassicAssert.IsInstanceOf(expected, actual)
dotnet_diagnostic.NUnit2038.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2038 // Consider using Assert.That(actual, Is.InstanceOf(expected)) instead of ClassicAssert.IsInstanceOf(expected, actual)
Code violating the rule here
#pragma warning restore NUnit2038 // Consider using Assert.That(actual, Is.InstanceOf(expected)) instead of ClassicAssert.IsInstanceOf(expected, actual)
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2038 // Consider using Assert.That(actual, Is.InstanceOf(expected)) instead of ClassicAssert.IsInstanceOf(expected, actual)
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2038:Consider using Assert.That(actual, Is.InstanceOf(expected)) instead of ClassicAssert.IsInstanceOf(expected, actual)",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

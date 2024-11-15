# NUnit2048

## Consider using Assert.That(...) instead of StringAssert(...)

| Topic    | Value
| :--      | :--
| Id       | NUnit2048
| Severity | Warning
| Enabled  | True
| Category | Assertion
| Code     | [StringAssertUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.4.0/src/nunit.analyzers/StringAssertUsage/StringAssertUsageAnalyzer.cs)

## Description

Consider using the constraint model, `Assert.That(actual, {0}(expected))`, instead of the classic model,
`StringAssert.{1}(expected, actual)`.

## Motivation

The classic Assert model contains less flexibility than the constraint model and makes it easy to mix the `expected` and
the `actual` parameter, so this analyzer marks usages of all `StringAssert` methods from the classic Assert model.

```csharp
[Test]
public void Test()
{
    StringAssert.Contains(expected, actual);
    StringAssert.DoesNotContain(expected, actual);
    StringAssert.StartsWith(expected, actual);
    StringAssert.DoesNotStartWith(expected, actual);
    StringAssert.EndsWith(expected, actual);
    StringAssert.DoesNotEndWith(expected, actual);
    StringAssert.AreEqualIgnoreCase(expected, actual);
    StringAssert.AreNotEqualIgnoreCase(expected, actual);
    StringAssert.IsMatch(expected, actual);
    StringAssert.DoesNotMatch(expected, actual);
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `StringAssert.<method>(expected, actual)` with
`Assert.That(actual, <constraint>(expected))`. So the code block above will be changed into.

```csharp
[Test]
public void Test()
{
    Assert.That(actual, Does.Contain(expected));
    Assert.That(actual, Does.Not.Contain(expected));
    Assert.That(actual, Does.StartWith(expected));
    Assert.That(actual, Does.Not.StartWith(expected));
    Assert.That(actual, Does.EndWith(expected));
    Assert.That(actual, Does.Not.EndWith(expected));
    Assert.That(actual, Is.EqualTo(expected).IgnoreCase);
    Assert.That(actual, Is.Not.EqualTo(expected).IgnoreCase);
    Assert.That(actual, Does.Match(expected));
    Assert.That(actual, Does.Not.Match(expected));
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2048: Consider using Assert.That(...) instead of StringAssert(...)
dotnet_diagnostic.NUnit2048.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2048 // Consider using Assert.That(...) instead of StringAssert(...)
Code violating the rule here
#pragma warning restore NUnit2048 // Consider using Assert.That(...) instead of StringAssert(...)
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2048 // Consider using Assert.That(...) instead of StringAssert(...)
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2048:Consider using Assert.That(...) instead of StringAssert(...)",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

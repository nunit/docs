# NUnit2014

## Use SomeItemsConstraint for better assertion messages in case of failure

| Topic    | Value
| :--      | :--
| Id       | NUnit2014
| Severity | Info
| Enabled  | True
| Category | Assertion
| Code     | [SomeItemsConstraintUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.4.0/src/nunit.analyzers/ConstraintUsage/SomeItemsConstraintUsageAnalyzer.cs)

## Description

Using SomeItemsConstraint will lead to better assertion messages in case of failure.

## Motivation

Using `Does.Contain` (or `Does.Not.Contain`) constraint will lead to better assertion messages in case of failure,
so this analyzer marks all usages of string `Contains` method where it is possible to replace
with `Does.Contain` constraint.

```csharp
[Test]
public void Test()
{
    var actual = new List<int> {1,2,3};
    int expected = 1;
    ClassicAssert.True(actual.Contains(expected));
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `ClassicAssert.True(actual.Contains(expected))` with
`Assert.That(actual, Does.Contain(expected))`. So the code block above will be changed into

```csharp
[Test]
public void Test()
{
    var actual = new List<int> {1,2,3};
    int expected = 1;
    Assert.That(actual, Does.Contain(expected));
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2014: Use SomeItemsConstraint for better assertion messages in case of failure
dotnet_diagnostic.NUnit2014.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2014 // Use SomeItemsConstraint for better assertion messages in case of failure
Code violating the rule here
#pragma warning restore NUnit2014 // Use SomeItemsConstraint for better assertion messages in case of failure
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2014 // Use SomeItemsConstraint for better assertion messages in case of failure
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2014:Use SomeItemsConstraint for better assertion messages in case of failure",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

# NUnit2045

## Use Assert.EnterMultipleScope or Assert.Multiple

| Topic    | Value
| :--      | :--
| Id       | NUnit2045
| Severity | Info
| Enabled  | True
| Category | Assertion
| Code     | [UseAssertMultipleAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.9.2/src/nunit.analyzers/UseAssertMultiple/UseAssertMultipleAnalyzer.cs)

## Description

Hosting Asserts inside an Assert.EnterMultipleScope or Assert.Multiple allows detecting more than one failure.

## Motivation

When independent `Assert` statements are called from an `Assert.EnterMultipleScope` or `Assert.Multiple` they all
will run. This allows detecting more than one failure in a single test run. Note that `Assert.EnterMultipleScope` is
the preferred method, but this functionality was released in NUnit 4.2. On older NUnit versions one can use
`Assert.Multiple`.

Without the `Assert.EnterMultipleScope` the below code will stop executing after the first failure and the second
violation won't be detected until the next run when the first one has been corrected.

```csharp
Assert.That(instance.Property1, Is.EqualTo(expectedProperty1Value));
Assert.That(instance.Property2, Is.EqualTo(expectedProperty2Value));
```

## How to fix violations

Add an `Assert.EnterMultipleScope` using block surrounding the `Assert` statements.

```csharp
using (Assert.EnterMultipleScope())
{
    Assert.That(instance.Property1, Is.EqualTo(expectedProperty1Value));
    Assert.That(instance.Property2, Is.EqualTo(expectedProperty2Value));
};
```

Using `Assert.Multiple` then the fix would look like this - where all the independent `Assert` statements are called from
inside the lambda parameter.

```csharp
Assert.Multiple(() =>
{
    Assert.That(instance.Property1, Is.EqualTo(expectedProperty1Value));
    Assert.That(instance.Property2, Is.EqualTo(expectedProperty2Value));
});
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2045: Use Assert.EnterMultipleScope or Assert.Multiple
dotnet_diagnostic.NUnit2045.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2045 // Use Assert.EnterMultipleScope or Assert.Multiple
Code violating the rule here
#pragma warning restore NUnit2045 // Use Assert.EnterMultipleScope or Assert.Multiple
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2045 // Use Assert.EnterMultipleScope or Assert.Multiple
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2045:Use Assert.EnterMultipleScope or Assert.Multiple",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

# NUnit2045

## Use Assert.Multiple

| Topic    | Value
| :--      | :--
| Id       | NUnit2045
| Severity | Info
| Enabled  | True
| Category | Assertion
| Code     | [UseAssertMultipleAnalyzer](https://github.com/nunit/nunit.analyzers/blob/3.6.0/src/nunit.analyzers/UseAssertMultiple/UseAssertMultipleAnalyzer.cs)

## Description

Hosting Asserts inside an Assert.Multiple allows detecting more than one failure.

## Motivation

When independent `Assert` statements are called from an `Assert.Multiple` they all will run.
This allows detecting more than one failure in a single test run.

Without the `Assert.Multiple` the below code will stop executing after the first failure and the second
violation won't be detected until the next run when the first one has been finished.

```csharp
Assert.That(instance.Property1, Is.EqualTo(expectedProperty1Value));
Assert.That(instance.Property2, Is.EqualTo(expectedProperty2Value));
```

## How to fix violations

Add an `Assert.Multiple` and call all independent `Assert` statements from the lambda parameter.

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

Configure the severity per project, for more info see [MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2045: Use Assert.Multiple
dotnet_diagnostic.NUnit2045.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2045 // Use Assert.Multiple
Code violating the rule here
#pragma warning restore NUnit2045 // Use Assert.Multiple
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2045 // Use Assert.Multiple
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2045:Use Assert.Multiple",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

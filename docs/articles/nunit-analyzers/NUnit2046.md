# NUnit2046

## Use CollectionConstraint for better assertion messages in case of failure

| Topic    | Value
| :--      | :--
| Id       | NUnit2046
| Severity | Info
| Enabled  | True
| Category | Assertion
| Code     | [UseCollectionConstraintAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.4.0/src/nunit.analyzers/UseCollectionConstraint/UseCollectionConstraintAnalyzer.cs)

## Description

Use Has.Length/Has.Count/Is.Empty instead of testing property directly.

## Motivation

Consider the difference in error message between the following pairs of Asserts:

```csharp
int[] array = { 1, 2 };
Assert.That(array.Length, Is.EqualTo(1));
Assert.That(array, Has.Length.EqualTo(1));
```

The first gives: `Expected: 1, But was: 2`, the second: `Expected: property Length equal to 1, But was: 2`
making it clear we talking about number of elements, not just a number.

The next example:

```csharp
int[] array = { 1, 2 };
Assert.That(array.Length, Is.EqualTo(0));
Assert.That(array, Is.Empty);
```

This results in `Expected: 0, But was: 2` in the first case and `Expected: <empty>, But was: < 1, 2 >` in the second.

```csharp
int[] array = Array.Empty<int>();
Assert.That(array.Length, Is.GreaterThanOrEqualTo(1));
Assert.That(array, Is.Not.Empty);
```

This would change: `Expected: greater than or equal to 1, But was: 0` into `Expected: not <empty>, But was: <empty>`

## How to fix violations

Replace test on explicit `.Length` or `.Count` properties with `Has.Length` and `Has.Count` respectively.
If testing against the value 0 use `Is.Empty` or `Is.Not.Empty` instead.

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2046: Use CollectionConstraint for better assertion messages in case of failure
dotnet_diagnostic.NUnit2046.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2046 // Use CollectionConstraint for better assertion messages in case of failure
Code violating the rule here
#pragma warning restore NUnit2046 // Use CollectionConstraint for better assertion messages in case of failure
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2046 // Use CollectionConstraint for better assertion messages in case of failure
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2046:Use CollectionConstraint for better assertion messages in case of failure",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

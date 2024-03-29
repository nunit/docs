# NUnit2040

## Non-reference types for SameAs constraint

| Topic    | Value
| :--      | :--
| Id       | NUnit2040
| Severity | Error
| Enabled  | True
| Category | Assertion
| Code     | [SameAsOnValueTypesAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.1.0/src/nunit.analyzers/SameAsOnValueTypes/SameAsOnValueTypesAnalyzer.cs)

## Description

The SameAs constraint always fails on value types as the actual and the expected value cannot be the same reference.

## Motivation

```csharp
var expected = Guid.Empty;
var actual = expected;

Assert.That(actual, Is.SameAs(expected));
```

As `Guid` is a `struct`, actual will be a copy of expected but not have the same reference.

## How to fix violations

Replace `Is.SameAs` with `Is.EqualTo`.

```csharp
var expected = Guid.Empty;
var actual = expected;

Assert.That(actual, Is.EqualTo(expected));
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2040: Non-reference types for SameAs constraint
dotnet_diagnostic.NUnit2040.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2040 // Non-reference types for SameAs constraint
Code violating the rule here
#pragma warning restore NUnit2040 // Non-reference types for SameAs constraint
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2040 // Non-reference types for SameAs constraint
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2040:Non-reference types for SameAs constraint",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

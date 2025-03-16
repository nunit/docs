# NUnit2025

## Wrong actual type used with ContainsConstraint

| Topic    | Value
| :--      | :--
| Id       | NUnit2025
| Severity | Hidden
| Enabled  | False
| Category | Assertion
| Code     | [ContainsConstraintWrongActualTypeAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.4.0/src/nunit.analyzers/ContainsConstraintWrongActualType/ContainsConstraintWrongActualTypeAnalyzer.cs)

## Description

The ContainsConstraint requires the type of the actual value to be either a string or a collection of strings.

## Motivation

Using a ContainsConstraint with an actual argument, which is neither a string nor a collection of strings, leads to an
assertion error.

## How to fix violations

Fix the actual value or use appropriate constraint.

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2025: Wrong actual type used with ContainsConstraint
dotnet_diagnostic.NUnit2025.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2025 // Wrong actual type used with ContainsConstraint
Code violating the rule here
#pragma warning restore NUnit2025 // Wrong actual type used with ContainsConstraint
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2025 // Wrong actual type used with ContainsConstraint
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2025:Wrong actual type used with ContainsConstraint",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

# NUnit2023

## Invalid NullConstraint usage

| Topic    | Value
| :--      | :--
| Id       | NUnit2023
| Severity | Error
| Enabled  | True
| Category | Assertion
| Code     | [NullConstraintUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.9.2/src/nunit.analyzers/NullConstraintUsage/NullConstraintUsageAnalyzer.cs)

## Description

NullConstraint is allowed only for reference types or nullable value types.

## Motivation

Non-nullable value types cannot have `null` value, therefore `Is.Null` assertions will always fail (or will always pass
for `Is.Not.Null`).

## How to fix violations

Use suitable constraint.

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2023: Invalid NullConstraint usage
dotnet_diagnostic.NUnit2023.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2023 // Invalid NullConstraint usage
Code violating the rule here
#pragma warning restore NUnit2023 // Invalid NullConstraint usage
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2023 // Invalid NullConstraint usage
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2023:Invalid NullConstraint usage",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

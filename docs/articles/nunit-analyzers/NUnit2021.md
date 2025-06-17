# NUnit2021

## Incompatible types for EqualTo constraint

| Topic    | Value
| :--      | :--
| Id       | NUnit2021
| Severity | Error
| Enabled  | True
| Category | Assertion
| Code     | [EqualToIncompatibleTypesAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.9.2/src/nunit.analyzers/EqualToIncompatibleTypes/EqualToIncompatibleTypesAnalyzer.cs)

## Description

The EqualTo constraint always fails as the actual and the expected value cannot be equal.

## Motivation

```csharp
class Foo { }
class Bar { }

var foo = new Foo();
var bar = new Bar();

Assert.That(foo, Is.EqualTo(bar));
```

There is no way that instances of types `Foo` and `Bar` could be considered equal, therefore such assertion will always
fail.

## How to fix violations

Fix your assertion (i.e. fix actual or expected value, or choose another constraint).

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2021: Incompatible types for EqualTo constraint
dotnet_diagnostic.NUnit2021.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2021 // Incompatible types for EqualTo constraint
Code violating the rule here
#pragma warning restore NUnit2021 // Incompatible types for EqualTo constraint
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2021 // Incompatible types for EqualTo constraint
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2021:Incompatible types for EqualTo constraint",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

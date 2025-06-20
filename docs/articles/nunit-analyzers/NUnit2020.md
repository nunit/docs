# NUnit2020

## Incompatible types for SameAs constraint

| Topic    | Value
| :--      | :--
| Id       | NUnit2020
| Severity | Error
| Enabled  | True
| Category | Assertion
| Code     | [SameAsIncompatibleTypesAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.9.2/src/nunit.analyzers/SameAsIncompatibleTypes/SameAsIncompatibleTypesAnalyzer.cs)

## Description

The SameAs constraint always fails because the actual and expected values have mutually exclusive types.

## Motivation

```csharp
class Foo { }
class Bar { }

var foo = new Foo();
var bar = new Bar();

Assert.That(foo, Is.SameAs(bar));
```

There is no way that the same instance can be of type Foo and type Bar, therefore such assertion will always fail.

## How to fix violations

Fix your assertion (i.e. fix actual or expected value, or choose another constraint)

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2020: Incompatible types for SameAs constraint
dotnet_diagnostic.NUnit2020.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2020 // Incompatible types for SameAs constraint
Code violating the rule here
#pragma warning restore NUnit2020 // Incompatible types for SameAs constraint
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2020 // Incompatible types for SameAs constraint
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2020:Incompatible types for SameAs constraint",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

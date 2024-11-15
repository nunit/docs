# NUnit2041

## Incompatible types for comparison constraint

| Topic    | Value
| :--      | :--
| Id       | NUnit2041
| Severity | Error
| Enabled  | True
| Category | Assertion
| Code     | [ComparableTypesAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.4.0/src/nunit.analyzers/ComparableTypes/ComparableTypesAnalyzer.cs)

## Description

The comparison constraint always fails as the actual and the expected value are not comparable.

## Motivation

```csharp
class Foo { }
class Bar { }

var foo = new Foo();
var bar = new Bar();

Assert.That(foo, Is.GreaterThan(bar));
```

There is no comparisons defined between instances of types `Foo` and `Bar`, therefore such assertion will always fail.

## How to fix violations

Fix your assertion (i.e. fix actual or expected value) or implement `IComparable<Bar>` on `Foo`.

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2041: Incompatible types for comparison constraint
dotnet_diagnostic.NUnit2041.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2041 // Incompatible types for comparison constraint
Code violating the rule here
#pragma warning restore NUnit2041 // Incompatible types for comparison constraint
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2041 // Incompatible types for comparison constraint
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2041:Incompatible types for comparison constraint",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

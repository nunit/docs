# NUnit1032

## An IDisposable field/property should be Disposed in a TearDown method

| Topic    | Value
| :--      | :--
| Id       | NUnit1032
| Severity | Error
| Enabled  | True
| Category | Structure
| Code     | [DisposeFieldsAndPropertiesInTearDownAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.1.0/src/nunit.analyzers/DisposeFieldsAndPropertiesInTearDown/DisposeFieldsAndPropertiesInTearDownAnalyzer.cs)

## Description

An IDisposable field/property should be Disposed in a TearDown method.

## Motivation

Not Disposing fields/properties can cause memory leaks or failing tests.

## How to fix violations

Dispose any fields/properties that are initialized in `SetUp` or `Test` methods in a `TearDown` method.
Fields/Properties that are initialized in `OneTimeSetUp`, or with initializers or in constructors
must be disposed in `OneTimeTearDown`.

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit1032: An IDisposable field/property should be Disposed in a TearDown method
dotnet_diagnostic.NUnit1032.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
Code violating the rule here
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Structure",
    "NUnit1032:An IDisposable field/property should be Disposed in a TearDown method",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

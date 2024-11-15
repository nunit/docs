# NUnit1032

## An IDisposable field/property should be Disposed in a TearDown method

| Topic    | Value
| :--      | :--
| Id       | NUnit1032
| Severity | Error
| Enabled  | True
| Category | Structure
| Code     | [DisposeFieldsAndPropertiesInTearDownAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.4.0/src/nunit.analyzers/DisposeFieldsAndPropertiesInTearDown/DisposeFieldsAndPropertiesInTearDownAnalyzer.cs)

## Description

An IDisposable field/property should be Disposed in a TearDown method.

This analyzer rule only applies to a `TestFixture` which is using the default
NUnit `SingleInstance` life cycle where the class is instantiated once for all tests.

If you are using `LifeCycle.InstancePerTestCase` you should dispose the fields/properties
in the `Dispose` method of the test class.

## Motivation

Not Disposing fields/properties can cause memory leaks or failing tests.

## How to fix violations

### LifeCycle.SingleInstance

Dispose any fields/properties that are initialized in `SetUp` or `Test` methods in a `TearDown` method.
Fields/Properties that are initialized in `OneTimeSetUp`, or with initializers or in constructors
must be disposed in `OneTimeTearDown`.

### LifeCycle.InstancePerTestCase

If you have `IDisposable` fields or properties, your class must implement the
[`IDisposable`](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable?view=net-8.0) interface.

Dispose any fields/properties that are initialized at declaration or in the constructor in the
[`Dispose`](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable.dispose?view=net-8.0) method.

The NUnit.Analyzer will not help you here as the functionality is available in
[Microsoft .NET Analyzers](https://www.nuget.org/packages/Microsoft.CodeAnalysis.NetAnalyzers).
These are the rules that will help you with this:

* [CA1001](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1001)
Types that own disposable fields should be disposable
* [CA2213](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca2213)
Disposable fields should be disposed

Unfortunately, those rules are not enabled by default, you can enable them in your project in a
[`.editorconfig`](https://learn.microsoft.com/en-us/visualstudio/code-quality/use-roslyn-analyzers?view=vs-2022#manually-configure-rule-severity-in-an-editorconfig-file)
 file using the following content:

```xml
# CA1001: Types that own disposable fields should be disposable
dotnet_diagnostic.CA1001.severity = warning
# CA2213: Disposable fields should be disposed
dotnet_diagnostic.CA2213.severity = warning
```

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

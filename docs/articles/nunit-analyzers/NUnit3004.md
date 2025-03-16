# NUnit3004

## Field should be Disposed in TearDown or OneTimeTearDown method

| Topic    | Value
| :--      | :--
| Id       | NUnit3004
| Severity | Info
| Enabled  | True
| Category | Suppressor
| Code     | [TypesThatOwnDisposableFieldsShouldBeDisposableSuppressor](https://github.com/nunit/nunit.analyzers/blob/4.4.0/src/nunit.analyzers/DiagnosticSuppressors/TypesThatOwnDisposableFieldsShouldBeDisposableSuppressor.cs)

## Description

Field/Property is Disposed in TearDown or OneTimeTearDown method

## Motivation

The Roslyn analyzer fires
[CA1001](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1001)
for classes that have
[`IDisposable`](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) members, but itself is not
`IDisposable`.

Many NUnit tests initialize fields in tests or a `SetUp` method and then `Dispose` them in the `TearDown` method.

## How to fix violations

Ensure that all `IDisposable` fields have a `Dispose` call in the `TearDown` method.

<!-- start generated config severity -->
## Configure severity

The rule has no severity, but can be disabled.

### Via ruleset file

To disable the rule for a project, you need to add a
[ruleset file](https://github.com/nunit/nunit.analyzers/blob/4.4.0/src/nunit.analyzers/DiagnosticSuppressors/NUnit.Analyzers.Suppressions.ruleset)

```xml
<?xml version="1.0" encoding="utf-8"?>
<RuleSet Name="NUnit.Analyzer Suppressions" Description="DiagnosticSuppression Rules" ToolsVersion="12.0">
  <Rules AnalyzerId="DiagnosticSuppressors" RuleNamespace="NUnit.NUnitAnalyzers">
    <Rule Id="NUnit3001" Action="Info" /> <!-- Possible Null Reference -->
    <Rule Id="NUnit3002" Action="Info" /> <!-- NonNullableField/Property is Uninitialized -->
    <Rule Id="NUnit3003" Action="Info" /> <!-- Avoid Uninstantiated Internal Classes -->
    <Rule Id="NUnit3004" Action="Info" /> <!-- Types that own disposable fields should be disposable -->
  </Rules>
</RuleSet>
```

and add it to the project like:

```xml
<PropertyGroup>
  <CodeAnalysisRuleSet>NUnit.Analyzers.Suppressions.ruleset</CodeAnalysisRuleSet>
</PropertyGroup>
```

For more info about rulesets see [MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

This is currently not working. Waiting for [Roslyn](https://github.com/dotnet/roslyn/issues/49727)

```ini
# NUnit3004: Field should be Disposed in TearDown or OneTimeTearDown method
dotnet_diagnostic.NUnit3004.severity = none
```
<!-- end generated config severity -->

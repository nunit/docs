# NUnit3003

## Class is an NUnit TestFixture and is instantiated using reflection

| Topic    | Value
| :--      | :--
| Id       | NUnit3003
| Severity | Info
| Enabled  | True
| Category | Suppressor
| Code     | [AvoidUninstantiatedInternalClassSuppressor](https://github.com/nunit/nunit.analyzers/blob/3.8.0/src/nunit.analyzers/DiagnosticSuppressors/AvoidUninstantiatedInternalClassSuppressor.cs)

## Description

Class is a NUnit TestFixture and called by reflection

## Motivation

The default roslyn analyzer has rule [CA1812](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1812)
which warns about internal classes not being used.
That analyzer doesn't know about NUnit test classes.
This suppressor catches the error, verifies the class is an NUnit TestFixture and if so suppresses the error.

<!-- start generated config severity -->
## Configure severity

The rule has no severity, but can be disabled.

### Via ruleset file

To disable the rule for a project, you need to add a
[ruleset file](https://github.com/nunit/nunit.analyzers/blob/3.8.0/src/nunit.analyzers/DiagnosticSuppressors/NUnit.Analyzers.Suppressions.ruleset)

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
# NUnit3003: Class is an NUnit TestFixture and is instantiated using reflection
dotnet_diagnostic.NUnit3003.severity = none
```
<!-- end generated config severity -->

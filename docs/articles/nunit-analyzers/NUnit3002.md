# NUnit3002

## Field/Property is initialized in SetUp or OneTimeSetUp method

| Topic    | Value
| :--      | :--
| Id       | NUnit3002
| Severity | Info
| Enabled  | True
| Category | Suppressor
| Code     | [NonNullableFieldOrPropertyIsUninitializedSuppressor](https://github.com/nunit/nunit.analyzers/blob/3.6.0/src/nunit.analyzers/DiagnosticSuppressors/NonNullableFieldOrPropertyIsUninitializedSuppressor.cs)

## Description

This rule check diagnostics reported by the CS8618 compiler error:

`CS8618: Non-nullable field '_name_' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.`
`CS8618: Non-nullable property '_Name_' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.`

If the violating field/property is set in the `SetUp` or `OneTimeSetUp` method. The rule suppresses the error.
This allows for non-nullable fields/properties to be used in a `TestFixture`.

The rule does detect indirect calls, when the field is set in a method called by the `SetUp` or `OneTimeSetUp` methods.

## Motivation

```csharp
[TestFixture]
internal sealed class SomeClassFixture
{
    private SomeClass instance;

    [SetUp]
    public void Setup()
    {
        instance = new SomeClass();
    }

    [Test]
    public void Test()
    {
        Assert.That(instance.MethodUnderTest(), Is.True)
    }
}
```

In the above fixture the compiler would give a warning because `instance` is not set in the constructor.
The suggestion to mark `instance` as nullable would mean that we have to test for null in all `Test` methods
or use the null suppression operator (`!`) everywhere.

## How to fix violations

Initialize the field in the `SetUp` or `OneTimeSetUp` methods.

<!-- start generated config severity -->
## Configure severity

The rule has no severity, but can be disabled.

### Via ruleset file

To disable the rule for a project, you need to add a
[ruleset file](https://github.com/nunit/nunit.analyzers/blob/3.6.0/src/nunit.analyzers/DiagnosticSuppressors/NUnit.Analyzers.Suppressions.ruleset)

```xml
<?xml version="1.0" encoding="utf-8"?>
<RuleSet Name="NUnit.Analyzer Suppressions" Description="DiagnosticSuppression Rules" ToolsVersion="12.0">
  <Rules AnalyzerId="DiagnosticSuppressors" RuleNamespace="NUnit.NUnitAnalyzers">
    <Rule Id="NUnit3001" Action="Info" /> <!-- Possible Null Reference -->
    <Rule Id="NUnit3002" Action="Info" /> <!-- NonNullableField/Property is Uninitialized -->
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
# NUnit3002: Field/Property is initialized in SetUp or OneTimeSetUp method
dotnet_diagnostic.NUnit3002.severity = none
```
<!-- end generated config severity -->

# NUnit3001

## Expression was checked in an Assert.NotNull, Assert.IsNotNull or Assert.That call

| Topic    | Value
| :--      | :--
| Id       | NUnit3001
| Severity | Info
| Enabled  | True
| Category | Suppressor
| Code     | [DereferencePossiblyNullReferenceSuppressor](https://github.com/nunit/nunit.analyzers/blob/3.6.0/src/nunit.analyzers/DiagnosticSuppressors/DereferencePossiblyNullReferenceSuppressor.cs)

## Description

This rule check diagnostics reported by the CS8601-CS8607 and CS8629 compiler errors:

`CS8602: Dereference of a possibly null reference.`

It then checks the previous statements for one of:

* `Assert.NotNull(...)`
* `Assert.IsNotNull(...)`
* `Assert.That(..., Is.Not.Null)`

For the same expression as the one that raised the original compiler error.
If found, the compiler error is suppressed.

The rule also covers `CS8629: Nullable value type may be null`

In this case, the previous statement is allowed to be one of:

* `Assert.That(...HasValue)`
* `Assert.That(...HasValue, Is.True)`
* `Assert.True(...HasValue)`
* `Assert.IsTrue(...HasValue)`

The exception is that if the statement is part of an `Assert.Multiple`
it is not suppressed, as in this case the statement containing the compiler error will be executed.

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
        string? result = instance.MethodUnderTest();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Length, Is.GreaterThan(0));
    }

    [Test]
    public void TestMultiple()
    {
        string? result = instance.MethodUnderTest();
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Length, Is.GreaterThan(0));
        });
    }
}
```

In the above fixture the compiler would give a warnings because `result` can be `null` and the compiler knows nothing
about the `Assert.That(result, Is.Not.Null);` statement.

The first occurrence - in the `Test` method - will be suppressed, the second - in the `TestMultiple` - will not.

## How to fix violations

Ensure that the reference is not `null` before dereferencing it.
This can be done using regular C# language constructs or NUnit assertions.

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
# NUnit3001: Expression was checked in an Assert.NotNull, Assert.IsNotNull or Assert.That call
dotnet_diagnostic.NUnit3001.severity = none
```
<!-- end generated config severity -->

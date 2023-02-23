# NUnit1030

## The type of parameter provided by the TestCaseSource does not match the type of the parameter in the Test method

| Topic    | Value
| :--      | :--
| Id       | NUnit1030
| Severity | Error
| Enabled  | True
| Category | Structure
| Code     | [TestCaseSourceUsesStringAnalyzer](https://github.com/nunit/nunit.analyzers/blob/3.6.0/src/nunit.analyzers/TestCaseSourceUsage/TestCaseSourceUsesStringAnalyzer.cs)

## Description

The type of parameters provided by the TestCaseSource must match the type of parameters in the Test method.

Note that the current implementation only works for single parameters.

## Motivation

A `TestCaseSourceAttribute` is used to pass parameters to a test method, but the test method expects a different type of parameter.

```charp
private static readonly IEnumerable<string> NUnitNameSpaces = new[] { ".NUnit", ".NUnitExtensions" };

[TestCaseSource(nameof(NUnitNameSpaces))]
public void IsNUnit(int n)
{
}
```

## How to fix violations

Match the type of parameters between the test data and the test method.


<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see [MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit1030: The type of parameter provided by the TestCaseSource does not match the type of the parameter in the Test method
dotnet_diagnostic.NUnit1030.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit1030 // The type of parameter provided by the TestCaseSource does not match the type of the parameter in the Test method
Code violating the rule here
#pragma warning restore NUnit1030 // The type of parameter provided by the TestCaseSource does not match the type of the parameter in the Test method
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit1030 // The type of parameter provided by the TestCaseSource does not match the type of the parameter in the Test method
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Structure",
    "NUnit1030:The type of parameter provided by the TestCaseSource does not match the type of the parameter in the Test method",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

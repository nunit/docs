# NUnit1029

## The number of parameters provided by the TestCaseSource does not match the number of parameters in the Test method

| Topic    | Value
| :--      | :--
| Id       | NUnit1029
| Severity | Error
| Enabled  | True
| Category | Structure
| Code     | [TestCaseSourceUsesStringAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.4.0/src/nunit.analyzers/TestCaseSourceUsage/TestCaseSourceUsesStringAnalyzer.cs)

## Description

The number of parameters provided by the TestCaseSource must match the number of parameters in the Test method.

Note that the current implementation only works for single parameters.

## Motivation

A `TestCaseSourceAttribute` is used to pass parameters to a test method, but the test method does not expect any or more
parameters than supplied.

```charp
private static readonly IEnumerable<string> NUnitNameSpaces = new[] { ".NUnit", ".NUnitExtensions" };

[TestCaseSource(nameof(NUnitNameSpaces))]
public void IsNUnit()
{
}
```

## How to fix violations

Match the number of parameters between the test data and the test method.

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit1029: The number of parameters provided by the TestCaseSource does not match the number of parameters in the Test method
dotnet_diagnostic.NUnit1029.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit1029 // The number of parameters provided by the TestCaseSource does not match the number of parameters in the Test method
Code violating the rule here
#pragma warning restore NUnit1029 // The number of parameters provided by the TestCaseSource does not match the number of parameters in the Test method
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit1029 // The number of parameters provided by the TestCaseSource does not match the number of parameters in the Test method
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Structure",
    "NUnit1029:The number of parameters provided by the TestCaseSource does not match the number of parameters in the Test method",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

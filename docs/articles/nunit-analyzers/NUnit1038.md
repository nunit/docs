# NUnit1038

## The type of the attribute values doesn't match the parameter type

| Topic    | Value
| :--      | :--
| Id       | NUnit1038
| Severity | Error
| Enabled  | True
| Category | Structure
| Code     | [RangeUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.9.2/src/nunit.analyzers/RangeUsage/RangeUsageAnalyzer.cs)

## Description

Ensure that the attribute and parameter types match.

## Motivation

The `Range` attribute is used to specify a range of values for a parameter in a test method.
The type of the range values must match the type of the parameter.
If NUnit cannot match the types, it will throw an exception at runtime.
NUnit rules are that an `int` can be assigned to any integral type or
to a `double` or `decimal`.

```csharp
[Test]
public void TestMethod([Range(1.0, 2.0, 0.1)] int value)
{
    // Test code here
}
```

## How to fix violations

Ensure that the type of the range values matches the type of the parameter.

```csharp
[Test]
public void TestMethod([Range(1.0, 2.0, 0.1)] double value)
{
    // Test code here
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit1038: The type of the attribute values doesn't match the parameter type
dotnet_diagnostic.NUnit1038.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit1038 // The type of the attribute values doesn't match the parameter type
Code violating the rule here
#pragma warning restore NUnit1038 // The type of the attribute values doesn't match the parameter type
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit1038 // The type of the attribute values doesn't match the parameter type
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Structure",
    "NUnit1038:The type of the attribute values doesn't match the parameter type",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

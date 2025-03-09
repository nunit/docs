# NUnit1005

## The type of the value specified via ExpectedResult must match the return type of the method

| Topic    | Value
| :--      | :--
| Id       | NUnit1005
| Severity | Error
| Enabled  | True
| Category | Structure
| Code     | [TestMethodUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.4.0/src/nunit.analyzers/TestMethodUsage/TestMethodUsageAnalyzer.cs)

## Description

The type of the value specified via ExpectedResult must match the return type of the method. Otherwise, this will lead
to an error at run-time.

## Motivation

To prevent tests that will fail at runtime due to improper construction.

## How to fix violations

### Example Violation

```csharp
[TestCase(1, ExpectedResult = true)]
public int NUnit1005SampleTest(int inputValue)
{
    return inputValue;
}
```

### Explanation

The sample above uses NUnit's `ExpectedResult` syntax. It defines a result of `true` (a `bool`) but the return type of
the method is `int`.

### Fix

Either modify the TestCase parameter:

```csharp
[TestCase(1, ExpectedResult = 1)]
public int NUnit1005SampleTest(int inputValue)
{
    return inputValue;
}
```

Or modify the return type and logic of the method:

```csharp
[TestCase(1, ExpectedResult = true)]
public bool NUnit1005SampleTest(int inputValue)
{
    return inputValue > 0;
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit1005: The type of the value specified via ExpectedResult must match the return type of the method
dotnet_diagnostic.NUnit1005.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit1005 // The type of the value specified via ExpectedResult must match the return type of the method
Code violating the rule here
#pragma warning restore NUnit1005 // The type of the value specified via ExpectedResult must match the return type of the method
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit1005 // The type of the value specified via ExpectedResult must match the return type of the method
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Structure",
    "NUnit1005:The type of the value specified via ExpectedResult must match the return type of the method",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

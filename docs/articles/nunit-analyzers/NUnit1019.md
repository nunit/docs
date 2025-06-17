# NUnit1019

## The source specified by the TestCaseSource does not return an I(Async)Enumerable or a type that implements I(Async)Enumerable

| Topic    | Value
| :--      | :--
| Id       | NUnit1019
| Severity | Error
| Enabled  | True
| Category | Structure
| Code     | [TestCaseSourceUsesStringAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.9.2/src/nunit.analyzers/TestCaseSourceUsage/TestCaseSourceUsesStringAnalyzer.cs)

## Description

The source specified by the TestCaseSource must return an I(Async)Enumerable or a type that implements I(Async)Enumerable.

## Motivation

To prevent tests that will fail at runtime due to improper construction.

## How to fix violations

### Example Violation

```csharp
public class AnalyzeWhenSourceDoesProvideIEnumerable
{
    private static readonly int testCases = 42;

    [TestCaseSource(nameof(testCases))]
    public void Test(int input)
    {
    }
}
```

### Explanation

In the sample above, the source specified by `TestCaseSource` - the field `testCases` - does not return an
`I(Async)Enumerable` or a type that implements `I(Async)Enumerable`, instead it returns an `int`.

However, sources specified by `TestCaseSource`
[must return an `I(Async)Enumerable` or a type that implements `I(Async)Enumerable`.](xref:testcasesourceattribute).

### Fix

Change `testCases` to return an `I(Async)Enumerable` or a type that implements `I(Async)Enumerable`:

```csharp
public class AnalyzeWhenSourceDoesProvideIEnumerable
{
    private static readonly int[] testCases = new int[] { 1, 2, 42 };

    [TestCaseSource(nameof(testCases))]
    public void Test(int input)
    {
    }
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit1019: The source specified by the TestCaseSource does not return an I(Async)Enumerable or a type that implements I(Async)Enumerable
dotnet_diagnostic.NUnit1019.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit1019 // The source specified by the TestCaseSource does not return an I(Async)Enumerable or a type that implements I(Async)Enumerable
Code violating the rule here
#pragma warning restore NUnit1019 // The source specified by the TestCaseSource does not return an I(Async)Enumerable or a type that implements I(Async)Enumerable
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit1019 // The source specified by the TestCaseSource does not return an I(Async)Enumerable or a type that implements I(Async)Enumerable
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Structure",
    "NUnit1019:The source specified by the TestCaseSource does not return an I(Async)Enumerable or a type that implements I(Async)Enumerable",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

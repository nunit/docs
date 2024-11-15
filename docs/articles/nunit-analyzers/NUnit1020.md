# NUnit1020

## The TestCaseSource provides parameters to a source - field or property - that expects no parameters

| Topic    | Value
| :--      | :--
| Id       | NUnit1020
| Severity | Error
| Enabled  | True
| Category | Structure
| Code     | [TestCaseSourceUsesStringAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.4.0/src/nunit.analyzers/TestCaseSourceUsage/TestCaseSourceUsesStringAnalyzer.cs)

## Description

The TestCaseSource must not provide any parameters when the source is a field or a property.

## Motivation

To prevent tests that will fail at runtime due to improper construction.

## How to fix violations

### Example Violation

```csharp
public class MyTestClass
{
    [TestCaseSource(nameof(DivideCases), new object[] { "Testing" })]
    public void DivideTest(int n, int d, int q)
    {
        ClassicAssert.AreEqual(q, n / d);
    }

    static object[] DivideCases =
    {
        new object[] { 12, 3, 4 },
        new object[] { 12, 2, 6 },
        new object[] { 12, 4, 3 }
    };
}
```

### Explanation

In the sample above, `DivideCases` is a field, and as such does not accept any arguments, so the `TestCaseSource` should
not supply any parameters.

### Fix

Either remove the parameter from `TestCaseSource` or change the field into a method.:

```csharp
public class MyTestClass
{
    [TestCaseSource(nameof(DivideCases), new object[] { "Testing" })]
    public void DivideTest(int n, int d, int q)
    {
        ClassicAssert.AreEqual(q, n / d);
    }

    static object[] DivideCases(string input)
    {
        return new object[]
        {
            new object[] { 12, 3, 4 },
            new object[] { 12, 2, 6 },
            new object[] { 12, 4, 3 }
        };
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
# NUnit1020: The TestCaseSource provides parameters to a source - field or property - that expects no parameters
dotnet_diagnostic.NUnit1020.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit1020 // The TestCaseSource provides parameters to a source - field or property - that expects no parameters
Code violating the rule here
#pragma warning restore NUnit1020 // The TestCaseSource provides parameters to a source - field or property - that expects no parameters
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit1020 // The TestCaseSource provides parameters to a source - field or property - that expects no parameters
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Structure",
    "NUnit1020:The TestCaseSource provides parameters to a source - field or property - that expects no parameters",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

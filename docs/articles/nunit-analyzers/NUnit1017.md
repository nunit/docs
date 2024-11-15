# NUnit1017

## The specified source is not static

| Topic    | Value
| :--      | :--
| Id       | NUnit1017
| Severity | Error
| Enabled  | True
| Category | Structure
| Code     | [TestCaseSourceUsesStringAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.4.0/src/nunit.analyzers/TestCaseSourceUsage/TestCaseSourceUsesStringAnalyzer.cs)

## Description

The specified source must be static.

## Motivation

To prevent tests that will fail at runtime due to improper construction.

## How to fix violations

### Example Violation

```csharp
public class MyTestClass
{
    [TestCaseSource(nameof(DivideCases))]
    public void DivideTest(int n, int d, int q)
    {
        ClassicAssert.AreEqual(q, n / d);
    }

    object[] DivideCases =
    {
        new object[] { 12, 3, 4 },
        new object[] { 12, 2, 6 },
        new object[] { 12, 4, 3 }
    };
}
```

### Explanation

In the sample above, `DivideCases` is not a `static` field.

However, sources specified by `TestCaseSource`
[must be `static`](xref:testcasesourceattribute).

### Fix

Make the source `static`:

```csharp
public class MyTestClass
{
    [TestCaseSource(nameof(DivideCases))]
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

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit1017: The specified source is not static
dotnet_diagnostic.NUnit1017.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit1017 // The specified source is not static
Code violating the rule here
#pragma warning restore NUnit1017 // The specified source is not static
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit1017 // The specified source is not static
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Structure",
    "NUnit1017:The specified source is not static",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

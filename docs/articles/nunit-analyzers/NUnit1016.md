# NUnit1016

## The source type does not have a default constructor

| Topic    | Value
| :--      | :--
| Id       | NUnit1016
| Severity | Error
| Enabled  | True
| Category | Structure
| Code     | [TestCaseSourceUsesStringAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.4.0/src/nunit.analyzers/TestCaseSourceUsage/TestCaseSourceUsesStringAnalyzer.cs)

## Description

The source type must have a default constructor in order to provide test cases.

## Motivation

To prevent tests that will fail at runtime due to improper construction.

## How to fix violations

### Example Violation

```csharp
public class MyTestClass
{
    [TestCaseSource(typeof(DivideCases))]
    public void DivideTest(int n, int d, int q)
    {
        ClassicAssert.AreEqual(q, n / d);
    }
}

class DivideCases : IEnumerable
{
    public DivideCases(int i) { }

    public IEnumerator GetEnumerator()
    {
        yield return new object[] { 12, 3, 4 };
        yield return new object[] { 12, 2, 6 };
        yield return new object[] { 12, 4, 3 };
    }
}
```

### Explanation

In the sample above, the class `DivideCases` does not have a default constructor - i.e. a constructor with no parameters.

However, source types specified by `TestCaseSource`
[must have a default constructor](xref:testcasesourceattribute).

### Fix

Add a default constructor to the source type (or remove the parameters from an existing constructor):

```csharp
public class MyTestClass
{
    [TestCaseSource(typeof(DivideCases))]
    public void DivideTest(int n, int d, int q)
    {
        ClassicAssert.AreEqual(q, n / d);
    }
}

class DivideCases : IEnumerable
{
    public DivideCases() { }

    public DivideCases(int i) { }

    public IEnumerator GetEnumerator()
    {
        yield return new object[] { 12, 3, 4 };
        yield return new object[] { 12, 2, 6 };
        yield return new object[] { 12, 4, 3 };
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
# NUnit1016: The source type does not have a default constructor
dotnet_diagnostic.NUnit1016.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit1016 // The source type does not have a default constructor
Code violating the rule here
#pragma warning restore NUnit1016 // The source type does not have a default constructor
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit1016 // The source type does not have a default constructor
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Structure",
    "NUnit1016:The source type does not have a default constructor",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

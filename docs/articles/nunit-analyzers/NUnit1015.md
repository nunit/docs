# NUnit1015

## The source type does not implement IEnumerable.

| Topic    | Value
| :--      | :--
| Id       | NUnit1015
| Severity | Error
| Enabled  | True
| Category | Structure
| Code     | [TestCaseSourceUsesStringAnalyzer](https://github.com/nunit/nunit.analyzers/blob/0.5.0/src/nunit.analyzers/TestCaseSourceUsage/TestCaseSourceUsesStringAnalyzer.cs)

## Description

The source type must implement IEnumerable in order to provide test cases.

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
        Assert.AreEqual(q, n / d);
    }
}

class DivideCases
{
    public IEnumerator GetData()
    {
        yield return new object[] { 12, 3, 4 };
        yield return new object[] { 12, 2, 6 };
        yield return new object[] { 12, 4, 3 };
    }
}
```

### Explanation

In the sample above, the class `DivideCases` does not implement `IEnumerable`.

However, source types specified by `TestCaseSource` [must implement `IEnumerable`](xref:testcasesourceattribute).

### Fix

Make the source type implement `IEnumerable`:

```csharp
public class MyTestClass
{
    [TestCaseSource(typeof(DivideCases))]
    public void DivideTest(int n, int d, int q)
    {
        Assert.AreEqual(q, n / d);
    }
}

class DivideCases : IEnumerable
{
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

Configure the severity per project, for more info see [MSDN](https://msdn.microsoft.com/en-us/library/dd264949.aspx).

### Via .editorconfig file

```ini
# NUnit1015: The source type does not implement IEnumerable.
dotnet_diagnostic.NUnit1015.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit1015 // The source type does not implement IEnumerable.
Code violating the rule here
#pragma warning restore NUnit1015 // The source type does not implement IEnumerable.
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit1015 // The source type does not implement IEnumerable.
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Structure",
    "NUnit1015:The source type does not implement IEnumerable.",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

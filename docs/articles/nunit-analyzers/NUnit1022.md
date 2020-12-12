# NUnit1022

## The specified source is not static.

| Topic    | Value
| :--      | :--
| Id       | NUnit1022
| Severity | Error
| Enabled  | True
| Category | Structure
| Code     | [ValueSourceUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/0.5.0/src/nunit.analyzers/ValueSourceUsage/ValueSourceUsageAnalyzer.cs)

## Description

The specified source must be static.

## Motivation

To prevent tests that will fail at runtime due to improper construction.

## How to fix violations

### Example Violation

```csharp
public class MyTestClass
{
    [Test]
    public void DivideTest([ValueSource(nameof(Numbers))] int n)
    {
        Assert.AreEqual(n, Is.GreaterThanOrEqualTo(0));
    }

    object[] Numbers => new int[] { 1, 2, 3 };
}
```

### Explanation

In the sample above, `Numbers` is not a `static` property.

However, sources specified by `ValueSource` [must be `static`](xref:valuesource).

### Fix

Make the source `static`:

```csharp
public class MyTestClass
{
    [Test]
    public void DivideTest([ValueSource(nameof(Numbers))] int n)
    {
        Assert.AreEqual(n, Is.GreaterThanOrEqualTo(0));
    }

    static object[] Numbers => new int[] { 1, 2, 3 };
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see [MSDN](https://msdn.microsoft.com/en-us/library/dd264949.aspx).

### Via .editorconfig file

```ini
# NUnit1022: The specified source is not static.
dotnet_diagnostic.NUnit1022.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit1022 // The specified source is not static.
Code violating the rule here
#pragma warning restore NUnit1022 // The specified source is not static.
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit1022 // The specified source is not static.
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Structure",
    "NUnit1022:The specified source is not static.",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

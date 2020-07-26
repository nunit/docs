# NUnit1024

## The source specified by the ValueSource does not return an IEnumerable or a type that implements IEnumerable.

| Topic    | Value
| :--      | :--
| Id       | NUnit1024
| Severity | Error
| Enabled  | True
| Category | Structure
| Code     | [ValueSourceUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/0.4.0/src/nunit.analyzers/ValueSourceUsage/ValueSourceUsageAnalyzer.cs)

## Description

The source specified by the ValueSource must return an IEnumerable or a type that implements IEnumerable.

## Motivation

To prevent tests that will fail at runtime due to improper construction.

## How to fix violations

### Example Violation

```csharp
public class AnalyzeWhenSourceDoesProvideIEnumerable
{
    private static readonly int testCases = 42;

    [Test]
    public void Test([ValueSource(nameof(testCases))] int input)
    {
    }
}
```

### Explanation

In the sample above, the source specified by `ValueSource` - the field `testCases` - does not return an `IEnumerable` or a type that implements `IEnumerable`,
instead it returns an `int`.

However, sources specified by `ValueSource` [must return an `IEnumerable` or a type that implements `IEnumerable`.](xref:valuesource).

### Fix

Change `testCases` to return an `IEnumerable` or a type that implements `IEnumerable`:

```csharp
public class AnalyzeWhenSourceDoesProvideIEnumerable
{
    private static readonly int[] testCases = new int[] { 1, 2, 42 };

    [Test]
    public void Test([ValueSource(nameof(testCases))] int input)
    {
    }
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file.

Configure the severity per project, for more info see [MSDN](https://msdn.microsoft.com/en-us/library/dd264949.aspx).

### Via #pragma directive.

```csharp
#pragma warning disable NUnit1024 // The source specified by the ValueSource does not return an IEnumerable or a type that implements IEnumerable.
Code violating the rule here
#pragma warning restore NUnit1024 // The source specified by the ValueSource does not return an IEnumerable or a type that implements IEnumerable.
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit1024 // The source specified by the ValueSource does not return an IEnumerable or a type that implements IEnumerable.
```

### Via attribute `[SuppressMessage]`.

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Structure",
    "NUnit1024:The source specified by the ValueSource does not return an IEnumerable or a type that implements IEnumerable.",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

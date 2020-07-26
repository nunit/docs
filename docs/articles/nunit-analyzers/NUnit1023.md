# NUnit1023

## The target method expects parameters which cannot be supplied by the ValueSource.

| Topic    | Value
| :--      | :--
| Id       | NUnit1023
| Severity | Error
| Enabled  | True
| Category | Structure
| Code     | [ValueSourceUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/0.4.0/src/nunit.analyzers/ValueSourceUsage/ValueSourceUsageAnalyzer.cs)

## Description

The target method expects parameters which cannot be supplied by the ValueSource.

## Motivation

To prevent tests that will fail at runtime due to improper construction.

## How to fix violations

### Example Violation

```csharp
public class MyTestClass
{
    [Test]
    public void StringTest([ValueSource(nameof(Strings))] string input)
    {
        Assert.That(input, Is.Not.Null);
    }

    static IEnumerable<string> Strings(string first, string second)
    {
        yield return first;
        yield return second;
    }
}
```

### Explanation

In the sample above, the method `Strings` expects two arguments, but the `ValueSource` cannot supply arguments.

### Fix

Change `Strings` so that it does not expect any arguments:

```csharp
public class MyTestClass
{
    [Test]
    public void StringTest([ValueSource(nameof(Strings))] string input)
    {
        Assert.That(input, Is.Not.Null);
    }

    static IEnumerable<string> Strings()
    {
        yield return "first";
        yield return "second";
    }
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file.

Configure the severity per project, for more info see [MSDN](https://msdn.microsoft.com/en-us/library/dd264949.aspx).

### Via #pragma directive.

```csharp
#pragma warning disable NUnit1023 // The target method expects parameters which cannot be supplied by the ValueSource.
Code violating the rule here
#pragma warning restore NUnit1023 // The target method expects parameters which cannot be supplied by the ValueSource.
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit1023 // The target method expects parameters which cannot be supplied by the ValueSource.
```

### Via attribute `[SuppressMessage]`.

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Structure",
    "NUnit1023:The target method expects parameters which cannot be supplied by the ValueSource.",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

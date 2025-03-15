# NUnit2042

## Comparison constraint on object

| Topic    | Value
| :--      | :--
| Id       | NUnit2042
| Severity | Info
| Enabled  | True
| Category | Assertion
| Code     | [ComparableTypesAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.4.0/src/nunit.analyzers/ComparableTypes/ComparableTypesAnalyzer.cs)

## Description

The comparison constraint might fail as the actual and the expected value might not implement IComparable.

## Motivation

```csharp
public static void ShouldBeGreaterThan(this object actual, object expected, string? message = null)
{
    Assert.That(actual, Is.GreaterThan(expected), message);
}
```

In the above function it is assumed that every instance of object is comparable.
The function works if the types actually are comparable, but will result in NUnit runtime errors if they are not.

## How to fix violations

Change the type to `IComparable`. This way you will get compilation failures
if called with types that do not implement IComparable.
A similar solution can be created which works for types implementing the generic `IComparable<T>`.

```csharp
public static void ShouldBeGreaterThan(this IComparable actual, IComparable expected, string? message = null)
{
    Assert.That(actual, Is.GreaterThan(expected), message);
}

public static void ShouldBeGreaterThan<T>(this T actual, T expected, string? message = null)
    where T : IComparable<T>
{
    Assert.That(actual, Is.GreaterThan(expected), message);
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2042: Comparison constraint on object
dotnet_diagnostic.NUnit2042.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2042 // Comparison constraint on object
Code violating the rule here
#pragma warning restore NUnit2042 // Comparison constraint on object
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2042 // Comparison constraint on object
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2042:Comparison constraint on object",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

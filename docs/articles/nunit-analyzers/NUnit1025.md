# NUnit1025

## The ValueSource argument does not specify an existing member

| Topic    | Value
| :--      | :--
| Id       | NUnit1025
| Severity | Error
| Enabled  | True
| Category | Structure
| Code     | [ValueSourceUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/3.8.0/src/nunit.analyzers/ValueSourceUsage/ValueSourceUsageAnalyzer.cs)

## Description

The ValueSource argument does not specify an existing member. This will lead to an error at run-time.

## Motivation

To prevent tests that will fail at runtime due to improper construction.

## How to fix violations

### Example Violation

```csharp
[Test]
public void NUnit1011SampleTest([ValueSource("MyIncorrectTestSource")] string stringValue)
{
    Assert.That(stringValue.Length, Is.EqualTo(3));
}

public static object[] MyTestSource()
{
    return new object[] {"One", "Two"};
}
```

### Explanation

In the example above, the test case source is named `MyIncorrectTestCaseSource`, but the test case source is actually
named `MyTestSource`. Because the names don't match, this will be an error.

### Fix

Rename the `TestCaseSource` to match:

```csharp
[Test]
public void NUnit1011SampleTest([ValueSource("MyTestSource")] string stringValue)
{
    Assert.That(stringValue.Length, Is.EqualTo(3));
}

public static object[] MyTestSource()
{
    return new object[] {"One", "Two"};
}
```

Or even better, use `nameof` so that the compiler may assist with mismatched names in the future:

```csharp
[Test]
public void NUnit1011SampleTest([ValueSource(nameof(MyTestSource))] string stringValue)
{
    Assert.That(stringValue.Length, Is.EqualTo(3));
}

public static object[] MyTestSource()
{
    return new object[] {"One", "Two"};
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit1025: The ValueSource argument does not specify an existing member
dotnet_diagnostic.NUnit1025.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit1025 // The ValueSource argument does not specify an existing member
Code violating the rule here
#pragma warning restore NUnit1025 // The ValueSource argument does not specify an existing member
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit1025 // The ValueSource argument does not specify an existing member
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Structure",
    "NUnit1025:The ValueSource argument does not specify an existing member",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

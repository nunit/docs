# NUnit1018

## The number of parameters provided by the TestCaseSource does not match the number of parameters in the target method

| Topic    | Value
| :--      | :--
| Id       | NUnit1018
| Severity | Error
| Enabled  | True
| Category | Structure
| Code     | [TestCaseSourceUsesStringAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.1.0/src/nunit.analyzers/TestCaseSourceUsage/TestCaseSourceUsesStringAnalyzer.cs)

## Description

The number of parameters provided by the TestCaseSource must match the number of parameters in the target method.

## Motivation

To prevent tests that will fail at runtime due to improper construction.

## How to fix violations

### Example Violation

```csharp
public class MyTestClass
{
    [TestCaseSource(nameof(Strings), new object[] { "Testing" })]
    public void StringTest(string input)
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

In the sample above, the method `Strings` expects two arguments, but the `TestCaseSource` only supplies one argument.

### Fix

Either change `Strings` to only expect one argument or supply both from the `TestCaseSource`:

```csharp
public class MyTestClass
{
    [TestCaseSource(nameof(Strings), new object[] { "Testing", "TestCaseSource" })]
    public void StringTest(string input)
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

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit1018: The number of parameters provided by the TestCaseSource does not match the number of parameters in the target method
dotnet_diagnostic.NUnit1018.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit1018 // The number of parameters provided by the TestCaseSource does not match the number of parameters in the target method
Code violating the rule here
#pragma warning restore NUnit1018 // The number of parameters provided by the TestCaseSource does not match the number of parameters in the target method
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit1018 // The number of parameters provided by the TestCaseSource does not match the number of parameters in the target method
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Structure",
    "NUnit1018:The number of parameters provided by the TestCaseSource does not match the number of parameters in the target method",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

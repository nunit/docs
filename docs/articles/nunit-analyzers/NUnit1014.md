# NUnit1014

## The async test method must have a Task\<T> return type when a result is expected

| Topic    | Value
| :--      | :--
| Id       | NUnit1014
| Severity | Error
| Enabled  | True
| Category | Structure
| Code     | [TestMethodUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.1.0/src/nunit.analyzers/TestMethodUsage/TestMethodUsageAnalyzer.cs)

## Description

The async test method must have a `Task<T>` return type when a result is expected.

## Motivation

To prevent tests that will fail at runtime due to improper construction.

## How to fix violations

### Example Violation

```csharp
[TestCase(1, ExpectedResult = true)]
public async Task NUnit1014SampleTest(int numberValue)
{
    return;
}
```

### Explanation

The NUnit `ExpectedResult` syntax is used, so this method needs to return a type that matches the type of expected
result you're looking for.

### Fix

Remove the `ExpectedResult` syntax:

```csharp
[TestCase(1)]
public async Task NUnit1014SampleTest(int numberValue)
{
    Assert.Pass();
}
```

Or, update the return task type to be what you're looking for, e.g. `Task<bool>` below:

```csharp
[TestCase(1, ExpectedResult = true)]
public async Task<bool> NUnit1014SampleTest(int numberValue)
{
    return Task.FromResult(true);
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit1014: The async test method must have a Task<T> return type when a result is expected
dotnet_diagnostic.NUnit1014.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit1014 // The async test method must have a Task<T> return type when a result is expected
Code violating the rule here
#pragma warning restore NUnit1014 // The async test method must have a Task<T> return type when a result is expected
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit1014 // The async test method must have a Task<T> return type when a result is expected
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Structure",
    "NUnit1014:The async test method must have a Task<T> return type when a result is expected",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

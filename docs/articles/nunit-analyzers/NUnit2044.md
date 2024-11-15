# NUnit2044

## Non-delegate actual parameter

| Topic    | Value
| :--      | :--
| Id       | NUnit2044
| Severity | Error
| Enabled  | True
| Category | Assertion
| Code     | [DelegateRequiredAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.4.0/src/nunit.analyzers/DelegateRequired/DelegateRequiredAnalyzer.cs)

## Description

The actual argument needs to be evaluated by the Assert to catch any exceptions.

## Motivation

In order for the `Assert.That` to catch an exception or a timeout, the code must be
a delegate so it can be evaluated by the method. If the parameter is not a
delegate, it will be evaluated before the call to `Assert.That` and stop further
execution.

## How to fix violations

Convert the call into a delegate using a lambda expression or method group.

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2044: Non-delegate actual parameter
dotnet_diagnostic.NUnit2044.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2044 // Non-delegate actual parameter
Code violating the rule here
#pragma warning restore NUnit2044 // Non-delegate actual parameter
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2044 // Non-delegate actual parameter
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2044:Non-delegate actual parameter",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

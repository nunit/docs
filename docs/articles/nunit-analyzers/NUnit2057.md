# NUnit2057

## Remove unnecessary lambda expression

| Topic    | Value
| :--      | :--
| Id       | NUnit2057
| Severity | Info
| Enabled  | True
| Category | Assertion
| Code     | [DelegateUnnecessaryAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.12.0/src/nunit.analyzers/DelegateUnnecessary/DelegateUnnecessaryAnalyzer.cs)

## Description

Only the argument value is needed by the Assert.

## Motivation

The `Assert` method will call a delegate if passed in, but that is an unnecessary overhead.

In most cases, only the return value is needed by the assertion.

There are two exceptions:

1. When catching exceptions, like in:

    ```csharp
    Assert.That(() => instance.Method1(null), Throws.ArgumentNullException);
    ```

2. When a method might need to be called multiple times, like in:

    ```csharp
    Assert.That(() => task.IsCompleted, Is.True.After(5).Seconds.PollEvery(100).MilliSeconds);
    ```

Sometimes developers unnecessarily create a lambda expression for the _actual_ parameter.

```csharp
Assert.That(() => instance.Method1(Parameters), Is.EqualTo(expected));
```

Here, the call is performed inside the `Assert` and then the result is tested.
This is not necessary. The same test can be written as:

```csharp
Assert.That(instance.Method1(Parameters), Is.EqualTo(expected));
```

It is clearer both in looks and in what is being tested here.

Sometimes the lambda is created implicitly like in:

```csharp
Assert.That(instance.Method2, Is.EqualTo(expected));
```

The fixed code should look like:

```csharp
Assert.That(instance.Method2(), Is.EqualTo(expected));
```

This clearly indicates that the `Assert` is on the return value of the method.

## How to fix violations

Remove the anonymous lambda creation `() =>`.
There is a code-fix that can do this for you.

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2057: Remove unnecessary lambda expression
dotnet_diagnostic.NUnit2057.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2057 // Remove unnecessary lambda expression
Code violating the rule here
#pragma warning restore NUnit2057 // Remove unnecessary lambda expression
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2057 // Remove unnecessary lambda expression
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2057:Remove unnecessary lambda expression",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

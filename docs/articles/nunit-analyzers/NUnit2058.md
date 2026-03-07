# NUnit2058

## The constraint is misused

| Topic    | Value
| :--      | :--
| Id       | NUnit2058
| Severity | Warning
| Enabled  | True
| Category | Assertion
| Code     | [MisusedConstraintsAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.12.0/src/nunit.analyzers/MisusedConstraints/MisusedConstraintsAnalyzer.cs)

## Description

The constraint didn't take the operator precedence into account.

## Motivation

We have seen users wanting to test for an equivalent of `!string.IsNullOrEmpty()` using `Is.Not.Null.Or.Empty`.

```csharp
Assert.That(name, Is.Not.Null.Or.Empty);
```

Because of the operator precedence this actually means `Is.Not.Null | Is.Empty`.
The `Is.Empty` part will only be tested when the item under test is `null`.
Depending on the type this either returns `false` or `throws` an `Exception`.

## How to fix violations

The code fix associated with this rule will convert this to test for both `Not.Null` and `Not.Empty`:

```csharp
Assert.That(name, Is.Not.Null.And.Not.Empty);
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2058: The constraint is misused
dotnet_diagnostic.NUnit2058.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2058 // The constraint is misused
Code violating the rule here
#pragma warning restore NUnit2058 // The constraint is misused
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2058 // The constraint is misused
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2058:The constraint is misused",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

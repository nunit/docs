# NUnit1028

## The non-test method is public.

| Topic    | Value
| :--      | :--
| Id       | NUnit1028
| Severity | Info
| Enabled  | True
| Category | Structure
| Code     | [NonTestMethodAccessibilityLevelAnalyzer](https://github.com/nunit/nunit.analyzers/blob/0.5.0/src/nunit.analyzers/NonTestMethodAccessibilityLevel/NonTestMethodAccessibilityLevelAnalyzer.cs)

## Description

A fixture should not contain any public non-test methods.

## Motivation

A fixture should be self-contained and not have methods callable by other classes.

## How to fix violations

If the methods are purely for this class, mark them as 'private'. If the methods are used by other classes move these
methods to a separate class used by the relevant test fixtures.

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see [MSDN](https://msdn.microsoft.com/en-us/library/dd264949.aspx).

### Via .editorconfig file

```ini
# NUnit1028: The non-test method is public.
dotnet_diagnostic.NUnit1028.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit1028 // The non-test method is public.
Code violating the rule here
#pragma warning restore NUnit1028 // The non-test method is public.
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit1028 // The non-test method is public.
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Structure",
    "NUnit1028:The non-test method is public.",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

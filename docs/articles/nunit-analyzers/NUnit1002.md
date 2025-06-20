# NUnit1002

## The TestCaseSource should use nameof operator to specify target

| Topic    | Value
| :--      | :--
| Id       | NUnit1002
| Severity | Warning
| Enabled  | True
| Category | Structure
| Code     | [TestCaseSourceUsesStringAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.9.2/src/nunit.analyzers/TestCaseSourceUsage/TestCaseSourceUsesStringAnalyzer.cs)

## Description

The TestCaseSource should use nameof operator to specify target.

## Motivation

Prevent test rot by ensuring that future renames don't accidentally break tests in an unexpected way. `nameof` adds some
compile-time support in these situations.

## How to fix violations

### Example Violation

```csharp
[TestCaseSource("MyTestSource")]
public void SampleTest(string stringValue)
{
    Assert.That(stringValue.Length, Is.EqualTo(3));
}

public static object[] MyTestSource()
{
    return new object[] {"One", "Two"};
}
```

### Problem

In this case, we're referring to `"MyTestSource"` as a string directly. This is brittle; should the name of the property
change, the test case source would become invalid, and we would not know this until executing tests.

### Fix

The fix is to use the C# `nameof` operator, which produces a string but references the field name. This way, when
refactoring and changing the name of your test source, it would also update the name within the `nameof()` operator.

The fix in action:

```csharp
[TestCaseSource(nameof(MyTestSource))] // using nameof
public void SampleTest(string stringValue)
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
# NUnit1002: The TestCaseSource should use nameof operator to specify target
dotnet_diagnostic.NUnit1002.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit1002 // The TestCaseSource should use nameof operator to specify target
Code violating the rule here
#pragma warning restore NUnit1002 // The TestCaseSource should use nameof operator to specify target
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit1002 // The TestCaseSource should use nameof operator to specify target
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Structure",
    "NUnit1002:The TestCaseSource should use nameof operator to specify target",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

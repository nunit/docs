# NUnit1027

## The test method has parameters, but no arguments are supplied by attributes.

| Topic    | Value
| :--      | :--
| Id       | NUnit1027
| Severity | Error
| Enabled  | True
| Category | Structure
| Code     | [TestMethodUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/0.5.0/src/nunit.analyzers/TestMethodUsage/TestMethodUsageAnalyzer.cs)

## Description

The test method has parameters, but no arguments are supplied by attributes.

## Motivation

To prevent tests that will fail at runtime due to improper construction.

## How to fix violations

### Example Violation

```csharp
[Test]
public void SampleTest(int numberValue)
{
    Assert.That(numberValue, Is.EqualTo(1));
}
```

### Problem

In the test case above, the declares that it expects one integer parameter, but no argument is supplied by the attributes. This will lead to a runtime failure.

### Fix

Ensure that the correct number of arguments - and of the correct type - is supplied to test methods that expect parameters.

One possible fix to this problem would be to supply the argument using a `TestCase`:

```csharp
[TestCase(1)]
public void SampleTest(int numberValue)
{
    Assert.That(numberValue, Is.EqualTo(1));
}
```

Another approach could be to supply the argument using an attribute on the argument - like `Range`

```csharp
[Test]
public void SampleTest([Range(1, 10)] int numberValue)
{
    Assert.That(numberValue, Is.EqualTo(1));
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see [MSDN](https://msdn.microsoft.com/en-us/library/dd264949.aspx).

### Via .editorconfig file

```ini
# NUnit1027: The test method has parameters, but no arguments are supplied by attributes.
dotnet_diagnostic.NUnit1027.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit1027 // The test method has parameters, but no arguments are supplied by attributes.
Code violating the rule here
#pragma warning restore NUnit1027 // The test method has parameters, but no arguments are supplied by attributes.
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit1027 // The test method has parameters, but no arguments are supplied by attributes.
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Structure",
    "NUnit1027:The test method has parameters, but no arguments are supplied by attributes.",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

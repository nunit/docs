# NUnit2007

## The actual value should not be a constant

| Topic    | Value
| :--      | :--
| Id       | NUnit2007
| Severity | Warning
| Enabled  | True
| Category | Assertion
| Code     | [ConstActualValueUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.4.0/src/nunit.analyzers/ConstActualValueUsage/ConstActualValueUsageAnalyzer.cs)

## Description

The actual value should not be a constant. This indicates that the actual value and the expected value have switched
places.

## Motivation

Bring developers' attention to a scenario in which their test is most likely testing the wrong thing, or to cases where
their actual and expected values may be accidentally swapped.

## How to fix violations

### Example Violation

```csharp
[Test]
public void NUnit2007SampleTest()
{
    var x = 5;
    Assert.That(5, Is.EqualTo(x));
    ClassicAssert.AreEqual(x, 5);
}
```

### Explanation

Both asserts above will trigger this warning. That's because the actual value should be the value produced by your code,
not a constant value that you're expecting (which should be in the place of the expected value).

In the case of equality, etc. this might seem like no big deal, but it really comes into play in the exceptions that are
raised by error messages. It's important that if your test fails, the message can correctly tell you what the expected
and actual values are.

As an aside, this is another reason why the `Assert.That` syntax is often preferred when asserting equality.

### Fix

Flip the actual and expected values so that your expected value is the constant and your actual value has been generated
by code.

```csharp
[Test]
public void NUnit2007SampleTest()
{
    var x = 5;
    Assert.That(x, Is.EqualTo(5));
    ClassicAssert.AreEqual(5, x);
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2007: The actual value should not be a constant
dotnet_diagnostic.NUnit2007.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2007 // The actual value should not be a constant
Code violating the rule here
#pragma warning restore NUnit2007 // The actual value should not be a constant
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2007 // The actual value should not be a constant
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2007:The actual value should not be a constant",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

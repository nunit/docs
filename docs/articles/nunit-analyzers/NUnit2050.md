# NUnit2050

## NUnit 4 no longer supports string.Format specification

| Topic    | Value
| :--      | :--
| Id       | NUnit2050
| Severity | Error
| Enabled  | True
| Category | Assertion
| Code     | [UpdateStringFormatToInterpolatableStringAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.4.0/src/nunit.analyzers/UpdateStringFormatToInterpolatableString/UpdateStringFormatToInterpolatableStringAnalyzer.cs)

## Description

Replace format specification with interpolated string.

## Motivation

In order to get better failure messages, NUnit4 uses
[`CallerArgumentExpression`](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.callerargumentexpressionattribute?view=net-7.0)
to include the expression passed in for the _actual_ and _constraint_ parameters.
These are parameters automatically supplied by the compiler.

To facilitate this, we needed to drop support for
[composite formatting](https://learn.microsoft.com/en-us/dotnet/standard/base-types/composite-formatting).
All NUnit4 asserts only allow a single _message_ parameter which can be either a simple string literal
or a [interpolatable string](https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/string-interpolation).

This analyzer needs to be run when still building against NUnit3 as otherwise your code won't compile.
When usages of the new methods with `params` are detected, the associated CodeFix will convert the format specification
into an interpolated string.

The affected methods are:

```csharp
Assert.Pass
Assert.Fail
Assert.Warn
Assert.Ignore
Assert.Inconclusive
Assert.That
Assume.That
```

Once you moved to NUnit4 the analyzer has some limited functionality as there are a few
cases with `Assert.That` or `Assume.That` where your NUnit3 code will compile on NUnit4,
but not the way you want it.
Here what you think are parameters to a format specification are actually interpreted as
the _actual_ and _constraint_ expression strings.
Unfortunately you only find that out when the test fails, which could be never.

## How to fix violations

The following code, valid in NUnit3:

```csharp
[TestCase(4)]
public void MustBeMultipleOf3(int value)
{
    Assert.That(value % 3, Is.Zero, "Expected value ({0}) to be multiple of 3", value);
}
```

Will fail with the following message:

```plaintext
Expected value (4) to be multiple of 3
Expected: 0
But was:  1
```

The associated CodeFix for this Analyzer rule will convert the test into:

```csharp
[TestCase(4)]
public void MustBeMultipleOf3(int value)
{
    Assert.That(value % 3, Is.Zero, $"Expected value ({value}) to be multiple of 3");
}
```

The failure message for NUnit4 becomes:

```csharp
Expected value (4) to be multiple of 3
Assert.That(value % 3, Is.Zero)
Expected: 0
But was:  1
```

As the `[CallerMemberExpression]` parameters are `string`, some of NUnit 3.x code compiles, but when failing show the
wrong message:

```csharp
[TestCase("NUnit 4", "NUnit 3")]
public void TestMessage(string actual, string expected)
{
    Assert.That(actual, Is.EqualTo(expected), "Expected '{0}', but got: '{1}'", expected, actual);
}
```

When using NUnit3, this results in:

```plaintext
  Expected 'NUnit 3', but got: 'NUnit 4'
  String lengths are both 7. Strings differ at index 6.
  Expected: "NUnit 3"
  But was:  "NUnit 4"
  -----------------^
```

But when using NUnit4, we get:

```plaintext
 Message:
  Expected '{0}', but got: '{1}'
Assert.That(NUnit 3, NUnit 4)
  String lengths are both 7. Strings differ at index 6.
  Expected: "NUnit 3"
  But was:  "NUnit 4"
  -----------------^
```

Where the format string is treated as the _message_ and its arguments are interpreted as the _actual_ and _expected_
expressions! After applying the code fix the code looks like:

```csharp
[TestCase("NUnit 4", "NUnit 3")]
public void TestMessage(string actual, string expected)
{
    Assert.That(actual, Is.EqualTo(expected), $"Expected '{expected}', but got: '{actual}'");
}
```

and the output:

```plaintext
 Message:
  Expected 'NUnit 3', but got: 'NUnit 4'
Assert.That(actual, Is.EqualTo(expected))
  String lengths are both 7. Strings differ at index 6.
  Expected: "NUnit 3"
  But was:  "NUnit 4"
  -----------------^
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2050: NUnit 4 no longer supports string.Format specification
dotnet_diagnostic.NUnit2050.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2050 // NUnit 4 no longer supports string.Format specification
Code violating the rule here
#pragma warning restore NUnit2050 // NUnit 4 no longer supports string.Format specification
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2050 // NUnit 4 no longer supports string.Format specification
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2050:NUnit 4 no longer supports string.Format specification",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

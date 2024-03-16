# NUnit1026

## The test or setup/teardown method is not public

| Topic    | Value
| :--      | :--
| Id       | NUnit1026
| Severity | Error
| Enabled  | True
| Category | Structure
| Code     | [TestMethodAccessibilityLevelAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.1.0/src/nunit.analyzers/TestMethodAccessibilityLevel/TestMethodAccessibilityLevelAnalyzer.cs)

## Description

The test or setup/teardown method is not public.

## Motivation

To prevent tests that will fail at runtime, as NUnit only runs public test methods.

## How to fix violations

### Example Violation

```csharp
private int Value;

[SetUp]
void NUnit1026SetUp()
{
    Value = 42;
}

[Test]
void NUnit1026SampleTest()
{
    Assert.That(Value, Is.GreaterThan(0));
}

[TestCase(1)]
private protected static void NUnit1026SampleTest2(int i)
{
    Assert.Pass();
}
```

### Explanation

In the example above, the test named `NUnit1026SampleTest` is not `public` - it has the default access modifier for a
method, i.e. `internal`. `NUnit1026SampleTest2` has the explicit access modifier `private protected`, which again is not
`public`. NUnit only runs `public` methods, so neither test can be run.

### Fix

The analyzer comes with a code fix that will change the access modifier to `public`. So the tests above will be changed
into.

```csharp
private int Value;

[SetUp]
public void NUnit1026SetUp()
{
    Value = 42;
}

[Test]
public void NUnit1026SampleTest()
{
    Assert.That(Value, Is.GreaterThan(0));
}

[TestCase(1)]
public static void NUnit1026SampleTest2(int i)
{
    Assert.Pass();
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit1026: The test or setup/teardown method is not public
dotnet_diagnostic.NUnit1026.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit1026 // The test or setup/teardown method is not public
Code violating the rule here
#pragma warning restore NUnit1026 // The test or setup/teardown method is not public
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit1026 // The test or setup/teardown method is not public
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Structure",
    "NUnit1026:The test or setup/teardown method is not public",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

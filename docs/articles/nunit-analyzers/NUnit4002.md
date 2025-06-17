# NUnit4002

## Use Specific constraint

| Topic    | Value
| :--      | :--
| Id       | NUnit4002
| Severity | Info
| Enabled  | True
| Category | Style
| Code     | [UseSpecificConstraintAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.9.2/src/nunit.analyzers/UseSpecificConstraint/UseSpecificConstraintAnalyzer.cs)

## Description

Replace 'EqualTo' with a keyword in the corresponding specific constraint.

## Motivation

Sometimes constraints can be written more concisely using the inbuilt constraints provided by NUnit -
e.g. `Is.True` instead of `Is.EqualTo(true)`.

Also, from NUnit version 4.3.0 where new overloads of `Is.EqualTo` were introduced, it is sometimes
not possible to uniquely determine `default` when provided as the expected value - e.g. in
`Is.EqualTo(default)`. Again, in such cases, it is better to use the inbuilt constraint provided by NUnit.

Some examples of constraints that can be be simplified by using a more specific constraint can be seen below.

```csharp
[Test]
public void Test()
{
    Assert.That(actualFalse, Is.EqualTo(false));
    Assert.That(actualTrue, Is.EqualTo(true));
    Assert.That(actualObject, Is.EqualTo(null));
    Assert.That(actualObject, Is.EqualTo(default));
    Assert.That(actualInt, Is.EqualTo(default));
}
```

## How to fix violations

The analyzer comes with a code fix that will replace the constraint `Is.EqualTo(x)` with
the matching `Is.X` constraint (for some `x`). So the code block above will be changed into

```csharp
[Test]
public void Test()
{
    Assert.That(actualFalse, Is.False);
    Assert.That(actualTrue, Is.True);
    Assert.That(actualObject, Is.Null);
    Assert.That(actualObject, Is.Null);
    Assert.That(actualInt, Is.Default);
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit4002: Use Specific constraint
dotnet_diagnostic.NUnit4002.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit4002 // Use Specific constraint
Code violating the rule here
#pragma warning restore NUnit4002 // Use Specific constraint
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit4002 // Use Specific constraint
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Style",
    "NUnit4002:Use Specific constraint",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

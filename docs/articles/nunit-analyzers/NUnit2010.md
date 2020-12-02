# NUnit2010

## Use EqualConstraint for better assertion messages in case of failure

| Topic    | Value
| :--      | :--
| Id       | NUnit2010
| Severity | Info
| Enabled  | True
| Category | Assertion
| Code     | [EqualConstraintUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/0.6.0/src/nunit.analyzers/ConstraintUsage/EqualConstraintUsageAnalyzer.cs)

## Description

Using EqualConstraint will lead to better assertion messages in case of failure.

## Motivation

Using `Is.EqualTo` (or `Is.Not.EqualTo`) constraint will lead to better assertion messages in case of failure,
so this analyzer marks all usages of `==` operator and `Equals` method where it is possible to replace
with `Is.EqualTo` constraint.

```csharp
[Test]
public void Test()
{
    Assert.True(actual == expected);
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `Assert.True(actual == expected)` with
`Assert.That(actual, Is.EqualTo(expected))`. So the code block above will be changed into

```csharp
[Test]
public void Test()
{
    Assert.That(actual, Is.EqualTo(expected));
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see [MSDN](https://msdn.microsoft.com/en-us/library/dd264949.aspx).

### Via .editorconfig file

```ini
# NUnit2010: Use EqualConstraint for better assertion messages in case of failure
dotnet_diagnostic.NUnit2010.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2010 // Use EqualConstraint for better assertion messages in case of failure
Code violating the rule here
#pragma warning restore NUnit2010 // Use EqualConstraint for better assertion messages in case of failure
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2010 // Use EqualConstraint for better assertion messages in case of failure
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2010:Use EqualConstraint for better assertion messages in case of failure",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

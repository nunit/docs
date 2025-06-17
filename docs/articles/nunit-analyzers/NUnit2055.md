# NUnit2055

## Consider using Is.InstanceOf\<T> constraint instead of an 'is T' expression

| Topic    | Value
| :--      | :--
| Id       | NUnit2055
| Severity | Info
| Enabled  | True
| Category | Assertion
| Code     | [InstanceOfAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.9.2/src/nunit.analyzers/InstanceOf/InstanceOfAnalyzer.cs)

## Description

Consider using `Is.InstanceOf<T>` instead of 'is T' expression for better assertion messages.

## Motivation

Using the `Is.InstanceOf<T>` (or `Is.Not.InstanceOf<T>`) constraint will lead to better assertion messages
when a test fails. This analyzer identifies usages of the `is` operator that can be replaced with
`Is.InstanceOf<T>` to improve the quality of assertion messages.

```csharp
[Test]
public void Test()
{
    Assert.That(instance1 is SomeType);
    Assert.That(instance2 is AnotherType, Is.True);
    Assert.That(instance3 is ThirdType, Is.False);
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `Assert.That(instance is SomeType, Is.True)`
and `Assert.That(instance is SomeType)` into `Assert.That(instance, Is.InstanceOf<SomeType>())`
and similarly replace `Assert.That(instance is SomeType, Is.False)` into
``Assert.That(instance, Is.Not.InstanceOf<SomeType>())``. So the code block above will be changed into

```csharp
[Test]
public void Test()
{
    Assert.That(instance1, Is.InstanceOf<SomeType>());
    Assert.That(instance2, Is.InstanceOf<AnotherType>());
    Assert.That(instance3, Is.Not.InstanceOf<ThirdType>());
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2055: Consider using Is.InstanceOf<T> constraint instead of an 'is T' expression
dotnet_diagnostic.NUnit2055.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2055 // Consider using Is.InstanceOf<T> constraint instead of an 'is T' expression
Code violating the rule here
#pragma warning restore NUnit2055 // Consider using Is.InstanceOf<T> constraint instead of an 'is T' expression
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2055 // Consider using Is.InstanceOf<T> constraint instead of an 'is T' expression
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2055:Consider using Is.InstanceOf<T> constraint instead of an 'is T' expression",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

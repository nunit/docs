# NUnit2049

## Consider using Assert.That(...) instead of CollectionAssert(...)

| Topic    | Value
| :--      | :--
| Id       | NUnit2049
| Severity | Warning
| Enabled  | True
| Category | Assertion
| Code     | [CollectionAssertUsageAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.9.2/src/nunit.analyzers/CollectionAssertUsage/CollectionAssertUsageAnalyzer.cs)

## Description

Consider using the constraint model, `Assert.That(actual, {0}(expected))`, instead of the classic model,
`CollectionAssert.{1}(expected, actual)`.

## Motivation

The classic Assert model contains less flexibility than the constraint model and makes it easy to mix the order of the
parameters, so this analyzer marks usages of all `CollectionAssert` methods from the classic Assert model.

```csharp
[Test]
public void Test()
{
    CollectionAssert.AllItemsAreInstancesOfType(collection, expected);
    CollectionAssert.AllItemsAreNotNull(collection);
    CollectionAssert.AllItemsAreUnique(collection);
    CollectionAssert.AreEqual(expected, actual);
    CollectionAssert.AreEquivalent(expected, actual);
    CollectionAssert.AreNotEqual(expected, actual);
    CollectionAssert.AreNotEquivalent(expected, actual);
    CollectionAssert.Contains(collection, expected);
    CollectionAssert.DoesNotContain(collection, expected);
    CollectionAssert.IsNotSubsetOf(subset, superset);
    CollectionAssert.IsSubsetOf(subset, superset);
    CollectionAssert.IsNotSupersetOf(superset, subset);
    CollectionAssert.IsSupersetOf(superset, subset);
    CollectionAssert.IsEmpty(collection);
    CollectionAssert.IsNotEmpty(collection);
    CollectionAssert.IsOrdered(collection);
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `StringAssert.<method>(expected, actual)` with
`Assert.That(actual, <constraint>(expected))`. So the code block above will be changed into.

```csharp
[Test]
public void Test()
{
    Assert.That(collection, Is.All.InstanceOf(expected));
    Assert.That(collection, Is.All.Not.Null);
    Assert.That(collection, Is.Unique);
    Assert.That(actual, Is.EqualTo(expected).AsCollection);
    Assert.That(actual, Is.EquivalentTo(expected));
    Assert.That(actual, Is.Not.EqualTo(expected).AsCollection);
    Assert.That(actual, Is.Not.EquivalentTo(expected));
    Assert.That(collection, Has.Member(expected));
    Assert.That(collection, Has.No.Member(expected));
    Assert.That(subset, Is.Not.SubsetOf(superset));
    Assert.That(subset, Is.SubsetOf(superset));
    Assert.That(superset, Is.Not.SupersetOf(subset));
    Assert.That(superset, Is.SupersetOf(subset));
    Assert.That(collection, Is.Empty);
    Assert.That(collection, Is.Not.Empty);
    Assert.That(collection, Is.Ordered);
}
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit2049: Consider using Assert.That(...) instead of CollectionAssert(...)
dotnet_diagnostic.NUnit2049.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2049 // Consider using Assert.That(...) instead of CollectionAssert(...)
Code violating the rule here
#pragma warning restore NUnit2049 // Consider using Assert.That(...) instead of CollectionAssert(...)
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2049 // Consider using Assert.That(...) instead of CollectionAssert(...)
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2049:Consider using Assert.That(...) instead of CollectionAssert(...)",
    Justification = "Reason...")]
```
<!-- end generated config severity -->

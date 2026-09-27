---
uid: attribute-dependsonfixture
---

# DependsOnFixture

Added in **NUnit 5.0**.

`DependsOnFixtureAttribute` specifies that a fixture must run after another
fixture. By default, the referenced fixture must run and pass before the
dependent fixture can run. This can be overridden by setting `AllowFailure`
to `true`.

## Constructor

```csharp
DependsOnFixtureAttribute(Type dependencyFixture)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `dependencyFixture` | `Type` | The fixture that must finish before the current fixture starts. |

## Properties

| Property | Type | Description | Default |
|----------|------|-------------|---------|
| `AllowFailure` | `bool` | Allows the current fixture to run even if the dependency fixture fails. | `false` |

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ❌ | ✅ | ❌ |

## Example

[!code-csharp[DependsOnFixture](~/snippets/Snippets.NUnit/Attributes/DependsOnFixtureAttributeExamples.cs#DependsOnFixture)]

## Notes

1. If the dependency fixture fails, the dependent fixture is marked
   **Skipped** by default.
2. If `AllowFailure = true`, NUnit still runs the dependent fixture even when
   the dependency fixture fails.
3. Misconfiguration—such as referencing a fixture that is not present in the
   current run, creating a circular dependency, using `[Order]` anywhere in
   the same dependency chain, or configuring fixtures in that dependency chain
   for parallel execution—causes the affected fixtures to be marked
   **Failed** as invalid.

### Automatic Inclusion

A test run which filters out some tests may cause a dependency to be filtered out from a test which is intended to run. This can most commonly happen when developing in an IDE like Visual Studio and a test method is clicked on to "Run Test". This might always cause the target test to fail because the dependency is filtered out and never run. To fix this, test dependencies are always included in a run when they are a dependency for a test also in the run.

This can produce unexpected results when combined with _test partitioning_ as it might be possible for a test dependency to be automatically included in multiple shards, effectively running the test twice.

## See Also

* [DependsOnTest Attribute](xref:attribute-dependsontest)
* [Order Attribute](xref:attribute-order)
* [Parallelizable Attribute](xref:attribute-parallelizable)

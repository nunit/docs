---
uid: attribute-dependsontest
---

# DependsOnTest

Added in **NUnit 5.0**.

`DependsOnTestAttribute` specifies that a test must run after another test. By
default, the referenced test must run and pass before the dependent test can
run.  This can be overridden by setting `AllowFailure` to `true`.

## Constructor

```csharp
DependsOnTestAttribute(string testName)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `testName` | `string` | The name of the test that must finish before the current test starts. |

In order to avoid mismatches prefer to use `nameof(mytest)`, where `mytest` is the method name of the test.
See examples below.
## Properties

| Property | Type | Description | Default |
|----------|------|-------------|---------|
| `AllowFailure` | `bool` | Allows the current test to run even if the dependency test fails. | `false` |

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ✅ | ❌ | ❌ |

## Example

[!code-csharp[DependsOnTest](~/snippets/Snippets.NUnit/Attributes/DependsOnTestAttributeExamples.cs#DependsOnTest)]

## Notes

1. If the dependency test fails, the dependent test is marked **Skipped** by
   default.
2. If `AllowFailure = true`, NUnit still runs the dependent test even when the
   dependency test fails.
3. Misconfiguration—such as referencing a test that is not present in the
   current run, creating a circular dependency, using `[Order]` anywhere in
   the same dependency chain, or configuring tests in that dependency chain for
   parallel execution—causes the affected tests to be marked **Failed** as
   invalid.
4. Use `nameof(...)` where possible so dependency names stay aligned with test
   method renames.

## See Also

* [DependsOnFixture Attribute](xref:attribute-dependsonfixture)
* [Order Attribute](xref:attribute-order)
* [Parallelizable Attribute](xref:attribute-parallelizable)

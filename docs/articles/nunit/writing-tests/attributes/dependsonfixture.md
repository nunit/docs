---
uid: attribute-dependsonfixture
---

# DependsOnFixture

Added in **NUnit 5.0**.

`DependsOnFixtureAttribute` specifies that a fixture must run after another
fixture. By default, the referenced fixture must run and pass before the
dependent fixture can run.

## Constructor

```csharp
DependsOnFixtureAttribute(Type dependantFixture)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `dependantFixture` | `Type` | The fixture that must finish before the current fixture starts. |

## Properties

| Property | Type | Description | Default |
|----------|------|-------------|---------|
| `AllowFailure` | `bool` | Allows the current fixture to run even if the dependency fixture fails. | `false` |

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ❌ | ✅ | ❌ |

## Example

```csharp
[TestFixture]
public class DatabaseFixture
{
    [Test]
    public void CreateSchema()
    {
    }
}

[TestFixture]
[DependsOnFixture(typeof(DatabaseFixture))]
public class ReportingFixture
{
    [Test]
    public void GenerateReport()
    {
    }
}

[TestFixture]
[DependsOnFixture(typeof(DatabaseFixture), AllowFailure = true)]
public class CleanupFixture
{
    [Test]
    public void RemoveTemporaryFiles()
    {
    }
}
```

## Notes

1. If the dependency fixture fails, the dependent fixture is marked
   **Skipped** by default.
2. If `AllowFailure = true`, NUnit still runs the dependent fixture even when
   the dependency fixture fails.
3. Misconfiguration—such as referencing a fixture that is not present in the
   current run, creating a circular dependency, or combining the dependency
   chain with `[Order]` or `[Parallelizable]`—causes the affected fixtures to
   be marked **Failed** as invalid.
4. `DependsOnFixture` is an explicit dependency mechanism and is generally a
   better fit than numeric ordering when one fixture truly depends on another.

## See Also

* [DependsOnTest Attribute](xref:attribute-dependsontest)
* [Order Attribute](xref:attribute-order)
* [Parallelizable Attribute](xref:attribute-parallelizable)

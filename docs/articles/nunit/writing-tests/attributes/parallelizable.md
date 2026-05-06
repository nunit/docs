---
uid: attribute-parallelizable
---

# Parallelizable

Added in **NUnit 3.7**.

The `ParallelizableAttribute` marks an assembly, fixture, or method (and optionally its descendants) as eligible for parallel execution. By default, tests are not parallel.

When used without an argument, scope defaults to `ParallelScope.Self`.

## Constructors

```csharp
ParallelizableAttribute()
ParallelizableAttribute(ParallelScope scope)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `scope` | `ParallelScope` | Controls what may run in parallel for this node and descendants. Defaults to `Self`. |

## Properties

| Property | Type | Description | Default |
|----------|------|-------------|---------|
| `Scope` | `ParallelScope` | Same as constructor `scope`. | `ParallelScope.Self` |

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ✅ | ✅ | ✅ |

> [!WARNING]
> When tests are run in parallel, you are responsible for the thread safety of your tests. Tests that run at
> the same time and modify instance fields or properties without locks will cause unexpected behavior as they would in
> any multi-threaded program. If you are using fields or properties between parallel tests consider using the
> [`FixtureLifeCycleAttribute`](xref:attribute-fixturelifecycle) to construct a new instance of a test fixture (class)
> for each test that is run.

Named argument form:

```csharp
[Parallelizable(scope: ParallelScope.All)]
```

## ParallelScope Enumeration

`ParallelScope` is a **[Flags]** enumeration. It applies to the attributed test and its subordinates. User-visible values:

| Value | Meaning | Valid On |
| --- | --- | --- |
| `ParallelScope.Self` | the test itself may be run in parallel with other tests | Classes, Methods |
| `ParallelScope.Children` | child tests may be run in parallel with one another | Assembly, Classes |
| `ParallelScope.Fixtures` | fixtures may be run in parallel with one another | Assembly, Classes |
| `ParallelScope.All` | the test and its descendants may be run in parallel with others at the same level | Classes, Methods |

## Notes

* Some values are invalid on certain elements, although they will compile. NUnit will report any tests so marked as
  invalid and will produce an error message.

* The `ParallelScope` enum has additional values, which are used internally but are not visible to users through
  Intellisense.

* The `ParallelizableAttribute` may be specified on multiple levels of the tests. Settings at a higher level may affect
  lower level tests, unless those lower-level tests override the inherited settings.

## See Also

* [FixtureLifeCycle Attribute](xref:attribute-fixturelifecycle)
* [NonParallelizable Attribute](xref:attribute-nonparallelizable)
* [LevelOfParallelism Attribute](xref:attribute-levelofparallelism)

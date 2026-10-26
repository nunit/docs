---
uid: attribute-parallelizable
---

# Parallelizable

Added in **NUnit 3.7**.

The `ParallelizableAttribute` marks an assembly, fixture, or method (and optionally its descendants) as eligible for parallel execution. By default, tests are not parallel.

When used without an argument, scope defaults to `ParallelScope.Self`.

> [!TIP]
> This page describes the attribute. For the common questions, such as how to turn parallel execution on, what to
> do about state shared between tests, and how to run fixtures in parallel while keeping each fixture's tests in
> order, see [Running Tests in Parallel](xref:paralleltests). How NUnit schedules parallel work is described in
> [Framework Parallel Test Execution](../../technical-notes/usage/Framework-Parallel-Test-Execution.md).

## Constructors

```csharp
ParallelizableAttribute()
ParallelizableAttribute(ParallelScope scope)
```

| Parameter | Type            | Description                                                                          |
| --------- | --------------- | ------------------------------------------------------------------------------------ |
| `scope`   | `ParallelScope` | Controls what may run in parallel for this node and descendants. Defaults to `Self`. |

## Properties

| Property | Type            | Description                  | Default              |
| -------- | --------------- | ---------------------------- | -------------------- |
| `Scope`  | `ParallelScope` | Same as constructor `scope`. | `ParallelScope.Self` |

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
| ------------ | ----------------------- | -------- |
| ✅           | ✅                      | ✅       |

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

`ParallelScope` is a `[Flags]` enumeration. It applies to the attributed test and its subordinates. User-visible values:

| Value                    | Meaning                                                                           | Valid On          |
| ------------------------ | --------------------------------------------------------------------------------- | ----------------- |
| `ParallelScope.Self`     | the test itself may be run in parallel with other tests                           | Classes, Methods  |
| `ParallelScope.Children` | child tests may be run in parallel with one another                               | Assembly, Classes, parameterized test methods |
| `ParallelScope.Fixtures` | fixtures may be run in parallel with one another                                  | Assembly, Classes |
| `ParallelScope.All`      | the test and its descendants may be run in parallel with others at the same level | Classes, parameterized test methods |

## Notes

* Some values are invalid on certain elements, although they will compile. NUnit will report any tests so marked as
  invalid and will produce an error message. On a test method that is not parameterized, only `ParallelScope.Self`
  is valid. On a parameterized test method, such as one with `[TestCase]` or `[TestCaseSource]`, `Children` or `All`
  lets the individual test cases run in parallel with one another.

* The `ParallelScope` enum has additional values, which are used internally but are not visible to users through
  Intellisense.

* The `ParallelizableAttribute` may be specified on multiple levels of the tests. Settings at a higher level may affect
  lower level tests, unless those lower-level tests override the inherited settings.

## See Also

* [Running Tests in Parallel](xref:paralleltests)
* [Framework Parallel Test Execution](../../technical-notes/usage/Framework-Parallel-Test-Execution.md)
* [FixtureLifeCycle Attribute](xref:attribute-fixturelifecycle)
* [NonParallelizable Attribute](xref:attribute-nonparallelizable)
* [LevelOfParallelism Attribute](xref:attribute-levelofparallelism)

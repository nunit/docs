---
uid: dependenttests
---

# Tests That Depend on Other Tests

Most tests should be independent: each one sets up what it needs and can run on its own, in any order. Sometimes,
though, tests really do depend on each other. An integration test may need an order to exist before it can ship it, or
a cleanup step must run after the tests that use a shared resource.

NUnit 5 lets you say this directly with [`[DependsOnTest]`](xref:attribute-dependsontest) and
[`[DependsOnFixture]`](xref:attribute-dependsonfixture).

> [!NOTE]
> Test dependencies were added in NUnit 5.0.

## Depending on another test

Put `[DependsOnTest]` on a test, with the name of the test it depends on. Use `nameof`, so the dependency still works
when the test is renamed.

[!code-csharp[DependentTests](~/snippets/Snippets.NUnit/WritingTestsGuideExamples.cs#DependentTests)]

- `ShipOrder` runs only after `CreateOrder` has finished. If `CreateOrder` fails, `ShipOrder` is **skipped** instead of
  failing with a confusing error.
- `CleanUpOrders` sets `AllowFailure = true`, so it runs even if `ShipOrder` failed. This is the pattern for cleanup
  that must always happen.

## Depending on another fixture

When a whole class of tests depends on another class, put [`[DependsOnFixture]`](xref:attribute-dependsonfixture) on
the class, with the type of the fixture it depends on. It works the same way: the dependent fixture waits for the other
fixture, and is skipped if that fixture fails, unless `AllowFailure` is set.

## Things to keep in mind

- Tests in a dependency chain can't run in parallel with each other. Don't mark them
  [`[Parallelizable]`](xref:attribute-parallelizable).
- Don't combine dependencies with [`[Order]`](xref:attribute-order) in the same chain. `[DependsOnTest]` and
  `[DependsOnFixture]` replace `[Order]` for most uses, and `[Order]` is deprecated.
- A circular dependency, or another invalid setup, marks the affected tests as failed, with a message that explains the
  problem.

See the [DependsOnTest](xref:attribute-dependsontest) and [DependsOnFixture](xref:attribute-dependsonfixture) reference
pages for all the details.

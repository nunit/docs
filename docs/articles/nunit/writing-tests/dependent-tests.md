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

A test can only depend on another test in the same fixture, including tests the fixture inherits from a base class.
NUnit looks up the name among the tests of that fixture only, so a test in another fixture is not found. There is no way
to depend on a single test in another fixture. Use `[DependsOnFixture]`, described below, to make a whole fixture wait
for all tests in another fixture. A test has at most one `[DependsOnTest]`, but several tests can depend on the same
test. If the named test is not found, the dependent test fails as invalid.

[!code-csharp[DependentTests](~/snippets/Snippets.NUnit/WritingTestsGuideExamples.cs#DependentTests)]

- `ShipOrder` runs only after `CreateOrder` has finished. If `CreateOrder` fails, `ShipOrder` is **skipped** instead of
  failing with a confusing error.
- `CleanUpOrders` sets `AllowFailure = true`, so it runs even if `ShipOrder` failed. This is the pattern for cleanup
  that must always happen.

## Depending on another fixture

When a whole class of tests depends on another class, put [`[DependsOnFixture]`](xref:attribute-dependsonfixture) on
the class, with the type of the fixture it depends on. It works the same way: the dependent fixture waits for the other
fixture, and is skipped if that fixture fails, unless `AllowFailure` is set.

The dependency is always the whole fixture: the dependent fixture waits for all tests in it. A fixture can only depend on
another fixture in the same namespace. NUnit looks up the type among the fixtures directly in that namespace only, so a
fixture in a parent, child or other namespace is not found. A fixture has at most one
`[DependsOnFixture]`, but several fixtures can depend on the same fixture. If the named fixture is not found, the
dependent fixture fails as invalid. A fixture can't depend on its own base class.

[!code-csharp[DependentFixtures](~/snippets/Snippets.NUnit/DependentFixtureExamples.cs#DependentFixtures)]

- `SeedDatabaseTests` has no dependency, so it runs first and fills the shared `CustomerDatabase`.
- `CustomerReportTests` starts only after **all** tests in `SeedDatabaseTests` have finished. If any of them fails, the
  fixture fails, and **every** test in `CustomerReportTests` is skipped, with a message that names the failed
  dependency.
- `CleanUpDatabaseTests` depends on `CustomerReportTests` with `AllowFailure = true`. It runs last, even if a report
  test failed, so the shared data is always removed.
- Dependencies chain: `CleanUpDatabaseTests` waits for `CustomerReportTests`, which waits for `SeedDatabaseTests`.
  When you run only a dependent fixture, for example from your IDE, NUnit still includes the fixture it depends on.

## Things to keep in mind

- Tests in a dependency chain can't run in parallel with each other. Don't mark them
  [`[Parallelizable]`](xref:attribute-parallelizable).
- Don't combine dependencies with [`[Order]`](xref:attribute-order) in the same chain. `[DependsOnTest]` and
  `[DependsOnFixture]` replace `[Order]` for most uses, and `[Order]` is deprecated.
- A circular dependency, or another invalid setup, marks the affected tests as failed, with a message that explains the
  problem.

See the [DependsOnTest](xref:attribute-dependsontest) and [DependsOnFixture](xref:attribute-dependsonfixture) reference
pages for all the details.

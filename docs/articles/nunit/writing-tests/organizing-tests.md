---
uid: organizingtests
---

# Organizing and Selecting Tests

As a test suite grows, you often want to run only part of it: the fast tests on every build, the integration tests at
night, or the one test you are working on. NUnit lets you group tests, and then choose which groups to run.

## Grouping tests with categories

Put [`[Category]`](xref:attribute-category) on a test or a fixture. A test can be in several categories, and it
inherits the categories of its fixture.

[!code-csharp[OrganizingCategories](~/snippets/Snippets.NUnit/WritingTestsGuideExamples.cs#OrganizingCategories)]

## Running only some categories

With `dotnet test`, filter on `TestCategory`:

```shell
# Only the integration tests
dotnet test --filter "TestCategory=Integration"

# Everything except the slow tests
dotnet test --filter "TestCategory!=Slow"
```

With the [NUnit console](xref:consolecommandline), use `--where` with the
[Test Selection Language](xref:testselectionlanguage), which can also select tests by name, class, namespace or
property:

```shell
nunit3-console MyTests.dll --where "cat == Integration && cat != Slow"
```

The same expressions work with `dotnet test` through the `NUnit.Where` setting, for example
`dotnet test -- NUnit.Where="cat == Integration"`. See [Configuring with .runsettings](xref:tipsandtricks) for all the
settings.

## Tests that run only on demand

Mark a test with [`[Explicit]`](xref:attribute-explicit) when it should run only when you select it yourself, for
example a test that rebuilds a database. It is skipped when you run all the tests.

## Tests that must not run for now

Mark a test with [`[Ignore]`](xref:attribute-ignore) when it can't run at the moment, and give the reason. Ignored tests
show up as warnings, so they are not forgotten. With `Until`, the test starts running again after the given date.

[!code-csharp[OrganizingExplicitIgnore](~/snippets/Snippets.NUnit/WritingTestsGuideExamples.cs#OrganizingExplicitIgnore)]

> [!TIP]
> If a project contains only explicit tests, running the project runs all of them, because the adapter can't tell that
> apart from selecting them yourself. See [Explicit](xref:attribute-explicit) for details.

## See also

- [Test Selection Language](xref:testselectionlanguage)
- [Console Command Line](xref:consolecommandline)
- The [Category](xref:attribute-category), [Explicit](xref:attribute-explicit) and [Ignore](xref:attribute-ignore)
  reference pages

---
uid: attribute-explicit
---

# Explicit

`ExplicitAttribute` marks a test, fixture, or assembly so it is **not** run merely because an enclosing suite ran. It
runs only when it is **explicitly selected**—for example by choosing that test or fixture by name, or by using a filter
that counts as an explicit match for it.

A filter that **excludes** tests (often written with **not**, such as `--where test!=My.Fixture`) is **not** treated as
explicitly selecting what is left behind, so explicit tests remain skipped unless you chose them via a positive
selection (direct name selection or filters that affirmatively match the test or a suite it lives under). The
command-line examples below show forms that include or exclude explicit tests.

You can pass an optional **reason** string; when the test is skipped as explicit, runners may show that text.

If an explicit item is executed as part of a broad “run everything” session but was never explicitly selected, NUnit skips
it with an **explicit** result. That outcome does not fail the run or count as an ordinary failure. Presentation in the UI
(or console summary) varies by runner.

## Constructors

```csharp
ExplicitAttribute()
ExplicitAttribute(string reason)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `reason` | `string` | Optional reason shown in skip output. |

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ✅ | ✅ | ✅ |

> [!WARNING]
> While the C# syntax allows you to place an Explicit attribute on a SetUpFixture class, the attribute is
> ignored by NUnit and has no effect in current releases.

## Examples of Use

Using the console command-line to select tests, the following options will include any explicit tests that fall under
the selection.

```none
    --test=My.Namespace.Fixture.Method
    --test=My.Namespace.Fixture
    --test=My.Namespace
    --where test==My.Namespace.Fixture.Method
    --where test==My.Namespace.Fixture
    --where test==My.Namespace
    --where cat==X
    --where "cat==X || cat==Y"
```

However, the following options will **not** include explicit tests

```none
    --where test!=My.Namespace.Fixture
    --where cat!=X
```

## TRAP

If a project contains only explicit tests, running the test project will execute all tests, as  it is treated as an
explicit test run. To prevent this, ensure the project includes at least one non-explicit test, even if it's just a
dummy test.

From [this issue](https://github.com/nunit/nunit3-vs-adapter/issues/1223), the following comment explains how the
adapter works with explicit tests:

*"When the adapter is called from the testhost, it receives a list of tests to run. It doesn't know HOW the Test
Explorer is being used. And thus it has no knowledge if there are other tests present that are not selected, OR if the
tests it receives are all the tests in the solution.*

*If all the tests are Explicit it will assume that this is an explicit testrun. When you only have one test, and that
test is explicit, it will be an explicit test run.*

*When you add the second test, which is not explicit, it will see both tests, and since there is a non-explicit test
included, the test is a non-explicit testrun, and all explicit tests will be ignored.*

*If you have a situation with only one explicit test, the work around is to just add another non-explicit test, which
can be empty, or even have a false Assume statement, which will make the test be inconclusive, thus not part of your
results."*

## TRICK

If you want to ensure NO Explicit tests are being run, e.g. a CI build, you can change the ExplicitMode to None.
You can do this either in a .runsettings file, or as a command line parameter

```cmd
dotnet test -- NUnit.ExplicitMode=None
```

(From version 5.2.0)

## Test Fixture Syntax

[!code-csharp[ExplicitFixtureExample](~/snippets/Snippets.NUnit/Attributes/ExplicitAttributeExamples.cs#ExplicitFixtureExample)]

## Test Syntax

[!code-csharp[ExplicitTestExample](~/snippets/Snippets.NUnit/Attributes/ExplicitAttributeExamples.cs#ExplicitTestExample)]

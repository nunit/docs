---
uid: paralleltests
---

# Running Tests in Parallel

Within a test assembly, NUnit runs tests one at a time unless you tell it otherwise. Marking a test
[`[Parallelizable]`](xref:attribute-parallelizable) is enough to have NUnit schedule it on a pool of worker threads,
alongside any other test marked the same way. The attribute is a statement that the test is *able* to run at the same
time as other tests. Making that true is your job, and most of this page is about that. It answers the questions that
come up most often. The attribute reference pages describe each attribute, and
[Framework Parallel Test Execution](../technical-notes/usage/Framework-Parallel-Test-Execution.md) describes how NUnit
schedules the work.

> [!TIP]
> Parallel execution only helps when the tests are independent. Most problems reported with parallel tests turn out to
> be state shared between tests, not a problem with NUnit. See
> [Tests that only fail when run in parallel](#tests-that-only-fail-when-run-in-parallel) before you reach for
> `[NonParallelizable]`.

## Turning parallel execution on

There are two ways to opt in, and choosing between them is the first decision to make.

**Mark fixtures and tests one at a time.** `[Parallelizable]` on a class means the fixture runs alongside other
fixtures while its own tests run in order. `[Parallelizable(ParallelScope.All)]` lets its tests run in parallel with
one another as well. Everything you have not marked keeps running one at a time, so each fixture you mark is one you
have checked.

[!code-csharp[ParallelFixtureSelf](~/snippets/Snippets.NUnit/ParallelTestsGuideExamples.cs#ParallelFixtureSelf)]

**Turn it on for the whole assembly** and mark the exceptions `[NonParallelizable]`. The attribute usually goes in a
file such as `AssemblyInfo.cs` or `GlobalUsings.cs`:

```csharp
using NUnit.Framework;

[assembly: Parallelizable(ParallelScope.Fixtures)]
```

With `ParallelScope.Fixtures`, test fixtures run in parallel with one another, but the tests inside each fixture still
run one at a time. With `ParallelScope.Children`, every fixture and every test runs in parallel with everything else,
unless a fixture or test overrides that with its own attribute. This is the quickest way to get a parallel run, but
not necessarily the safest. Every fixture in the assembly becomes a candidate, including ones written before the
setting existed and ones added later, so a test that shares state shows up later as an intermittent failure rather
than at the moment you turned parallelism on.

Many teams start with the first approach and switch to the second once their fixtures are known to be independent.

NUnit uses as many worker threads as the machine has processors, with a minimum of two. The
[`[LevelOfParallelism]`](xref:attribute-levelofparallelism) assembly attribute changes that number.

## Tests that only fail when run in parallel

A test that passes on its own and fails when run in parallel is almost always sharing something mutable with another
test. The usual suspects are:

- **Fixture instance fields.** By default NUnit creates one instance of your fixture class and runs every test in it
  on that instance. A `[SetUp]` method that assigns a field is overwriting the same field that another test, running on
  another thread, is still using.
- **Static fields and singletons.** A static `HttpClient`, database connection, or browser driver is shared by every
  test in the process, whatever fixture they are in.
- **External resources.** Two tests writing to the same file, the same database table, or the same port.

For fixture instance state, [`[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]`](xref:attribute-fixturelifecycle)
gives each test its own instance of the fixture, so `[SetUp]` and `[TearDown]` work on a resource that no other test
can see. This example creates a session per test, which is also the pattern for a Selenium web driver or any other
object that must not be driven from two threads at once:

[!code-csharp[ParallelInstancePerTestCase](~/snippets/Snippets.NUnit/ParallelTestsGuideExamples.cs#ParallelInstancePerTestCase)]

For static state and external resources, NUnit cannot isolate the tests for you. Either give each test its own copy of
the resource, or mark the tests that need it [`[NonParallelizable]`](xref:attribute-nonparallelizable) so that they run
on their own after all parallel work has finished:

[!code-csharp[ParallelNonParallelizable](~/snippets/Snippets.NUnit/ParallelTestsGuideExamples.cs#ParallelNonParallelizable)]

> [!NOTE]
> `[OneTimeSetUp]` and `[OneTimeTearDown]` run once per fixture even with `InstancePerTestCase`, and must then be
> static. Anything they create is shared by every test in the fixture.

## Running fixtures in parallel but each fixture's tests in order

A fixture is the unit NUnit uses to keep tests in order. `[Parallelizable]` without an argument, which is
`ParallelScope.Self`, means the fixture may run at the same time as other fixtures while its own tests run one after
another. The same applies when the assembly uses `ParallelScope.Fixtures`. If a set of tests shares a resource that
must not be used from two threads at once, keeping those tests in one fixture marked `[Parallelizable]` is the simplest
way to serialize them without slowing down the rest of the run.

## Running the cases of one test in parallel

A test method with `[TestCase]`, `[TestCaseSource]` or `[Values]` arguments is a small suite of test cases. Mark it with
`[Parallelizable(ParallelScope.Children)]` and the cases run in parallel with one another. `ParallelScope.All` does
the same thing on a test method, because the suite itself always runs on its fixture's thread and only the `Children`
part has an effect. Whether the cases also overlap with other tests depends on the fixture. In a fixture that is not
itself parallel, the cases run in parallel with one another and nothing else runs at the same time, not even the
fixture's other tests. In a parallel fixture, the cases share the worker pool with everything else that is eligible.

[!code-csharp[ParallelTestCases](~/snippets/Snippets.NUnit/ParallelTestsGuideExamples.cs#ParallelTestCases)]

On a test method that is not parameterized, that is a plain `[Test]` method with no `[TestCase]`, `[TestCaseSource]` or
`[Values]`, `ParallelScope.Self` is the only valid scope. NUnit reports the test as invalid if you use `Children` or
`All` there, and the NUnit Analyzers flag it at build time as
[NUnit1009](../../nunit-analyzers/NUnit1009.md).

## Keeping a group of fixtures apart from the rest

There is no attribute for a namespace, but a [`[SetUpFixture]`](xref:attribute-setupfixture) applies to every fixture
in its namespace, and its parallel settings apply to them as well. A `[NonParallelizable]` SetUpFixture with
`[Parallelizable]` fixtures inside it runs as a group. Nothing outside the group runs while the group runs, and within
the group the fixtures run in parallel with one another:

[!code-csharp[ParallelGroupIsolated](~/snippets/Snippets.NUnit/ParallelTestsGuideExamples.cs#ParallelGroupIsolated)]

The opposite arrangement, a group that runs in parallel with other groups while its own fixtures run one at a time, is
not something NUnit supports. A `[Parallelizable]` SetUpFixture with `[NonParallelizable]` fixtures inside it does not
do that: every non-parallel fixture in the assembly waits in the same queue and runs one at a time, whatever namespace
it is in. If you need that shape, put the tests that share the resource in one fixture, as described above, or move
each group to its own test project and let the test runner run the projects in parallel. Whether a runner does that by
default is covered in [Parallel execution did not make the run faster](#parallel-execution-did-not-make-the-run-faster).

## Limiting parallelism for one test

[`[LevelOfParallelism]`](xref:attribute-levelofparallelism) sets the number of worker threads for the whole assembly and
cannot be applied to a single fixture or test. To let a parameterized test run its cases in parallel while limiting how
many run at once, for example because each case calls a rate-limited service, throttle inside the test with a static
`SemaphoreSlim`:

[!code-csharp[ParallelThrottle](~/snippets/Snippets.NUnit/ParallelTestsGuideExamples.cs#ParallelThrottle)]

## Parallel execution did not make the run faster

Parallel execution has a cost. For a suite of very fast tests, starting and switching between worker threads can take
longer than the tests themselves, so adding `[Parallelizable]` may make such a run slightly slower rather than faster.
It pays off when the tests spend their time waiting, for a database, a web request, or a browser.

If your solution has several test projects, note that running them in parallel with one another is the job of the test
runner, not of NUnit, and each runner has its own default:

- The NUnit console runner runs each assembly in its own process, in parallel, by default. See
  [Engine Parallel Test Execution](../technical-notes/usage/Engine-Parallel-Test-Execution.md).
- `dotnet test` in its default VSTest mode, and Visual Studio Test Explorer, run one project at a time unless
  `MaxCpuCount` is set in a runsettings file.
- `dotnet test` in Microsoft.Testing.Platform mode, which the .NET 10 SDK uses when `global.json` selects that runner,
  runs test projects in parallel by default, up to the number of processors. `--max-parallel-test-modules` changes the
  limit. See [NUnit and Microsoft.Testing.Platform](../../vs-test-adapter/NUnit-And-Microsoft-Test-Platform.md).

When a project with more than a couple of thousand tests runs much more slowly as a whole than the same tests run in
smaller batches, check the adapter's [`AssemblySelectLimit`](xref:tipsandtricks#assemblyselectlimit) setting before
looking at parallelism.

## See also

- The [Parallelizable](xref:attribute-parallelizable), [NonParallelizable](xref:attribute-nonparallelizable),
  [LevelOfParallelism](xref:attribute-levelofparallelism) and [FixtureLifeCycle](xref:attribute-fixturelifecycle)
  reference pages
- [Framework Parallel Test Execution](../technical-notes/usage/Framework-Parallel-Test-Execution.md), for how NUnit
  schedules parallel and non-parallel work
- [Engine Parallel Test Execution](../technical-notes/usage/Engine-Parallel-Test-Execution.md), for running assemblies
  in parallel with the console runner
- [Preparing and Cleaning Up Tests](xref:setupandteardownguide), for which setup methods run per test and which run
  once

---
uid: setupandteardownguide
---

# Setup and Teardown

Most tests need something prepared before they run: an object to test, a temporary folder, a database connection. Many
also need something cleaned up afterwards. NUnit lets you put this code in separate methods, so each test only
contains what it is actually testing.

There are three levels, depending on how often the code should run:

| Attribute | Runs | Use it for |
|---|---|---|
| [`[SetUp]`](xref:attribute-setup) | Before **each** test | State that every test needs a fresh copy of |
| [`[TearDown]`](xref:attribute-teardown) | After **each** test | Cleaning up what `[SetUp]` or the test created |
| [`[OneTimeSetUp]`](xref:attribute-onetimesetup) | **Once**, before all tests in the class | Expensive resources that the tests can share |
| [`[OneTimeTearDown]`](xref:attribute-onetimeteardown) | **Once**, after all tests in the class | Releasing those shared resources |
| [`[SetUpFixture]`](xref:attribute-setupfixture) | **Once** for a whole namespace, or the whole test assembly | Resources that many test classes share, such as a test server |

## Before and after each test: [SetUp] and [TearDown]

A method marked `[SetUp]` runs before every test in the class, and a method marked `[TearDown]` runs after every
test. This is the one to use by default: each test starts from the same, clean state, and tests can't affect each
other.

[!code-csharp[PerTestSetUpTearDown](~/snippets/Snippets.NUnit/SetUpTearDownGuideExamples.cs#PerTestSetUpTearDown)]

`[TearDown]` also runs when the test fails, and even when `[SetUp]` itself failed halfway. Write it so that it copes
with things that were never created, like the `Directory.Exists` check above.

## Once for all tests in a class: [OneTimeSetUp] and [OneTimeTearDown]

A method marked `[OneTimeSetUp]` runs once, before the first test in the class, and `[OneTimeTearDown]` runs once,
after the last one. Use them for things that are slow to create, such as loading data or starting a service, and that
the tests can safely share.

You can combine the levels. In this example, the product catalog is expensive and only read by the tests, so it is
created once. The shopping cart is cheap and changed by every test, so each test gets a new one:

[!code-csharp[PerFixtureOneTimeSetUp](~/snippets/Snippets.NUnit/SetUpTearDownGuideExamples.cs#PerFixtureOneTimeSetUp)]

> [!WARNING]
> Anything created in `[OneTimeSetUp]` is shared by all tests in the class. If one test changes it, the next test sees
> the change, and the result can depend on the order the tests run in. Only share things the tests don't modify, or
> reset them in `[SetUp]`.

## Once for many classes: [SetUpFixture]

When several test classes need the same expensive setup, such as a test database or a web server, put it in a class
marked `[SetUpFixture]`. Its `[OneTimeSetUp]` method runs once, before any test in the **same namespace** and in its
child namespaces, and its `[OneTimeTearDown]` runs once after all of them.

[!code-csharp[SetUpFixtureForNamespace](~/snippets/Snippets.NUnit/SetUpTearDownGuideExamples.cs#SetUpFixtureForNamespace)]

- The namespace decides which tests the setup fixture covers. A setup fixture **outside any namespace** covers the
  whole test assembly.
- The class must be public and have a default constructor, or be static.
- A setup fixture can only have `[OneTimeSetUp]` and `[OneTimeTearDown]` methods, not `[SetUp]` and `[TearDown]`.

## Which one should I use?

1. **Does each test need its own, fresh copy?** Use `[SetUp]` and `[TearDown]`. This is the safest choice, so start
   here.
2. **Is it slow to create, and do the tests only read it?** Use `[OneTimeSetUp]` and `[OneTimeTearDown]` in the test
   class.
3. **Do several test classes need it?** Use a `[SetUpFixture]` in the namespace that contains those classes, or outside
   any namespace for the whole assembly.
4. **Does every test need to clean up after itself, even when it fails?** Put the cleanup in `[TearDown]` or
   `[OneTimeTearDown]`, not at the end of the test, because the rest of a failing test doesn't run.

## The order everything runs in

For a test class in a namespace with a setup fixture, NUnit runs:

1. `[OneTimeSetUp]` of the setup fixture outside any namespace, if there is one
2. `[OneTimeSetUp]` of the setup fixtures for the namespace, from the outermost namespace inward
3. `[OneTimeSetUp]` of the test class
4. For **each** test: `[SetUp]`, then the test, then `[TearDown]`
5. `[OneTimeTearDown]` of the test class
6. `[OneTimeTearDown]` of the setup fixtures, in the reverse order of step 1 and 2

With inheritance, setup methods in a base class run before those in the derived class, and teardown methods in the
derived class run before those in the base class. If a derived class overrides a base class setup method, only the
override runs, so give the methods different names instead.

If a class has several methods with the same attribute, their order is not defined. Use one method per level, or
spread them over base and derived classes.

## When setup fails

- If **`[SetUp]` fails**, the test doesn't run and is reported as failed. `[TearDown]` still runs.
- If **`[OneTimeSetUp]` fails**, none of the tests in the class run, and they are all reported as failed, with the setup
  error as the reason. `[OneTimeTearDown]` still runs.
- The same applies to a `[SetUpFixture]`: if its `[OneTimeSetUp]` fails, none of the tests it covers run.

## Good to know

- **Async setup:** all of these methods can be `async` and return a `Task`. NUnit waits for them to finish.
- **Constructors and `IDisposable`:** by default, NUnit creates one instance of the test class for all its tests, so
  the constructor runs once, like `[OneTimeSetUp]`. If the class implements `IDisposable`, NUnit calls `Dispose`
  when it is done with the instance. `[SetUp]` and `[TearDown]` make the intent clearer, and work the same way with
  every life cycle.
- **A new instance for each test:** with
  [`[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]`](xref:attribute-fixturelifecycle), NUnit creates a new instance
  of the test class for every test. Fields can then never leak between tests, which also helps when tests run in
  [parallel](xref:attribute-parallelizable). `[OneTimeSetUp]` and `[OneTimeTearDown]` must be static in that case.
- **The current test:** inside `[SetUp]` and `[TearDown]`, [`TestContext.CurrentContext`](xref:testcontext) describes
  the test that is about to run or has just run. In `[TearDown]` you can check its result, for example to save extra
  logs only when a test failed.

## See also

- The [SetUp](xref:attribute-setup), [TearDown](xref:attribute-teardown), [OneTimeSetUp](xref:attribute-onetimesetup),
  [OneTimeTearDown](xref:attribute-onetimeteardown) and [SetUpFixture](xref:attribute-setupfixture) reference pages
- [SetUp and TearDown](setup-teardown/index.md), with more details on inheritance
- [FixtureLifeCycle](xref:attribute-fixturelifecycle)

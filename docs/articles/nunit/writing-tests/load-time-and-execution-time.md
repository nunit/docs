---
uid: loadtimeandexecutiontime
---

# Load Time and Execution Time

NUnit handles a test assembly in two separate phases. First it **loads** the assembly and builds the complete list of
tests it contains. Only then does it **execute** some or all of those tests. Nothing about a test can change once
loading is over, and code that runs in one phase cannot share live objects with code in the other unless you arrange
it deliberately. Most surprises with data sources and custom attributes come down to this split.

## The two phases

| Phase | What NUnit does | Your code that runs |
| ----- | --------------- | ------------------- |
| **Load time**, also called *discovery* | Loads the assembly, finds the test classes and methods, reads every NUnit attribute, collects or generates every argument, and builds the internal tree of fixtures and test cases. Runners use this tree to display, count and select tests. | Members named by [`[TestCaseSource]`](xref:attribute-testcasesource), [`[ValueSource]`](xref:attribute-valuesource), [`[TestFixtureSource]`](xref:attribute-testfixturesource) and [`[DatapointSource]`](xref:attribute-datapointsource); source classes used by those attributes; static constructors and field initializers that those members touch; and the load-time interfaces of [custom attributes](xref:customattributes). |
| **Execution time** | Runs the selected tests and reports their results. | Fixture constructors, [`[SetUpFixture]`](xref:attribute-setupfixture) methods, [`[OneTimeSetUp]`](xref:attribute-onetimesetup), [`[SetUp]`](xref:attribute-setup), the test bodies, [`[TearDown]`](xref:attribute-teardown) and [`[OneTimeTearDown]`](xref:attribute-onetimeteardown). |

Charlie Poole, NUnit's original author, suggests imagining that execution takes place about a century after loading.
By the time the first test runs, everything load-time code did is finished and gone, except for the tests it
produced.

## What this means for your tests

### The test tree is fixed before execution starts

Every test case, including the value of every argument, exists before the first `[OneTimeSetUp]` runs. Changing the
data behind a source later, for example in `[SetUp]`, has no effect, because NUnit has already read it:

[!code-csharp[DataIsFixedBeforeSetUp](~/snippets/Snippets.NUnit/LoadTimeExecutionTimeExamples.cs#DataIsFixedBeforeSetUp)]

For the same reason, state created in `[OneTimeSetUp]`, in a `[SetUpFixture]` or in a fixture constructor does not
exist yet when a data source runs. A source that reads such state sees `null` or default values, or throws.

### Arguments are not copied

NUnit does not serialize, clone or marshal the arguments it collected at load time. A test receives exactly the
objects that the source created during the load that produced that test. If a test and your setup code appear to
hold two different copies of an object, the object was created twice, by code that ran in both phases. The
[worked example](#a-worked-example-the-listener-that-never-hears-anything) below shows how that happens.

### Load-time code can run more than once

* A source member is evaluated once for **every attribute that names it**. Two test methods that share one
  `[TestCaseSource]` run the source twice.
* Sources run for **every test in the assembly**, even when you run a single test, because NUnit must build the whole
  tree before a runner can select from it. The Visual Studio adapter's [PreFilter](xref:tipsandtricks#prefilter)
  setting can narrow this down.
* Some runners load the assembly more than once per run, so all load-time code runs again from scratch, in a fresh
  process. See [How often is an assembly loaded?](#how-often-is-an-assembly-loaded) below.

A data source must therefore be **repeatable**: for the same code, it must return the same cases, with the same
names and arguments, in the same order, every time it runs.

* Do not use `System.Random`, `DateTime.Now`, `Guid.NewGuid()` or anything else that varies between calls. A test
  case whose name or arguments differ between two loads cannot be matched by the runner, so a test selected from one
  load may not exist in the next. If you need random arguments, use the [Random](xref:attribute-random) attribute.
  Its values come from NUnit's seeded [Randomizer](xref:randomizermethods), so a run can be reproduced with the same
  seed.
* Avoid side effects, such as incrementing a static counter or registering objects in a static collection. Every
  evaluation of the source repeats them.
* Keep sources cheap. Work done in a source is paid for every method that uses it, and on every load.

### Live objects belong in setup, not in sources

Anything that must be alive while a test runs, such as an event subscription, a listener, an open connection or a
shared service, should be created at execution time: in `[OneTimeSetUp]`, in a `[SetUpFixture]`, in `[SetUp]` or
in the test itself. Use test data to describe *which* case to run, and let the test resolve the live object when it
executes.

## A worked example: the listener that never hears anything

This scenario was reported in [nunit/docs#996](https://github.com/nunit/docs/issues/996). A `[SetUpFixture]`
creates a shared event bus and subscribes a listener to it. A test publishes a message to a bus it received as an
argument, and the listener never hears it:

[!code-csharp[ListenerAttachedAtExecutionTimeToAnotherBus](~/snippets/Snippets.NUnit/LoadTimeExecutionTimeExamples.cs#ListenerAttachedAtExecutionTimeToAnotherBus)]

It is tempting to explain this as the bus being copied on its way from discovery to execution. That is not what
happens. When the source runs, `TestEnvironment.Bus` is still `null`, because `[OneTimeSetUp]` has not run yet, so
the source creates a bus of its own. That object is what the test receives. The bus with the listener is a second,
unrelated instance, created later, at execution time. Nothing was copied or lost in transit. The code ran in both
phases and created an object each time.

The fix is to keep the source to plain data and to create everything that must be live at execution time:

[!code-csharp[ListenerAndBusBothAtExecutionTime](~/snippets/Snippets.NUnit/LoadTimeExecutionTimeExamples.cs#ListenerAndBusBothAtExecutionTime)]

## Sharing expensive state between a source and the tests

Sometimes a source genuinely needs a service, for instance to enumerate the cases from a database, and the tests need
the same service. Setup methods cannot provide it, because they run too late. Instead, initialize the service lazily,
so that whichever side touches it first creates it:

[!code-csharp[LazySharedState](~/snippets/Snippets.NUnit/LoadTimeExecutionTimeExamples.cs#LazySharedState)]

Within one load of the assembly, the source and the tests then share one instance. A runner may still load the
assembly more than once, so the initializer can run more than once per run. Keep it free of side effects that cannot
be repeated.

## How often is an assembly loaded?

How many times the loading phase happens depends on the runner, not on NUnit. Write your sources so that it does not
matter.

| Runner | Loads per run |
| ------ | ------------- |
| NUnit Console, NUnitLite | Once. The tests are built and then run in the same process. |
| `dotnet test`; Visual Studio with real-time test discovery on | Once. The adapter explores and then runs the same loaded tests. |
| Visual Studio with real-time test discovery off | Twice. Test Explorer loads the assembly in one test host to discover the tests, and each run loads it again in a new test host. |

See [Discovery and execution in the adapter](xref:vstestadapterusage#discovery-and-execution) for the details and
their practical consequences.

## Writing your own attributes

The same split applies to attributes you write yourself, with some extra rules about state kept in attribute
instances. See [Custom Attributes](xref:customattributes).

## See also

* [Data Driven Tests](xref:datadriventests)
* [Parameterized Tests](xref:parameterizedtests)
* [Preparing and Cleaning Up Tests](xref:setupandteardownguide)
* [TestCaseSource](xref:attribute-testcasesource), [ValueSource](xref:attribute-valuesource) and
  [TestFixtureSource](xref:attribute-testfixturesource)

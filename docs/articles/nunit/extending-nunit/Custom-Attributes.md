---
uid: customattributes
---

# Custom Attributes

NUnit implements a great deal of its functionality in its attributes. This functionality is accessed through a number
of standard interfaces, which are implemented by the attributes. Users may create their own attributes by implementing
these interfaces.

The interfaces fall into two groups, according to the stage in the life-cycle of a test at which NUnit calls them:
**load time** and **execution time**. The grouping is more than a convenience. Which group an interface belongs to
decides what an attribute implementing it can and cannot do, so it pays to understand the split before choosing an
interface. [Load Time and Execution Time](xref:loadtimeandexecutiontime) explains the split from the test writer's
point of view. This page covers what it means for attribute authors.

## Load-Time Interfaces

_Loading_ tests means loading the assembly into memory and examining its content to discover the classes and methods
that represent tests. NUnit builds its internal representation of every test at this time, including the arguments
of every test case. If requested by the runner, information about the tests is returned for display, as the Visual
Studio Test Explorer and the NUnit GUI do.

The following interfaces are called at load time.

| Interface                                                 | Used By                                                                                      |
| --------------------------------------------------------- | -------------------------------------------------------------------------------------------- |
| [IFixtureBuilder](IFixtureBuilder-Interface.md)           | Attributes that know how to build a fixture from a test class                                |
| [ITestBuilder](ITestBuilder-Interface.md)                 | Attributes that know how to build one or more parameterized test cases for a method          |
| [ISimpleTestBuilder](ISimpleTestBuilder-Interface.md)     | Attributes that know how to build a single non-parameterized test case for a method          |
| [IParameterDataSource](IParameterDataSource-Interface.md) | Attributes that supply values for a single parameter for use in generating test cases        |
| [IImplyFixture](IImplyFixture-Interface.md)               | Attributes used on a method to signal that the defining class should be treated as a fixture |
| [IApplyToTest](IApplyToTest-Interface.md)                 | Attributes that make modifications to a test immediately after it is constructed             |

Load-time code decides **what the tests are**: which tests exist, what they are called, which arguments they receive,
and which properties, categories and run states they carry. Everything it decides is final once loading completes.

Load-time code cannot:

* **Affect a running test directly.** No load-time interface is called again once the tests are built. Whatever the
  test needs at execution time must already be stored on the `Test` object, in its arguments or in its `Properties`,
  or be created at execution time by one of the interfaces below.
* **Rely on execution-time state.** Nothing created by fixture constructors, `[OneTimeSetUp]`, `[SetUpFixture]` or
  `[SetUp]` methods exists yet. Those all run later.
* **Hand live objects to the execution phase.** An object a builder creates and passes as an argument is created at
  load time. The test receives that same object, not a copy, but if the runner loads the assembly more than once the
  builder runs again and creates a new one. Anything else that was attached to the first object, such as an event
  subscription made elsewhere, is not attached to the second.

## Execution-Time Interfaces

At execution time, some or all of the tests that were previously loaded are actually run. Their results are returned
and made available to the runner.

The following interfaces are called at execution time.

| Interface                                       | Used By                                                       |
| ----------------------------------------------- | ------------------------------------------------------------- |
| [IApplyToContext](IApplyToContext-Interface.md) | Attributes that set up the context prior to execution         |
| [ICommandWrapper](ICommandWrapper-Interface.md) | Attributes that can wrap a `TestCommand` with another command |

[Action Attributes](xref:actionattributes) and [Execution Hooks](Execution-Hooks.md) also run at execution time.

Execution-time code is the right place for anything that must be alive while the test runs: event subscriptions,
listeners, connections, shared services and anything else with a lifetime. It has access to the test's arguments and
properties, which load-time code prepared for it, and to the `TestExecutionContext`.

## Rules for attribute authors

1. **Do not keep state in attribute instances.** NUnit obtains attributes through reflection, and it may ask for them
   more than once. Each request creates new attribute instances. An attribute that implements both `ITestBuilder` and
   `IApplyToTest`, for example, can be called on two different instances: one when the tests are built and another
   when attributes are applied to them. A field set in `BuildFrom` is then not visible in `ApplyToTest`. How often
   instances are created varies between NUnit versions, so never depend on it. Put what a test needs on the `Test`
   object itself, in its arguments or its `Properties`, or resolve it at execution time.
2. **Builders must be repeatable.** A builder or data source must produce the same tests, with the same names and
   arguments, every time it runs. Runners match tests between loads by name, and some runners load the assembly more
   than once per run. Do not use `Random`, the current time, or counters and other static side effects.
3. **Create live objects at execution time.** Have the builder supply data that describes what the test needs, such
   as a key or a factory delegate, and have an execution-time interface, an action attribute or the test's own setup
   create or resolve the object. A `Func<T>` or `Lazy<T>` passed as an argument is a good way to defer creation until
   the test runs.
4. **Do not assume the assembly is loaded once.** The Visual Studio adapter can load it once to discover tests and
   again, in another process, to run them. See
   [Discovery and execution in the adapter](xref:vstestadapterusage#discovery-and-execution).

## See also

* [Load Time and Execution Time](xref:loadtimeandexecutiontime)
* [Framework Extensibility](Framework-Extensibility.md)

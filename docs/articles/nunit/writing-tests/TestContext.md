---
uid: testcontext
---

# TestContext

Each NUnit test runs in an execution context, which includes information about the environment as well as the test
itself. The `TestContext` class allows tests to access certain information about the execution context.

> [!NOTE]
> It's important to remember that "test" in NUnit may refer to an individual test cases or a suite such as a
> `TestFixture`. Within a test method, `SetUp` method or `TearDown` method, the context is that of the individual test
> case. Within a `OneTimeSetUp` or `OneTimeTearDown` method, the context refers to the fixture as a whole. This can lead
> to confusion, since most runners display information about fixtures differently from test cases. In fact, some runners
> may not display information about fixtures at all!

## Static Properties

### CurrentContext

Gets the context of the currently executing test. This context is created separately for each test before it begins
execution. See below for properties of the current context.

### Out

Gets a TextWriter used for sending output to the current test result.

If output written by your code never shows up, or shows up under a different test, see
[Capturing output from other threads and hosted applications](#capturing-output-from-other-threads-and-hosted-applications)
below.

### Error

Gets a TextWriter used for sending error output intended for immediate display.

### Progress

Gets a TextWriter used for  sending normal (non-error) output intended for immediate display.

### TestParameters

Test parameters may be supplied to a run in various ways, depending on the runner used. For example, the console runner
provides a command-line argument and v3.4 of the NUnit 3 VS Adapter will supports specifying them in a .runsettings
file. The static TestParameters property returns an object representing those passed-in parameters.

The TestParameters object supports the following properties:

* `Count` - The number of parameters.
* `Names` - A collection of the names of the supplied parameters.
* `this[string name]` - The value of a parameter. In Vb, use `Item`.

The TestParameters object supports the following methods:

* `Exists(string name)` - Returns true if a parameter of that name exists.
* `Get(string name)`- Returns the same value as the indexer.
* `Get<T>(string name, T defaultValue)` - Returns the value of the parameter converted from a string to type T or the
  specified default if the parameter doesn't exist. Throws an exception if conversion fails.

**Note** that all parameter values are strings. You may convert them to other Types using the generic `Get` method
listed above or using your own code. An exception may be thrown if the supplied value cannot be converted correctly.

## Static Methods

### Write

Writes text to the current test result, that is the Out writer.  Prefer to use the Out writer directly for better clarity.

Note: *These methods will be deprecated in the future*

```csharp
Write(bool value)
Write(char value)
Write(char[] value)
Write(double value)
Write(Int32 value)
Write(Int64 value)
Write(decimal value)
Write(object value)
Write(Single value)
Write(string value)
Write(UInt32 value)
Write(UInt64 value)
Write(string format, object arg1)
Write(string format, object arg1, object arg2)
Write(string format, object arg1, object arg2, object arg3)
Write(string format, params object[] args)
```

### WriteLine

Writes text to the current test result, followed by a newline, that is the Out writer.  
Prefer to use the Out writer directly for better clarity.

Note: *These methods will be deprecated in the future*

```csharp
  WriteLine()
  WriteLine(bool value)
  WriteLine(char value)
  WriteLine(char[] value)
  WriteLine(double value)
  WriteLine(Int32 value)
  WriteLine(Int64 value)
  WriteLine(decimal value)
  WriteLine(object value)
  WriteLine(Single value)
  WriteLine(string value)
  WriteLine(UInt32 value)
  WriteLine(UInt64 value)
  WriteLine(string format, object arg1)
  WriteLine(string format, object arg1, object arg2)
  WriteLine(string format, object arg1, object arg2, object arg3)
  WriteLine(string format, params object[] args)
```

### AddFormatter (3.2+)

Adds a formatter for values based on some criterion, such as the Type of the value. The provided formatter will be used
when an expected or actual value needs to be displayed as part of a message from a constraint.

```csharp
AddFormatter(ValueFormatter formatter);
AddFormatter(ValueFormatterFactory formatterFactory);
```

Both `ValueFormatter` and `ValueFormatterFactory` are delegates. `ValueFormatter` takes a single object as an argument
and returns its string representation. The `AddFormatter` overload that takes a ValueFormatter is intended for use in
most cases that arise.

### AddTestAttachment (3.7+)

Attaches a file, with optional description, to the current test.

```csharp
AddTestAttachment(string filePath, string description = null);
```

The file will be attached to the test result in the xml report. Test runners, such as the NUnit 3 VS Adapter, may also
present the file to the user.

Notes:

1. The file must exist at the time of attachment.
1. File paths will be resolved as fully rooted paths, relative to `TestContext.CurrentContext.WorkDirectory`, which can
   be set by the user.

## Properties of the CurrentContext

### Test

Gets a representation of the current test, with the following properties:

* `ID` - The unique Id of the test
* `Name` - The name of the test, whether set by the user or generated automatically
* `Namespace` - The namespace of the test
* `DisplayName` - The display name of the test
* `FullName` - The fully qualified name of the test
* `MethodName` - The name of the method representing the test, if any
* `Method` - The IMethodInfo of the test method
* `Type` - The `TypeInfo` of the test
* `ClassName` - The classname of the test
* `Arguments` - The arguments as a list of objects, if any.
* `ExpectedResult` - The expected result, if that is set for the test
* `Properties` - An `IPropertyBag` of the test properties. Note: The `Get` method ONLY returns the first property
(with a given key) for the current level.

The following properties are in version 4.2 and above.

* `Parent` - The parent of the given test.
* `AllPropertyValues` - Returns a list of values (as objects) for a given property across the complete test hierarchy
* `AllCategories` - Returns a list of all categories (as strings) across the complete test hierarchy
* `PropertyHierarchy` - A utility method which returns the complete hierarchy of all properties including the name,
  value and level where they are found.

### Result

Gets a representation of the test result, with the following properties:

* `Outcome` - A `ResultState` representing the outcome of the test. `ResultState` has the following properties:
  * `Status` - A `TestStatus` with four possible values:
    * Inconclusive
    * Skipped
    * Passed
    * Warning
    * Failed
  * `Label` - An optional string value, which can provide sub-categories for each Status. See below for a list of
    common outcomes supported internally by NUnit.
  * `Site` - A `FailureSite` value, indicating the stage of execution in which the test generated its result. Possible
    values are
    * Test
    * SetUp
    * TearDown
    * Parent
    * Child
* `Assertions` - A list of `AssertionResult` values generated up to this point in the test. Please note that **only
  failed assertions** will be stored in here to limit the size of the result tree and potential impact on performance.
  Each `AssertionResult` has the following properties:
  * `Status` - An `AssertionStatus` with five possible values:
    * Inconclusive
    * Passed
    * Warning
    * Failed
    * Error
  * `Message` - A string containing the message produced by the assertion (possibly null).
  * `StackTrace` - A string containing the stack trace associated with the assertion.
* `PassCount` - An int representing the number of test cases that passed when running the test and all its children.
* `FailCount` - An int representing the number of test cases that failed when running the test and all its children.
* `SkipCount` - An int representing the number of test cases that were skipped when running the test and all its
  children.
* `InconclusiveCount` - An int representing the number of test cases that were inconclusive when running the test and
  all its children.
* `StackTrace` - A string containing the stack trace associated with an error or failure.
* `Message` - A string containing the message associated with a test failure or with not running the test.

Although the outcome of the test may be accessed during setup or test execution, it only has a useful value in the
teardown stage.

### Common Outcomes

The following is a list of outcomes currently produced by NUnit. Others may be added in the future.

* Success: the test passed. (Status=Passed)
* Inconclusive: the test was inconclusive. (Status=Inconclusive)
* Failure: a test assertion failed. (Status=Failed, Label=empty)
* Error: an unexpected exception occurred. (Status=Failed, Label=Error)
* NotRunnable: the test was invalid and could not be run. (Status=Failed, Label=Invalid)
* Cancelled: the user cancelled while this test was running. (Status=Failed, Label=Cancelled)
* Ignored: the test was ignored. (Status=Skipped, Label=Ignored)
* Explicit: the test was not run because it is marked Explicit. (Status=Skipped, Label=Explicit)
* Skipped: the test was skipped for some other reason. (Status=Skipped, Label=empty)

### ActiveTests

> [!NOTE]
> This property was added in NUnit 5.0.

Gets the list of test cases under the current suite that will run, after any filter has been applied. It is available
in `OneTimeSetUp` and `OneTimeTearDown` methods, and returns `null` everywhere else.

This lets a `SetUpFixture` or a fixture skip expensive setup, such as starting a database, when none of the tests that
need it will run. It works the same way with every runner, for example `dotnet test`, the NUnit Console or an IDE.

[!code-csharp[ActiveTestsExample](~/snippets/Snippets.NUnit/ActiveTestsExample.cs#ActiveTestsExample)]

### TestDirectory

Gets the full path of the directory containing the current test assembly.

### WorkDirectory

Gets the full path of the directory to be used for output from this test run. The XML result file and any redirected
output files are located under this directory. This is normally the directory that was current when execution of NUnit
began but may be changed by use of the `--work` option of nunit-console.

### Random

Returns a `Randomizer` object, which may be used in the test code to generate random values. These values are repeatable
on reruns of the tests so long as (a) the test assembly is not changed and (b) the same seed is used. The initial random
seed used in any test run may be found in the XML result file and may be provided to a subsequent run on the command
line.

See [Randomizer Methods](Randomizer-Methods.md) for details about each available random data type.

## Capturing output from other threads and hosted applications

NUnit decides which test a piece of output belongs to by looking at the current test's execution context, which .NET
carries in an `AsyncLocal` as part of the `ExecutionContext`. `Console.Out`, `TestContext.Out`, `TestContext.Progress`
and `TestContext.Error` all consult that context when they are written to. The context flows automatically across
`await`, `Task.Run`, thread pool work items and threads started from the test, so output written in any of those
places is captured as usual.

The context cannot reach code that runs where the test's `ExecutionContext` was never flowed to: a thread or hosting
pipeline that was started outside the test, or anything on the far side of a socket. When NUnit finds no test context
it uses an ad hoc placeholder context instead. `Console.WriteLine` then goes to the original console, `TestContext.Out`
writes to a result that no runner reports, and `Progress` and `Error` are discarded. The output is silently lost or, if a
long-lived background thread inherited the context of an earlier test, shows up under the wrong test.

### ASP.NET Core integration tests with WebApplicationFactory

This is the most common way to hit the problem. `WebApplicationFactory<TEntryPoint>` hosts the application on an
in-memory `TestServer`, and by default `TestServer` deliberately does not flow the caller's `ExecutionContext` into the
request pipeline. Request handlers, middleware and the application's `ILogger` calls therefore all run without NUnit's
test context, so `Console.WriteLine` or `TestContext.Out.WriteLine` inside them never reaches the test output. Output
from the application's own console logger may still appear, but under whichever test happened to start the host first.

`TestServer` has an opt-in setting for exactly this situation, `PreserveExecutionContext`. Turn it on in your factory
and the context of the test that sends each request flows into the server:

[!code-csharp[PreserveExecutionContextFactory](~/snippets/Snippets.NUnit.AspNetCore/WebApplicationFactoryOutputExamples.cs#PreserveExecutionContextFactory)]

Because the context travels with each request, it does not matter whether the factory is created in the test body, in
`[SetUp]` or in `[OneTimeSetUp]`. Every test's requests are attributed to that test, even when a single factory and
client are shared by the whole fixture:

[!code-csharp[PreserveExecutionContextOneTimeSetUp](~/snippets/Snippets.NUnit.AspNetCore/WebApplicationFactoryOutputExamples.cs#PreserveExecutionContextOneTimeSetUp)]

If you cannot derive from the factory, set the property on the server before creating a client:

[!code-csharp[PreserveExecutionContextProperty](~/snippets/Snippets.NUnit.AspNetCore/WebApplicationFactoryOutputExamples.cs#PreserveExecutionContextProperty)]

Once the context flows, `Console.WriteLine`, `TestContext.Out` and `TestContext.Progress` inside the application behave
exactly as they do in the test method, and the application's `ILogger` output, including the default console logger,
lands in the right test too. The application used by these examples is an ordinary minimal API with no reference to
NUnit:

[!code-csharp[WebAppProgram](~/snippets/Snippets.WebApp/Program.cs#WebAppProgram)]

### Servers on their own threads or in another process

`PreserveExecutionContext` only helps with the in-memory `TestServer`. When the application listens on a real Kestrel
endpoint, for example for browser tests with Playwright or Selenium, or runs as a separate process, requests arrive on
the server's own threads and no execution context can flow from the test. You then have two options.

The first is to give the application a writer instead of relying on the ambient context. A `TextWriter` obtained from
`TestContext.Out` while the test is running stays bound to that test's result, no matter which thread later writes to
it. An `ILoggerProvider` that writes to such a writer gets the application's logging into the test output:

[!code-csharp[TextWriterLoggerProvider](~/snippets/Snippets.NUnit.AspNetCore/WebApplicationFactoryOutputExamples.cs#TextWriterLoggerProvider)]

[!code-csharp[KestrelCapturedWriter](~/snippets/Snippets.NUnit.AspNetCore/WebApplicationFactoryOutputExamples.cs#KestrelCapturedWriter)]

Capture the writer per test, in the test body or in `[SetUp]`. A writer captured in `[OneTimeSetUp]` belongs to the
fixture rather than to any test case, and most runners do not display fixture-level output, so the messages disappear
again.

The second option is to restore NUnit's context inside the application. The community package
[Agoda.NUnit.KestrelLogging](https://github.com/agoda-com/NUnit.KestrelLogging) adds middleware that re-attaches the
`TestExecutionContext` that was current when the factory was created. It is mentioned here as an example rather than an
endorsement. It relies on NUnit internals and has the same limitation as the captured writer: it works when the factory
is created in the test body or in `[SetUp]`, but not when a shared factory is created in `[OneTimeSetUp]`, because
every test case gets its own output writer.

The original investigation and a repro are in
[nunit/nunit#5067](https://github.com/nunit/nunit/discussions/5067).

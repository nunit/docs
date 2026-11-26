---
uid: xmlformats
---

# XML Formats

> [!WARNING]
> This is a draft. The contents may be out of date.

Use of XML in NUnit 2.x is somewhat limited and is only used in external files. NUnit 3.0 uses XML in several of its
interfaces for communicating between its three architectural layers.

The samples given here represent the current state of the application and are subject to change. Watch this page for new
information as development continues.

## NUnit Projects

An NUnit project is stored as a file with the extension .nunit and describes one or more test assemblies to be executed,
together with certain parameters used in running them. No schema is used for this file.

* [Sample NUnit Project](https://nunit.org/files/nunit_project_25.txt)

Currently, the format is the same as for NUnit 2.x but it is likely to change as the project proceeds. Note that
NUnitLite does not use or recognize NUnit projects, but only assemblies.

For details of the file contents, see [NUnit Project XML Format](xref:nunitprojectxmlformat)

## NUnit Settings

The NUnitSettings30.xml file holds default settings for NUnit 3.0. No schema is used for this file. The format is the
same as for 2.x but new settings may be added and the names of certain keys are likely to change.

* [Sample NUnit Settings File](https://nunit.org/files/sample_nunitsettings_file.txt)

## Test Results

The results of an test run are saved in a file with the default name of TestResult.xml. The schema of this file is being
modified substantially for NUnit 3.0.

* [Sample](https://nunit.org/files/testresult_30.txt)
* Schema not yet available

For details of the file layout see [Test Result XML Format](Test-Result-XML-Format.md).

## V2 Test Results

Optionally, NUnit 3.0 is able to save results in the NUnit 2.x format for use with CI servers that do not yet understand
the new format.

* [Sample](https://nunit.org/files/testresult_25.txt)
* [Schema](https://nunit.org/files/testresult_schema_25.txt)

## Test Representation

When using the -explore option, a list of tests without results is returned. The format used is simply a subset of the
test result format, without the result information.

See [Test Result XML Format](Test-Result-XML-Format.md) for details.

## Test Filters

Information about which tests to run is provided to the framework using a test filter, represented as an XML fragment.
See [Test Filters](Test-Filters.md) for details.

## Test Packages

## Progress Reports

As a test run progresses, the engine sends XML fragments to every `ITestEventListener`, including
[event listener extensions](xref:eventlisteners). Each fragment is a single top-level element.

### `<start-run>`

Sent once by the engine before any test starts.

* **Contained Elements:** `<command-line>`, holding the command used to start the run in a CDATA section.
* **Attributes:**
  * **count** The number of test cases the run is expected to execute, after filtering.
  * **start-time** The UTC time the run started, in `yyyy-MM-dd HH:mm:ssZ` format.
  * **engine-version** The version of the NUnit engine.
  * **clr-version** The runtime version the engine is running on, taken from `Environment.Version`.

> [!WARNING]
> **count** is not always available. When the console runner is given the `--agents` option, the engine does not load
> the test assemblies until an agent is free, so it cannot count the tests before the run starts and reports `0`.
> Older versions of the console runner reported `0` in all cases. Extensions that show progress should treat a count of
> `0` as "unknown" rather than as an empty run.

### `<start-suite>` and `<start-test>`

Sent by the framework when a suite (assembly, namespace, fixture or parameterized method) or an individual test case
begins. The start events carry only identifying information. The result arrives later in the matching `<test-suite>`
or `<test-case>` element.

* **Attributes:**
  * **id** The unique id of the test.
  * **parentId** The id of the containing suite, or an empty string for the top-level suite.
  * **name** The name of the test.
  * **fullname** The full name of the test.
  * **type** The kind of test, such as `Assembly`, `TestFixture`, `ParameterizedMethod` or `TestMethod`.
  * **framework-version** On the `<start-suite>` for an assembly only, the version of the NUnit framework in use.
  * **classname** On `<start-test>` only, the full name of the class containing the test method.
  * **methodname** On `<start-test>` only, the name of the test method.

### `<test-suite>`, `<test-case>` and `<test-run>`

As a test run progresses, individual test run results are sent as xml fragments from the result file under construction.
A runner can, in fact, construct a copy of the result file incrementally using these fragments if desired.

## VisualState

The Gui runner uses a file with the suffix .VisualState.xml to save the current visual state of a project so that it may
be restored upon re-opening. This file is private to the Gui but is included here for completeness. The current format
is identical to that used in NUnit 2.x.

* [Sample Visual State File](https://nunit.org/files/sample_visual_state_25.txt)

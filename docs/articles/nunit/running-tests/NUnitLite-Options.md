# NUnitLite Options

The NUnitLite runner is invoked by executing the test program. If desired, any of the following options may be specified:

| Option | Description |
| ------ | ----------- |
| `--test=NAMES` | Comma-separated list of NAMES of tests to run or explore. This option may be repeated. |
| `--testlist=PATH` | File PATH containing a list of tests to run, one per line. This option may be repeated. |
| `--prefilter=NAMES` | Comma-separated list of NAMES of test classes or namespaces to be loaded. This option may be repeated. |
| `--where=EXPRESSION` | Test selection EXPRESSION indicating what tests will be run. |
| `--params, -p=VALUE` | Define a test parameter. |
| `--timeout=MILLISECONDS` | Set timeout for each test case in MILLISECONDS. |
| `--seed=SEED` | Set the random SEED used to generate test cases. |
| `--workers=NUMBER` | Specify the NUMBER of worker threads to be used in running tests. If not specified, defaults to 2 or the number of processors, whichever is greater. |
| `--stoponerror` | Stop run immediately upon any test failure or error. |
| `--wait` | Wait for input before closing console window. |
| `--work=PATH` | PATH of the directory to use for output files. If not specified, defaults to the current directory. |
| `--output`, `--out=PATH` | File PATH to contain text output from the tests. |
| `--err=PATH` | File PATH to contain error output from the tests. |
| `--result=SPEC` | An output SPEC for saving the test results. This option may be repeated. |
| `--explore[=SPEC]` | Display or save test info rather than running tests. Optionally provide an output SPEC for saving the test info. This option may be repeated. |
| `--noresult` | Don't save any test results. |
| `--labels=VALUE` | Specify whether to write test case names to the output. Values: `Off`, `On`, `All` |
| `--test-name-format=VALUE` | Non-standard naming pattern to use in generating test names. |
| `--teamcity` | Turns on use of TeamCity service messages. |
| `--trace=LEVEL` | Set internal trace LEVEL. Values: `Off`, `Error`, `Warning`, `Info`, `Verbose` (Debug) |
| `--noheader`, `--noh` | Suppress display of program information at start of run. |
| `--nocolor`, `--noc` | Displays console output without color. |
| `--help`, `-h` | Display this message and exit. |
| `--version`, `-V` | Display the header and exit. |

## Description

By default, this command runs the tests contained in the
assemblies and projects specified. If the `--explore` option
is used, no tests are executed but a description of the tests
is saved in the specified or default format.

## Test Selection

Several options allow selection of a subset of the tests in an
assembly for execution or display.

The `--prefilter` option operates first. If specified, it
limits the classes, which NUnit will examine to find tests.
Classes not included are simply ignored and the other two
selection options never even see them.

The `--where` option introduces a _where clause_, the most flexible
but also the most complex way to introduce tests. See the documentation of
[Test SelectionLanguage](https://docs.nunit.org/articles/nunit/running-tests/Test-Selection-Language.html)
for details.

The `--test` and `testlist` options allow selecting individual
tests by name. The list of tests selected is joined to any `--where`
clause you provide by a logical `and` operation. That is, if both
`--test` and `--where` are specified, __both__ must be satisfied by
a test in order for it to run.

## XML Output

Several options that specify processing of XML output take
an output specification as a value. A SPEC may take one of
the following forms:

* `--OPTION:filename`
* `--OPTION:filename;format=formatname`
* `--OPTION:filename;transform=xsltfile`

The `--result` option may use any of the following formats:

* `nunit3` - the native XML format for NUnit 3.0
* `nunit2` - legacy XML format used by earlier releases of NUnit

The `--explore` option may use any of the following formats:

* `nunit3` - the native XML format for NUnit 3.0
* `cases` - a text file listing the full names of all test cases.

If `--explore` is used without any specification following, a list of
test cases is output to the console.

If none of the options (`--result`, `--explore`, `--noxml`) is used,
NUnit saves the results to `TestResult.xml` in nunit3 format.

Any transforms provided must handle input in the native nunit3 format.

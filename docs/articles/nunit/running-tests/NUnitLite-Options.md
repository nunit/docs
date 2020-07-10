# NUnitLite Options

The NUnitLite runner is invoked by executing the test program. If desired, any of the following options may be specified:

| Option | Description |
| ------ | ----------- |
| `--test=NAMES` | Comma-separated list of NAMES of tests to run or explore. This option may be repeated. |
| `--testlist=PATH` | File PATH containing a list of tests to run, one per line. This option may be repeated. |
| `--include=CATEGORIES` | Test CATEGORIES to be included. May be a single category, a comma-separated list of categories or a category expression.|
| `--exclude=CATEGORIES` | Test CATEGORIES to be excluded. May be a single category, a comma-separated list of categories or a category expression.|
| `--timeout=MILLISECONDS` | Set timeout for each test case in MILLISECONDS. |
| `--seed=SEED` | Set the random SEED used to generate test cases.|
| `--workers=NUMBER` | Specify the NUMBER of worker threads to be used in running tests.|
| `--stoponerror` | Stop run immediately upon any test failure or error.|
| `--wait` | Wait for input before closing console window.|
| `--work=PATH` | PATH of the directory to use for output files.|
| `--output`, `--out=PATH` | File PATH to contain text output from the tests.
| `--err=PATH` | File PATH to contain error output from the tests.|
| `--result=SPEC` | An output SPEC for saving the test results. This option may be repeated.|
| `--explore[=SPEC]` | Display or save test info rather than running tests. Optionally provide an output SPEC for saving the test info. This option may be repeated.|
| `--noresult` | Don't save any test results.|
| `--labels=VALUE` | Specify whether to write test case names to the output. Values: `Off`, `On`, `All`|
| `--trace=LEVEL` | Set internal trace LEVEL. Values: `Off`, `Error`, `Warning`, `Info`, `Verbose` (Debug)|
| `--teamcity` | Turns on use of TeamCity service messages.|
| `--noheader`, `--noh` | Suppress display of program information at start of run.|
| `--nocolor`, `--noc` | Displays console output without color.|
| `--verbose`, `-v` | Display additional information as the test runs.|
| `--help`, `-h` | Display this message and exit.|

## Description

By default, this command runs the tests contained in the
assemblies and projects specified. If the `--explore` option
is used, no tests are executed but a description of the tests
is saved in the specified or default format.

Several options that specify processing of XML output take
an output specification as a value. A SPEC may take one of
the following forms:

* `--OPTION:filename`
* `--OPTION:filename;format=formatname`
* `--OPTION:filename;transform=xsltfile`

The --result option may use any of the following formats:

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

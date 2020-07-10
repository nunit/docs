### NUnitLite Options

The NUnitLite runner is invoked by executing the test program. If desired, any of the 
following options may be specified:

<table class="nunit" style="margin-left:0; max-width:700px">

<tr><th>--test=NAMES</th>
    <td>Comma-separated list of NAMES of tests to run or explore. This option may be repeated.</td></tr>
    
<tr><th>--testlist=PATH</th>
    <td>File PATH containing a list of tests to run, one per line. This option may be repeated.</td></tr>
    
<tr><th>--include=CATEGORIES</th>
    <td>Test CATEGORIES to be included. May be a single category, a comma-separated list of categories or a category expression.</td></tr>
    
<tr><th>--exclude=CATEGORIES</th>
    <td>Test CATEGORIES to be excluded. May be a single category, a comma-separated list of categories or a category expression.</td></tr>
    
<tr><th>--timeout=MILLISECONDS</th>
    <td>Set timeout for each test case in MILLISECONDS.</td></tr>
    
<tr><th>--seed=SEED</th>
    <td>Set the random SEED used to generate test cases.</td></tr>
    
<tr><th>--workers=NUMBER</th>
    <td>Specify the NUMBER of worker threads to be used in running tests.</td></tr>
    
<tr><th>--stoponerror</th>
    <td>Stop run immediately upon any test failure or error.</td></tr>
    
<tr><th>--wait</th>
    <td>Wait for input before closing console window.</td></tr>

<tr><th>--work=PATH</th>
    <td>PATH of the directory to use for output files.</td></tr>

<tr><th>--output, --out=PATH</th>
    <td>File PATH to contain text output from the tests.</td></tr>
    
<tr><th>--err=PATH</th>
    <td>File PATH to contain error output from the tests.</td></tr>
    
<tr><th>--result=SPEC</th>
    <td>An output SPEC for saving the test results. This option may be repeated.</td></tr>
    
<tr><th>--explore[=SPEC]</th>
    <td>Display or save test info rather than running tests. Optionally provide an output SPEC for saving the test info. This option may be repeated.</td></tr>
    
<tr><th>--noresult</th>
    <td>Don't save any test results.</td></tr>
    
<tr><th>--labels=VALUE</th>
    <td>Specify whether to write test case names to the output. Values: Off, On, All</td></tr>
    
<tr><th>--trace=LEVEL</th>
    <td>Set internal trace LEVEL. Values: Off, Error, Warning, Info, Verbose (Debug)</td></tr>
    
<tr><th>--teamcity</th>
    <td>Turns on use of TeamCity service messages.</td></tr>
    
<tr><th>--noheader, --noh</th>
    <td>Suppress display of program information at start of run.</td></tr>
    
<tr><th>--nocolor, --noc</th>
    <td>Displays console output without color.</td></tr>
    
<tr><th>--verbose, -v</th>
    <td>Display additional information as the test runs.</td></tr>
    
<tr><th>--help, -h</th>
    <td>Display this message and exit.</td></tr>
    
</table>

### Description

By default, this command runs the tests contained in the
assemblies and projects specified. If the **--explore** option
is used, no tests are executed but a description of the tests
is saved in the specified or default format.

Several options that specify processing of XML output take
an output specification as a value. A SPEC may take one of
the following forms:
 * --OPTION:filename
 * --OPTION:filename;format=formatname
 * --OPTION:filename;transform=xsltfile

The --result option may use any of the following formats:
 * nunit3 - the native XML format for NUnit 3.0
 * nunit2 - legacy XML format used by earlier releases of NUnit

The --explore option may use any of the following formats:
 * nunit3 - the native XML format for NUnit 3.0
 * cases  - a text file listing the full names of all test cases.

If --explore is used without any specification following, a list of
test cases is output to the console.

If none of the options {--result, --explore, --noxml} is used,
NUnit saves the results to TestResult.xml in nunit3 format.

Any transforms provided must handle input in the native nunit3 format.


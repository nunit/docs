# Console Runner

The nunit3-console.exe program is a text-based runner for listing and running our tests from the command-line. It is
able to run all NUnit 3.0 or higher tests natively and can run NUnit 2.x tests if the v2 driver is installed.
  
This runner is useful for automation of tests and integration into other systems. It automatically saves its results in
XML format, allowing you to produce reports or otherwise process the results. The following is a screenshot of the
console program output.

![Screen shot of nunit-console](~/images/console-mock.png)

In this example, nunit3-console has just run selected tests in the mock-nunit-assembly.exe assembly that is part of the
NUnit distribution. This assembly contains a number of tests, some of which are either ignored or marked explicit. The
summary line shows the result of the test run.

## Console Exit Codes

The console will exit with zero if all tests pass, a positive number if there are any test failures, and a negative
number in the case of any errors in running the test suite. The current exit codes used are summarized below:

| Exit code | Meaning |
|---|---|
|   0   | All tests passed. Note that some tests may still have produced warnings -- those will be listed in the console output.  |
| 1-100 | Some tests have failed. The exit code will reflect the number of test failures (capped at 100).  |
|  -1   | Invalid argument found on command line. |
|  -2   | One of the assemblies passed into the console was found to be invalid. This may include assemblies which contain no tests. |
|  -3   | No longer used. Previously used when a requested test fixture could not be found. |
|  -4   | An invalid test fixture was found within the test suite. |
|  -5   | No longer used. Previously used when the App Domain within which the tests were run could not be unloaded cleanly. This situation is now logged as a warning instead of an error, and will result in the console exiting zero.  |
| -100  | An unexpected error occurred. This may indicate a bug within the test runner - please consider filing an issue on the [nunit-console repository](https://github.com/nunit/nunit-console/issues).  |

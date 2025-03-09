---
uid: runningtests
---

# Running Tests

There are several ways to run your tests, depending on your needs. The most common way is to use one of the common IDEs,
such as Visual Studio, Visual Studio Code or Rider, or to use `dotnet test` from the command line. All of these use
different parts of the NUnit ecosystem to run your tests. The Microsoft tools use the NUnit3TestAdapter, whereas
Jetbrains Rider use the NUnit.Engine.

To start using NUnit with these tools, see the [Installation section](xref:installation).

Also see the information on the [NUnit3TestAdapter](https://docs.nunit.org/articles/vs-test-adapter/Index.html) for more
detailed information on how to use it and configure it.

In addition to these NUnit provides two special runners, the NUnit.Console and the NUnitLite runners, which are
described below.

* The [Console Runner](Console-Runner.md), `nunit-console.exe`, is used for batch execution.
* The [NUnitLite runner](NUnitLite-Runner.md), `nunitlite-runner.exe`, is a light weight runner originally used
  internally in the team, but can be used by anyone who wants to have a simple way of running tests from the command
  line.

Just for fun, to see how the different runners are being used, we can look at the `nuget.org` download statistics for
each of the runners, per Oct 2023:

|Runner|Downloads|Comment|
|------|---------|-------|
|NUnit3TestAdapter|  211.4 million| Used by Visual Studio, VS Code and dotnet test|
|NUnit.Console| 22.5 million||
|NUnitLite| 4.6 million||

## Other runners

The `VSTest.Console` is also a Microsoft runner, but it is less used now as `dotnet test` has taken over.  It does use
the `NUnit3TestAdapter` as well.

The `Azure Pipelines` have some tasks for running tests, like
[VSTest](https://learn.microsoft.com/en-us/azure/devops/pipelines/tasks/reference/vstest-v2?view=azure-pipelines), which
also use the `NUnit3TestAdapter` under the hood.

## Some information on the internal working

### NUnit.Engine

All runners except NUnitLite use the NUnit.Engine, including Rider. It should not be used alone, as the different
runners have different requirements for how the engine is used and which version is being used. See [Compatibility of
the Test Adapter with the Test
Engine](https://docs.nunit.org/articles/vs-test-adapter/Adapter-Engine-Compatibility.html) for some more detailed
information on this.

### NUnit Agent

When running tests in a separate process, the console and gui runners make use of the NUnit Agent program,
nunit-agent.exe. Although not directly run by users, nunit-agent does load and execute tests and users need to be aware
of it, especially when debugging is involved.

## Additional Information

For additional general information on how tests are loaded and run, see

* [Runtime Selection](xref:runtimeselection)
* [Assembly Isolation](xref:assemblyisolation)
* [Configuration Files](xref:configurationfiles)
* [Visual Studio Support](xref:visualstudiosupport)

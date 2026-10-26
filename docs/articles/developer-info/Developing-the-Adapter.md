# Developing the Adapter

This page follows the [common workflow](Developing-NUnit.md) for the
[NUnit3 VS Adapter](https://github.com/nunit/nunit3-vs-adapter). The repros are in
[nunit3-vs-adapter.issues](https://github.com/nunit/nunit3-vs-adapter.issues). The adapter connects NUnit to VSTest
and Microsoft.Testing.Platform, so many of its bugs are about finding a test, selecting it with a filter, or showing
it in Visual Studio Test Explorer. This page also shows how to check those.

## Building and testing

The repository has a Cake build script, `build.cmd` (or `build.ps1`), in the repository root:

| Command               | What it does                                                                              |
|-----------------------|-------------------------------------------------------------------------------------------|
| `build`               | Builds the solution (default target).                                                     |
| `build -t test`       | Runs the unit tests on net462 and net8.0, with both VSTest and `dotnet test`.             |
| `build -t package`    | Creates the NuGet package and zip in `package\`. It does not build first.                 |
| `build -t acceptance` | Builds, creates the NuGet package and runs the acceptance tests against that package.     |

* Run the acceptance tests with `build -t acceptance`. They test the NuGet package, so running the acceptance test
  project directly uses a stale or missing package.
* `build -t package` packs the binaries that are already built. Run `build` first, or the package contains old code.

Copy the package to the local feed with `copynp.cmd`, giving the version from the file name in `package\`:

```cmd
.\copynp.cmd 6.4.0-alpha.0.25
```

Then point the repro at it, see [Testing an unreleased package](xref:developingnunit#testing-an-unreleased-package).

## The adapter's dump files

Turn on the adapter's dump files in the repro's `.runsettings` while you work on a bug, see
[DumpXmlTestDiscovery and DumpXmlTestResults](xref:tipsandtricks#dumpxmltestdiscovery-and-dumpxmltestresults):

```xml
<RunSettings>
  <NUnit>
    <DumpXmlTestDiscovery>true</DumpXmlTestDiscovery>
    <DumpXmlTestResults>true</DumpXmlTestResults>
  </NUnit>
</RunSettings>
```

The dumps are written to `bin\<configuration>\<target framework>\Dump`:

* `D_<assembly>.dump` is the discovery: the NUnit XML of every test.
* `E_<assembly>.dump` is the execution. Its `VS_Input_TestCases` section lists exactly which tests VSTest or Visual
  Studio asked the adapter to run, and the `TestFilter` section shows the NUnit filter the adapter made from them.

These two sections tell you whether a test was lost before it reached the adapter, or inside the adapter. The
execution dump is overwritten by each run; set `DumpNumberedFiles` to keep one for each run.

## Checking filters from the command line

Many adapter bugs are about selecting a test: a test is found, but a filter for it runs nothing, or an error. VSTest
can list the fully qualified names and run a filter, without Visual Studio:

```cmd
dotnet vstest bin\Debug\net10.0\Issue677.dll /ListFullyQualifiedTests /ListTestsTargetPath:fqn.txt
dotnet vstest bin\Debug\net10.0\Issue677.dll "/TestCaseFilter:FullyQualifiedName=TestFixtureSourceError.TestsBroken(Windows Edgium).Test1"
```

Run each listed name alone as a filter, both as written and with `\`, `(`, `)`, `&`, `|`, `=`, `!` and `~` escaped
with a `\`, and compare the number of tests run with the number listed. A small script that loops over `fqn.txt` does
this for a whole repro. `dotnet test --filter` uses the same filter syntax.

## Checking Test Explorer with te-dump

Some bugs show only in Visual Studio Test Explorer: a test in the wrong place in the tree, an extra node that never
runs, or a result that is not shown. `te-dump`
([NUnit.Tools.TestExplorerDump](https://github.com/nunit/NUnit.Tools.TestExplorerDump)) prints the Test Explorer
tree as text, so you, a script or an AI assistant can see exactly what Test Explorer shows, and compare it before and
after a fix. It can also drive Visual Studio: start it on a solution, rebuild, run all or some tests, and close it. It
reads Test Explorer through Windows UI Automation and drives Visual Studio through EnvDTE; nothing is installed into
Visual Studio. It runs on Windows only. Its README has the install steps and all options.

### A full round trip

Clean the repro first, so no results or test lists from earlier runs are left: delete the `.vs`, `bin` and `obj`
folders, for example with [vsclean](https://github.com/OsirisTerje/VSClean) `-d`. Then run a session in the repro
folder:

```cmd
cd Issue1408
te-dump session
```

`session` starts a new Visual Studio on the solution, rebuilds it, waits for test discovery, dumps the tree, runs all
tests, dumps the tree again and closes Visual Studio, also when a step fails. The trees are printed, and written to a
`te-dump` folder next to the solution, for example `te-dump\Issue1408-20261026-194618-discovered.txt` and
`...-after-run.txt`. Add `te-dump/` to `.gitignore`.

Each line is `Kind: Name [Outcome] (test count)`; a test has no kind and no count:

```text
# after run
Project: Issue1408 [Passed] (3)
  Namespace: NUnitTestExplorerFailure [Passed] (3)
    Class: Tests [Passed] (3)
      Test Group: Demonstration [Passed] (2)
        Demonstration([(0, 0)]) [Passed]
        Demonstration([(1, 2), (3, 4)]) [Passed]
      Demonstration [Not Run]
```

Here the two tests ran, and `Demonstration [Not Run]` is an extra node. It comes from Visual Studio's own source-based
test discovery, which finds the method in the source code but cannot match it to the tests the adapter reports.

### Running single tests

Test Explorer often runs only some tests: a single test, or one node of the tree. Bugs in that path do not show with
Run All. Keep Visual Studio open and run the tests one at a time:

```cmd
te-dump start
te-dump --pid 73760 --expand-all
te-dump run --pid 73760 --filter SimpleTest
te-dump --pid 73760 --expand-all
te-dump close --pid 73760
```

`start` prints the process id to use with the other commands. `--filter` is Test Explorer's search text, for example
`SimpleTest`, `FullName:"Ns.Class.Method"` or `Class:"Class1"`. `te-dump list` shows the Visual Studio instances that
have Test Explorer open.

Do not run a session on a solution that is already open in another Visual Studio: both use the same `.vs` folder.

### Reading the results

When Test Explorer shows a test as Not Run after it has run, look at the adapter's execution dump from that run:

* The test is not in `VS_Input_TestCases`: Visual Studio did not ask the adapter to run it.
* The test is in `VS_Input_TestCases` but has no result in the dump: the adapter's filter did not select it, see the
  `TestFilter` section.
* The test has a result in the dump: NUnit ran it, and the adapter received the result. The dump records it before the
  adapter converts the result and reports it to VSTest, so a failure in that step is still possible; look for errors
  in the Tests output pane. With no errors there, Visual Studio did not match the reported result to the test it shows.

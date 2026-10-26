---
uid: developingnunit
---

# How to Develop and Fix Bugs in NUnit

This page describes how we work on a bug in the NUnit framework or the NUnit3 VS Adapter: reproduce it, fix it, check
the fix against the repro, and keep the repro as a regression test. The steps for each project are on their own pages:

* [Developing the Framework](Developing-the-Framework.md)
* [Developing the Adapter](Developing-the-Adapter.md)

## The workflow

1. **Reproduce.** Make a repro project for the issue in the project's issues repository, and check that it shows
   the bug with the released packages.
2. **Specify.** Write a failing unit test or acceptance test in the project repository.
3. **Fix.** Change the code until the test passes, and run the project's tests.
4. **Check.** Build a package with the fix, point the repro at it, and check that the bug is gone.
5. **Submit.** Raise the pull request, with `Fixed #<issue>` at the top of the description, see
   [Contributions](Contributions.md). Keep the repro, with the package versions updated.

## The issues repositories

Each project has a repository with one repro for each issue that has one:

| Repository                                                                      | Repros for                       |
|---------------------------------------------------------------------------------|----------------------------------|
| [nunit.issues](https://github.com/nunit/nunit.issues)                           | The NUnit framework              |
| [nunit3-vs-adapter.issues](https://github.com/nunit/nunit3-vs-adapter.issues)   | The NUnit3 VS Adapter            |

A repro is a folder named `Issue<number>`, for example `Issue1097` for issue 1097, with the smallest project that
shows the bug and builds as it is. Link the folder from the issue. Guidelines for a repro:

* Use the code from the issue where you can, and add a comment that explains what the bug is.
* Use the current target framework and package versions, unless the bug needs older ones.
* Always reference `Microsoft.NET.Test.Sdk` and `coverlet.collector`, as a real test project does.

A repro is not required to raise an issue: some bugs are hard to reproduce. When you can make one, it makes the issue
much easier for others to understand and fix.

### Files in a repro folder

| File                                            | Purpose                                                                   |
|-------------------------------------------------|---------------------------------------------------------------------------|
| `*.csproj`, `*.slnx` or `*.sln`                 | The repro project or solution.                                            |
| `NuGet.config`                                  | Package sources, with a local feed when testing an unreleased package.    |
| `.runsettings`                                  | Optional. Settings the bug needs. Visual Studio only picks it up from the solution folder. |
| `run_*.cmd` and `run_*.sh`                      | Optional. Commands to run instead of plain `dotnet test`, see below.      |
| `issue_metadata.json`                           | The issue's state, milestone and labels, synchronized from GitHub.        |
| `issue_initialstate.json`                       | The target frameworks and package versions the repro was made with.       |
| `issue_results.json`                            | The results of the last run: restore, build and test, with their output.  |
| Marker files                                    | Optional, see below.                                                      |

The metadata and result files are written by IssueRunner, see below; you don't need to make them.

Marker files tell IssueRunner how to treat the folder. A marker can be an empty file or a `.md` file that says why:

| Marker                 | Meaning                                                           |
|------------------------|-------------------------------------------------------------------|
| `ignore`               | Skip the issue in all runs.                                       |
| `explicit`             | Run the issue only when it is asked for by number.                |
| `wip`                  | Work in progress, skipped in normal runs.                         |
| `gui`                  | The issue shows only in a GUI, such as Visual Studio Test Explorer. |
| `windows`              | Windows only, skipped on Linux.                                   |
| `closedasnotplanned`   | The issue was closed as not planned.                              |

### Custom run scripts

By default a repro is run with `dotnet test`. When it needs a filter, a runsettings file or only some of its
projects, add a `run_<name>.cmd` and a `run_<name>.sh` with the same commands. Both are needed, since the repros are
run on Windows and Linux. Comments in the first 10 lines can give the expected results:

```cmd
REM EXPECT_TESTS=1
REM EXPECT_PASS=1
dotnet test --filter "FullyQualifiedName~Baz\(1\)"
```

The supported keys are `EXPECT_TESTS`, `EXPECT_PASS`, `EXPECT_FAIL` and `EXPECT_SKIP`. The run fails when the
results differ.

### Running the repros with IssueRunner

[IssueRunner](https://github.com/nunit/nunit.tools.issuerunner) runs the repros of an issues repository, keeps the
results, and reports regressions. It has a command line tool and a GUI. Build it from its repository, then run it
from the root of the issues repository:

```cmd
..\nunit.tools.issuerunner\run-tests.cmd --issues 1097,782 --feed Local
```

| Option                                                         | Meaning                                                  |
|----------------------------------------------------------------|----------------------------------------------------------|
| `--issues <numbers>`                                           | Run only these issues.                                   |
| `--scope All`, `New`, `NewAndFailed`, `RegressionOnly`, `OpenOnly` | Run a group of issues. `RegressionOnly` runs the closed issues. |
| `--feed Stable`, `Beta`, `Alpha`, `Local`                      | Where the packages come from. `Local` adds `C:\nuget`.   |
| `--rerun-failed`                                               | Run again only what failed last time.                    |
| `--skip-netfx`                                                 | Skip .NET Framework projects, for example on Linux.      |

Other commands keep the repository up to date: `metadata sync-from-github` and `metadata sync-to-folders` update the
`issue_metadata.json` files, `reset` sets the target frameworks and packages back to `issue_initialstate.json`, and
`report generate` writes `TestReport.md`. The IssueRunner README has the details.

The closed issues are regression tests: run `--scope RegressionOnly` with a new package before a release.

## Testing an unreleased package

Both projects get their package version from [MinVer](https://github.com/adamralph/minver): the last tag and the
number of commits since it, for example `6.4.0-alpha.0.25`. Build the package with the project's build script, and copy
it to a local feed, by default `C:\nuget`. A repro then needs a `NuGet.config` with that feed:

```xml
<configuration>
  <packageSources>
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
    <add key="local" value="C:\nuget" />
  </packageSources>
</configuration>
```

Update the repro to the new package with [dotnet-outdated](https://github.com/dotnet-outdated/dotnet-outdated),
instead of editing the version by hand:

```cmd
dotnet outdated -u -pre Always -inc NUnit3TestAdapter
```

Two things to watch out for:

* **Same version, different code.** Two branches with the same number of commits get the same version. NuGet caches
  a package by its version, so a repro can silently use an older package with that version. Give a package a version
  of its own with `set MINVERVERSIONOVERRIDE=6.4.0-alpha.0.40` before building and packing, or restore into an
  isolated folder with `dotnet restore --packages <folder>`.
* **Check what you test.** After a restore, check that the repro uses the package you expect, for example in
  `obj\project.assets.json`.

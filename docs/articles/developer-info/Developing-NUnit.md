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

### Using a repro

Work with one repro at a time, on its own:

```cmd
cd Issue1097
dotnet test
```

* Run its `run_*.cmd` or `run_*.sh` scripts instead when it has them, see below.
* Open the solution in Visual Studio when the bug is about Visual Studio. A `.runsettings` in the folder is picked up
  automatically. For Test Explorer bugs, see
  [Checking Test Explorer with te-dump](Developing-the-Adapter.md#checking-test-explorer-with-te-dump).
* Point it at an unreleased package to check a fix, see [Testing an unreleased package](#testing-an-unreleased-package).

### Files in a repro folder

| File                                            | Purpose                                                                   |
|-------------------------------------------------|---------------------------------------------------------------------------|
| `*.csproj`, `*.slnx` or `*.sln`                 | The repro project or solution.                                            |
| `NuGet.config`                                  | Package sources, with a local feed when testing an unreleased package.    |
| `.runsettings`                                  | Optional. Settings the bug needs. Visual Studio only picks it up from the solution folder. |
| `run_*.cmd` and `run_*.sh`                      | Optional. Commands to run instead of plain `dotnet test`, see below.      |
| Marker file                                     | Optional. Says what kind of repro it is, see below.                       |
| `issue_metadata.json`, `issue_initialstate.json`, `issue_results.json` | Written by IssueRunner, see below. |

The `issue_*.json` files are information, and you don't need to make them: the issue's state, milestone and labels
from GitHub, the target frameworks and packages the repro was made with, and the results of the last IssueRunner run.

A marker file says what kind of repro it is. It can be an empty file, or a `.md` file that says why:

| Marker                 | Meaning                                                           |
|------------------------|-------------------------------------------------------------------|
| `ignore`               | The repro should not be run.                                      |
| `explicit`             | The repro must be run by hand, for example one project at a time. |
| `wip`                  | Work in progress.                                                 |
| `gui`                  | The bug shows only in a GUI, such as Visual Studio Test Explorer. |
| `closedasnotplanned`   | The issue was closed as not planned.                              |
| `windows`              | The repro runs on Windows only.                                   |

### Custom run scripts

By default a repro is run with `dotnet test`. When it needs a filter, a runsettings file or only some of its
projects, add a `run_<name>.cmd` and a `run_<name>.sh` with the same commands. Both are needed, since the repros are
run on Windows and Linux. Comments in the first 10 lines can say what to expect:

```cmd
REM EXPECT_TESTS=1
REM EXPECT_PASS=1
dotnet test --filter "FullyQualifiedName~Baz\(1\)"
```

The keys are `EXPECT_TESTS`, `EXPECT_PASS`, `EXPECT_FAIL` and `EXPECT_SKIP`. They are information for the reader:
IssueRunner does not check them, it only looks at the script's exit code. A script that must catch a wrong number of
tests, for example a filter that runs nothing, has to check the count itself and exit with a non-zero code.

## Testing an unreleased package

Both projects get their package version from [MinVer](https://github.com/adamralph/minver): the last tag and the
number of commits since it, for example `6.4.0-alpha.0.25`. Build the package with the project's build script, and copy
it to a local feed, by default `C:\nuget`. A repro then needs a `NuGet.config` with that feed. The dotnet tool
[nugetc](https://github.com/HermitOS/nugetconfigcreator) makes and changes the file:

```cmd
dotnet tool install -g nugetc
cd Issue1097
nugetc add local
```

`nugetc add local` creates a `NuGet.config` with nuget.org and `C:\nuget`, or adds `C:\nuget` to the file that is
there:

```xml
<configuration>
  <packageSources>
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
    <add key="local" value="C:\nuget" />
  </packageSources>
</configuration>
```

`nugetc add myget` adds the NUnit MyGet feed, `https://www.myget.org/F/nunit/api/v3/index.json`.
`nugetc remove local`, `disable local` and `enable local` change the file again, and `nugetc reset` sets it back to
nuget.org only.

Update the repro to the new package with [dotnet-outdated](https://github.com/dotnet-outdated/dotnet-outdated),
instead of editing the version by hand. `-inc` updates the packages whose names contain the text, and `-exc` leaves
out the packages whose names contain the text:

```cmd
REM An adapter fix
dotnet outdated -u -pre Always -inc NUnit3TestAdapter

REM A framework fix: the NUnit package, not the adapter or the analyzers
dotnet outdated -u -pre Always -inc NUnit -exc NUnit3TestAdapter -exc NUnit.Analyzers
```

Two things to watch out for:

* **Same version, different code.** Two branches with the same number of commits get the same version. NuGet caches
  a package by its version, so a repro can silently use an older package with that version. Give a package a version
  of its own with `set MINVERVERSIONOVERRIDE=6.4.0-alpha.0.40` before building and packing, or restore into an
  isolated folder with `dotnet restore --packages <folder>`.
* **Check what you test.** After a restore, check that the repro uses the package you expect, for example in
  `obj\project.assets.json`.

## Running all repros with IssueRunner

[IssueRunner](https://github.com/nunit/nunit.tools.issuerunner) runs all or some repros of an issues repository and
reports which pass, for example to see if they still work with a new package before a release. You don't need it to
work on a bug. Clone it next to the issues repository, build it with its `build.cmd`, and run it from the root of the
issues repository:

```cmd
..\nunit.tools.issuerunner\run-tests.cmd --issues 1097,782 --feed Local
..\nunit.tools.issuerunner\run-tests.cmd --scope Regression
```

* `--feed Local` adds `C:\nuget`. `--scope Regression` runs the closed issues, `Open` the open ones.
* It skips folders with an `ignore`, `explicit`, `wip`, `gui` or `closedasnotplanned` marker, also when you ask for
  them by number. `windows` folders are skipped with `--skip-netfx`.
* The issues repositories also run it in their CI workflows.

The IssueRunner README has all commands and options.

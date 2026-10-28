# Developing the Framework

This page follows the [common workflow](Developing-NUnit.md) for the [NUnit framework](https://github.com/nunit/nunit).
The repros are in [nunit.issues](https://github.com/nunit/nunit.issues).

## Building and testing

The repository has one solution, `nunit.slnx`, and a Cake build script: `build.cmd` (Windows), `build.ps1`
(PowerShell) or `build.sh` (Linux and macOS). They take the same arguments:

| Command                      | What it does                                                          |
|------------------------------|-----------------------------------------------------------------------|
| `build`                      | Restores and builds everything (default target).                      |
| `build --target=Rebuild`     | Cleans the output and builds everything.                              |
| `build --target=Test`        | Runs all tests, on all target frameworks.                             |
| `build --target=Package`     | Creates the packages in `package\`. It does not build first.          |
| `build --showdescription`    | Lists all targets.                                                    |

The configuration is `Release` by default; use `--configuration=Debug` to change it. The tests to run are in the
`nunit.framework.tests-*`, `nunit.framework.legacy.tests-*` and `nunitlite.tests-*` projects. The other test projects
contain tests that fail on purpose, for the integration tests. [BUILDING.md](https://github.com/nunit/nunit/blob/main/BUILDING.md)
in the repository has the details.

## Fixing a bug

1. Make the repro in [nunit.issues](https://github.com/nunit/nunit.issues): a folder `Issue<number>` with a
   `readme.md` that links to the issue, and a project that builds and runs. Link the folder from the issue.
2. Add a failing test to the framework's test projects that shows the bug, then fix the code. Run
   `build --target=Test`: the framework targets several frameworks, and a fix can behave differently on each.
3. Run `build` and `build --target=Package`, and copy the `NUnit` package from `package\` to your local feed.
4. Update the repro to that package, see [Testing an unreleased package](xref:developingnunit#testing-an-unreleased-package),
   and check that the bug is gone. The repro runs through the NUnit3 VS Adapter, so a bug that only shows in Visual
   Studio can be checked there too, see [Checking Test Explorer with te-dump](Developing-the-Adapter.md#checking-test-explorer-with-te-dump).

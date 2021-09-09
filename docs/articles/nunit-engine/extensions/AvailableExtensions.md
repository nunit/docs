---
uid: availableengineextensions
---

# Available NUnit Engine Extensions

The NUnit team provides several extensions for the engine. They are all available individually as
packages for installation through nuget and also as chcolatey packages. Some extensions are also
bundled with specific distributions of the Console runner.

## Extensions Authored by the NUnit Team

### V2 Result Writer

The V2 Result writer makes it possible to save test results in the older NUnit V2 format, for use
with report programs and integration servers, which require that format.

#### Installation

 * NuGet: `Install NUnit.Extension.V2.Result.Writer`
 * Choco: Install `nunit-extension-v2-result-writer`
 * Bundled with the `NUnit.Console` NuGet package and the msi package.

#### Usage

 Specify `nunit2` format with the console runner `--result` or `--explore` options.

### V2 Framework Driver

The V2 Framework Driver allows the engine to run NUnit V2 tests, which is not normally possible.

#### Installation

 * NuGet: `Install NUnit.Extension.V2.Framework.Driver`
 * Choco: Install `nunit-extension-v2-framework-driver`
 * Bundled with the `NUnit.Console` NuGet package and the msi package.

#### Usage

 If installed, it is used automatically when V2 tests are being run.

### NUnit Project Loader

The NUnit Project Loader allows the engine to run NUnit projects, file extension `.nunit`.
If it is not installed, the runner will give an error indicating the file type is unrecognized.

#### Installation

 * NuGet: `Install NUnit.Extension.NUnit.Project.Loader`
 * Choco: Install `nunit-extension-nunit-project-loader`
 * Bundled with the `NUnit.Console` NuGet package and the msi package.

#### Usage

 Create the project in any editor, following the NUnit project format specification.
 You may also use the NUnit Project Editor, a legacy V2 program, since the format has
 not changed in NUnit 3.

### Visual Studio Project Loader

The VS Project Loader allows the engine to load tests from a Visual Studio
project or solution. Note that when used with a solution file, the extension
tries to avoid loading assemblies, which do not contain tests, through use
of heuristics, which may fail in certain circumstances.

#### Installation

 * NuGet: `Install NUnit.Extension.VS.Project.Loader`
 * Choco: Install `nunit-extension-vs-project-loader`
 * Bundled with the `NUnit.Console` NuGet package and the msi package.

#### Usage

 If installed, it is used automatically when V2 tests are being run.

### Teamcity Test Listener

The Teamcity Test Listener is used to run NUnit under TeamCity, providing
special output messages, which TeamCity is able to interpret.

#### Installation

 * NuGet: `Install NUnit.Extension.TeamCity.Test.Listener`
 * Choco: Install `nunit-extension-teamcity-test-listener`
 * Bundled with the `NUnit.Console` NuGet package and the msi package.

> [!WARNING]
> We plan to stop bundling the teamcity extension in the future. When that happens, individual installation will be necessary.

#### Usage

 This extension must be activated for a particular test run. When running under the
 NUnit 3 Console, use the `--teamcity` option to activate it.

## Community-Authored Extensions Highlight

TODO

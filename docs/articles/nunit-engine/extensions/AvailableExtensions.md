---
uid: availableengineextensions
---

# Available NUnit Engine Extensions

The NUnit team provides several extensions for the engine. They are all available individually as packages for
installation through NuGet and also as Chocolatey packages. Some extensions are also bundled with specific distributions
of the Console runner.

## V2 Result Writer

The V2 Result writer makes it possible to save test results in the older NUnit V2 format, for use with report programs
and integration servers that require that format.

### Installation

* NuGet: Reference package `NUnit.Extension.NUnitV2ResultWriter` in your project
* Chocolatey: `choco install nunit-extension-nunit-v2-result-writer`
* Also bundled with the `NUnit.Console` NuGet and MSI packages.

### Usage

 Specify `nunit2` format with the console runner `--result` or `--explore` options.

## V2 Framework Driver

The V2 Framework Driver allows the engine to run NUnit V2 tests, which is not normally possible.

### Installation

* NuGet: Reference package `NUnit.Extension.NUnitV2.Driver` in your project
* Chocolatey: `choco install nunit-extension-nunit-v2-driver`
* Also bundled with the `NUnit.Console` NuGet and MSI packages.

### Usage

 If installed, it is used automatically when V2 tests are being run.

## NUnit Project Loader

The NUnit Project Loader allows the engine to run NUnit projects, which have a file extension of `.nunit`. If it is not
installed, the runner will give an error indicating the file type is unrecognized.

### Installation

* NuGet: Reference package `NUnit.Extension.NUnitProjectLoader` in your project
* Chocolatey: `choco install nunit-extension-nunit-project-loader`
* Also bundled with the `NUnit.Console` NuGet and MSI packages.

### Usage

 Create the project in any editor, following the NUnit project format specification. You may also use the NUnit Project
 Editor, a legacy V2 program, since the format has not changed in NUnit 3.

## Visual Studio Project Loader

The VS Project Loader allows the engine to load tests from a Visual Studio project or solution.

> [!NOTE]
> When used with a solution file, the extension tries to avoid loading assemblies that do not contain tests,
> through the use of heuristics. This may fail in certain circumstances.

### Installation

* NuGet: Reference package `NUnit.Extension.VSProjectLoader` in your project
* Chocolatey: `choco install nunit-extension-vs-project-loader`
* Also bundled with the `NUnit.Console` NuGet and MSI packages.

### Usage

 If installed, it is used automatically when V2 tests are being run.

## Teamcity Test Listener

The Teamcity Test Listener is used to run NUnit under TeamCity, providing special output messages, which TeamCity is
able to interpret.

### Installation

* NuGet: Reference package `NUnit.Extension.TeamCityEventListener` in your project
* Chocolatey: `choco install nunit-extension-teamcity-event-listener`
* Also bundled with the `NUnit.Console` NuGet and MSI packages.

> [!WARNING]
> We plan to stop bundling the TeamCity extension with the release of NUnit 4.0. When that happens,
> individual installation will be required in order to use it.

### Usage

 This extension must be activated for a particular test run. When running under the NUnit 3 Console runner, use the
 `--teamcity` option to activate it.

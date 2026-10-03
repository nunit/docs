# Visual Studio Test Adapter

The NUnit Test Adapter lets you run NUnit tests in Visual Studio, Rider and Visual Studio Code, and from the command
line with `dotnet test`. It runs tests written with NUnit 3, NUnit 4 and NUnit 5.

The adapter is published on NuGet as **NUnit3TestAdapter**. The name comes from the NUnit 3 era; the same package is
used for all current NUnit versions.

* [Download released versions](https://www.nuget.org/packages/NUnit3TestAdapter/)
* [Download pre-release versions](https://www.myget.org/feed/nunit/package/nuget/NUnit3TestAdapter)

## Getting started

Add the adapter as a NuGet package to each test project. The NUnit project templates in Visual Studio, Rider and
`dotnet new nunit` already include it. See [Installation](xref:vstestadapterinstallation) for how to add it to an
existing project, and [Usage](Usage.md) for running and debugging tests in Visual Studio.

## Two ways to run tests

The adapter supports both test platforms that `dotnet test` and the IDEs use:

* **VSTest**, the classic test platform. This is the default.
* **[Microsoft.Testing.Platform](NUnit-And-Microsoft-Test-Platform.md)** (MTP), the newer and lighter test platform.
  From adapter version 6.0, MTP version 2 is supported.

## Supported .NET versions

The current adapter, version 6, runs tests on .NET Framework 4.6.2 and later, and on .NET 8 and later. Older .NET
versions, such as .NET Core 3.1 and .NET 5 to 7, need an older adapter version. See
[Supported Frameworks](Supported-Frameworks.md) for which adapter version supports which .NET version.

## Configuration

Use a `.runsettings` file, or settings on the `dotnet test` command line, to control how the adapter runs your tests:
test filters, output, parallel execution, result files and more. See
[Configuration with runsettings](xref:tipsandtricks) for all the settings.

## Older versions

* The adapter can't run NUnit 2.x tests. Those need the NUnit 2 adapter, which is no longer maintained.
* Up to version 3.17, the adapter was also available as a VSIX extension for Visual Studio 2019 and earlier. The VSIX
  version is deprecated and doesn't work with Visual Studio 2022 or later. Use the NuGet package instead.

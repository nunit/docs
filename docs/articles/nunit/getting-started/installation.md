---
uid: installation
---

# Installation

To install NUnit, you can use various installation approaches, depending upon your preferred development environment and preferences.

## I'm using Visual Studio as my development tool

You can add a NUnit project from the `Add New Project` dialog. Search for `NUnit` and choose the `NUnit Test Project` template.

This will add a new project to your solution, containing a single test class and a single test method. Your project file will have the necessary references to NUnit, the NUnit Test Adapter, the NUnit Analyzer, Microsoft Test SDK and the coverlet code coverage package.

> [!NOTE]
> Be aware that the templates behind this may be out of date, so always go to the `Manage NuGet Packages` dialog and update to the latest version of all packages there.

## I'm using Visual Studio Code as my development tool

Ensure you have the [C# Dev Kit](https://code.visualstudio.com/docs/csharp/get-started) installed. Then `Shift+CTRL+P`, type `New` and select `New Project`. Select `NUnit 3 Test Project` and follow the prompts.
The results will be exactly the same as if you had used Visual Studio.

Rider has built-in support for NUnit, and is using the same template, so you'll achieve the same result.

## I'm using Rider as my development tool

This is the same procedure as for Visual Studio: `Add New Project`, select the `NUnit Test Project` template, and follow the prompts.
The results will be exactly the same as if you had used Visual Studio.

## I prefer to do this using the command line or any of the built-in terminals

From your solution folder, run `dotnet new nunit -o TestProject1` to create a new NUnit test project in the folder `TestProject1`.
The results will be exactly the same as if you had used Visual Studio.

## Examples of what you get

All of the above will create a new project with the following structure, after updating the packages to the latest versions (as of Sept 2023):

```csproj
<Project Sdk="Microsoft.NET.Sdk">

    <PropertyGroup>
        <TargetFramework>net8.0</TargetFramework>
        <ImplicitUsings>enable</ImplicitUsings>
        <Nullable>enable</Nullable>

        <IsPackable>false</IsPackable>
    </PropertyGroup>

    <ItemGroup>
        <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.7.2" />
        <PackageReference Include="NUnit" Version="3.13.3" />
        <PackageReference Include="NUnit3TestAdapter" Version="4.5.0" />
        <PackageReference Include="NUnit.Analyzers" Version="3.7.0">
          <PrivateAssets>all</PrivateAssets>
          <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
        </PackageReference>
        <PackageReference Include="coverlet.collector" Version="6.0.0">
          <PrivateAssets>all</PrivateAssets>
          <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
        </PackageReference>
     </ItemGroup>

</Project>

```

It will create a `UnitTest1.cs` file with the following contents:

```cs
namespace TestProject1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}
```

and a `Usings.cs` file:

```cs
global using NUnit.Framework;
```

## Adding NUnit to an existing test project

If you need to update an existing test project to use NUnit -- perhaps a .NET Standard class lib you want to convert to a test project, or adding NUnit to a project that already has XUnit or MSTest -- you can do that by adding the `ItemGroup` in the `.csproj` file above to your project file, and then the appropriate `using NUnit.Framework;` in your code.

Also note that multiple different test frameworks (XUnit, MSTest, NUnit) can co-exist in the same test project, preferably in different files to avoid name clashes. See [this blog post](https://devblogs.microsoft.com/devops/part-2using-traits-with-different-test-frameworks-in-the-unit-test-explorer/) for details.

## TL;DR

All of the above ways to create a new NUnit project will result in the same structure, the same test class and methods, and the same packages being installed. That means you can do it any way you like, you can start with one tool and continue with another.

The template used is maintained as part of .NET and will be upgraded when .NET updates. All the above pick the template from .NET, which is why the end result is the same.

## I want to do it the old and hard way

This is from the older documentation, and is still valid, but we recommend you use the above methods.

1. Full NUnit install via NuGet.
2. NUnitLite install via NuGet.
3. Zip and/or MSI file download.
4. Combined Approach

### Using NuGet Packages and the NUnit Console

In Visual Studio, from the Tools menu, select NuGet Package Manager | Manage NuGet packages for solution...
Open the Browser tab, and Scroll or use search to locate the **NUnit** and **NUnit.Console** packages.

### NUnit and NUnit.Console

Install both packages. The **NUnit** package should be referenced by each of your test assemblies, but not by any others.

Locate nunit3-console in the **packages\NUnit.ConsoleRunner.3.X.X\tools** (or your configured package directory of choice) directory under your solution. This is the location from which you must run nunit3-console when if you would like to run NUnit3 from console.
We recommend you only use this approach when running under the control of a script on your build server.

 [See here for more details of using the NUnit Console app](https://github.com/nunit/nunit-console#readme).

## NUnit3TestAdapter

If you want to automate the running of NUnit tests on a clean machine without any installations (e.g. Azure DevOps or GitHub Actions build agents) - and you're using Visual Studio 2012 or later, use this package.

See [the Visual Studio Test Adapter](xref:vstestadapterinstallation) for details.

Note that if you have used any of the top 4 approaches, you already have this package installed, and it will work on any CI build system.

### Using NuGet NUnitLite Package

The NUnitLite approach provides a way to run NUnit tests without a full install of the NUnit runner and test engine assemblies. Only the framework and a small runner program are installed. If you want to experiment with NUnit or debug something in NUnit, this can be a helpful choice.

Follow the instructions for [NUnitLite](xref:nunitlite) to install the package and create a test assembly. You will need to add a reference to the `NUnitLite` package in your test assembly.

To run your tests, simply run your executable test assembly. No other runner is needed.

Note that since this approach includes a `Program.cs` it can not be combined with the ordinary unit test project, as that would create two entry points, which would confuse the compiler.

### Downloading the Zip File -- Not Recommended

Download the latest binary zip of the NUnit Framework from our [Download page](https://nunit.org/download/). Unzip the file into any convenient directory.

You can also download the latest binary zip or an MSI installer of the NUnit Console from [GitHub](https://github.com/nunit/nunit-console/releases). Unzip the file or install the MSI and then if you would like be able to run nunit3-console from the command line, put the bin directory, containing nunit3-console.exe on your path.

In your test assemblies, add a reference to nunit.framework.dll, using the copy in the subdirectory for the appropriate runtime version. For example, if you are targeting .NET 4.0, you should reference the framework assembly in the net-4.0 subdirectory.

Run nunit3-console from the command line, giving it the path to your test assembly. To run NUnit's own framework tests from within the NUnit bin directory, enter:

```cmd
     nunit3-console net-2.0/nunit.framework.tests.dll
```

### Combined Approach

This approach is useful if you would like to use a single copy of nunit3-console with individual copies of the framework in each project.

Simply follow the zip file procedure to get a central copy of NUnit on your system. Then install the **NUnit Version 3** NuGet package in each of your test assemblies. For desktop use by developers, this approach may give you the best of both worlds.

---
uid: vstestadapterinstallation
---

# Adapter Installation

You'll need to install the adapter as a NuGet package for each of your test projects.

## Installing the NuGet Package

You will most likely want to add a new NUnit Test Project to your solution.  The easiest way is to use the ```dotnet``` command on the command line.

Go to your project root and where you want to add your project.

Create a folder for the project with a name matching what your new test project should be named.

Then run the command `dotnet new nunit`.

You will now get a complete nunit test project with the same name as the folder.  You will also have a template unit test class there as a starter.

If you have a Visual Studio solution file in the root folder, you can go there and add the new nunit csproj easily:

Assume you are at a solution root, and you either have a solution file, or have just been adding it with `dotnet new sln`.

```cmd
md Whatever.Test
cd Whatever.Test
dotnet new nunit
cd ..
dotnet sln add Whatever.Test\Whatever.Test.csproj
```

And you're ready to go !

### Manually Adding the Adapter as a Package Reference to Your Test Projects

When adding packages manually, we recommended installing the framework, the adapter, and the analyzer for optimal out-of-the-box functionality.  The adapter and the framework are required. The analyzer will help during development, but is not strictly required to make your project work.  `coverlet.collector` is the recommended code coverage package you should go for.

You should ensure you also reference `Microsoft.NET.Test.Sdk` as well; it is required for test discoverability.

1. Open your test project `csproj` file
2. Add the necessary package references as shown in the snippet example below (NOTE: these are the current versions at time of writing; you'll want to install the latest versions.)

```xml
  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.4.0" />
    <PackageReference Include="NUnit" Version="3.13.3" />
    <PackageReference Include="NUnit3TestAdapter" version="4.3.1" />
    <PackageReference Include="coverlet.collector" Version="3.2.0" />
    <PackageReference Include="NUnit.Analyzers" Version="3.5.0" />
  </ItemGroup>
```

Note: *You don't need to, nor should you, add any nunit.console or any other runner package*

### Working with the Visual Studio Nuget manager

If you have a legacy project type, or prefer working outside of the command line, you can also use the Visual Studio 'Manage NuGet packages in the solution' menu option. It can also be used for the new SDK projects, but you may find it faster to open the `csproj` and copy/paste the references in.

With an active solution in Visual Studio, follow these steps:

1. From the `Tools` menu, use Library Package Manager and select `Manage NuGet packages for solution`
2. In the left panel, select `Online`
3. Locate (search for) `NUnit3Test Adapter` in the center panel and highlight it
4. Click `Install`
5. In the `Select Projects` dialog, select all test projects in your solution.

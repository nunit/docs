# .NET Core and .NET Standard

More information and getting started tutorials are available for NUnit and .NET Core targeting [C#](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit), [F#](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-fsharp-with-nunit) and [Visual Basic](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-visual-basic-with-nunit) in the .NET Core documentation's [Unit Testing in .NET Core and .NET Standard](https://docs.microsoft.com/en-us/dotnet/core/testing/) page.

Each test project needs to reference version 4.1.0 or later of the NUnit3 Visual Studio Test Adapter.

It is recommended to install the adapter from NuGet if you are testing .NET Core or .NET Standard projects.
The VSIX adapter has been deprecated for VS2019. Latest version is 3.17.0. For VS2022 there is no VSIX adapter.

Adding this adapter and `Microsoft.NET.Test.Sdk` version `17.0.0` to your NUnit test projects will also enable the `dotnet test` command for .NET Core projects.

Any tests using the new style CSPROJ format, either .NET Core or .NET 4.x, need to add a `PackageReference` to the NuGet package `Microsoft.NET.Test.Sdk`. Your test assemblies must also be .NET Core or .NET 4.x, not .NET Standard.

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.NET.Test.Sdk" Version="15.5.0" />
  <PackageReference Include="NUnit" Version="3.9.0" />
  <PackageReference Include="NUnit3TestAdapter" Version="3.9.0" />
</ItemGroup>
```

.NET Core test can be run on the command line with `dotnet test`, for example,

```cmd
> dotnet test .\test\NetCore10Tests\NetCore10Tests.csproj
```

For a more complete walk-through, please see [Testing .NET Core with NUnit in Visual Studio 2017](https://www.alteridem.net/2017/05/04/test-net-core-nunit-vs2017/)

## Using the NUnit project templates

The NUnit test project templates come included with `dotnet`.

You can run `dotnet new nunit` to create an NUnit test project.

### FAQ

#### Why can't my tests target .NET Standard

Visual Studio and VSTest require that the tests target a specific platform. .NET Standard is like a Portable library in that it does not target any specific platform, but can run on any supported platform. Microsoft decided that your tests should be compiled to target a platform so they know which platform to run your tests under and you get the behavior you expect for the platform you are targeting. You can however target multiple platforms in your tests and compile and run each from the command line. It still only runs one platform from Visual Studio, but I would hope that is being worked on. I haven't tested 15.3 yet.

It is similar to a console application, it cannot be .NET Standard, it must target a platform, .NET Core or .NET Framework.

This limitation is the same for all test adapters including xUnit and MSTest2.

#### My tests aren't showing up in Visual Studio 2017 or later

- Are you using the NuGet adapter package?
- Are you using version 4.1.0 or newer of the NuGet package?
- Do your tests target .NET Core or the full .NET Framework? (see above)
- Have you added a Package Reference to `Microsoft.NET.Test.Sdk`?
- Have you restarted Visual Studio? It is still a bit temperamental.

#### My tests multi-target .NET Core and .NET Framework, why can't I run both in Visual Studio

This is a limitation of Visual Studio, hopefully it will be fixed in a future release.

Meanwhile, you can run specific tests using the `--framework` command line option of [dotnet test](https://docs.microsoft.com/en-ca/dotnet/core/tools/dotnet-test?tabs=netcore2x)

#### How do I produce a test results file

`dotnet test` can generate an NUnit3 test result file by adding a runsettings property. The property to add is [TestOutputXml](https://docs.nunit.org/articles/vs-test-adapter/Tips-And-Tricks.html#testoutputxml). This generation is done using the NUnit Engine report service, and produce the same result as the [NUnit3-console](https://www.nuget.org/packages/NUnit.Console/). This is available through the [NUnit3TestAdapter](https://www.nuget.org/packages/NUnit3TestAdapter).

You run it by adding the setting on the command line (or in a runsettings file):

```console
dotnet test  -- NUnit.TestOutputXml=yourfoldername
```

The folder is relative to the binary test folder, or you can use an absolute path. The latter is useful in CI scenarios.

Alternatively, there is a 3rd party package, [NUnitXml.TestLogger](https://www.nuget.org/packages/NunitXml.TestLogger/) which also produces a NUnit3 xml format. Details for [use see here](https://github.com/spekt/nunit.testlogger). Note that this is a re-implementation of the NUnit3 format, and may differ.

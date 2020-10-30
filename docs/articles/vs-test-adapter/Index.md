# Visual Studio Test Adapter

The NUnit 3 Test Adapter allows you to run NUnit 3 tests inside Visual Studio. This is a new adapter, based partly on the code of the original NUnit Test Adapter, but modified to work with NUnit 3.

It is not possible to run NUnit 2.x tests using this adapter. Use the original adapter for that purpose. If you need to work with projects using NUnit 2.x and other projects using NUnit 3, you may install both versions of the adapter.

The current release is designed to work with Visual Studio 2012, 2013, 2015, 2017 and 2019. Some features are not available under VS2012 RTM. It also works from command line using either vstest.console or dotnet test, and is also used by JetBrains ReSharper for Visual Studio and Rider IDE, and their corresponding command line tool.

The current release works with .net framework 3.5 and higher, and with .net core `2.*` and `3.*`.

Releases of Visual Studio prior to VS 2012 did not have the ability to directly run tests built with Open Source testing frameworks like NUnit.

[Download Released versions](https://www.nuget.org/packages/NUnit3TestAdapter/)

[Download Pre-release versions](https://www.myget.org/feed/nunit/package/nuget/NUnit3TestAdapter)

The adapter is delivered as a nuget package, to be installed into all test projects.  

> [!NOTE]
> There is also a VSIX extension version, which was used earlier for Visual Studio. The support for this has been deprecated, although it still works. The recommendation is to avoid this and use the nuget version.

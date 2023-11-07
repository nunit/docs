# Visual Studio Test Adapter

The NUnit 3 Test Adapter allows you to run NUnit 3 tests inside Visual Studio or with `dotnet` on the command line.

The current release is designed to work with Visual Studio 2012, 2013, 2015, 2017, 2019 and 2022. Some features are not
available under VS2012 RTM. It also works from the command line using either `vstest.console` or `dotnet test`.

The current release works with .net framework 3.5 and higher, with .net core `3.*`, and with .net 5, .net 6, and .net 7.

Releases of Visual Studio prior to VS 2012 did not have the ability to directly run tests built with Open Source testing
frameworks like NUnit.

[Download Released versions](https://www.nuget.org/packages/NUnit3TestAdapter/)

[Download Pre-release versions](https://www.myget.org/feed/nunit/package/nuget/NUnit3TestAdapter)

The adapter is delivered as a nuget package to be installed into all test projects.  

> [!NOTE] Up to version 3.17 there is also a VSIX extension version, which was used earlier for Visual Studio up to
> version 2019. The support for this has been deprecated, and the existing VSIX version does not work for VS 2022. The
> recommendation is to avoid this altogether and use the nuget version. It is not possible to run NUnit 2.x tests using
> this adapter. Use the original adapter for that purpose. If you need to work with projects using NUnit 2.x and other
> projects using NUnit 3, you may install both versions of the adapter.

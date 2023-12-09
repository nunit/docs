# Adapter V4 Release Notes

## NUnit3 Test Adapter for Visual Studio and Dotnet - Version 4.5.0 - May 30, 2023

This is a version supporting the upcoming NUnit version 4.  It uses a released version of the NUnit.Engine, version
3.15.4.

* [1080](https://github.com/nunit/nunit3-vs-adapter/issues/1080) Allow the adapter to be used with NUnit version 4
* [1100](https://github.com/nunit/nunit3-vs-adapter/issues/1100) Allow to debug parallel tests

## NUnit3 Test Adapter for Visual Studio - Version 4.4.2 - Mar 1, 2023

This is a hotfix for the 4.4.0 version.  The 4.4.0 included the NUnit.Engine 3.16.3, which uses an external package for
loading assemblies.  It turns out the engine fails for certain types of loading, in particular when an assembly is
loaded by reflection.

In order to fix this, this version have reverted to a version of the NUnit.Engine based on 3.15.2, which does not have
this way of loading assemblies. The included Engine is not available as a separate package, but if you use anything that
needs the engine package (like the NUnit.Console), version 3.15.2 should work.

The embedded engine handles the .net 8 the same way as with the 4.4.0 adapter.

The following issues, all related to the same problem, are fixed in this release:

* [1065](https://github.com/nunit/nunit3-vs-adapter/issues/1065) WebHostBuilder.ConfigureServices method not found when
  using version 4.4.0
* [1066](https://github.com/nunit/nunit3-vs-adapter/issues/1066) Breaking change for TestAssemblyLoadContext
* [1069](https://github.com/nunit/nunit3-vs-adapter/issues/1069) Any type loaded from assembly at runtime does not match
  compile-time type
* [1070](https://github.com/nunit/nunit3-vs-adapter/issues/1070) NUnit failed to load test assembly after upgrading from
  4.3.1 to 4.4.0

Thanks to everyone that reported in, and special thanks to everyone that provided repro solutions for the problem.

## NUnit3 Test Adapter for Visual Studio - Version 4.4.0 - Feb 26, 2023

**:warning: This version has been unlisted on NuGet, please use version 4.4.2 instead.**

The main focus is the support for .Net 8.  This version of the adapter will accept any higher version of the .net, also
future higher versions than .net 8.

The following issues are fixed in this release:

* [1049](https://github.com/nunit/nunit3-vs-adapter/issues/1049) .Net Framework tests fails when .Net 8 is present on
  system

* [1037](https://github.com/nunit/nunit3-vs-adapter/issues/1037) TestContext.Progress shows up as Warning in TFS/Azure
  Dev Ops. Thanks to [mharwig](https://github.com/mharwig) for the
  [PR](https://github.com/nunit/nunit3-vs-adapter/pull/1038).

### Beta release

A beta release, Version 4.4.0-beta.1, was released on Feb 23, 2023. There is no changes between this and the previous
beta release, except for updates of packages for the test projects.

## NUnit3 Test Adapter for Visual Studio - Version 4.3.2 - Des 9, 2023

A hotfix release for issue [#1144](https://github.com/nunit/nunit3-vs-adapter/issues/1144).

The adapter could not work running under .net 8 due to the use of an older NUnit.Engine.
The engine has been updated to version 3.15.5

* [1144](https://github.com/nunit/nunit3-vs-adapter/issues/1144) Fixed by team.

## NUnit3 Test Adapter for Visual Studio - Version 4.3.1 - Nov 19, 2022

This is a hotfix release for three major and critical problems:

1) .Net Framework (4.8 and lower) would crash due to InternalTracelog files trying to be written to the Program Files
   directory.
2) InternalTracelog files would appear in root of solution
3) TestOutputXml did not work correctly when specified

In order to get these fixed the support for netcore2.1 had to be dropped.  This version is also now unsupported by
Microsoft, so the adapter follows that.

* [987](https://github.com/nunit/nunit3-vs-adapter/issues/987) Regression on this issue due to the InternalTracelog
  files
* [1026](https://github.com/nunit/nunit3-vs-adapter/issues/1026) Current directory C:\WINDOWS\system32 again
* [1027](https://github.com/nunit/nunit3-vs-adapter/issues/1027) Test Explorer is finding tests, but not running them
  after upgrading to NUnit3TestAdapter v4.3.0
* [1028](https://github.com/nunit/nunit3-vs-adapter/issues/1028) Test discovery emits zero length `internaltrace` log
  file per project
* [1030](https://github.com/nunit/nunit3-vs-adapter/issues/1030) Problem if OutputXmlFolderMode setting is not in
  .runsettings
* [1031](https://github.com/nunit/nunit3-vs-adapter/issues/1031) TestOutputXml regressions

### Credits

Thanks to [Jan Inge Dalsbø](https://github.com/janid1967), [Taylor Willis](https://github.com/Guitrum), [Kai
Nadler](https://github.com/smkanadl), [Barnabas Lakner](https://github.com/barnabas90),
[sandrohanea](https://github.com/sandrohanea), [Elliot Prior](https://github.com/Quogu), [Todd
Ogin](https://github.com/ojintoad), [Evheniyrz](https://github.com/evheniyrz), [Manfred
Brands](https://github.com/manfred-brands), [Boris Drajer](https://github.com/bdrajer), [Ken
V](https://github.com/varnk), [Mike Vorhees](https://github.com/mrvoorhe) for all the help with reporting the issues,
reproducing them, analysis and diagnostics, and confirming that 4.3.1 resolves the issues.  Your help is really
appreciated!

## NUnit3 Test Adapter for Visual Studio - Version 4.3.0 - Oct 29, 2022

This version is for support of the .net 7 framework. See an overview of [supported frameworks
here](/articles/vs-test-adapter/Supported-Frameworks.html).

The support is due to the updated embedded [NUnit.Engine version
3.15.2](/articles/nunit-engine/release-notes.html#nunit-console--engine-3152---june-30-2022).

* [987](https://github.com/nunit/nunit3-vs-adapter/issues/987)  System.ArgumentException: Unknown framework version 7.0

Other bugs fixed:

* [990](https://github.com/nunit/nunit3-vs-adapter/issues/990) Missing output with failed test stack traces for
  Assert.Multiple
* [997](https://github.com/nunit/nunit3-vs-adapter/issues/997) TRX report file folder inconsistent with XML report
  folder using .runsettings file. Note that a new runsettings flag has been added for supporting this, see
  [OutputXmlFolderMode](/articles/vs-test-adapter/Tips-And-Tricks.html#OutputXmlFolderMode).

## NUnit3 Test Adapter for Visual Studio - Version 4.2.1 - Jan 21, 2022

This is a hotfix release for

* [941](https://github.com/nunit/nunit3-vs-adapter/issues/941) When running `dotnet test` with filter, all tests are run
  and all console output is logged.

This fix applies to test projects where all tests are excluded by a test item filter. Previously, as of v4.2.0, all
tests were unintentionally run. Note that this issue did not affect category filters.

## NUnit3 Test Adapter for Visual Studio - Version 4.2.0 - Dec 19, 2021

This is a bug fix release, with the following fixes:

* [818](https://github.com/nunit/nunit3-vs-adapter/issues/818) Known Vulnerability in System.Xml.XPath.XmlDocument
* [912](https://github.com/nunit/nunit3-vs-adapter/issues/912) Explicit runs when using NUnit-filters 'cat!=FOO'
* [914](https://github.com/nunit/nunit3-vs-adapter/issues/914) AddTestAttachment does not work anymore in VS2022
* [918](https://github.com/nunit/nunit3-vs-adapter/issues/918) New DiscoveryMode doesn't play nicely with
  TestFixtureSource - Missing GenericFixture
* [919](https://github.com/nunit/nunit3-vs-adapter/issues/919) VSTest test case filter does not work with parentheses
* [929](https://github.com/nunit/nunit3-vs-adapter/issues/929) Lots of warnings logged when filter matches no tests
  'cat=BAZ', including other issues in the same.  Thanks to [@runehalfdan](https://github.com/runehalfdan) for a lot of
  help reproducing and verifying these issues.  Fixing this also improved performance, and cleared out issues with
  Explicit tests.
* [934](https://github.com/nunit/nunit3-vs-adapter/issues/934) Console output no longer output by dotnet test -v n.

### Engine update

The NUnit.Engine has been updated to version 3.13 in this release.  See [engine release
notes](xref:consoleenginereleasenotes) for details.

### Development

The [debugging of an adapter](Debugging.md) has been made simpler, using just a runsetting to enable it.  See [this
post](http://hermit.no/debugging-the-nunit3testadapter-take-2/) for details on the process.

## NUnit3 Test Adapter for Visual Studio - Version 4.1.0 - Nov 8, 2021

This is a bug fix release, with the following fixes:

* [516](https://github.com/nunit/nunit3-vs-adapter/issues/516) ArgumentException when whitespace sent to logger. Thanks
  to [Matt Jones - mthjones](https://github.com/mthjones) for a very good repro, that helped nail this down!

* [865](https://github.com/nunit/nunit3-vs-adapter/issues/865) Breaking changing in 3.17 on "Exception encountered
  unloading application domain"

* [869](https://github.com/nunit/nunit3-vs-adapter/issues/869) NUnitTestAdapter - Discovery exception

* [884](https://github.com/nunit/nunit3-vs-adapter/issues/884) NUnit3TestAdapter 4.0.0 - DiscoveryException: Not a
  TestFixture, SetUpFixture or TestSuite, but ParameterizedFixture

## NUnit3 Test Adapter for Visual Studio - Version 4.0.0 - June 6, 2021

This major release contains a series of changes, and also underlying changes in the adapter.  

This is currently the version that will support Visual Studio 2022.  The earlier versions will initially not support VS
2022.

(There is a currently unknown issue that blocks the 3.X series for VS 2022.  It is currently unclear if the Visual
Studio team may be able to fix this issue. Any fix from the adapter side will include an upgrade, and then the 4.X
series is the solution for that.)

* [**Explicit**](https://github.com/nunit/nunit3-vs-adapter/issues?q=is%3Aissue+is%3Aclosed+project%3Anunit%2Fnunit3-vs-adapter%2F3)
  works now for all versions of Visual Studio. This is covered by several issues, see below on alpha and beta release
  notes.  

See the alpha and beta release notes below for more issues and features that have been resolved and is included in this
major release.

The following additional features have been implemented in the final release.

* [671](https://github.com/nunit/nunit3-vs-adapter/issues/671) Exception in OneTimeSetUp has no stack trace

* [843](https://github.com/nunit/nunit3-vs-adapter/issues/843) Reporting random seed for a test case

* [863](https://github.com/nunit/nunit3-vs-adapter/pull/863) The Test Name is by default added to the console output for
  tests. It can be turned off by the
  [UseTestNameInConsoleOutput](/articles/vs-test-adapter/Tips-And-Tricks.html#usetestnameinconsoleoutput) property.

The following additional issue has been resolved:

* [779](https://github.com/nunit/nunit3-vs-adapter/issues/779) Filtering tests with any "PropertyAttribute"

* [852](https://github.com/nunit/nunit3-vs-adapter/issues/852) NullReferenceException in ExtractTestFixture in
  v4.0.0-beta2.

## NUnit3 Test Adapter for Visual Studio - Version 4.0.0-beta.2 - April 6, 2021

This will be a short beta.2, given we don't hit on any intricate issues.  

A major change in this version is the upgrade of the NUnit.Engine to version 3.12, and thus Mono.Cecil is no longer
used.  Instead it has a reduced version (based on Mono.Cecil) packed into TestCentric.engine.metadata doing the same job
with navigation data.  

The following issues have been resolved:

* [824](https://github.com/nunit/nunit3-vs-adapter/issues/824 ) "Not a TestFixture or TestSuite, but SetUpFixture"
  exception is being thrown in case of more than one SetUpFixture
* [811](https://github.com/nunit/nunit3-vs-adapter/issues/811) "System.FormatException: The UTC representation of the
  date falls outside the year range 1-9999" from skipped test in Eastern European time zone.  Thanks to
  [KalleOlaviNiemitalo](https://github.com/KalleOlaviNiemitalo) for suggesting the fix.

Also a performance improvement was done, thanks to [Pakrym](https://github.com/pakrym) for the [PR
821](https://github.com/nunit/nunit3-vs-adapter/pull/821)

## NUnit3 Test Adapter for Visual Studio - Version 4.0.0-beta.1 - Nov 20, 2020

This beta is based on the earlier alpha version, and includes new fixes, some reported in the alpha. A great thank you
to those who reported and checked out the fixes in the alpha!

The alpha has more than 32000 downloads, with only a few issues reported, so we feel safe to move up to a beta.  The
time for beta will be much shorter, so we might be able to release a final 4.0.0 version before end of 2020.

We have also been able to shoehorn some new features into the release.

* [770](https://github.com/nunit/nunit3-vs-adapter/issues/770)  "Not a TestFixture, but TestSuite" error when using
  un-namespaced SetupFixture.
* [774](https://github.com/nunit/nunit3-vs-adapter/issues/774) Tests not executed if Console.WriteLine() is used.
* [780](https://github.com/nunit/nunit3-vs-adapter/issues/780) NUnit3TestAdapter 3.17.0 empty output file regression?
* [781](https://github.com/nunit/nunit3-vs-adapter/issues/781) An exception occurred while test discoverer
  'NUnit3TestDiscoverer' was loading tests. Exception: Object reference not set to an instance of an object, with
  VS2015.
* [785](https://github.com/nunit/nunit3-vs-adapter/issues/785) Seemingly redundant dependency on
  Microsoft.DotNet.InternalAbstractions. Thanks to [teo-tsirpanis](https://github.com/teo-tsirpanis) for [PR
  790](https://github.com/nunit/nunit3-vs-adapter/pull/790).
* [786](https://github.com/nunit/nunit3-vs-adapter/issues/786) When using TRX logger, should warn about incompatible
  test adapter across .NET Framework and .NET Core and/or log where an adapter is located.
* [788](https://github.com/nunit/nunit3-vs-adapter/issues/788) Documentation: Broken links in user guide
  [vs-test-adapter/Resources.html].
* [797](https://github.com/nunit/nunit3-vs-adapter/issues/797) Proprietary licensed files
* [800](https://github.com/nunit/nunit3-vs-adapter/issues/800) Rerun in azure devops overwrites last test results xml.
  Thanks to [netcorefactory](https://github.com/netcorefactory) for [PR
  799](https://github.com/nunit/nunit3-vs-adapter/pull/799).

## NUnit3 Test Adapter for Visual Studio - Version 4.0.0-alpha.1 - July 12, 2020

This is an early pre-release version.  

The code has been rewritten/refactored in order to get some of the more complex issues fixed.  It does pass all the
automatic tests we have, but there are still more tests we would like to take it through, before we release a beta.  

We would really appreciate it if you give this alpha a spin. and
[report](https://github.com/nunit/nunit3-vs-adapter/issues) whatever you find back to us.

The major fixes now are Explicit runs are fully back, both in Visual Studio and on command line with dotnet test and
vstest.console.

Further there has been a significant performance improvement for large test sets, and in particular when you run with
categories or other filters.

For those interested in details, some of this has been achieved by converting the VSTest type of filters to NUnit native
filters  (Thanks to [Charlie Poole](https://github.com/CharliePoole) for his excellent contribution here.).

* [497](https://github.com/nunit/nunit3-vs-adapter/issues/497)  Dotnet test with category filter is slow with a lot of
  tests
* [545](https://github.com/nunit/nunit3-vs-adapter/issues/545)  Setting `TestCaseSource` to `Explicit` makes other tests
  in fixture explicit
* [612](https://github.com/nunit/nunit3-vs-adapter/issues/612)  It is not possible to run an explicit test from Test
  Explorer
* [658](https://github.com/nunit/nunit3-vs-adapter/issues/658)  Explicit tests are automatically run in Visual Studio
  2019
* [767](https://github.com/nunit/nunit3-vs-adapter/issues/767)  Replace use of VSTest filters with NUnit filters

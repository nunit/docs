---
uid: consoleenginereleasenotes
---

# Console and Engine Release Notes

## NUnit Console & Engine 3.16.1 - January 4, 2023

This release fixes several critical or high-priority bugs in the 3.16.0 release.

### Bugs

- [__#1271__](https://github.com/nunit/nunit-console/issues/1271) Install dotnet tool failed
- [__#1274__](https://github.com/nunit/nunit-console/issues/1274) NUnit Console won't run unless .NET Desktop and ASP.NET Runtimes are installed
- [__#1275__](https://github.com/nunit/nunit-console/issues/1275) Missing assembly in NUnit.Engine nuget package
- [__#1277__](https://github.com/nunit/nunit-console/issues/1277) NUnit does not work without .NET Core

### Build

- [__#1284__](https://github.com/nunit/nunit-console/pull/1284) Restore ability to debug packages

## NUnit Console & Engine 3.16.0 - November 14, 2022

Further releases in the 3.x series were not anticipated after 3.15. However, since a number of new features and enhancements have been implemented,
we are releasing version 3.16 of the engine and console runner.

This release incorporates support for executing tests under .NET 7.0. The runner itself is now built for .NET 4.6.2 rather than .NET 2.0.
Substantial changes have been made in the location of dependencies when running under .NET Core.

### Bugs

- [__#291__](https://github.com/nunit/nunit-console/issues/291) Error running tests from assembly built using VS2017 csproj file format
- [__#299__](https://github.com/nunit/nunit-console/issues/299) Attempting to target too low a framework throws exception
- [__#1130__](https://github.com/nunit/nunit-console/issues/1130) v3.14 fails with target framework net461 ... net48 on linux (ArgumentException: The net-4.6.1 framework is not available.), but v3.12 works well
- [__#1176__](https://github.com/nunit/nunit-console/issues/1176) Exception when targeting .NET Framework with .NET 7 installed
- [__#1178__](https://github.com/nunit/nunit-console/issues/1178) Running tests with nunit3-console version 3.15.0 generates empty log files
- [__#1180__](https://github.com/nunit/nunit-console/issues/1180) NUnit Engine 3.15.0 cannot load the test assembly
- [__#1182__](https://github.com/nunit/nunit-console/issues/1182) Running tests using the VS Solution results in an exception if any projects target .NET Standard
- [__#1183__](https://github.com/nunit/nunit-console/issues/1183) Build hangs when test spawns processes which do not terminate properly
- [__#1185__](https://github.com/nunit/nunit-console/issues/1185) 3.15.0 - MSI package is unable to acquire remote process agent
- [__#1203__](https://github.com/nunit/nunit-console/issues/1203) NUnit Console 3.15.2: Could not load file or assembly "System.Windows.Forms"
- [__#1206__](https://github.com/nunit/nunit-console/issues/1206) NUnit.Engine.NUnitEngineException when spaces in agent file path
- [__#1208__](https://github.com/nunit/nunit-console/issues/1208) Inconsistencies between nunit3-console and running the project via Visual Studio
- [__#1217__](https://github.com/nunit/nunit-console/issues/1217) Assembly loading deduplication
- [__#1225__](https://github.com/nunit/nunit-console/issues/1225) Restore netcoreapp3.1 build to the engine package

### Build

- [__#1118__](https://github.com/nunit/nunit-console/issues/1118) Reorganize build output (bin) directories
- [__#1244__](https://github.com/nunit/nunit-console/pull/1244) Upgrade Cake.Tool to 2.3.0
- [__#1246__](https://github.com/nunit/nunit-console/issues/1246) Reduce build targets for nunit.engine.core assembly
- [__#1254__](https://github.com/nunit/nunit-console/pull/1254) Get Linux build working under Azure - tests still not run
- [__#1255__](https://github.com/nunit/nunit-console/pull/1255) Get MacOS build working in Azure
- [__#1257__](https://github.com/nunit/nunit-console/pull/1257) Enable testing under MacOS on Azure

### Enhancements

- [__#941__](https://github.com/nunit/nunit-console/issues/941) Allow netcoreapp agent to work with non-standard dotnet install locations
- [__#1223__](https://github.com/nunit/nunit-console/issues/1223) Exception when previously unknown .NET Core runtime is found on machine
- [__#1224__](https://github.com/nunit/nunit-console/issues/1224) Change name of NUnit Net Core Runner executable
- [__#1243__](https://github.com/nunit/nunit-console/issues/1243) Upgrade our .Net 7.0 assemblies to RC 2

### Features

- [__#1216__](https://github.com/nunit/nunit-console/issues/1216) Add .NET 7.0 Agent
- [__#1232__](https://github.com/nunit/nunit-console/issues/1232) Stop building console runner with .NET 2.0
- [__#1265__](https://github.com/nunit/nunit-console/issues/1265) Update .NET 7.0 Support from RC-2 to Final Release

## NUnit Console & Engine 3.15.2 - June 30, 2022

Release primarily to correct a critical bug arising when .NET 7.0 is installed.

__Note:__ There is no 3.15.1 release because a 3.15.1 package identical to 3.15.0 was accidentally uploaded to NuGet.org when 3.15 was released.

### Bugs

* [__#1178__](https://github.com/nunit/nunit-console/issues/1178) Running tests with nunit3-console version 3.15.0 generates empty log files
* [__#1193__](https://github.com/nunit/nunit-console/issues/1193) Prevent Crash under .NET 7.0 in 3.15.1 build
* [__#1196__](https://github.com/nunit/nunit-console/issues/1196) Modify build script to support continued version 3 releases where needed

## NUnit Console & Engine 3.15 - February 10, 2022

Final Release of NUnit ConsoleRunner 3.15.0. No changes from the beta1 Release.

Version 3.15.0 is expected to be the final release in the 3.x series.

## NUnit Console & Engine 3.15 Beta 1 - February 6, 2022

Beta release of version 3.15.0 of the Console Runner. Both the standard runner and the dotnet CLI command are now able to run tests under .Net 6.0.

* [__#1017__](https://github.com/nunit/nunit-console/issues/1017) Should we change 'master' to 'main'?
* [__#1026__](https://github.com/nunit/nunit-console/issues/1026) Make NUnit.Engine.Internal.Tests.PathUtilTests_Windows.SamePathOrUnder work under ubuntu-latest
* [__#1044__](https://github.com/nunit/nunit-console/issues/1044) Agent for .NET 6.0
* [__#1050__](https://github.com/nunit/nunit-console/issues/1050) More discrete logging
* [__#1087__](https://github.com/nunit/nunit-console/issues/1087) Switch all engine tests to NUnitLite
* [__#1094__](https://github.com/nunit/nunit-console/issues/1094) CreateDraftRelease command should run locally without a release branch
* [__#1095__](https://github.com/nunit/nunit-console/issues/1095) Allow single-letter options for cake script
* [__#1096__](https://github.com/nunit/nunit-console/issues/1096) Symbol package validation failing for NUnit.ConsoleRunner.NetCore
* [__#1108__](https://github.com/nunit/nunit-console/issues/1108) Generate AssemblyInfo files from csproj
* [__#1112__](https://github.com/nunit/nunit-console/issues/1112) Use VS2022 for CI Build
* [__#1123__](https://github.com/nunit/nunit-console/issues/1123) NETCORE Console Runner should target .NET 6.0
* [__#1125__](https://github.com/nunit/nunit-console/pull/1125) Save results of each package test separately

## NUnit Console & Engine 3.14 - January 15, 2022

This release features a new agent for tests targeting .NET 5.0. In addition, automation of our publication and release process
is now complete from creation of a draft release through releasing to production on GitHub. While this doesn't impact users directly,
it will allow us to speed up the introduction of new features in coming releases.

* [570](https://github.com/nunit/nunit-console/issues/570) Where are the checksums for your downloads?
* [1012](https://github.com/nunit/nunit-console/issues/1012) Automatically roll-forward if no .NET Core 3.1 runtime available
* [1048](https://github.com/nunit/nunit-console/issues/1048) Agent for Net 5.0
* [1057](https://github.com/nunit/nunit-console/issues/1057) Automate all package publication and release
* [1075](https://github.com/nunit/nunit-console/issues/1075) Separate nunit.engine.core.tests from nunit.engine.tests
* [1084](https://github.com/nunit/nunit-console/issues/1084) Eliminate Packaging on Azure
* [1090](https://github.com/nunit/nunit-console/issues/1090) Test of --debug-agent option fails under linux Debug configuration

## NUnit Console & Engine 3.13 - November 30, 2021

This is the first release of the NUnit Console Runner, `nunit3-console.exe`, which allows running of both .NET Framework and .NET Core tests,
either separately or in combination. The `nunit3-console.exe` runner executes under the .NET Framework but is able to launch .NET Core agents
and communicate with them over a TCP connection.

A second major feature in this release is engine support for preemptive cancellation when the normal approach of requesting the test run to
self-terminate doesn't work. This is an engine feature, available to any runners supporting cancellation.

* [382](https://github.com/nu__Bugs__nit/nunit-console/issues/382) Only 1 agent running with multiple projects and --process=Multiple
* [418](https://github.com/nunit/nunit-console/issues/418) <TestAssembly.dll>.config files not loaded when using an .nunit project file and --process=Multiple
* [551](https://github.com/nunit/nunit-console/issues/551) Make engine easier to Debug
* [609](https://github.com/nunit/nunit-console/issues/609) Run after Reload reports assemblies multiple times
* [642](https://github.com/nunit/nunit-console/issues/642) Engine needs preemptive cancellation
* [726](https://github.com/nunit/nunit-console/issues/726) Remove .NET Standard 1.6 build
* [764](https://github.com/nunit/nunit-console/issues/764) Error: Found two different objects associated with the same URI, /xxxxx/TestAgency
* [789](https://github.com/nunit/nunit-console/issues/789) DirectoryFinder.GetDirectories throws for a path with the drive specified
* [803](https://github.com/nunit/nunit-console/issues/803) Remove CHANGES.TXT to simplify release process
* [828](https://github.com/nunit/nunit-console/issues/828) Reported issues with dependency loading in .NET Core Console
* [852](https://github.com/nunit/nunit-console/issues/852) No tests of .NET Core 3.1 packages
* [855](https://github.com/nunit/nunit-console/issues/855) Improved testability of DirectoryFinder
* [869](https://github.com/nunit/nunit-console/issues/869) Link to release notes on docs and Review uses of CHANGES.TXT
* [892](https://github.com/nunit/nunit-console/issues/892) Implement Package tests for engine and console runner
* [895](https://github.com/nunit/nunit-console/issues/895) Make sure AssemblyDefinitions are disposed after use.
* [898](https://github.com/nunit/nunit-console/issues/898) Removed support for .NET Core 1.1
* [904](https://github.com/nunit/nunit-console/issues/904) The test-run element is missing a count of warnings
* [908](https://github.com/nunit/nunit-console/issues/908) Known Vulnerability in System.Xml.XPath.XmlDocument
* [915](https://github.com/nunit/nunit-console/issues/915) StackOverflowException in console-runner when addins-file contains "./" or ".\"
* [923](https://github.com/nunit/nunit-console/issues/923) Agent communication layer
* [933](https://github.com/nunit/nunit-console/issues/933) Update TestCentric MetaData dependency
* [943](https://github.com/nunit/nunit-console/issues/943) Remove Travis CI
* [947](https://github.com/nunit/nunit-console/issues/947) Make default TestAgency URI unique per run (v2)
* [949](https://github.com/nunit/nunit-console/issues/949) nunit.engine.tests are failing to unload on master branch
* [956](https://github.com/nunit/nunit-console/issues/956) fix for test assembly loading failure in NUnit.ConsoleRunner.NetCore
* [957](https://github.com/nunit/nunit-console/issues/957) Include pdbs with nuget and zip packages and publish source code
* [964](https://github.com/nunit/nunit-console/issues/954) Update Code of Conduct
* [1014](https://github.com/nunit/nunit-console/issues/1014) GetClrVersionForFramework throws if .Net6.0 is installed
* [1025](https://github.com/nunit/nunit-console/issues/1025) chore(pipeline): Use ubuntu-latest
* [1031](https://github.com/nunit/nunit-console/issues/1031) Fix incorrect MyGet push URL
* [1033](https://github.com/nunit/nunit-console/issues/1033) Update to current version of TestCentric.Metadata package
* [1037](https://github.com/nunit/nunit-console/issues/1037) Eliminate End of Life Check in builds
* [1039](https://github.com/nunit/nunit-console/issues/1039) Stop re-publishing deprecated packages with each new release

## NUnit Console & Engine 3.12 - January 17, 2021

## .NET Core NUnit Console 3.12 Beta 2  - January 17, 2021

This release contains various improvements to running tests on .NET Core and Mono, and changes to
extension loading logic to allow the Engine to better support extensions which target multiple platforms. There are additionally
a number of fixes to issues that were identified with 3.12 Beta 1. Please also be aware that this will be the last version of
the NUnit Engine to support .NET Standard 1.6.

The .NET Core Console remains in Beta due to some unresolved dependency loading and framework targeting issues - contributions to
fix these issues would be very welcome!

Code contributions in this release were included from [Charlie Poole](https://github.com/CharliePoole), [Chris Maddock](https://github.com/ChrisMaddock), [Christian Bay](https://github.com/tdctaz), [Eberhard Beilharz](https://github.com/ermshiperete), [Ed Ball](https://github.com/ejball), [Joseph Musser](https://github.com/jnm2), [Manohar Singh](https://github.com/mano-si), [Mattias Cavigelli](https://github.com/mcavigelli) and [Mikkel Nylander Bundgaard](https://github.com/mikkelbu). Thank you to all those who contributed both in code, and otherwise.

Please note the below list includes only issues resolved between 3.12.0 Beta 1 and the final release. For those upgrading from 3.11.1
or earlier, please also see the Beta release notes.

* [511](https://github.com/nunit/nunit-console/issues/511) [Build] Improve detection of installed .NET Core Runtimes
* [718](https://github.com/nunit/nunit-console/issues/718) Eliminate use of Mono.Cecil
* [810](https://github.com/nunit/nunit-console/issues/810) Build NUnit.ConsoleRunner.NetCore as a .NET Core Tool.
* [811](https://github.com/nunit/nunit-console/issues/811) Use readonly modifier where possible
* [818](https://github.com/nunit/nunit-console/issues/818) Remove redundant dependency on Microsoft.DotNet.InternalAbstractions for platforms other than .NET Standard 1.6
* [825](https://github.com/nunit/nunit-console/issues/825) Revert change to increment nunit.engine.api assembly version
* [829](https://github.com/nunit/nunit-console/issues/829) Revert change made to IExtensionService in nunit.engine.api
* [830](https://github.com/nunit/nunit-console/issues/830) [CI] Test on .NET 5.0
* [837](https://github.com/nunit/nunit-console/issues/837) Fully remove Microsoft.Dotnet.InternalAbstractions dependency
* [844](https://github.com/nunit/nunit-console/issues/844) .NET Core console runner fails to load extensions when netfx and netstandard versions conflict
* [847](https://github.com/nunit/nunit-console/issues/847) [Build] Specify .NET 2.0 version of extensions for msi
* [853](https://github.com/nunit/nunit-console/issues/853) [Build] Allow local build to succeed even if all runtimes are not installed
* [863](https://github.com/nunit/nunit-console/issues/863) [Build] Use released version of NUnit Framework 3.13.0

## NUnit Console & Engine 3.12 Beta 1 - August 1, 2020

This is the first beta release of the NUnit Console able to run .NET Core Tests. In addition to this, this release also contains a number of bug fixes, improvements when running on Mono and significant refactoring work towards the goal of creating an engine able to run tests on a wider range of .NET platforms.

We're particularly interested in this beta release being tested by users of the .NET Core console and users running tests on Mono. Please feedback any issues to the [nunit-console repository](https://github.com/nunit/nunit-console/issues).

The .NET Core Console is a separate executable to the original version, and can be found in either the .zip file download, or the new [NUnit.ConsoleRunner.NetCore](https://www.nuget.org/packages/NUnit.ConsoleRunner.NetCore/) NuGet package. Our longer-term aim is to create a single console which is able to run both .NET Core and .NET Framework tests.

Code contributions in this release were included from [Charlie Poole](https://github.com/CharliePoole), [Chris Maddock](https://github.com/ChrisMaddock), [Christian Bay](https://github.com/tdctaz), [Eberhard Beilharz](https://github.com/ermshiperete), [Joseph Musser](https://github.com/jnm2), [Manohar Singh](https://github.com/mano-si) and [Mikkel Nylander Bundgaard](https://github.com/mikkelbu). Thank you to all those who contributed both in code, and other ways!

* [391](https://github.com/nunit/nunit-console/issues/391) Provide useful error message when agent crashes with a stack overflow exception
* [475](https://github.com/nunit/nunit-console/issues/475) Create .NET Core Console Runner
* [662](https://github.com/nunit/nunit-console/issues/662) Mono: Stacktrace missing files and line numbers
* [710](https://github.com/nunit/nunit-console/issues/710) .NET Core engine only works when located in same directory as test assembly
* [733](https://github.com/nunit/nunit-console/issues/733) iconUrl is deprecated in NuGet packages
* [740](https://github.com/nunit/nunit-console/issues/740) Create separate agents for .NET 2.0-3.5 and .NET 4.x
* [747](https://github.com/nunit/nunit-console/issues/747) [CI] Change macOS image version
* [748](https://github.com/nunit/nunit-console/issues/748) Make Project config information available to runners
* [750](https://github.com/nunit/nunit-console/issues/750) .NET Core Console Packaging
* [751](https://github.com/nunit/nunit-console/issues/751) Minor updates to Contributing.MD
* [757](https://github.com/nunit/nunit-console/issues/757) Unable to test net 3.5 assembly if there's incompatible extension installed
* [758](https://github.com/nunit/nunit-console/issues/758) Carry CurrentDirectory over to agent Processes
* [761](https://github.com/nunit/nunit-console/issues/761) Revert accidental debug message change
* [762](https://github.com/nunit/nunit-console/issues/762) Simplify agent communication in preparation for new wire protocol
* [765](https://github.com/nunit/nunit-console/issues/765) Split RuntimeFramework package setting into two: Requested and Target
* [768](https://github.com/nunit/nunit-console/issues/768) Test run exits with an exit code of 0 if a multiple of 256 tests fail
* [775](https://github.com/nunit/nunit-console/issues/775) Extension loading broken on Linux when installed from nuget package
* [777](https://github.com/nunit/nunit-console/issues/777) Remove unused code to locate engine from registry keys
* [778](https://github.com/nunit/nunit-console/issues/778) Add .NET Core 3.1 build of engine to access APIs for loading .NET Core assemblies correctly
* [779](https://github.com/nunit/nunit-console/issues/779) [CI] Revert to running .NET Standard Engine Tests via NUnitLite
* [783](https://github.com/nunit/nunit-console/issues/783) Refactor XMLTransformResultWriterTests to avoid initializing entire engine
* [784](https://github.com/nunit/nunit-console/issues/784) Fix DirectTestRunner to not give all drivers the same ID.
* [790](https://github.com/nunit/nunit-console/issues/790) Fix agent debug logging
* [800](https://github.com/nunit/nunit-console/issues/800) TypeLoadException thrown when changes are made to the API assembly, with multiple versions of the engine available
* [801](https://github.com/nunit/nunit-console/issues/801) Begin incrementing EngineApiVersion with every release, as per Engine version

## NUnit Console & Engine 3.11.1 - February 15, 2020

This hotfix fixes a problem with NUnit Project file settings being ignored.

* [730](https://github.com/nunit/nunit-console/issues/730) NUnit project file settings are ignored
* [732](https://github.com/nunit/nunit-console/issues/732) Upgrade Cake Build to fix Linux CI

## NUnit Console 3.11 - January 26, 2020

This release fixes a range of minor bugs, and includes a significant amount of internal restructuring work. In future, this will enable improved .NET Standard support in the engine, and a .NET Core build of the console.

* [22](https://github.com/nunit/nunit-console/issues/22) Engine modifies TestPackage
* [53](https://github.com/nunit/nunit-console/issues/53) Add project element to top-level sub-project before merging
* [181](https://github.com/nunit/nunit-console/issues/181) XSLT Transform not honoring --encoding value
* [336](https://github.com/nunit/nunit-console/issues/336) Should legacyCorruptedStateExceptionsPolicy enabled=true in nunit3-console.exe.config?
* [386](https://github.com/nunit/nunit-console/issues/386) nUnit project loader does not work when --inprocess is set
* [453](https://github.com/nunit/nunit-console/issues/453) build-mono-docker.ps1 fails to run out the box
* [514](https://github.com/nunit/nunit-console/issues/514) Add higher-level unit tests for structure of TestRunners
* [586](https://github.com/nunit/nunit-console/issues/586) Create Separate Addin File for the Engine NuGet Package
* [588](https://github.com/nunit/nunit-console/issues/588) licenseUrl in NuGet packages are deprecated
* [591](https://github.com/nunit/nunit-console/issues/591) Release 3.10 merge
* [592](https://github.com/nunit/nunit-console/issues/592) Add status badge from Azure pipelines
* [594](https://github.com/nunit/nunit-console/issues/594) Fixed typos in release notes
* [595](https://github.com/nunit/nunit-console/issues/595) Clean extension dir before running FetchExtensions task
* [603](https://github.com/nunit/nunit-console/issues/603) Engine returns assembly-level test-suite event twice
* [605](https://github.com/nunit/nunit-console/issues/605) Trailing \ in --work argument causes agent to crash
* [607](https://github.com/nunit/nunit-console/issues/607) Unload + Load changes TestPackage IDs
* [611](https://github.com/nunit/nunit-console/issues/611) Set DisableImplicitNuGetFallbackFolder and bump Ubuntu on Travis
* [612](https://github.com/nunit/nunit-console/issues/612) Fix logging when including exception
* [617](https://github.com/nunit/nunit-console/issues/617) Consider expanding projects before building ITestRunner structure
* [625](https://github.com/nunit/nunit-console/issues/625) [Feature] Extend `start-run` data for ITestEventListener
* [628](https://github.com/nunit/nunit-console/issues/628) [Question] Possible to set both labels=After and labels=Before
* [634](https://github.com/nunit/nunit-console/issues/634) Remove unnecessary stream creation in XML Transform writer
* [635](https://github.com/nunit/nunit-console/issues/635) Remove all #regions from codebase
* [636](https://github.com/nunit/nunit-console/issues/636) Labels option: Rename On as OnOutputOnly, and deprecate On and All
* [637](https://github.com/nunit/nunit-console/issues/637) Refactor RunnerSelectionTests
* [639](https://github.com/nunit/nunit-console/issues/639) Engine initializes DriverService too early
* [667](https://github.com/nunit/nunit-console/issues/667) Console Runner loads wrong .NET framework version when executing tests from multiple assemblies at once
* [669](https://github.com/nunit/nunit-console/issues/669) nunit.console-runner-with-extensions.nuspec: Remove outdated release notes
* [671](https://github.com/nunit/nunit-console/issues/671) Manually updated .NET Core SDK on Linux build
* [681](https://github.com/nunit/nunit-console/issues/681) Display path and version of extension assemblies
* [683](https://github.com/nunit/nunit-console/issues/683) Safely encapsulating the atomic agent database operations
* [684](https://github.com/nunit/nunit-console/issues/684) Split engine into upper and lower parts
* [691](https://github.com/nunit/nunit-console/issues/691) Sign NuGet Packages and msi
* [693](https://github.com/nunit/nunit-console/issues/693) Update Engine tests to run on LTS .NET Core version
* [696](https://github.com/nunit/nunit-console/issues/696) Minimal compilation/test of .NET Core Console
* [698](https://github.com/nunit/nunit-console/issues/698) Update NUnit v2 driver extension in combined packages
* [703](https://github.com/nunit/nunit-console/issues/703) Update Console options for .NET Core Console build
* [704](https://github.com/nunit/nunit-console/issues/704) Agent in nupkg should not be referenced and causes warnings in consuming projects
* [706](https://github.com/nunit/nunit-console/issues/706) build.cake maintenance
* [707](https://github.com/nunit/nunit-console/issues/707) Set agent to reference core and not full engine
* [713](https://github.com/nunit/nunit-console/issues/713) Engine will not recognize .NET Framework versions beyond 4.5

## NUnit Console 3.10 - March 24, 2019

This release merges the .NET Standard version of the engine back into the nunit.engine
NuGet package and adds a .NET Standard 2.0 version of the engine that re-enables most
services and extensions. This deprecates the `nunit.engine.netstandard` NuGet package.
Any test runners using the old .NET Standard version of the engine should switch to
this release.

The `--params` command line option which took multiple test parameters separated by
a semicolon is now deprecated in favor of the new `--testparam` command line option.
One of the most common uses for test parameters was to pass connection strings into
tests but this required workarounds to handle the semicolons. Now you must pass in
each test parameter separately using a `--testparam` or `--tp` option for each.

### Issues Resolved

* [8](https://github.com/nunit/nunit-console/issues/8) TempResourceFile.Dispose causes run to hang
* [23](https://github.com/nunit/nunit-console/issues/23) In nunit3-console you cannot pass parameters containing ';' because they always get split
* [178](https://github.com/nunit/nunit-console/issues/178) Add date and time to console output
* [282](https://github.com/nunit/nunit-console/issues/282) "Execution terminated after first error" does not fail the console runner
* [388](https://github.com/nunit/nunit-console/issues/388) Merge .NET Standard Engine back into the main solution
* [389](https://github.com/nunit/nunit-console/issues/389) Update Mono.Cecil to latest
* [433](https://github.com/nunit/nunit-console/issues/433) All messages from EventListenerTextWriter goes to console output independent on stream name
* [454](https://github.com/nunit/nunit-console/issues/454) Misc improvements to ExtensionServiceTests
* [455](https://github.com/nunit/nunit-console/issues/455) Remove CF, Silverlight and PORTABLE functionality
* [464](https://github.com/nunit/nunit-console/issues/464) NUnit Console Reports Successful Exit Code When there is an Exception on Dispose
* [473](https://github.com/nunit/nunit-console/issues/473) ArgumentException: DTD is prohibited in this XML document
* [476](https://github.com/nunit/nunit-console/issues/476) .NET Standard engine to load extensions
* [479](https://github.com/nunit/nunit-console/issues/479) Merge .NET Standard Engine code back into the main solution
* [483](https://github.com/nunit/nunit-console/issues/483) Error in SetUpFixture does not result in non-zero exit code
* [485](https://github.com/nunit/nunit-console/issues/485) Invalid integer arguments do not display properly in error message
* [493](https://github.com/nunit/nunit-console/issues/493) Correct order of params to Guard.ArgumentValid()
* [498](https://github.com/nunit/nunit-console/issues/498) Reset console colors after Ctrl-C
* [501](https://github.com/nunit/nunit-console/issues/501) Create result directory if it does not exist
* [502](https://github.com/nunit/nunit-console/issues/502) Remove unused method from build.cake
* [506](https://github.com/nunit/nunit-console/issues/506) Dogfood NUnit.Analyzers via the nunit-console tests
* [508](https://github.com/nunit/nunit-console/issues/508) Re-Enable OSX CI tests
* [515](https://github.com/nunit/nunit-console/issues/515) Appveyor CI failing on master
* [518](https://github.com/nunit/nunit-console/issues/518) Correct Refactoring Error
* [519](https://github.com/nunit/nunit-console/issues/519) Break up multiple console error messages with color
* [523](https://github.com/nunit/nunit-console/issues/523) Reloading multiple files causes exception
* [524](https://github.com/nunit/nunit-console/issues/524) .NET Standard 2.0 engine crashes when .NET Framework extensions are in Global NuGet Cache
* [525](https://github.com/nunit/nunit-console/issues/525) Separate NuGet Restore for Appveyor build
* [531](https://github.com/nunit/nunit-console/issues/531) Building a forked master branch results in publishing artifacts
* [533](https://github.com/nunit/nunit-console/issues/533) Duplicate ids when loading a project
* [544](https://github.com/nunit/nunit-console/issues/544) Deprecate nunit.netstandard.engine NuGet package
* [546](https://github.com/nunit/nunit-console/issues/546) Cannot run a project file using --process:Separate
* [547](https://github.com/nunit/nunit-console/issues/547) --labels=Before ignores `--nocolor`
* [556](https://github.com/nunit/nunit-console/issues/556) Appveyor CI failing due to nuget restore
* [557](https://github.com/nunit/nunit-console/issues/557) Disable CliFallbackFolder as a nuget source
* [562](https://github.com/nunit/nunit-console/issues/562) Fix typo in comment
* [563](https://github.com/nunit/nunit-console/issues/563) ProjectService is incorrectly initialized in agents
* [565](https://github.com/nunit/nunit-console/issues/565) Eliminate -dbg suffix from version
* [566](https://github.com/nunit/nunit-console/issues/566) SettingsService is not needed in agents
* [567](https://github.com/nunit/nunit-console/issues/567) Unnecessary call to IProjectService
* [571](https://github.com/nunit/nunit-console/issues/571) Space characters in the work directory path are not properly handled
* [583](https://github.com/nunit/nunit-console/issues/583) NUnit Console NuGet Package Doesn't Load Extensions
* [587](https://github.com/nunit/nunit-console/issues/587) Disable new MSBuild GenerateSupportedRuntime functionality, which breaks framework targeting

## NUnit Console 3.9 - September 5, 2018

This release should stop the dreaded SocketException problem on shutdown. The
console also no longer returns -5 when AppDomains fail to unload at the end of a
test run. These fixes should make CI runs much more stable and predictable.

For developers working on the NUnit Console and Engine project, Visual Studio
2017 update 5 or newer is now required to compile on the command line. This does
not effect developers using NUnit or the NUnit Console, both of which support building
and running your tests in any IDE and on any .NET Framework back to .NET 2.0.

### Issues Resolved

* [103](https://github.com/nunit/nunit-console/issues/103) The switch statement does not cover all values of the 'RuntimeType' enum: NetCF.
* [218](https://github.com/nunit/nunit-console/issues/218) Move Distribution back into the nunit-console project.
* [253](https://github.com/nunit/nunit-console/issues/253) Master Chocolatey issue
* [255](https://github.com/nunit/nunit-console/issues/255) SocketException thrown during console run
* [312](https://github.com/nunit/nunit-console/issues/312) CI failure: SocketException
* [360](https://github.com/nunit/nunit-console/issues/360) CommandLineOption --err does not write error input to ErrorFile
* [367](https://github.com/nunit/nunit-console/issues/367) nunit3-console loads nunit.framework with partial name
* [370](https://github.com/nunit/nunit-console/issues/370) Nunit.Console 3.8 - Socket Exception
* [371](https://github.com/nunit/nunit-console/issues/371) Remove -5 exit code on app domain unload failures
* [394](https://github.com/nunit/nunit-console/issues/394) Multi-targeted Engine Extensions
* [399](https://github.com/nunit/nunit-console/issues/399) Fix minor document issues
* [411](https://github.com/nunit/nunit-console/issues/411) Make output received when providing user friendly messages unloading the domain more user friendly
* [412](https://github.com/nunit/nunit-console/issues/412) Extensions not detected for version 3.9.0-dev-03997
* [436](https://github.com/nunit/nunit-console/issues/436) NUnitEngineException : Unable to acquire remote process agent
* [446](https://github.com/nunit/nunit-console/issues/446) Output CI version info to console
* [448](https://github.com/nunit/nunit-console/issues/448) Update vs-project-loader extension to 3.8.0
* [450](https://github.com/nunit/nunit-console/issues/450) Update NUnit.Extension.VSProjectLoader to 3.8.0
* [456](https://github.com/nunit/nunit-console/issues/456) NuGet Package : Add `repository` metadata.
* [461](https://github.com/nunit/nunit-console/issues/461) Use MSBuild /restore

## NUnit Console 3.8 - January 27, 2018

This release includes several fixes when unloading AppDomains and better error reporting. The
aggregate NuGet packages also include updated versions of several extensions.

### Issues Resolved

* [6](https://github.com/nunit/nunit-console/issues/6) TypeLoadException in nunit3-console 3.0.1
* [93](https://github.com/nunit/nunit-console/issues/93) Update Readme with information about the NuGet packages
* [111](https://github.com/nunit/nunit-console/issues/111) Provide better info when AppDomain won't unload
* [116](https://github.com/nunit/nunit-console/issues/116) NUnit 3.5.0 defaults to single agent process when using an nunit project file
* [191](https://github.com/nunit/nunit-console/issues/191) Exception encountered unloading AppDomain
* [228](https://github.com/nunit/nunit-console/issues/228) System.Reflection.TargetInvocationException with nunit3-console --debug on Mono
* [246](https://github.com/nunit/nunit-console/issues/246) No way to specify app.config with console runner
* [256](https://github.com/nunit/nunit-console/issues/256) Rewrite ConsoleRunnerTests.ThrowsNUnitEngineExceptionWhenTestResultsAreNotWriteable()
* [259](https://github.com/nunit/nunit-console/issues/259) NUnit3 agent hangs after encountering an "CannotUnloadAppDomainException"
* [262](https://github.com/nunit/nunit-console/issues/262) Transform file existence check should check current directory instead of WorkDirectory
* [267](https://github.com/nunit/nunit-console/issues/267) Fix possible NRE
* [273](https://github.com/nunit/nunit-console/issues/273) Insufficient error handling message in ProcessRunner -> RunTests method
* [275](https://github.com/nunit/nunit-console/issues/275) Integrate chocolatey packages with build script
* [284](https://github.com/nunit/nunit-console/issues/284) NUnit3: An exception occured in the driver while loading tests...   bei NUnit.Engine.Runners.ProcessRunner.RunTests(ITestEventListener listener, TestFilter filter)
* [285](https://github.com/nunit/nunit-console/issues/285) ColorConsoleWriter.WriteLabel causes NullReferenceException
* [289](https://github.com/nunit/nunit-console/issues/289) Warnings not displayed
* [298](https://github.com/nunit/nunit-console/issues/298) Invalid --framework option throws exception
* [300](https://github.com/nunit/nunit-console/issues/300) Agents do not respect the Console WORK parameter when writing log file
* [304](https://github.com/nunit/nunit-console/issues/304) Catch agent debugger launch exceptions, and improve agent crash handling
* [309](https://github.com/nunit/nunit-console/issues/309) No driver found if framework assembly reference has uppercase characters
* [314](https://github.com/nunit/nunit-console/issues/314) Update NUnit.Extension.VSProjectLoader to 3.7.0
* [318](https://github.com/nunit/nunit-console/issues/318) Update NUnit.Extension.TeamCityEventListener to 1.0.3
* [320](https://github.com/nunit/nunit-console/issues/320) Return error code -5 when AppDomain fails to unload
* [323](https://github.com/nunit/nunit-console/issues/323) Assertion should not be ordered in AgentDatabaseTests
* [343](https://github.com/nunit/nunit-console/issues/343) Superfluous unload error shown in console
* [349](https://github.com/nunit/nunit-console/issues/349) Get all TestEngine tests running under NUnitAdapter apart from those .
* [350](https://github.com/nunit/nunit-console/issues/350) Invalid assemblies no longer give an error message
* [355](https://github.com/nunit/nunit-console/issues/355) NuGet package links to outdated license

## NUnit Console 3.7 - July 13, 2017

### Engine

* Creates a .NET Standard version of the engine for use in the Visual Studio Adapter
* Fixes several issues that caused the runner to exit with a SocketException

### Issues Resolved

* [10](https://github.com/nunit/nunit-console/issues/10) Create a .NET Standard version of the Engine
* [11](https://github.com/nunit/nunit-console/issues/11) insufficient info on driver reflection exception
* [12](https://github.com/nunit/nunit-console/issues/12) Upgrade Cake build to latest version
* [24](https://github.com/nunit/nunit-console/issues/24) Update --labels switch with option to show real-time pass/fail results in console runner
* [31](https://github.com/nunit/nunit-console/issues/31) Nunit 3.4.1 NUnit.Engine.Runners
* [72](https://github.com/nunit/nunit-console/issues/72) TestContext.Progress.Write writes new line
* [82](https://github.com/nunit/nunit-console/issues/82) Remove unused repository paths from repositories.config
* [99](https://github.com/nunit/nunit-console/issues/99) Remove unused --verbose and --full command line options
* [126](https://github.com/nunit/nunit-console/issues/126) Resolve differences between NUnit Console and NUnitLite implementations of @filename
* [162](https://github.com/nunit/nunit-console/issues/162) Add namespace keyword to Test Selection Language
* [171](https://github.com/nunit/nunit-console/issues/171) Socket Exception when stopping Remote Agent
* [172](https://github.com/nunit/nunit-console/issues/172) Limit Language level to C#6
* [193](https://github.com/nunit/nunit-console/issues/193) Settings are stored with invariant culture but retrieved with CurrentCulture
* [194](https://github.com/nunit/nunit-console/issues/194) Better logging or error handling in SettingsStore.SaveSettings
* [196](https://github.com/nunit/nunit-console/issues/196) Allow comments in @FILE files
* [200](https://github.com/nunit/nunit-console/issues/200) Remove obsolete warnings from build script
* [206](https://github.com/nunit/nunit-console/issues/206) Remove reference to removed `noxml` option
* [207](https://github.com/nunit/nunit-console/issues/207)  Create Chocolatey package(s) for the console
* [208](https://github.com/nunit/nunit-console/issues/208) Explore flags test update
* [213](https://github.com/nunit/nunit-console/issues/213) Master build failing after merging .NET Standard Engine
* [216](https://github.com/nunit/nunit-console/issues/216) Compiling mock-assembly in Visual Studio 2017 fails
* [217](https://github.com/nunit/nunit-console/issues/217) NUnit .NET Standard NuGet package missing some values
* [219](https://github.com/nunit/nunit-console/issues/219) Runtime.Remoting.RemotingException in NUnit.Engine.Runners.ProcessRunner.Dispose
* [221](https://github.com/nunit/nunit-console/issues/221) Added missing nuget package info
* [222](https://github.com/nunit/nunit-console/issues/222) Improve missing agent error message
* [225](https://github.com/nunit/nunit-console/issues/225) SocketException thrown by nunit3-console.exe --explore option
* [248](https://github.com/nunit/nunit-console/issues/248) Agent TestEngine contains duplicate services
* [252](https://github.com/nunit/nunit-console/issues/252) Console crashes when specifying both format and transform for result
* [254](https://github.com/nunit/nunit-console/issues/254) Correct misprint ".con" -> ".com"

## NUnit Console 3.6.1 - March 6, 2017

### Engine

* This hotfix release addresses a race condition in the Engine that caused
   tests to intermittently fail.

### Issues Resolved

* [168](https://github.com/nunit/docs/issues/168) Intermittent errors while running tests after updating to 3.6

## NUnit Console 3.6 - January 14, 2017

### Console Runner

* Added command line option `--skipnontestassemblies` to skip assemblies that do
   not contain tests without raising an error and to skip assemblies that contain
   the NUnit.Framework.NonTestAssemblyAttribute.
* Messages from the new Multiple Assert blocks will be displayed individually
* Warnings from the new Warn.If, Warn.Unless and Assert.Warn are now displayed

### Engine

* NUnit agents now monitor the running engine process and will terminate themselves
   if the parent runner process is killed or dies

### Issues Resolved

* [16](https://github.com/nunit/nunit-console/issues/16) NUnit Engine Tests fail if not run from test directory
* [18](https://github.com/nunit/nunit-console/issues/18) Invalid file type is shown in XML as type="Assembly"
* [23](https://github.com/nunit/nunit-console/issues/23) In nunit3-console you cannot pass parameters containing ';' because they always get split
* [37](https://github.com/nunit/nunit-console/issues/37) NUnit 3 console should produce xml events for ITestEventListener which contain
      unique id in the scope of all test agents for NUnit 2 tests
* [58](https://github.com/nunit/nunit-console/issues/58) System.Configuration.ConfigurationErrorsException thrown in multiple domain mode.
* [62](https://github.com/nunit/nunit-console/issues/62) NUnit3 Fails on DLL with no Tests, Unlike NUnit2
* [100](https://github.com/nunit/nunit-console/issues/100) Class NUnit.Engine.Services.ResultWriters.Tests.SchemaValidator is never used
* [101](https://github.com/nunit/nunit-console/issues/101) Method NUnit.Options.OptionSet.Unprocessed always returns "false"
* [104](https://github.com/nunit/nunit-console/issues/104) Type of variable enumerated in 'foreach' is not guaranteed to be cast-able
* [110](https://github.com/nunit/nunit-console/issues/110) Writability check could give a friendlier message.
* [113](https://github.com/nunit/nunit-console/issues/113) Add task descriptions to Build.cake
* [127](https://github.com/nunit/nunit-console/issues/127) Modify console runner to display multiple assert information
* [128](https://github.com/nunit/nunit-console/issues/128) Terminate agent if main process has terminated
* [133](https://github.com/nunit/nunit-console/issues/133) NUnit downloadable packages zip file naming is confusing and non-intuitive
* [136](https://github.com/nunit/nunit-console/issues/136) Handle early termination of multiple assert block
* [138](https://github.com/nunit/nunit-console/issues/138) Report Warnings in console runner
* [145](https://github.com/nunit/nunit-console/issues/145) MasterTestRunner.RunAsync no longer provides start-run and test-run events
* [151](https://github.com/nunit/nunit-console/issues/151) Unexpected behavior from --framework flag
* [153](https://github.com/nunit/nunit-console/issues/153) Remove some settings used by the engine
* [156](https://github.com/nunit/nunit-console/issues/156) Use high-quality icon for nuspecs
* [157](https://github.com/nunit/nunit-console/issues/157) Fix Detection of invalid framework when --inprocess
* [159](https://github.com/nunit/nunit-console/issues/159) Update extension versions in the NuSpec Files

## Earlier Releases

* Release Notes for [NUnit 2.9.1 through 3.5](xref:pre35releasenotes).
* Release Notes for [NUnit 2.6 through 2.6.4](https://nunit.org/?p=releaseNotes&r=2.6.4)
* Release Notes for [NUnit 2.5 through 2.5.10](https://nunit.org/?p=releaseNotes&r=2.5.10)
* Release Notes for [NUnit 2.4 through 2.4.8](https://nunit.org/?p=releaseNotes&r=2.4.8)
* Release Notes for [NUnit 2.0 through 2.2.10](https://nunit.org/?p=releaseNotes&r=2.2.10)

---
uid: tipsandtricks
---

# Tips and Tricks

## NUnit 3

### VS Test .Runsettings configuration

Certain NUnit Test Adapter settings are configurable using a .runsettings file.
The following options are available:

|Key|Type|Options| Default|
|---|----|-------|--------------|
|[InternalTraceLevel](#internaltracelevel)| enum |  Off, Error, Warning, Info, Verbose,  Debug| Nothing => Off|
|[NumberOfTestWorkers](#numberoftestworkers)| int | nr of workers | -1|
|[ShadowCopyFiles](#shadowcopyfiles)| bool |True, False | False|
|[Verbosity](#verbosity)| int | -1, 0-5 . -1 means quiet mode | 0|
|[UseVsKeepEngineRunning](#usevskeepenginerunning)| bool | True, False| False|
|BasePath| string | path| ?|
|PrivateBinPath | string| directory1;directory2;etc |?|
|RandomSeed | int | seed integer| random|
|DefaultTimeout |int|timeout in mS, 0 means infinite|0|
|[DefaultTestNamePattern](#defaulttestnamepattern)|string|Pattern for display name|{m}{a}|
|[WorkDirectory](#workdirectory)|string|specify directory|Test assembly location|
|[TestOutputXml](#testoutputxml)|string|specify directory|Test Result Xml output folder|
|[DumpXmlTestDiscovery](#dumpxmltestdiscovery-and-dumpxmltestresults)|bool|Enable dumping of NUnit discovery response xml|false|
|[DumpXmlTestResults](#dumpxmltestdiscovery-and-dumpxmltestresults)|bool|Enable dumping of NUnit execution response xml|false|
|[PreFilter](#prefilter)|bool|Enable pre-filtering to increase performance for Visual Studio testing|false|
|[ShowInternalProperties](#showinternalproperties)| bool | Turn on showing internal NUnit properties in Test Explorer| false|
|[Where](#where)|string| NUnit Filter expression|
|[UseParentFQNForParametrizedTests](#useparentfqnforparametrizedtests)|bool|Enable parent as FQN for parametrized tests|false|
|[UseNUnitIdforTestCaseId](#usenunitidfortestcaseid) |bool|Uses NUnit test id as VSTest Testcase Id, instead of FullyQualifiedName|false|
|[ConsoleOut](#consoleout)|int|Sends standard console output to the output window|1|
|[UseTestNameInConsoleOutput](#usetestnameinconsoleoutput)|bool|Adds name of test as a prefix in the output window for console output|true|
|[StopOnError](#stoponerror)|bool|Stops on first error|false|
|[SkipNonTestAssemblies](#skipnontestassemblies)|bool|Adapter supports NonTestAssemblyAttribute|true|
|[MapWarningTo](#mapwarningto)|enum|Map Assert.Warn to either Passed, Failed or Skipped|Skipped|
|[DisplayName](#displayname)|enum|Set what a DisplayName is, options: Name, FullName or FullNameSep|Name|
|[FullnameSeparator](#fullnameseparator)|string|FullNameSep separator|':'|
|[DiscoveryMethod](#discoverymethod)|enum|How execution discovery is done, options are `Legacy` or `Current`|Current|
|[AssemblySelectLimit](#assemblyselectlimit)|int|Number of tests accepted before filters are turned off|2000|
|[NewOutputXmlFileForEachRun](#newoutputxmlfileforeachrun)|bool|Creates a new file for each test run|false|
|[IncludeStackTraceForSuites](#includestacktraceforsuites)|bool|Includes stack trace for failures in suites, like exceptions in OneTimeSetup|true|

### Visual Studio templates for runsettings

You can install [item templates for runsettings](https://marketplace.visualstudio.com/items?itemName=OsirisTerje.Runsettings-19151) in Visual Studio (applies to version 2017, 2019 and upwards) which includes the NUnit settings mentioned here.  Note that there are available separate installs for earlier Visual Studio versions, links to these can be found in the above.

### Example implementation

See <https://github.com/nunit/nunit3-vs-adapter/blob/8a9b8a38b7f808a4a78598542ddaf557950c6790/demo/demo.runsettings>

### NUnit .runsettings implementation

<https://github.com/nunit/nunit3-vs-adapter/blob/master/src/NUnitTestAdapter/AdapterSettings.cs#L143>

---

### Details

#### DefaultTestNamePattern

The default format used to provide test names, expressed as an NUnit [Template Based Test Name Pattern](xref:templatebasedtestnaming).

#### WorkDirectory

Our WorkDirectory is the place where output files are intended to be saved for the run, whether created by NUnit or by the user, who can access the work directory using TestContext. It's different from TestDirectory, which is the directory containing the test assembly. For a run with multiple assemblies, there could be multiple TestDirectories, but only one WorkDirectory.
User sets work directory to tell NUnit where to put stuff like the XML or any text output. User may also access it in the code and save other things there. Think of it as the directory for saving stuff.

#### TestOutputXml

If this is specified, the adapter will generate NUnit Test Result Xml data in the folder specified here.  If not specified, no such output will be generated.  
The folder can be

1) An absolute path
2) A relative path, which is then relative to either WorkDirectory, or if this is not specified, relative to the current directory, as defined by .net runtime.

(From version 3.12)

#### InternalTraceLevel

This setting is a diagnostic setting forwarded to NUnit, and not used by the adapter itself.  For further information see the [NUnit Tracelevel documentation](xref:internaltracespec)

#### NumberOfTestWorkers

This  setting is sent to NUnit to determine how  [parallelization](xref:parallelizableattribute) should be performed.  
Note in particular that NUnit can either run directly or for parallel runs use queue of threads.  Set to 0, it will run directly, set to 1 it will use a queue with a single thread.  

#### ShadowCopyFiles

This setting is sent to NUnit to enable/disable shadow-copying.

#### Verbosity

This controls the outputs from the adapter to the Visual Studio Output/Tests window.
A higher number includes the information from the lower numbers.
It has the following actual levels:

-1 : Quiet mode.  Only shows errors and warnings.  

0 : Default, normal information verbosity

1-3: Some more information from setting are output (in particular regarding parallelization)

4: Outputs the values from the  runsettings it has discovered.

5: Outputs all debug statements in the adapter

#### UseVsKeepEngineRunning

This setting is used by the adapter to signal to the VSTest.Execution engine to keep running after the tests have finished running.  This can speed up execution of subsequent test runs, as the execution engine already is loaded, but running the risks of either holding onto test assemblies and having some tests not properly cleaned out.   The settings is the same as using the Visual Studio  Test/Test Settings/Keep Test Execution Engine running.

#### DumpXmlTestDiscovery and DumpXmlTestResults

These settings are used to dump the output from NUnit, as it is received by the adapter, before any processing in the adapter is done, to disk.  It is part of the diagnostics tools for the adapter.
You can find the files under your current output folder, in a sub-folder named Dump.
(Note: This is not the same as the TestResults folder, this data is not test results, but diagnostics dumps)

#### PreFilter

A pre-filter will improve performance when testing a selection of tests from the Test Explorer.  It is default off, because there are issues in certain cases, see below. If you **don't** have any of the cases below, you can turn PreFilter on.

* Your code contains a SetupFixture [#649](https://github.com/nunit/nunit3-vs-adapter/issues/649)
* Your code uses a TestCaseSource and uses SetName to set the display name instead of SetArgDisplayNames [#650](https://github.com/nunit/nunit3-vs-adapter/issues/650)
* You are using a version of NUnit lower than 3.11  [#648](https://github.com/nunit/nunit3-vs-adapter/issues/648)

If you just need to add this, you can add a runsettings file (any filename, extension .runsettings) containing:

```xml
<RunSettings>
   <NUnit>
       <PreFilter>true</PreFilter>
   </NUnit>
</RunSettings>
```

(From version 3.15.1)

#### ShowInternalProperties

The [NUnit internal properties](https://github.com/nunit/nunit/blob/master/src/NUnitFramework/framework/Internal/PropertyNames.cs) have been "over-populating" in the Test Explorer.  These are default filtered out, although you may still see these when you have [Source Based Discovery (SBD)](https://docs.microsoft.com/en-us/visualstudio/test/test-explorer-faq?view=vs-2017) turned on (which is the default in VS).  Once you have run test execution, they will be gone. We expect this part of the issue (SBD) to be fixed in VS.  If you still want to see them, set this property to true.

#### Where

A NUnit Test Selection Language filter can be added to the runsettings file.  The details are described in **[this blog post](https://blog.prokrams.com/2019/12/16/nunit3-filter-dotnet/)**

Using the runsettings should be like:

```xml
<RunSettings>
    <NUnit>
        <Where>cat == SomeCategory or method == SomeMethodName or namespace == My.Name.Space or name == 'TestMethod(5)'</Where>
    </NUnit>
</RunSettings>
```

(From version 3.16.0)

#### UseParentFQNForParametrizedTests

Setting this may give more stable results when you have complex data driven/parametrized tests.  However, when this is set selecting a single test within such a group, means that **all** tests in that group is executed.

Note that this often has to be set together with [UseNUnitIdforTestCaseId](#usenunitidfortestcaseid)

(From version 3.16.1)

#### UseNUnitIdforTestCaseId

The default setting is false, causes the VSTest Testcase ID to be based on the NUnit fullname property, which is nearly equal to a FullyQualifiedName.  The fullname is also set into the Testcase FullyQualifiedName property.

By setting this property true, it shifts to using the NUnit id as the basis for the testcase id.  This may in certain cases give more stable results, and are more correct.  

However, it has been seen to also have adverse effects, so use with caution.

(From version 3.16.1)

#### ConsoleOut

When set to 1, default, will send Console standard output to the Visual Studio Output/Test window, and also with dotnet test, it will appear here. (Note: You have to use the '-v n' option)

Disable this by setting it to 0, which is also the default for version earlier than 3.17.0.

See [Issue 343](https://github.com/nunit/nunit3-vs-adapter/issues/343) for more information and discussion

(From version 3.17.0)

#### UseTestNameInConsoleOutput

When set to `true`, the default, the name of the test is added as a prefix in front of each console line output.  This only applies to the output in the output window.

(From version 4.0.0)

#### StopOnError

When enabled (set to true), the tests will stop after the first test failed.  Useful when working with a system with many tests running for a long time, where a few fails.  It can then speed up by stopping at the first one.

See [Issue 675](https://github.com/nunit/nunit3-vs-adapter/issues/675) for more information and discussion

(From version 3.17.0)

#### MapWarningTo

Assert Warnings will default map to `Skipped`, but you can set this to any other state, using MapWarningTo.  The options are:
`Passed`, `Failed` or `Skipped`.

(From version 3.17.0)

#### SkipNonTestAssemblies

If the attribute `NonTestAssembly` is added in an assembly, it will be skipped from further testing.  If [RTD](https://devblogs.microsoft.com/dotnet/real-time-test-discovery/) is enabled in Visual Studio, the tests will be displayed, but running will skip them.  
See explanation for the [NonTestAssembly Attribute](xref:nontestassembly), and [Issue explanation here](https://github.com/nunit/nunit3-vs-adapter/issues/758).

(From version 3.17.0)
(Default changed to true from 4.0.0)

#### DisplayName

The default for Test Explorer `DisplayName` is to use the Name of the test, which normally is the method name.  Using DisplayName you can change between `Name`, `FullName` or `FullNameSep`.  The last one will then use the FullNameSeparator,which defaults to '`:`'.
See [Issue 640](https://github.com/nunit/nunit3-vs-adapter/issues/640) for explanations of use and [sample code](https://github.com/nunit/nunit3-vs-adapter.issues/tree/master/Issue640) here.  

(From version 3.17.0)

#### FullNameSeparator

The separator character used when DisplayName is FullNameSep.  It is default '`:`', but can be changed to anything.

(From version 3.17.0)

#### DiscoveryMethod

The 4.0 version of the NUnit3TestAdapter has a rewritten discovery mechanism and also other redesigns/refactoring done.  This setting let you switch back to the old form of discovery, using the setting `Legacy`.  The default value is `Current`.  

The `Current` setting enables the Explicit feature back.  It also performs better (approx 30% faster for large test sets).  It might affect certain special cases, so therefore you can switch back.

(From version 4.0.0)

#### AssemblySelectLimit

If you run from the IDE (Visual Studio) the adapter will receive a list of tests to process.  This is heavy when the number of tests are large. If the number of tests exceeds this limit, the list will be skipped and all tests in the assembly will be run (except those tests that are Explicit or Ignored).  

This might have an adverse effect if you select a category and you have more than 2000 tests, the category setting will be ignored. In that case, just increase this limit to higher than your number of tests.

You might also receive a list from the command line, and in that case it will also be skipped the same way.  Here the category will be honored since the category filter will be converted to a NUnit filter.

(From version 4.0.0)

#### NewOutputXmlFileForEachRun

Default behavior is to produce one test output file which is being overwritten for each run  Setting this to `true`, the adapter produces a new test output file for each run, numbering them sequentially.  Default is `false`.

The background is the following scenario, as described by [netcorefactory](https://github.com/netcorefactory) in [Issue 800](https://github.com/nunit/nunit3-vs-adapter/issues/800):

"*Running test in azure devops one can choose to rerun failed ( flaky ) tests. Mostly when running (selenium) e2e tests this becomes important. The .xml results file is currently overwritten each retry run. Other test coverage tooling dependent on this file receives only latest run results.
Better to allow the possibility to deliver a results file per run.*"

(From version 4.0.0)

#### IncludeStackTraceForSuites

Exceptions outside test cases are reported with its stack trace included in the message.  One example here is exceptions in OneTimeSetUp and OneTimeTearDown. They belong to the outer suite, and their exceptions are reported as part of the message. This option includes the stack trace in that message.  If this becomes too much information, this option turns the stack trace reporting off.

(From version 4.0.0)

---

### Some further information on directories (From [comment on issue 575](https://github.com/nunit/nunit3-vs-adapter/issues/575#issuecomment-445786421) by [Charlie](https://github.com/CharliePoole) )

NUnit also supports TestContext.TestDirectory, which is the directory where the current test assembly is located. Note that if you have several test assemblies in different directories, the value will be different when each one of them accesses it. Note also that there is no way you can set the TestDirectory because it's always where the assembly is located.

The BasePath is a .NET thing. It's the base directory where assemblies are searched for. You can also have subdirectories listed in the PrivateBinPath. NUnit take scare of all this automatically now, so the old console options are no longer supported. For finding things you want to read at runtime, the TestDirectory and the BasePath will usually be the same thing.

### Registry Settings

> [!NOTE]
> As of the 3.0 final release, the registry settings are no longer recognized. Instead, use settings in the `.runsettings` file.

---

## NUnit 2.x

NUnit 2.X does not support runsettings.

### Registry Settings

Certain settings in the registry affect how the adapter runs. All these settings are added by using RegEdit under the key **HKCU\Software\nunit.org\VSAdapter**.

#### ShadowCopy

By default NUnit no longer uses shadowcopy. If this causes an issue for you shadowcopy can be enabled by setting the DWORD value UseShadowCopy to 1.
  
#### KeepEngineRunning

By default the NUnit adapter will "Kill" the Visual Studio Test Execution engine after each run. Visual Studio 2013 and later has a new setting under its top menu, **Test | Test Settings | Keep Test Execution Engine Running**. The adapter normally ignores this setting.

In some cases it can be useful to have the engine running, e.g. during debugging of the adapter itself. You can then set the adapter to follow the VS setting by setting the DWORD value UseVsKeepEngineRunning to 1.

#### Verbosity

Normally the adapter reports exceptions using a short format, consisting of the message only. You can change it to report a verbose format that includes the stack trace, by setting a the DWORD value Verbosity to 1.

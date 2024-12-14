---
uid: frameworkreleasenotes
---
<!-- markdownlint-disable-file MD013 -->
<!-- markdownlint-disable-file MD033 -->

# Framework Release

## NUnit 4.3.0 -  Dec 15. 2024

This release includes a series of enhancements and bug fixes. Notably, some of the bug fixes address issues related to a lack of type safety in NUnit. See issues [4877](https://github.com/nunit/nunit/issues/4877),
[4876](https://github.com/nunit/nunit/issues/4876), [4875](https://github.com/nunit/nunit/issues/4875), [4874](https://github.com/nunit/nunit/issues/4874) and [150](https://github.com/nunit/nunit/issues/150).  

Be aware that this might cause compile errors in cases where the code was previously ignored. These errors can be safely resolved by removing the affected code..

There are 29 issues fixed in this release.

### Enhancements

* [4890](https://github.com/nunit/nunit/issues/4890) Add .net 8 as a target framework in the package. Thanks to NUnit Team member [Manfred Brands](https://github.com/manfred-brands) for [PR 4884](https://github.com/nunit/nunit/pull/4884)
* [4886](https://github.com/nunit/nunit/issues/4886) Optimize ToArray()[0] with First() in TestAssert class in TestAssert.cs. Thanks to [Saurav-shres](https://github.com/Saurav-shres) for [PR 4888](https://github.com/nunit/nunit/pull/4888)
* [4862](https://github.com/nunit/nunit/issues/4862) PropertiesComparer 32 Property Limit Error Message. Thanks to [Cincidial](https://github.com/Cincidial) for [PR 4870](https://github.com/nunit/nunit/pull/4870)
* [4861](https://github.com/nunit/nunit/issues/4861) Always repeat Test x times. Thanks to [Christoph](https://github.com/cfuerbachersparks) for [PR 4864](https://github.com/nunit/nunit/pull/4864)
* [4852](https://github.com/nunit/nunit/issues/4852) Expand the usability of `Contains.Key(...).WithValue(...)`. Thanks to [Michael Render](https://github.com/RenderMichael) for [PR 4854](https://github.com/nunit/nunit/pull/4854)
* [4846](https://github.com/nunit/nunit/issues/4846) Add NET9 target for the framework tests. Thanks to [Leon Lux](https://github.com/Lachstec) for [PR 4851](https://github.com/nunit/nunit/pull/4851)
* [4839](https://github.com/nunit/nunit/issues/4839) Allow to use collection expressions with collection constraints. Thanks to [Oleksandr Liakhevych](https://github.com/Dreamescaper) for [PR 4840](https://github.com/nunit/nunit/pull/4840)
* [4832](https://github.com/nunit/nunit/issues/4832) Setting thread names to make debugging easier. Thanks to NUnit Team member [Terje Sandstrom](https://github.com/OsirisTerje) for [PR 4835](https://github.com/nunit/nunit/pull/4835)
* [4811](https://github.com/nunit/nunit/issues/4811) Assert.ThatAsync does not support polling. Thanks to [Oleksandr Liakhevych](https://github.com/Dreamescaper) for [PR 4813](https://github.com/nunit/nunit/pull/4813)
* [4771](https://github.com/nunit/nunit/issues/4771) Support tuples in inline data. Thanks to [MaxKot](https://github.com/MaxKot) for [PR 4772](https://github.com/nunit/nunit/pull/4772)
* [2492](https://github.com/nunit/nunit/issues/2492) EqualConstraint.Using(StringComparer.*) causes overload ambiguity error. Thanks to NUnit Team member [Manfred Brands](https://github.com/manfred-brands) for [PR 4882](https://github.com/nunit/nunit/pull/4882)

### Bug fixes

* [4887](https://github.com/nunit/nunit/issues/4887) FileLoadException for NUnit 4.2.2 when upgrade the System.Buffers to 4.6.0. Thanks to NUnit Team member [Terje Sandstrom](https://github.com/OsirisTerje) for [PR 4891](https://github.com/nunit/nunit/pull/4891)
* [4877](https://github.com/nunit/nunit/issues/4877) Fix EqualTo modifiers for DateTime. Thanks to NUnit Team member [Manfred Brands](https://github.com/manfred-brands) for [PR 4882](https://github.com/nunit/nunit/pull/4882)
* [4876](https://github.com/nunit/nunit/issues/4876) Equal.Within Fails With Negative Tolerance. Thanks to [Raffael Botschen](https://github.com/RaffaelCH) for [PR 4881](https://github.com/nunit/nunit/pull/4881)
* [4875](https://github.com/nunit/nunit/issues/4875) String constraints should not allow using Within. Thanks to NUnit Team member [Manfred Brands](https://github.com/manfred-brands) for [PR 4882](https://github.com/nunit/nunit/pull/4882)
* [4874](https://github.com/nunit/nunit/issues/4874) IgnoreCase, Seconds and Minutes can be used on numerical constraints. Thanks to NUnit Team member [Manfred Brands](https://github.com/manfred-brands) for [PR 4882](https://github.com/nunit/nunit/pull/4882)
* [4868](https://github.com/nunit/nunit/issues/4868) TestCase- and TestCaseSourceAttribute cannot handle generic test methods where method parameter is Nullable&lt;T&gt;. Thanks to NUnit Team member [Manfred Brands](https://github.com/manfred-brands) for [PR 4872](https://github.com/nunit/nunit/pull/4872)
* [4836](https://github.com/nunit/nunit/issues/4836) PropertiesComparer doesn't work well with records. Thanks to [Oleksandr Liakhevych](https://github.com/Dreamescaper) for [PR 4837](https://github.com/nunit/nunit/pull/4837)
* [4807](https://github.com/nunit/nunit/issues/4807) Is.EqualTo with empty ValueTuple throws System.NotSupportedException "Specified Tolerance not supported for instances of type 'System.ValueTuple' and 'System.ValueTuple'" after updating to NUnit 4.2.2. Thanks to NUnit Team member [Manfred Brands](https://github.com/manfred-brands) for [PR 4809](https://github.com/nunit/nunit/pull/4809)
* [4281](https://github.com/nunit/nunit/issues/4281) Throws and Delayed (.After) Constraints do not cooperate, resulting in incorrectly failing test. Thanks to [Oleksandr Liakhevych](https://github.com/Dreamescaper) for [PR 4815](https://github.com/nunit/nunit/pull/4815)
* [4110](https://github.com/nunit/nunit/issues/4110) Support running single-threaded async tests on Linux. Thanks to NUnit Team member [Manfred Brands](https://github.com/manfred-brands) for [PR 4883](https://github.com/nunit/nunit/pull/4883)
* [3772](https://github.com/nunit/nunit/issues/3772) IsEquivalent on default ImmutableArray throws exception. Thanks to [Sergio L.](https://github.com/mr-sergito) for [PR 4850](https://github.com/nunit/nunit/pull/4850)
* [3713](https://github.com/nunit/nunit/issues/3713) Description of --where=EXPRESSION missing from Notes section. Thanks to [rsjackson3](https://github.com/rsjackson3) for [PR 4817](https://github.com/nunit/nunit/pull/4817)
* [150](https://github.com/nunit/nunit/issues/150) Improve inference of type arguments in generic test methods. Thanks to NUnit Team member [Steven Weerdenburg](https://github.com/stevenaw) for [PR 4873](https://github.com/nunit/nunit/pull/4873)

### Refactorings

None

### Internal fixes

* [4865](https://github.com/nunit/nunit/issues/4865) Increase Legacy NUnit so at least all methods are covered. Thanks to NUnit Team member [Manfred Brands](https://github.com/manfred-brands) for [PR 4871](https://github.com/nunit/nunit/pull/4871)
* [4841](https://github.com/nunit/nunit/issues/4841) MacOS test failure. Thanks to NUnit Team member [Manfred Brands](https://github.com/manfred-brands) for [PR 4842](https://github.com/nunit/nunit/pull/4842)
* [4819](https://github.com/nunit/nunit/issues/4819) Remove `StringUtil.Compare()` and update references in the tests. Thanks to [Sergio L.](https://github.com/mr-sergito) for [PR 4827](https://github.com/nunit/nunit/pull/4827)
* [4798](https://github.com/nunit/nunit/issues/4798) Add a test to ensure direct framework dependencies in csproj are reflected in nuspec. Thanks to NUnit Team member [Terje Sandstrom](https://github.com/OsirisTerje) for [PR 4799](https://github.com/nunit/nunit/pull/4799)

### Deprecated features

None

### Others


### The following issues are marked as breaking changes

None


### Acknowledgements

First and foremost, we want to recognize the exceptional contributions of team members [Manfred Brands](https://github.com/manfred-brands) and [Steven Weerdenburg](https://github.com/stevenaw) for their dedicated efforts on this release, particularly their work on improving type safety.

We also express our heartfelt gratitude to everyone who has contributed to this release
by reporting bugs, suggesting enhancements, and providing valuable feedback.
Your efforts help make NUnit better for the entire community.

A special thank you to the following reporters for identifying issues:

<table>
<tr>
<td><a href="https://github.com/cfuerbachersparks">Christoph</a></td>
<td><a href="https://github.com/KrzysFR">Christophe Chevalier</a></td>
<td><a href="https://github.com/Cincidial">Cincidial</a></td>
<td><a href="https://github.com/jnm2">Joseph Musser</a></td>
</tr>
<tr>
<td><a href="https://github.com/Lachstec">Leon Lux</a></td>
<td><a href="https://github.com/manfred-brands">Manfred Brands</a></td>
<td><a href="https://github.com/MaxKot">MaxKot</a></td>
<td><a href="https://github.com/MCMrARM">MCMrARM</a></td>
</tr>
<tr>
<td><a href="https://github.com/RenderMichael">Michael Render</a></td>
<td><a href="https://github.com/michaelamaura">Michaela Maura Elschner</a></td>
<td><a href="https://github.com/mzh3511">mzh3511</a></td>
<td><a href="https://github.com/Dreamescaper">Oleksandr Liakhevych</a></td>
</tr>
<tr>
<td><a href="https://github.com/RaffaelCH">Raffael Botschen</a></td>
<td><a href="https://github.com/biocoder-frodo">Sander</a></td>
<td><a href="https://github.com/Saurav-shres">Saurav-shres</a></td>
<td><a href="https://github.com/seesharks">seesharks</a></td>
</tr>
<tr>
<td><a href="https://github.com/stevenaw">Steven Weerdenburg</a></td>
<td><a href="https://github.com/OsirisTerje">Terje Sandstrom</a></td>
<td><a href="https://github.com/wimvangool">Wim van Gool</a></td>
</tr>
</table>


and to the commenters who engaged in discussions and offered further insights:

<table>
<tr>
<td><a href="https://github.com/CharliePoole">CharliePoole</a></td>
<td><a href="https://github.com/ChrisMaddock">Chris Maddock</a></td>
<td><a href="https://github.com/cfuerbachersparks">Christoph</a></td>
<td><a href="https://github.com/KrzysFR">Christophe Chevalier</a></td>
</tr>
<tr>
<td><a href="https://github.com/Cincidial">Cincidial</a></td>
<td><a href="https://github.com/Kooddammn">Harsh Jain</a></td>
<td><a href="https://github.com/jnm2">Joseph Musser</a></td>
<td><a href="https://github.com/Lachstec">Leon Lux</a></td>
</tr>
<tr>
<td><a href="https://github.com/manfred-brands">Manfred Brands</a></td>
<td><a href="https://github.com/MaxKot">MaxKot</a></td>
<td><a href="https://github.com/RenderMichael">Michael Render</a></td>
<td><a href="https://github.com/michaelamaura">Michaela Maura Elschner</a></td>
</tr>
<tr>
<td><a href="https://github.com/mikkelbu">Mikkel Nylander Bundgaard</a></td>
<td><a href="https://github.com/Dreamescaper">Oleksandr Liakhevych</a></td>
<td><a href="https://github.com/PicNet">PicNet</a></td>
<td><a href="https://github.com/RaffaelCH">Raffael Botschen</a></td>
</tr>
<tr>
<td><a href="https://github.com/rprouse">Rob Prouse</a></td>
<td><a href="https://github.com/rsjackson3">rsjackson3</a></td>
<td><a href="https://github.com/sba-schleupen">Sascha Bartl</a></td>
<td><a href="https://github.com/Saurav-shres">Saurav-shres</a></td>
</tr>
<tr>
<td><a href="https://github.com/mr-sergito">Sergio L.</a></td>
<td><a href="https://github.com/stevenaw">Steven Weerdenburg</a></td>
<td><a href="https://github.com/OsirisTerje">Terje Sandstrom</a></td>
<td><a href="https://github.com/wimvangool">Wim van Gool</a></td>
</tr>
</table>


## NUnit 4.2.2 - August 31. 2024

This hotfix addresses an issue with asynchronous behavior introduced in version 4.2.0. It resolves a regression bug that affected the release.

* [4802](https://github.com/nunit/nunit/issues/4802) System.NotSupportedException when using AsyncEnumerable test cases for `TestCaseSourceAttribute`. Fixed by [PR 4804](https://github.com/nunit/nunit/pull/4804.)

## NUnit 4.2.1 - August 23. 2024

This is a hotfix release for 4.2.0, fixing issues related to .NET Framework.

### Bug fixes

* [4795](https://github.com/nunit/nunit/issues/4795) NUnit 4.2.0 is missing System.Buffers on .NET Framework.
* [4794](https://github.com/nunit/nunit/issues/4794) `EqualConstraint` fails with missing assembly references on .NET Framework since NUnit 4.2.

## NUnit 4.2 - August 22. 2024

There are 37 issues fixed in this release.

### Enhancements

* [4777](https://github.com/nunit/nunit/issues/4777) Publicly expose `IgnoreAttribute.Reason`. Thanks to [Michael Render](https://github.com/RenderMichael) for [PR 4781](https://github.com/nunit/nunit/pull/4781)
* [4738](https://github.com/nunit/nunit/issues/4738) QoL suggestion: fail fast in Assert.Multiple under debugger. Thanks to [MaceWindu](https://github.com/MaceWindu) for [PR 4749](https://github.com/nunit/nunit/pull/4749)
* [4710](https://github.com/nunit/nunit/issues/4710) Improve PropertiesComparer diagnostics. Fixed by team [PR 4712](https://github.com/nunit/nunit/pull/4712)
* [4686](https://github.com/nunit/nunit/issues/4686) Provide a ProgressTraceListener to redirect Trace output to the NUnit Progress output. Thanks to [maettu-this](https://github.com/maettu-this) for [PR 4709](https://github.com/nunit/nunit/pull/4709)
* [4632](https://github.com/nunit/nunit/issues/4632) Generic TestCase and TestCaseParameter support. Fixed by team [PR 4755](https://github.com/nunit/nunit/pull/4755)
* [4353](https://github.com/nunit/nunit/issues/4353) TestContext.AddTestAttachment with long file paths. Thanks to [Rohit Aggarwal](https://github.com/Meet2rohit99) for [PR 4665](https://github.com/nunit/nunit/pull/4665)
* [4134](https://github.com/nunit/nunit/issues/4134) NUnit 3 console does not display logs from background thread from a library. Thanks to [maettu-this](https://github.com/maettu-this) for [PR 4709](https://github.com/nunit/nunit/pull/4709)
* [3918](https://github.com/nunit/nunit/issues/3918) String comparison without whitespace. Fixed by team [PR 4664](https://github.com/nunit/nunit/pull/4664)
* [3829](https://github.com/nunit/nunit/issues/3829) Consider optimizing `StreamsComparer` for happy path. Thanks to [Mithilesh Zavar](https://github.com/mithileshz) for [PR 4668](https://github.com/nunit/nunit/pull/4668)
* [3767](https://github.com/nunit/nunit/issues/3767) Incorrect number of items listed in failure message. Thanks to [Dmitrij](https://github.com/iamdmitrij) for [PR 4702](https://github.com/nunit/nunit/pull/4702)
* [1396](https://github.com/nunit/nunit/issues/1396) Class Level Category Missing from TestContext. Fixed by team [PR 4757](https://github.com/nunit/nunit/pull/4757)
* [796](https://github.com/nunit/nunit/issues/796) `TestContext.CurrentContext.Test.Properties` from TestFixture should be available from `TestContext` for Test. Fixed by team [PR 4757](https://github.com/nunit/nunit/pull/4757)
* [548](https://github.com/nunit/nunit/issues/548) Properties set on a parameterized method are not accessible to TestContext. Fixed by team [PR 4757](https://github.com/nunit/nunit/pull/4757)
* [4587](https://github.com/nunit/nunit/issues/4587) Feature request: Assert.Multiple() could return an IDisposable, avoiding passing an Action around.. Fixed by team [PR 4758](https://github.com/nunit/nunit/pull/4758)

### Bug fixes

* [4782](https://github.com/nunit/nunit/issues/4782) Bug report: [ValueSource] doesn't play nice with [CancelAfter]. Fixed by team [PR 4783](https://github.com/nunit/nunit/pull/4783)
* [4770](https://github.com/nunit/nunit/issues/4770) Bug report: [Values] doesn't play nice with [CancelAfter]. Fixed by team [PR 4774](https://github.com/nunit/nunit/pull/4774)
* [4750](https://github.com/nunit/nunit/issues/4750) `DefaultFloatingPointTolerance` ignored for `TestCaseData`. Fixed by team [PR 4754](https://github.com/nunit/nunit/pull/4754)
* [4723](https://github.com/nunit/nunit/issues/4723) CurrentContext.Result.Outcome.Status is inconclusive in TearDown if Timeout attribute is used in 4.x. Fixed by team [PR 4727](https://github.com/nunit/nunit/pull/4727)
* [4705](https://github.com/nunit/nunit/issues/4705) The dll's in the release 4.1 has version 4.0.1. Fixed by team [PR 4706](https://github.com/nunit/nunit/pull/4706)
* [4670](https://github.com/nunit/nunit/issues/4670) `.ContainKey().WithValue()` and `.Or`/`.And` interact incorrectly. Fixed by team [PR 4672](https://github.com/nunit/nunit/pull/4672)
* [4659](https://github.com/nunit/nunit/issues/4659) TestCaseSource that contains Exception with InnerException - not running tests. Fixed by team [PR 4663](https://github.com/nunit/nunit/pull/4663)
* [4651](https://github.com/nunit/nunit/issues/4651) After upgrade from version 3.14.0 to 4.* running multiple test categories in parentheses separated with 'OR' stopped working. Fixed by team [PR 4760](https://github.com/nunit/nunit/pull/4760)
* [4639](https://github.com/nunit/nunit/issues/4639) `ValueTask` is not being properly consumed by the `AwaitAdapter`. Fixed by team [PR 4640](https://github.com/nunit/nunit/pull/4640)
* [4598](https://github.com/nunit/nunit/issues/4598) DefaultTimeout in .runsettings + TearDown method seems to break test output. Fixed by team [PR 4692](https://github.com/nunit/nunit/pull/4692)
* [4589](https://github.com/nunit/nunit/issues/4589) Exception when using test filters from .runsettings or --filter argument from dotnet test. Fixed by team [PR 4760](https://github.com/nunit/nunit/pull/4760)
* [4584](https://github.com/nunit/nunit/issues/4584) Nunit 4.0.x Test case selection is incorrect with certain test data. Fixed by team [PR 4773](https://github.com/nunit/nunit/pull/4773)
* [1358](https://github.com/nunit/nunit/issues/1358) TestContext.CurrentContext.Test.Properties does not contain value(s) from PropertyAttribute when using TestCaseAttribute. Fixed by team [PR 4757](https://github.com/nunit/nunit/pull/4757)

### Refactorings

* [4577](https://github.com/nunit/nunit/issues/4577) Remove some version hard-coding in the OSPlatformTranslator. Fixed by team [PR 4756](https://github.com/nunit/nunit/pull/4756)

### Internal fixes

* [4735](https://github.com/nunit/nunit/issues/4735) StreamComparer - Pool allocating the byte array reduces memory allocation by 96%. Thanks to [Mithilesh Zavar](https://github.com/mithileshz) for [PR 4737](https://github.com/nunit/nunit/pull/4737)
* [4733](https://github.com/nunit/nunit/issues/4733) Improve speed of Randomizer.GetString. Fixed by team [PR 4512](https://github.com/nunit/nunit/pull/4512)
* [3981](https://github.com/nunit/nunit/issues/3981) Switch default branch to main. Fixed by team [PR 4753](https://github.com/nunit/nunit/pull/4753)
* [4649](https://github.com/nunit/nunit/issues/4649) Switch to using MacOS 14 in GitHub Actions. Fixed by team [PR 4648](https://github.com/nunit/nunit/pull/4648)
* [3757](https://github.com/nunit/nunit/issues/3757) Re-Add WinForms and WPF based tests. Fixed by team [PR 4776](https://github.com/nunit/nunit/pull/4776)

### Deprecated features

None

### Others

* [4765](https://github.com/nunit/nunit/issues/4765) Document ThrowOnEachFailurUnderDebugger.
* [4730](https://github.com/nunit/nunit/issues/4730) Remove reference to the mailing list from CONTRIBUTING.md. Fixed by team [PR 4752](https://github.com/nunit/nunit/pull/4752)
* [4726](https://github.com/nunit/nunit/issues/4726) `Using&lt;TCollectionType, TMemberType&gt;` is unclear. Thanks to [Michael Render](https://github.com/RenderMichael) for [PR 4729](https://github.com/nunit/nunit/pull/4729)
* [4684](https://github.com/nunit/nunit/issues/4684) Increment StreamsComparer by 'Actual bytes read' rather than the buffer size. Fixed by team [PR 4671](https://github.com/nunit/nunit/pull/4671)

### The following issues are marked as breaking changes

None

## NUnit 4.1 - February 23. 2024

This release is a bugfix and smaller enhancement release.

There are 8 issues fixed in this release.

### Enhancements

* [4600](https://github.com/nunit/nunit/issues/4600) Add `DateTime`/`TimeSpan` support for inequality tolerance. Thanks to [Michael Render](https://github.com/RenderMichael) for [PR 4618](https://github.com/nunit/nunit/pull/4618)
* [4572](https://github.com/nunit/nunit/issues/4572) Make new PropertiesComparer optional. Fixed by team [PR 4608](https://github.com/nunit/nunit/pull/4608)  Adding modifier UsingPropertiesComparer() to AnyOf-, Equal-, SomeItems-, CollectionEquivalent-, CollectionSubset-, CollectionSuperSet-, DictionaryContainsKey-, DictionaryContainsKeyValuePair-, DictionaryContainsValue- and UniqueItemsConstraint.
* [1215](https://github.com/nunit/nunit/issues/1215) Explicit specification of generic method types on TestCase and TestCaseSource. Fixed by team [PR 4620](https://github.com/nunit/nunit/pull/4620)  See [TestCase](https://docs.nunit.org/articles/nunit/writing-tests/attributes/testcase.html) and [TestCaseSource](https://docs.nunit.org/articles/nunit/writing-tests/attributes/testcasesource.html) documentation.

### Bug fixes

* [4602](https://github.com/nunit/nunit/issues/4602) WpfMessagePumpStrategy - change from Dispatcher.Run to Dispatcher.PushFrame . Thanks to [soerendd](https://github.com/soerendd) for [PR 4603](https://github.com/nunit/nunit/pull/4603)
* [4591](https://github.com/nunit/nunit/issues/4591) Parameter count mismatch with indexer. Fixed by team [PR 4608](https://github.com/nunit/nunit/pull/4608)
* [4581](https://github.com/nunit/nunit/issues/4581) NUnit 4 needs System.Threading.Tasks.Extensions for net472 tests. Fixed by team [PR 4582](https://github.com/nunit/nunit/pull/4582)

### Refactorings

* [4626](https://github.com/nunit/nunit/issues/4626) Remove link in readme to the google discuss group, it's spammed.. Fixed by team [PR 4627](https://github.com/nunit/nunit/pull/4627)

### Internal fixes

* [4606](https://github.com/nunit/nunit/issues/4606) GitHub Actions fail on `master` for Windows and Linux builds. Fixed by team [PR 4607](https://github.com/nunit/nunit/pull/4607)

### Deprecated features

None

### The following issues are marked as breaking changes

None.

Be aware that in version 4.0 the different equality constraints included checking properties of objects.
That was a breaking change from earlier versions, and has now been replaced with an UsingPropertiesComparer()
 modifier, making this optional.

## NUnit 4.0.1 - December 2. 2023

This is a hotfix release for three issues related to targeting windows targets, like `net6.0-windows`.  If you don't use these targets, you can safely ignore this release.

For more details, see the information in the issues below:

### Bug fixes

* [4571](https://github.com/nunit/nunit/issues/4571) NUnit 4: dotnet test behaving differently locally vs on GH Actions (failing). Fixed by team [PR 4574](https://github.com/nunit/nunit/pull/4574)
* [4565](https://github.com/nunit/nunit/issues/4565) Unable to test project targeting net8.0-windows and win-x64 . Fixed by team [PR 4569](https://github.com/nunit/nunit/pull/4569)
* [4564](https://github.com/nunit/nunit/issues/4564) Tests not discovered for .NET Windows-specific TFM without Windows build number. Fixed by team [PR 4569](https://github.com/nunit/nunit/pull/4569)

## NUnit 4.0.0 - November 26. 2023

This release is an incremental improvement of version 3, and can be used
with the same runners as before, although a minor upgrade might be needed for some.

For the `NUnit3TestAdapter`, you
will need version `4.5` to run tests with NUnit 4.

If you use the `NUnit Console`, you will need version `3.15.3` or later (but not any 3.16.X versions)).

The minimum target framework supported is now dotnet framework `4.6.2`, and .net `6.0`.

See the [planning notes](../Towards-NUnit4.md) for more information about the changes.

See the [migration guide](https://docs.nunit.org/articles/nunit/release-notes/Nunit4.0-MigrationGuide.html) for how to move your projects from NUnit 3 to NUnit 4.

### Credits

All issues marked "Fixed by team" has been done by [the members of the framework team][TeamLink].

Issues marked "Thanks to" has been done by external contributors. We appreciate all the work all these people have been
doing!

There are 112 issues fixed in this release.  

### Enhancements

* [4551](https://github.com/nunit/nunit/issues/4551) Make ConstraintExpression.AnyOf() accept IEnumerable. Thanks to [Ivan Gurin](https://github.com/ivan-gurin) for [PR 4552](https://github.com/nunit/nunit/pull/4552)
* [4521](https://github.com/nunit/nunit/issues/4521) Proposal: Async test case sources . Fixed by team [PR 4389](https://github.com/nunit/nunit/pull/4389)
* [4489](https://github.com/nunit/nunit/issues/4489) Use buffer pooling when calculating partition filters. Fixed by team [PR 4500](https://github.com/nunit/nunit/pull/4500)
* [4476](https://github.com/nunit/nunit/issues/4476) Add support to `StreamsComparer` for non-seek able streams. Thanks to [Michael Render](https://github.com/RenderMichael) for [PR 4483](https://github.com/nunit/nunit/pull/4483)
* [4433](https://github.com/nunit/nunit/issues/4433) Add string syntax attributes (.NET 7+). Thanks to [Michael Render](https://github.com/RenderMichael) for [PR 4425](https://github.com/nunit/nunit/pull/4425)
* [4431](https://github.com/nunit/nunit/issues/4431) Improving error message handling and performing assert consolidation. Fixed by team [PR 4430](https://github.com/nunit/nunit/pull/4430)
* [4421](https://github.com/nunit/nunit/issues/4421) Add support for native .NET-6.0 target . Fixed by team [PR 4431](https://github.com/nunit/nunit/pull/4431)
* [4413](https://github.com/nunit/nunit/issues/4413) Assert.That methods should autogenerate message, if null. Fixed by team [PR 4419](https://github.com/nunit/nunit/pull/4419)
* [4394](https://github.com/nunit/nunit/issues/4394) Expand NUnitEquality to use Equality of all Properties. Fixed by team [PR 4436](https://github.com/nunit/nunit/pull/4436)
* [4391](https://github.com/nunit/nunit/issues/4391) Hash/Partition based Test Filter. Thanks to [Andrew Armstrong](https://github.com/Plasma) for [PR 4392](https://github.com/nunit/nunit/pull/4392)
* [4385](https://github.com/nunit/nunit/issues/4385) Add support for Test Cancellation. Fixed by team [PR 4386](https://github.com/nunit/nunit/pull/4386)
* [4355](https://github.com/nunit/nunit/issues/4355) Allow Is.AnyOf to be called with arrays or other collections. Fixed by team [PR 4356](https://github.com/nunit/nunit/pull/4356)
* [4149](https://github.com/nunit/nunit/issues/4149) Distribute optimized framework builds with easy debugging. Thanks to [Marko Lahma](https://github.com/lahma) for [PR 4350](https://github.com/nunit/nunit/pull/4350)
* [4144](https://github.com/nunit/nunit/issues/4144) Stderr/Console.Error will hold back Unicode escaped log messages. Thanks to [Max Schmitt](https://github.com/mxschmitt) for [PR 4145](https://github.com/nunit/nunit/pull/4145)
* [4101](https://github.com/nunit/nunit/issues/4101) Expose ExpectedResult to the TestContext. Fixed by team [PR 4239](https://github.com/nunit/nunit/pull/4239)
* [4086](https://github.com/nunit/nunit/issues/4086) Perform case-insensitive string comparisons in-place. Fixed by team [PR 4088](https://github.com/nunit/nunit/pull/4088)
* [4053](https://github.com/nunit/nunit/issues/4053) Cache method discovery by migrating PR 4034 to main. Fixed by team [PR 4208](https://github.com/nunit/nunit/pull/4208)
* [3984](https://github.com/nunit/nunit/issues/3984) Add net6.0 targets. Fixed by team [PR 3988](https://github.com/nunit/nunit/pull/3988)
* [3941](https://github.com/nunit/nunit/issues/3941) PlatformAttribute has AllowMultiple = true, but that doesn't work. Fixed by team [PR 3926](https://github.com/nunit/nunit/pull/3926)
* [3936](https://github.com/nunit/nunit/issues/3936) Is there any way we could make use of CallerArgumentExpressionAttribute?. Fixed by team [PR 4419](https://github.com/nunit/nunit/pull/4419)
* [3899](https://github.com/nunit/nunit/issues/3899) Allow randomizing 'Guid' test arguments with [Random]. Thanks to [Arnaud TAMAILLON](https://github.com/Greybird) for [PR 3951](https://github.com/nunit/nunit/pull/3951)
* [3866](https://github.com/nunit/nunit/issues/3866) SupportedOSPlatform. Fixed by team [PR 3926](https://github.com/nunit/nunit/pull/3926)
* [3856](https://github.com/nunit/nunit/issues/3856) Theories in nested Testfixtures. Thanks to [Felix Kr”ner](https://github.com/Crown0815) for [PR 3857](https://github.com/nunit/nunit/pull/3857)
* [3718](https://github.com/nunit/nunit/issues/3718) Improve readability of "assert failed" message for DictionaryContainsKeyValuePairConstraint WithValue(). Fixed by team [PR 3778](https://github.com/nunit/nunit/pull/3778)
* [3457](https://github.com/nunit/nunit/issues/3457) Add DefaultConstraint. Thanks to [Oleksandr Liakhevych](https://github.com/Dreamescaper) for [PR 3781](https://github.com/nunit/nunit/pull/3781)
* [3432](https://github.com/nunit/nunit/issues/3432) Assert.That is blocking and might lead to deadlock when used with WCF.. Thanks to [Gavin Lambert](https://github.com/uecasm) for [PR 4322](https://github.com/nunit/nunit/pull/4322)
* [3391](https://github.com/nunit/nunit/issues/3391) TestCaseSource to recognize new async streams. Fixed by team [PR 4538](https://github.com/nunit/nunit/pull/4538)
* [3376](https://github.com/nunit/nunit/issues/3376) Nullable Reference Types annotations. Fixed by team through multiple PRs. . Fixed by team [PR 3488](https://github.com/nunit/nunit/pull/3488)
* [3043](https://github.com/nunit/nunit/issues/3043) Add AsyncEnumerable support for TestCaseSource, ValueSource, and TestFixtureSource. Fixed by team [PR 4538](https://github.com/nunit/nunit/pull/4538)
* [2843](https://github.com/nunit/nunit/issues/2843) Replacing ThrowsAsync with a composable async alternative. Thanks to [Gavin Lambert](https://github.com/uecasm) for [PR 4322](https://github.com/nunit/nunit/pull/4322)
* [1459](https://github.com/nunit/nunit/issues/1459) Support for params keyword in parameterized test fixtures. Thanks to [Leo Shine](https://github.com/Shiney) for [PR 4478](https://github.com/nunit/nunit/pull/4478)
* [4391](https://github.com/nunit/nunit/issues/4391) Hash/Partition based Test Filter. Thanks to [Andrew Armstrong](https://github.com/Plasma) for [PR 4392](https://github.com/nunit/nunit/pull/4392)
* [3936](https://github.com/nunit/nunit/issues/3936) Is there any way we could make use of CallerArgumentExpressionAttribute?. Fixed by team [PR 4419](https://github.com/nunit/nunit/pull/4419)
* [3798](https://github.com/nunit/nunit/issues/3798) Support abstract methods marked as tests. Fixed by team [PR 4490](https://github.com/nunit/nunit/pull/4490)

### Bug fixes

* [4554](https://github.com/nunit/nunit/issues/4554) SetUpFixture has stopped working going from NUnit 3.13.3 to 3.14.0/4.0.0-beta.1. Fixed by team [PR 4555](https://github.com/nunit/nunit/pull/4555)
* [4532](https://github.com/nunit/nunit/issues/4532) Assert.That no longer allows 'null' message. Fixed by team [PR 4533](https://github.com/nunit/nunit/pull/4533)
* [4529](https://github.com/nunit/nunit/issues/4529) Forwardport: Missing stack trace when exception occurs during OneTimeSetUp #2466. Fixed by team [PR 4469](https://github.com/nunit/nunit/pull/4469)
* [4528](https://github.com/nunit/nunit/issues/4528) Forwardport: Is.SupersetOf and Is.SubsetOf no longer work with ImmmutableDictionary&lt;TKey,TValue&gt; in NUnit 3.13.3 #4095. Fixed by team [PR 4098](https://github.com/nunit/nunit/pull/4098)
* [4522](https://github.com/nunit/nunit/issues/4522) Missing stack trace when exception occurs during OneTimeSetUp #2466. Fixed by team [PR 4469](https://github.com/nunit/nunit/pull/4469)
* [4491](https://github.com/nunit/nunit/issues/4491) NUnit 4.0 fails when [Repeat] is present and test passes. Fixed by team [PR 4517](https://github.com/nunit/nunit/pull/4517)
* [4484](https://github.com/nunit/nunit/issues/4484) String not-regex constraint succeeds non-`string` actual value. Thanks to [Michael Render](https://github.com/RenderMichael) for [PR 4492](https://github.com/nunit/nunit/pull/4492)
* [4450](https://github.com/nunit/nunit/issues/4450) Missing comparison failure details for EqualTo when comparing two collection. Thanks to [Ashish Dawale](https://github.com/ashishdawale20) for [PR 4502](https://github.com/nunit/nunit/pull/4502)
* [4423](https://github.com/nunit/nunit/issues/4423) Chaining multiple collection asserts with index. Thanks to [Daniel Waechtler](https://github.com/crabstars) for [PR 4480](https://github.com/nunit/nunit/pull/4480)
* [4400](https://github.com/nunit/nunit/issues/4400) Within throws ArgumentException if null value is involved. Thanks to [Ashish Dawale](https://github.com/ashishdawale20) for [PR 4482](https://github.com/nunit/nunit/pull/4482)
* [4319](https://github.com/nunit/nunit/issues/4319) TextRunner accidentally disposes System.Out. Thanks to [Norm Johanson](https://github.com/normj) for [PR 4317](https://github.com/nunit/nunit/pull/4317)
* [4308](https://github.com/nunit/nunit/issues/4308) Random attribute with Distinct and wide range causes test to disappear. Thanks to [Russell Smith](https://github.com/mr-russ) for [PR 4316](https://github.com/nunit/nunit/pull/4316)
* [4264](https://github.com/nunit/nunit/issues/4264) Assert.Multiple method should fail only if a contained assertion failed. Thanks to [Samuel Delarosbil](https://github.com/sdelarosbil) for [PR 4313](https://github.com/nunit/nunit/pull/4313)
* [4259](https://github.com/nunit/nunit/issues/4259) Bug: Assert.That(IEnumerable&lt;Type&gt;, Has.All.Property(nameof(Type.Namespace)) fails.. Fixed by team [PR 4260](https://github.com/nunit/nunit/pull/4260)
* [4255](https://github.com/nunit/nunit/issues/4255) InternalTrace.Initialize fails with Nullref exception. Fixed by team [PR 4256](https://github.com/nunit/nunit/pull/4256)
* [4246](https://github.com/nunit/nunit/issues/4246) Stack overflow when running tests on machine with Thai regional format. Fixed by team [PR 4345](https://github.com/nunit/nunit/pull/4345)
* [4243](https://github.com/nunit/nunit/issues/4243) Type args are not deduced correctly for parameterized fixtures. Thanks to [Samuel Delarosbil](https://github.com/sdelarosbil) for [PR 4307](https://github.com/nunit/nunit/pull/4307)
* [4237](https://github.com/nunit/nunit/issues/4237) Bogus check for Windows 11. Fixed by team [PR 4374](https://github.com/nunit/nunit/pull/4374)
* [4158](https://github.com/nunit/nunit/issues/4158) SetupFixture should have an `AttributeUsage` of `Inherited = false`. Thanks to [TillW](https://github.com/x789) for [PR 4222](https://github.com/nunit/nunit/pull/4222)
* [4107](https://github.com/nunit/nunit/issues/4107) Incorrect type specified for Values attribute fails unrelated tests. Fixed by team [PR 4133](https://github.com/nunit/nunit/pull/4133)
* [4096](https://github.com/nunit/nunit/issues/4096) NUnit.Framework 3.13.2 introduced a breaking change that conceals problems with tests. Fixed by team [PR 4133](https://github.com/nunit/nunit/pull/4133)
* [3964](https://github.com/nunit/nunit/issues/3964) DictionaryContainsKeyValuePairConstraint doesn't work with `IDictionary&lt;TKey, TValue&gt;`. Thanks to [Louis Zanella](https://github.com/louis-z) for [PR 4014](https://github.com/nunit/nunit/pull/4014)
* [3961](https://github.com/nunit/nunit/issues/3961) OneTimeTearDown runs on a new thread with mismatched Thread Name and Worker Id. Thanks to [EraserKing](https://github.com/EraserKing) for [PR 4004](https://github.com/nunit/nunit/pull/4004)
* [3953](https://github.com/nunit/nunit/issues/3953) Dispose is not called on test fixtures with LifeCycle.InstancePerTestCase without TearDown method. Fixed by team [PR 3963](https://github.com/nunit/nunit/pull/3963)
* [3872](https://github.com/nunit/nunit/issues/3872) Add support for `ref bool`, `ref bool?`, `in bool`, and `in bool?` when using `NUnit.Framework.ValuesAttribute`. Thanks to [Samuel Delarosbil](https://github.com/sdelarosbil) for [PR 4304](https://github.com/nunit/nunit/pull/4304)
* [3868](https://github.com/nunit/nunit/issues/3868) Order attribute skips classes with multiple test fixtures. Thanks to [Samuel Delarosbil](https://github.com/sdelarosbil) for [PR 4304](https://github.com/nunit/nunit/pull/4304)
* [3867](https://github.com/nunit/nunit/issues/3867) nunit Framework tests do not run with "dotnet test" nor inside VS2019 (Windows). Fixed by team [PR 4315](https://github.com/nunit/nunit/pull/4315)
* [3858](https://github.com/nunit/nunit/issues/3858) Running tests with ITestAction attributes leaks memory. Thanks to [Marko Lahma](https://github.com/lahma) for [PR 4300](https://github.com/nunit/nunit/pull/4300)
* [3811](https://github.com/nunit/nunit/issues/3811) Incorrect summary comments on Warn.If overloads. Fixed by team [PR 3845](https://github.com/nunit/nunit/pull/3845)
* [3735](https://github.com/nunit/nunit/issues/3735) Parallelizable TestFixtureSource with TestFixtureData not running in parallel. Thanks to [Julien Richard](https://github.com/jairbubbles) for [PR 4099](https://github.com/nunit/nunit/pull/4099)
* [3449](https://github.com/nunit/nunit/issues/3449) Assert.AreEqual overloads for nullable double are not useful. Thanks to [Anton Ashmarin](https://github.com/Antash) for [PR 3780](https://github.com/nunit/nunit/pull/3780)
* [3274](https://github.com/nunit/nunit/issues/3274) Overridden tests are not discovered in NUnit 3.12.0. Fixed by team [PR 4490](https://github.com/nunit/nunit/pull/4490)
* [3215](https://github.com/nunit/nunit/issues/3215) Better error message for generic test where type parameter cannot be determined. Thanks to [Ove Bastiansen](https://github.com/ovebastiansen) for [PR 4382](https://github.com/nunit/nunit/pull/4382)
* [2870](https://github.com/nunit/nunit/issues/2870) CollectionTally (EquivalentTo) should throw for non-transitive comparisons. Thanks to [Russell Smith](https://github.com/mr-russ) for [PR 4312](https://github.com/nunit/nunit/pull/4312)
* [2841](https://github.com/nunit/nunit/issues/2841) DelayedConstraint calls delegate twice. Fixed by team [PR 4488](https://github.com/nunit/nunit/pull/4488)
* [2835](https://github.com/nunit/nunit/issues/2835) Control character encoding is inconsistent between TestCase[Source] and TestFixture[Source]. Fixed by team [PR 4498](https://github.com/nunit/nunit/pull/4498)
* [2436](https://github.com/nunit/nunit/issues/2436) Properties on System.Type cannot be used with either property constraint. Fixed by team [PR 4259](https://github.com/nunit/nunit/pull/4259)
* [1428](https://github.com/nunit/nunit/issues/1428) NUnitLite package always installs both Program.cs and Program.vb. Fixed by team [PR 3952](https://github.com/nunit/nunit/pull/3952)

### Refactorings

* [4539](https://github.com/nunit/nunit/issues/4539) Upgrade to latest analyzers package and fix the warnings.
* [4434](https://github.com/nunit/nunit/issues/4434) Fixing the classic asserts. Fixed by team [PR 4438](https://github.com/nunit/nunit/pull/4438)
* [4416](https://github.com/nunit/nunit/issues/4416) Move classic asserts into its own project . Fixed by team [PR 4417](https://github.com/nunit/nunit/pull/4417)
* [4380](https://github.com/nunit/nunit/issues/4380) Consistently use _ prefix for field names. Fixed by team [PR 4387](https://github.com/nunit/nunit/pull/4387)
* [4378](https://github.com/nunit/nunit/issues/4378) Update code base to use 'is (not) null' consistently. Fixed by team [PR 4379](https://github.com/nunit/nunit/pull/4379)
* [4376](https://github.com/nunit/nunit/issues/4376) Update code base to explicitly specify accessibility. Fixed by team [PR 4377](https://github.com/nunit/nunit/pull/4377)
* [4364](https://github.com/nunit/nunit/issues/4364) Add NUnit.Analyzer to our test projects. Fixed by team [PR 4366](https://github.com/nunit/nunit/pull/4366)
* [4111](https://github.com/nunit/nunit/issues/4111) `Is.Empty` constraint on complex collections might hide bugs. Thanks to [Felix Kr”ner](https://github.com/Crown0815) for [PR 4120](https://github.com/nunit/nunit/pull/4120)
* [4051](https://github.com/nunit/nunit/issues/4051) Update codebase to use Array.Empty&lt;T&gt;. Thanks to [Marcin Jedrzejek](https://github.com/mjedrzejek) for [PR 4127](https://github.com/nunit/nunit/pull/4127)
* [3932](https://github.com/nunit/nunit/issues/3932) Make `Numerics` class internal. Thanks to [TillW](https://github.com/x789) for [PR 4205](https://github.com/nunit/nunit/pull/4205)

### Internal fixes

* [4503](https://github.com/nunit/nunit/issues/4503) Add NET8 target for the framework tests. Thanks to [Ashish Dawale](https://github.com/ashishdawale20) for [PR 4511](https://github.com/nunit/nunit/pull/4511)
* [4432](https://github.com/nunit/nunit/issues/4432) Fix null message in internal static string? ExtendedMessage(string methodName, string? message, string actualExpression, string constraintExpression). Fixed by team [PR 4430](https://github.com/nunit/nunit/pull/4430)
* [4331](https://github.com/nunit/nunit/issues/4331) Add testing to "Accumulate further failures if any on AssertMultiple instead of throwing". Thanks to [Samuel Delarosbil](https://github.com/sdelarosbil) for [PR 4313](https://github.com/nunit/nunit/pull/4313)
* [4212](https://github.com/nunit/nunit/issues/4212) Add Windows11 support to the Platform attribute. Fixed by team [PR 4213](https://github.com/nunit/nunit/pull/4213)
* [4170](https://github.com/nunit/nunit/issues/4170) Add .NET7 as a build target for the test suite . Fixed by team [PR 4224](https://github.com/nunit/nunit/pull/4224)
* [4078](https://github.com/nunit/nunit/issues/4078) THREAD_ABORT not properly set. Fixed by team [PR 4079](https://github.com/nunit/nunit/pull/4079)
* [4075](https://github.com/nunit/nunit/issues/4075) Remove unnecessary allocations in NUnitEqualityComparer. Fixed by team [PR 4076](https://github.com/nunit/nunit/pull/4076)
* [4072](https://github.com/nunit/nunit/issues/4072) Use pattern matching in Constraints to avoid unnecessary casts. Fixed by team [PR 4073](https://github.com/nunit/nunit/pull/4073)
* [4065](https://github.com/nunit/nunit/issues/4065) Use pattern matching in the comparers. Fixed by team [PR 4066](https://github.com/nunit/nunit/pull/4066)
* [4055](https://github.com/nunit/nunit/issues/4055) Use static Regex.IsMatch in ValueMatchFilter to take advantage of caching. Fixed by team [PR 4056](https://github.com/nunit/nunit/pull/4056)
* [4049](https://github.com/nunit/nunit/issues/4049) Simplify property retrieval in DefaultTestAssemblyBuilder.Build(). Thanks to [Scott Buchanan](https://github.com/Phyrik) for [PR 4054](https://github.com/nunit/nunit/pull/4054)
* [3935](https://github.com/nunit/nunit/issues/3935) `Numerics.IsFixedPointNumeric` should return false for decimals. Thanks to [Wellington Balbo](https://github.com/wbalbo) for [PR 3942](https://github.com/nunit/nunit/pull/3942)
* [3789](https://github.com/nunit/nunit/issues/3789) Change copyright header on files. Fixed by team [PR 3795](https://github.com/nunit/nunit/pull/3795)
* [3764](https://github.com/nunit/nunit/issues/3764) Switch to the dotnet tool version of Cake. Fixed by team [PR 3835](https://github.com/nunit/nunit/pull/3835)
* [3588](https://github.com/nunit/nunit/issues/3588) Audit string equality comparisons and consider changes for v4. Fixed by team [PR 3770](https://github.com/nunit/nunit/pull/3770)
* [2485](https://github.com/nunit/nunit/issues/2485) Remove\Trim copyright on individual files. Fixed by team [PR 3795](https://github.com/nunit/nunit/pull/3795)
* [4504](https://github.com/nunit/nunit/issues/4504) Remove appveyor build. Fixed by team [PR 4509](https://github.com/nunit/nunit/pull/4509)
* [4465](https://github.com/nunit/nunit/issues/4465) Update cake version in build scripts. Fixed by team [PR 4540](https://github.com/nunit/nunit/pull/4540)
* [4036](https://github.com/nunit/nunit/issues/4036) Drop net45 build target in nunit4. Fixed by team [PR 4050](https://github.com/nunit/nunit/pull/4050)
* [3984](https://github.com/nunit/nunit/issues/3984) Add net6.0 targets. Fixed by team [PR 3988](https://github.com/nunit/nunit/pull/3988)
* [3980](https://github.com/nunit/nunit/issues/3980) Drop netcoreapp2.1 targets. Fixed by team [PR 3988](https://github.com/nunit/nunit/pull/3988)
* [3812](https://github.com/nunit/nunit/issues/3812) Add GitHub Actions. Fixed by team [PR 3819](https://github.com/nunit/nunit/pull/3819)
* [3764](https://github.com/nunit/nunit/issues/3764) Switch to the dotnet tool version of Cake. Fixed by team [PR 3835](https://github.com/nunit/nunit/pull/3835)
* [3758](https://github.com/nunit/nunit/issues/3758) Drop .NET 3.5 Build Targets. Fixed by team [PR 3760](https://github.com/nunit/nunit/pull/3760)
* [2485](https://github.com/nunit/nunit/issues/2485) Remove\Trim copyright on individual files. Fixed by team [PR 3795](https://github.com/nunit/nunit/pull/3795)

### Deprecated features

* [4415](https://github.com/nunit/nunit/issues/4415) Remove use of params for messages. Fixed by team [PR 4419](https://github.com/nunit/nunit/pull/4419)
* [4036](https://github.com/nunit/nunit/issues/4036) Drop net45 build target in nunit4. Fixed by team [PR 4050](https://github.com/nunit/nunit/pull/4050)
* [3980](https://github.com/nunit/nunit/issues/3980) Drop netcoreapp2.1 targets. Fixed by team [PR 3988](https://github.com/nunit/nunit/pull/3988)
* [3769](https://github.com/nunit/nunit/issues/3769) Remove code marked "Obsolete". Fixed by team [PR 3836](https://github.com/nunit/nunit/pull/3836)
* [3758](https://github.com/nunit/nunit/issues/3758) Drop .NET 3.5 Build Targets. Fixed by team [PR 3760](https://github.com/nunit/nunit/pull/3760)
* [3708](https://github.com/nunit/nunit/issues/3708) Drop .NET 4.0 Build Target. Fixed by team [PR 3760](https://github.com/nunit/nunit/pull/3760)
* [3410](https://github.com/nunit/nunit/issues/3410) Consider deprecating NUnitEqualityComparer.AreEqual optional bool parameter. Thanks to [TillW](https://github.com/x789) for [PR 3960](https://github.com/nunit/nunit/pull/3960)
* [3132](https://github.com/nunit/nunit/issues/3132) Remove AssertionHelper and AssertionHelperTests. Fixed by team [PR 3836](https://github.com/nunit/nunit/pull/3836)

### Others

* [3869](https://github.com/nunit/nunit/issues/3869) Copyright notices for third-party code. Thanks to [Lennart Brggemann](https://github.com/lennartb-) for [PR 4444](https://github.com/nunit/nunit/pull/4444)
* [3301](https://github.com/nunit/nunit/issues/3301) [HandleProcessCorruptedStateExceptions] has no effect unless we disable partial trust. Fixed by team [PR 4398](https://github.com/nunit/nunit/pull/4398)

### The following issues are marked as breaking changes

* [4416](https://github.com/nunit/nunit/issues/4416) Move classic asserts into its own project . Fixed by team [PR 4417](https://github.com/nunit/nunit/pull/4417)
* [4415](https://github.com/nunit/nunit/issues/4415) Remove use of params for messages. Fixed by team [PR 4419](https://github.com/nunit/nunit/pull/4419)

Also note that there are some breaking changes in the API for NUnit.

Ref [Issue 4610](https://github.com/nunit/nunit/issues/4610).

* Constraint.Description:  It is now an abstract get property, earlier a virtual with protected setter.  
* PrefixConstraint.DescriptionPrefix: It is now an abstract get property, earlier a virtual with protected setter.

## NUnit 3.14.0 - November 4, 2023

Total number of issues fixed in this release is : 16

### Enhancements

* [4046](https://github.com/nunit/nunit/issues/4046) Backport .NET6 test infra + build improvements from #3984 onto
  v3.13 branch. Fixed by team [PR 4077](https://github.com/nunit/nunit/pull/4077) ( backport of issue 3984)
* [4009](https://github.com/nunit/nunit/issues/4009) Performance degradation on many tests. Thanks to [Marko
  Lahma](https://github.com/lahma) for [PR 4034](https://github.com/nunit/nunit/pull/4034)
* [3859](https://github.com/nunit/nunit/issues/3859) Proper test result exception message when hitting
  `TimeoutAttribute`. Fixed by team [PR 4118](https://github.com/nunit/nunit/pull/4118)
* [3601](https://github.com/nunit/nunit/issues/3601) Nunit 3.10.1.0 + ReSharper 2020.1.4: Test execution delayed by
  ~60seconds . Thanks to [Marko Lahma](https://github.com/lahma) for [PR 4034](https://github.com/nunit/nunit/pull/4034)
* [2729](https://github.com/nunit/nunit/issues/2729) Proposal: Async test case sources. Fixed by team [PR
  4390](https://github.com/nunit/nunit/pull/4390)

### Bug fixes

* [4527](https://github.com/nunit/nunit/issues/4527) Backport: NUnit.Framework 3.13.2 introduced a breaking change that
  conceals problems with tests. Fixed by team [PR 4104](https://github.com/nunit/nunit/pull/4104) ( backport of issue
  4096 by pr 4133)
* [4525](https://github.com/nunit/nunit/issues/4525) Backport: SetupFixture should have an AttributeUsage of Inherited =
  false . Thanks to [TillW](https://github.com/x789) for [PR 4223](https://github.com/nunit/nunit/pull/4223) ( backport
  of issue 4158 by pr 4222)
* [4523](https://github.com/nunit/nunit/issues/4523) Backport: Stack overflow when running tests on machine with Thai
  regional format. Fixed by team [PR 4346](https://github.com/nunit/nunit/pull/4346) ( backport of issue 4246 by pr
  4345)
* [4324](https://github.com/nunit/nunit/issues/4324) Backport to v3:  TextRunner accidentally disposes System.Out.
  Thanks to [Norm Johanson](https://github.com/normj) for [PR 4325](https://github.com/nunit/nunit/pull/4325) ( backport
  of issue 4319 by pr 4317)
* [4095](https://github.com/nunit/nunit/issues/4095) Is.SupersetOf and Is.SubsetOf no longer work with
  IImmmutableDictionary<TKey,TValue> in NUnit 3.13.3. Fixed by team [PR 4097](https://github.com/nunit/nunit/pull/4097)
* [3859](https://github.com/nunit/nunit/issues/3859) Proper test result exception message when hitting
  `TimeoutAttribute`. Fixed by team [PR 4118](https://github.com/nunit/nunit/pull/4118)
* [3710](https://github.com/nunit/nunit/issues/3710) Calling NUnitLite from LINQpad, can't parse assembly path. Thanks
  to [Norm Johanson](https://github.com/normj) for [PR 4325](https://github.com/nunit/nunit/pull/4325)
* [2466](https://github.com/nunit/nunit/issues/2466) Missing stack trace when exception occurs during OneTimeSetUp.
  Fixed by team [PR 4467](https://github.com/nunit/nunit/pull/4467)

### Refactorings

None

### Internal fixes

* [4524](https://github.com/nunit/nunit/issues/4524) Backport: Add .NET7 as a build target for the test suite #4170.
  Fixed by team [PR 4302](https://github.com/nunit/nunit/pull/4302) ( backport of issue 4170 by pr 4224)
* [4293](https://github.com/nunit/nunit/issues/4293) .NET5 Test Suite is failing on Azure DevOps for Windows. Fixed by
  team [PR 4296](https://github.com/nunit/nunit/pull/4296)
* [2973](https://github.com/nunit/nunit/issues/2973) Write up recommended way to test and link it from the readme.
  Thanks to [Bruno Juchli](https://github.com/BrunoJuchli) for [PR 2971](https://github.com/nunit/nunit/pull/2971)

### Deprecated features

None

### The following issues are marked as breaking changes

None

## NUnit 3.13.3 - March 20, 2022

This release includes several performance enhancements. [@lahma](https://github.com/lahma) provided a massive speed
improvement for large, parametrized test suites. In addition, equivalency tests with large unsortable collections run
faster by determining if the collections are sortable before attempting to sort them.

We've added several fixes for .NET 6.0 and we've stopped testing NUnit against .NET Core 2.1 which is now out of
support.

There are also several fixes for the new `FixtureLifeCycle` feature and other smaller bug fixes and performance
improvements.

### Issues Resolved

* [2963](https://github.com/nunit/nunit/issues/2963) Flakey tests in FrameworkControllerTests
* [3643](https://github.com/nunit/nunit/issues/3643) Assert.Pass(message) produces "reason" in XML-Result
* [3841](https://github.com/nunit/nunit/issues/3841) Breaking change: Is.SupersetOf with ValueTuple requires IComparable
  in NUnit 3.13.2
* [3843](https://github.com/nunit/nunit/issues/3843) IDisposable & InstancePerTestCase: Object created for OneTimeSetUp
  is not disposed
* [3898](https://github.com/nunit/nunit/issues/3898) NUnit 3.13.2 : LessThanOrEqualTo fails on a case which should
  succeed
* [3903](https://github.com/nunit/nunit/issues/3903) Backport race condition fix (PR 3883)
* [3904](https://github.com/nunit/nunit/issues/3904) Backport fix for "IDisposable & InstancePerTestCase" (PR 3843)
* [3929](https://github.com/nunit/nunit/issues/3929) Fix high precision decimal calculations in v3.13 (#3898)
* [3959](https://github.com/nunit/nunit/issues/3959) Marked 'NUnitEqualityComparer.AreEqual(object, object, Tolerance,
  bool)' as obsolete
* [3962](https://github.com/nunit/nunit/issues/3962) Ensure that AfterTest always runs in AfterTestCommand
* [3971](https://github.com/nunit/nunit/issues/3971) Backport "Add missing `[DoesNotReturn]` annotations" from #3958
* [3976](https://github.com/nunit/nunit/issues/3976) Equivalency fallback for non-IComparable types can leave
  CollectionTally in corrupt state
* [3998](https://github.com/nunit/nunit/issues/3998) Eagerly determine when a set is unsortable
* [3999](https://github.com/nunit/nunit/issues/3999) Numeric comparison fails when it should succeed.
* [4000](https://github.com/nunit/nunit/issues/4000) OverflowException comparing large double values
* [4007](https://github.com/nunit/nunit/issues/4007) Eagerly detect sortable types for equivalency tests in 3.13.x
* [4030](https://github.com/nunit/nunit/issues/4030) IsEmpty doesn't work with new .NET6 PriorityQueue
* [4032](https://github.com/nunit/nunit/issues/4032) Tests won't run with an abstract base class that has a
  TestCaseFixtureSource
* [4033](https://github.com/nunit/nunit/issues/4033) Recognized private members in base class for Source attributes
* [4034](https://github.com/nunit/nunit/issues/4034) Improve method discovery and filtering performance
* [4041](https://github.com/nunit/nunit/issues/4041) Minimize empty array allocations via centralized helper for
  pre-net46
* [4043](https://github.com/nunit/nunit/issues/4043) Stop testing the framework against netcoreapp21 in v3.13 branch
* [4045](https://github.com/nunit/nunit/issues/4045) Drop netcore2.1 as a target (backport #3986)
* [4058](https://github.com/nunit/nunit/issues/4058) Remove TopLevel property from ValueMatchFilter

## NUnit 3.13.2 - April 27, 2021

This release fixes a new issue with the `FixtureLifeCycle` attribute where `IDisposable` test fixtures were not being
disposed properly. As always, [@gleb-osokin](https://github.com/gleb-osokin) has been a great help with this new
feature.

It also fixes a long-standing performance issue with `CollectionAssert.AreEquivalent` and the
`CollectionEquivalentConstraint` when comparing large collections. The deep comparison that NUnit performs on the two
collections will always have a worst case bound of O(n^2) but we have optimized it so that the majority of use cases
will be closer to O(n).

We've also made significant optimizations to the OR filters for selecting tests using their full name. This dramatically
improves test performance for large code bases that use `dotnet test`. Thanks to [@pakrym](https://github.com/pakrym)
for his help with this.

### Issues Resolved

* [2799](https://github.com/nunit/nunit/issues/2799) CollectionAssert.AreEquivalent is extremely slow
* [3589](https://github.com/nunit/nunit/issues/3589) File headers, copyrights, and licenses
* [3773](https://github.com/nunit/nunit/issues/3773) IDisposable not working with InstancePerTestCase
* [3779](https://github.com/nunit/nunit/issues/3779) Obsolete AreEqual methods with nullable numeric arguments for 3.13
* [3784](https://github.com/nunit/nunit/issues/3784) Build the v3.13-dev branch
* [3786](https://github.com/nunit/nunit/issues/3786) NUnit with dotnet test results in O(n^2) filtering complexity
* [3810](https://github.com/nunit/nunit/issues/3810) Enable deterministic build
* [3818](https://github.com/nunit/nunit/issues/3818) AppVeyor failing to build v3.13-dev branch PRs
* [3832](https://github.com/nunit/nunit/issues/3832) Deploy v3.13-dev branch builds to MyGet

## NUnit 3.13.1 - January 31, 2021

This release addresses several misses with the new `FixtureLifeCycle` attribute, switches to using
[SourceLink](https://github.com/dotnet/sourcelink) and NuGet
[snupkg](https://docs.microsoft.com/en-us/nuget/create-packages/symbol-packages-snupkg) packages for debugging into
NUnit from your unit tests. It also addresses issues with the time format of ignored and explicit tests in the test
results file.

### Issues Resolved

* [2339](https://github.com/nunit/nunit/issues/2339) Wrong date format in Ignored TestFixtures
* [3715](https://github.com/nunit/nunit/issues/3715) `FixtureLifeCycle(LifeCycle.InstancePerTestCase)` Not working with
  `TestFixtureSource`
* [3716](https://github.com/nunit/nunit/issues/3716) Assembly level `FixtureLifeCycle(LifeCycle.InstancePerTestCase)`
  doesn't work
* [3724](https://github.com/nunit/nunit/issues/3724) Test start and end time should end with Z
* [3726](https://github.com/nunit/nunit/issues/3726) Assert `EqualTo().Within().Seconds` does not work with DateTimes in
  NUnit 3.13
* [3729](https://github.com/nunit/nunit/issues/3729) AppVeyor builds failing
* [3736](https://github.com/nunit/nunit/issues/3736) `AreEqual.Within` throws on failure with non-numeric types
* [3743](https://github.com/nunit/nunit/issues/3743) Parametrized tests do not respect
  `FixtureLifeCycle.InstancePerTestCase`
* [3745](https://github.com/nunit/nunit/issues/3745) After upgrading to NUnit 3.13.0 the debugger enters NUnit code
  despite having checked "Enable Just My Code"

## NUnit 3.13 - January 7, 2021

The [`FixtureLifeCycle`](xref:fixturelifecycleattribute) attribute has been added to indicate that an instance for a
test fixture or all test fixtures in an assembly should be constructed for each test within the fixture or assembly.

This attribute may be applied to a test fixture (class) or to a test assembly. It is useful in combination with the
[Parallelizable Attribute](xref:parallelizableattribute) so that a new instance of a test fixture is constructed for
every test within the test fixture. This allows tests to run in isolation without sharing instance fields and properties
during parallel test runs. This make running parallel tests easier because it is easier to make your tests thread safe.

This release also fixes several issues running tests in .NET 5.0. If your tests target .NET 5.0, we recommend updating
to this release.

### Issues Resolved

* [34](https://github.com/nunit/nunit/issues/34) Async testing with F#
* [52](https://github.com/nunit/nunit/issues/52) Self-contained item in array causes stack overflow
* [1394](https://github.com/nunit/nunit/issues/1394) `Has.Property` cannot see explicit interface implementation
  properties
* [1491](https://github.com/nunit/nunit/issues/1491) Add a CLA to the project
* [1546](https://github.com/nunit/nunit/issues/1546) `NUnitEqualityComparer.GetEquatableGenericArguments` should
  explicitly order arguments
* [1809](https://github.com/nunit/nunit/issues/1809) `Assert.AreEqual` fails for Complex on Linux
* [1897](https://github.com/nunit/nunit/issues/1897) `EqualTo().Using()` prevents caller from comparing strings to
  anything else
* [2211](https://github.com/nunit/nunit/issues/2211) Add support of indexers to the PropertyConstraint
* [2222](https://github.com/nunit/nunit/issues/2222) Switch to one Release branch
* [2477](https://github.com/nunit/nunit/issues/2477) Parameterized fixture with `Explicit` attribute can not be run when
  selected by name
* [2574](https://github.com/nunit/nunit/issues/2574) Instance-per-test-case feature
* [2680](https://github.com/nunit/nunit/issues/2680) Deprecate the `DebugWriter` class
* [3611](https://github.com/nunit/nunit/issues/3611) Properties are shown when `--explore:nunit3` is run on entire
  project, but omitted when using the `--where` clause
* [3054](https://github.com/nunit/nunit/issues/3054) Don't enforce `[Timeout]` when debugger is attached
* [3075](https://github.com/nunit/nunit/issues/3075) Complete `RunAsyncAction` tests in `FrameworkControllerTests`
* [3228](https://github.com/nunit/nunit/issues/3228) Modulo bias is present in `Randomizer.NextDecimal(decimal)`
* [3240](https://github.com/nunit/nunit/issues/3240) Automate uploading of test results to Azure Pipelines
* [3243](https://github.com/nunit/nunit/issues/3243) Azure DevOps does not build release branch
* [3249](https://github.com/nunit/nunit/issues/3249) Pin GitLink version to speed up Cake script
* [3251](https://github.com/nunit/nunit/issues/3251) `RawInt32()` can't use Next since the maximum is always exclusive
  and it would never return int.MaxValue
* [3252](https://github.com/nunit/nunit/issues/3252) Timeout of 100 ms in `TestTimeoutDoesNotStopCompletion`
  occasionally fails the macOS build
* [3253](https://github.com/nunit/nunit/issues/3253) Chance of failure in random bias tests is not sufficiently low for
  CI
* [3256](https://github.com/nunit/nunit/issues/3256) Building under VS2019
* [3257](https://github.com/nunit/nunit/issues/3257) Running under mono
* [3259](https://github.com/nunit/nunit/issues/3259) The type of an Array isn't inferred from properly
* [3264](https://github.com/nunit/nunit/issues/3264) Test that `IRepeatTest` only gets attributes via the `IMethodInfo`
  interface
* [3275](https://github.com/nunit/nunit/issues/3275) Enable setting `IgnoreUntilDate` in `TestCaseData.Ignore`
* [3279](https://github.com/nunit/nunit/issues/3279) Improve failure message from `UniqueItemsConstraint`
* [3282](https://github.com/nunit/nunit/issues/3282) `TimeoutAttribute` makes all Assertions count as failure
* [3283](https://github.com/nunit/nunit/issues/3283) `ExecutionContext` is flowed between unrelated tests
* [3286](https://github.com/nunit/nunit/issues/3286) Testing for equality using a predicate throws exception for
  collections
* [3290](https://github.com/nunit/nunit/issues/3290) 'Good first issue' or 'help wanted' issue count badge
* [3296](https://github.com/nunit/nunit/issues/3296) `ExceptionHelper.GetExceptionMessage(Exception ex)` should tolerate
  exceptions from exceptions
* [3302](https://github.com/nunit/nunit/issues/3302) Incorrect formatting of failure message if test fails with
  `Assert.Multiple`
* [3303](https://github.com/nunit/nunit/issues/3303) Check type of actual argument using consistent helper method
* [3304](https://github.com/nunit/nunit/issues/3304) `CheckString` should not be a generic method
* [3305](https://github.com/nunit/nunit/issues/3305) Remove unused methods
* [3307](https://github.com/nunit/nunit/issues/3307) Sporadic `GetResultIsNotCalledUntilContinued` failure
* [3308](https://github.com/nunit/nunit/issues/3308) Fix disposal in `EnumerablesComparer`
* [3309](https://github.com/nunit/nunit/issues/3309) Simplify code in `EventListenerTextWriter`
* [3311](https://github.com/nunit/nunit/issues/3311) Minimal unit of `DateTime` in the report when Test was
  started/ended
* [3312](https://github.com/nunit/nunit/issues/3312) Simplify `ProviderCache` and make it instantiable since it is
  intentionally not thread safe
* [3315](https://github.com/nunit/nunit/issues/3315) `Assert.DoesNotThrow()` stopped working as it was previously
* [3318](https://github.com/nunit/nunit/issues/3318) Fix `AwaitAdapter` terminology
* [3321](https://github.com/nunit/nunit/issues/3321) Keep dependencies up to date
* [3322](https://github.com/nunit/nunit/issues/3322) Speed up build script by removing unnecessary builds
* [3324](https://github.com/nunit/nunit/issues/3324) Broken link in `CHANGES.md`
* [3328](https://github.com/nunit/nunit/issues/3328) Problems when using a mixture of Not and Or filters in NUnit
  framework 3.12.0
* [3331](https://github.com/nunit/nunit/issues/3331) `Contains.Key` no longer working for `IDictionary`
* [3338](https://github.com/nunit/nunit/issues/3338) Azure Pipelines is failing on Linux for both netstandard 1.4 and
  2.0
* [3356](https://github.com/nunit/nunit/issues/3356) `SetUpFixture` not run
* [3368](https://github.com/nunit/nunit/issues/3368) Tests with warnings are not added to console `TestResult.xml` total
  count
* [3383](https://github.com/nunit/nunit/issues/3383) Drop netstandard1.4 and stop testing on end-of-life versions of
  .NET Core
* [3389](https://github.com/nunit/nunit/issues/3389) Show names of parameters
* [3390](https://github.com/nunit/nunit/issues/3390) `SetUpFixture` not being triggered when running tests using
  `--testlist`
* [3392](https://github.com/nunit/nunit/issues/3392) Use of `Thread.CurrentPrincipal` in Blazor/WASM
* [3393](https://github.com/nunit/nunit/issues/3393) Nuget Package Not Signed
* [3395](https://github.com/nunit/nunit/issues/3395) `Randomizer.NextString()` can probably be sped up
* [3408](https://github.com/nunit/nunit/issues/3408) Save test results as build artifacts
* [3411](https://github.com/nunit/nunit/issues/3411) Update nuspec file to mention support for NET Standard 2.0+
* [3414](https://github.com/nunit/nunit/issues/3414) Azure pipelines are failing on Linux
* [3415](https://github.com/nunit/nunit/issues/3415) Azure CI: Still publish test results on failure
* [3423](https://github.com/nunit/nunit/issues/3423) `TestResult.cs` casts `ITestResult` to `TestResult`
* [3447](https://github.com/nunit/nunit/issues/3447)
  `Is.EqualTo(...).Using(StructuralComparisons.StructuralEqualityComparer or StructuralComparer)` not working
* [3452](https://github.com/nunit/nunit/issues/3452) Assertions that use an existing Regex
* [3453](https://github.com/nunit/nunit/issues/3453) Visibility of SetUp/TearDown Methods
* [3454](https://github.com/nunit/nunit/issues/3454) Pre-Filtering in NUnitLite has problems
* [3464](https://github.com/nunit/nunit/issues/3464) Improve debugging experience
* [3470](https://github.com/nunit/nunit/issues/3470) Assertion for key-value-pair
* [3475](https://github.com/nunit/nunit/issues/3475) Our XML comments are using `<code>` (block element) instead of
  `<c>` (inline element)
* [3485](https://github.com/nunit/nunit/issues/3485) Should we make `MultipleAssertException.TestResult` maybe-null or
  obsolete two constructors?
* [3496](https://github.com/nunit/nunit/issues/3496) Adding data dictionary should not add a trailing newline
* [3497](https://github.com/nunit/nunit/issues/3497) Fix mixed line endings in Git
* [3503](https://github.com/nunit/nunit/issues/3503) Remove implicit cast from `ITestResult` to `TestResult`
* [3505](https://github.com/nunit/nunit/issues/3505) Better failure messages for Subset and Superset constraints
* [3506](https://github.com/nunit/nunit/issues/3506) `ValueTuple` tests now running if not targeting NET35
* [3536](https://github.com/nunit/nunit/issues/3536) Reduce newly added API surface
* [3542](https://github.com/nunit/nunit/issues/3542) Update NuGet Package Icons
* [3547](https://github.com/nunit/nunit/issues/3547) `DelayedConstraint` constrains does not preserve original result
  additional information
* [3551](https://github.com/nunit/nunit/issues/3551) Add `PrivateAssets="all"` to analyzer dependency
* [3552](https://github.com/nunit/nunit/issues/3552) `MessagePumpStrategy` does not work for WPF on netcoreapp3.0 and
  upwards
* [3559](https://github.com/nunit/nunit/issues/3559) Disables the DOC100 suggestion and reverts the added paragraph
  elements
* [3563](https://github.com/nunit/nunit/issues/3563) Improve `TextMessageWriter` output for numeric values
* [3565](https://github.com/nunit/nunit/issues/3565) .NET 5 issue with `PlatformAttribute`
* [3583](https://github.com/nunit/nunit/issues/3583) Avoid using a culture-sensitive `EndsWith` in common code
* [3592](https://github.com/nunit/nunit/issues/3592) Add classname and methodname to the start-test event
* [3594](https://github.com/nunit/nunit/issues/3594) Reduce memory overhead of `TestNameGenerator`
* [3596](https://github.com/nunit/nunit/issues/3596) `AreAlmostEqualUlps` throws `OverflowException` for `-0`
* [3598](https://github.com/nunit/nunit/issues/3598) Fix typo
* [3608](https://github.com/nunit/nunit/issues/3608) `[Platform]` attribute fails with `DllNotFoundException` in WASM
* [3616](https://github.com/nunit/nunit/issues/3616) Extend `Is.Empty` to work for `Guid.Empty`
* [3618](https://github.com/nunit/nunit/issues/3618) NUnit has a P/Invoke whose native function doesn't exist on all
  platforms
* [3622](https://github.com/nunit/nunit/issues/3622) `EmptyDirectoryConstraint` doesn't need to enumerate entire
  directory contents
* [3632](https://github.com/nunit/nunit/issues/3632) `Assert.Inconclusive()` reports failed when timeout used
* [3636](https://github.com/nunit/nunit/issues/3636) NUnitLite filtering fails if space in test name before (
* [3641](https://github.com/nunit/nunit/issues/3641) Type implementing `IComparable<float>` (or any `IComparable`) fails
  comparison.
* [3647](https://github.com/nunit/nunit/issues/3647) Fix exception under Blazor 5
* [3650](https://github.com/nunit/nunit/issues/3650) Build issue with the latest .NET SDK 5.0.100-rc.2
* [3657](https://github.com/nunit/nunit/issues/3657) Add Framework Version to the XML
* [3662](https://github.com/nunit/nunit/issues/3662) `TestContext.CurrentContext.CurrentRepeatCount` only contains retry
  count not the repeat count
* [3667](https://github.com/nunit/nunit/issues/3667) Create FrameworkPackageSetting to set `CurrentCulture` and
  `CurrentUICulture`
* [3676](https://github.com/nunit/nunit/issues/3676) `Parallelizeable` tests sometimes shares memory
* [3679](https://github.com/nunit/nunit/issues/3679) Issue 3390: Do not prefilter relevant `SetUpFixtures`
* [3694](https://github.com/nunit/nunit/issues/3694) Async tests causes double failure messages
* [3699](https://github.com/nunit/nunit/issues/3699) Compilation of netcoreapp3.1 targets fails on CI (both AppVeyor and
  Azure Pipelines)

## NUnit 3.12 - May 14, 2019

This release of NUnit finally drops support for .NET 2.0. If your application still targets .NET 2.0, your tests will
need to target at least .NET 3.5. Microsoft ended support for .NET 2.0 on July 12, 2011. Microsoft recommends that
everyone migrate to at least .NET Framework 3.5 SP1 for security and performance fixes.

This release dramatically improves NUnit support for async tests including returning ValueTask and custom tasks from
tests, improved handling of SynchronizationContexts and better exception handling.

The .NET Standard 2.0 version of NUnit continues to gain more functionality that is found in the .NET 4.5 version of the
framework like setting the ApartmentState and enabling Timeout on tests.

### Issues Resolved

* [474](https://github.com/nunit/nunit/issues/474) TypeHelperTests.cs is orphaned
* [999](https://github.com/nunit/nunit/issues/999) Support multiple TestOf attributes per test
* [1638](https://github.com/nunit/nunit/issues/1638) TimeoutAttribute not available when targeting netcoreapp framework
* [2168](https://github.com/nunit/nunit/issues/2168) ThrowsAsync reports OperationCanceledException as
  TaskCanceledException
* [2194](https://github.com/nunit/nunit/issues/2194) How to use `Contains.Substring` with `And`
* [2286](https://github.com/nunit/nunit/issues/2286) Add support for custom Task (i.e. ValueTask)
* [2579](https://github.com/nunit/nunit/issues/2579) AppVeyor Test Failures under .NET 3.5
* [2614](https://github.com/nunit/nunit/issues/2614) TestExecutionContext.CurrentContext is saved in Remoting
  CallContext between test runs
* [2696](https://github.com/nunit/nunit/issues/2696) Getting WorkerId fails in debug
* [2772](https://github.com/nunit/nunit/issues/2772) Random failing of parallel test run: Unhandled Exception:
  System.InvalidOperationException: Stack empty.
* [2975](https://github.com/nunit/nunit/issues/2975) ComparisonConstraints are allocating string on construction
* [3014](https://github.com/nunit/nunit/issues/3014) Timeout failures on MacOS
* [3023](https://github.com/nunit/nunit/issues/3023) NUnit runner fails when test method returns ValueTask<>
* [3035](https://github.com/nunit/nunit/issues/3035) Apartment state can't be used for .NET Standard 2.0 tests
* [3036](https://github.com/nunit/nunit/issues/3036) Apartment state can't be used for .NET Standard 2.0 tests
* [3038](https://github.com/nunit/nunit/issues/3038) TestName in TestCase attribute not validated to be not empty
* [3042](https://github.com/nunit/nunit/issues/3042) RequiresThreadAttribute allows ApartmentState.Unknown, unlike
  ApartmentAttribute
* [3048](https://github.com/nunit/nunit/issues/3048) Add .idea folder to .gitignore
* [3053](https://github.com/nunit/nunit/issues/3053) Conversion from TestCase string parameter to DateTimeOffset
* [3059](https://github.com/nunit/nunit/issues/3059) Constraint Throws.Exception does not work with async return value
* [3068](https://github.com/nunit/nunit/issues/3068) First Chance Exception in RuntimeFramework
* [3070](https://github.com/nunit/nunit/issues/3070) End support for .NET Framework 2.0 (released in 2005)
* [3073](https://github.com/nunit/nunit/issues/3073) CollectionAssert.AreEquivalent fails for ValueTuple Wrapped
  Dictionary
* [3079](https://github.com/nunit/nunit/issues/3079) Regression from 3.10 to 3.11: Range in bytes
* [3082](https://github.com/nunit/nunit/issues/3082) Is.Ordered.By
* [3085](https://github.com/nunit/nunit/issues/3085) XML Test-Suite Assembly does not contain DLL path anymore
* [3089](https://github.com/nunit/nunit/issues/3089) Remove outdated comment
* [3093](https://github.com/nunit/nunit/issues/3093) Tests having TaskLike objects as their return type throws Exception
* [3094](https://github.com/nunit/nunit/issues/3094) Bad error message if collections have different types
* [3104](https://github.com/nunit/nunit/issues/3104) Removed NET20 compile output
* [3105](https://github.com/nunit/nunit/issues/3105) Add tests for use of ApartmentState.Unknown in
  RequiresThreadAttribute
* [3107](https://github.com/nunit/nunit/issues/3107) Declare class in Program.cs provided with NUnitLite Nuget package
  static
* [3109](https://github.com/nunit/nunit/issues/3109) Azure DevOps build fails in Save package artifacts
* [3124](https://github.com/nunit/nunit/issues/3124) Switch copyright notice
* [3128](https://github.com/nunit/nunit/issues/3128) Correct documentation on ParallelScope
* [3137](https://github.com/nunit/nunit/issues/3137) Fix doc-comments in NUnitTestAssemblyRunner
* [3138](https://github.com/nunit/nunit/issues/3138) Assert.Ignore breaks when a Task is returned w/o using async/await
* [3139](https://github.com/nunit/nunit/issues/3139)  Add Azure pipelines badge to front page
* [3144](https://github.com/nunit/nunit/issues/3144) Retry attribute should not derive from PropertyAttribute
* [3145](https://github.com/nunit/nunit/issues/3145) Capture additional exception details in the test output
* [3156](https://github.com/nunit/nunit/issues/3156) UnexpectedExceptionTests should tolerate Mono on Azure DevOps
  Ubuntu
* [3159](https://github.com/nunit/nunit/issues/3159) Make tests more tolerant
* [3161](https://github.com/nunit/nunit/issues/3161) https url repo
* [3166](https://github.com/nunit/nunit/issues/3166) Allow static SetUpFixture classes
* [3171](https://github.com/nunit/nunit/issues/3171) Incorrect type for Test Fixtures when using running explore with a
  filter
* [3175](https://github.com/nunit/nunit/issues/3175) Improve user-facing messages
* [3181](https://github.com/nunit/nunit/issues/3181) Template Based Test Naming - Incorrect truncation for individual
  arguments
* [3186](https://github.com/nunit/nunit/issues/3186) Fix licenseUrl element in nuspec, will be deprecated
* [3193](https://github.com/nunit/nunit/issues/3193) Cake Build Fails with Visual Studio 2019
* [3195](https://github.com/nunit/nunit/issues/3195) Drop or at least make Travis not required?
* [3231](https://github.com/nunit/nunit/issues/3231) Breaking change in filter functionality between framework 2.7 and
  3.11
* [3209](https://github.com/nunit/nunit/issues/3209) Test fail when posting to SynchronizationContext.Current
* [3211](https://github.com/nunit/nunit/issues/3211) Fix logging
* [3218](https://github.com/nunit/nunit/issues/3218) Remove to-dos from the code base
* [3222](https://github.com/nunit/nunit/issues/3222) Our build script tests hang when run with Mono on Windows
* [3233](https://github.com/nunit/nunit/issues/3233) AndConstraint should write additional information from failed
  constraint

## NUnit 3.11 - October 6, 2018

* More informative assertion messages
* PlatformAttribute is available on and now detects .NET Core
* ValuesAttribute now works with nullable types
* Async tests detecting and running Windows Forms or WPF message pumps rather than deadlocking
* Support for UWP 10.0 is back via .NET Standard 1.4

### Issues Resolved

* [352](https://github.com/nunit/nunit/issues/352) Test with infinite loop in TearDown cannot be aborted
* [452](https://github.com/nunit/nunit/issues/452) Deprecate the existing Chocolatey framework package
* [660](https://github.com/nunit/nunit/issues/660) Order dependence of And and Or constraints should be documented
* [1200](https://github.com/nunit/nunit/issues/1200) async test + Apartment(ApartmentState.STA) => await not returning
  on STA thread
* [2123](https://github.com/nunit/nunit/issues/2123) Task.Run inside a test will result in deadlock if a control was
  created previously
* [2146](https://github.com/nunit/nunit/issues/2146) Assert.That with a Throws constraint does not provide as much info
  as Assert.Throws
* [2427](https://github.com/nunit/nunit/issues/2427) PropertyConstraint throws away the more helpful message in the base
  constraint result
* [2432](https://github.com/nunit/nunit/issues/2432) Ability to exclude/include the platform .NET Core
* [2450](https://github.com/nunit/nunit/issues/2450) NullReferenceException in ExceptionHelper.BuildMessage on Mono
* [2536](https://github.com/nunit/nunit/issues/2536) SetArgDisplayNames for TestCaseData and TestFixtureData
* [2611](https://github.com/nunit/nunit/issues/2611) Enable .NET Standard 1.6 tests on non-Windows
* [2693](https://github.com/nunit/nunit/issues/2693) Ensure that ReSharper settings are consistent with the editorconfig
  configuration
* [2757](https://github.com/nunit/nunit/issues/2757) Broken `char` comparison in v3.7 and higher
* [2759](https://github.com/nunit/nunit/issues/2759) Test fails with "No arguments were provided" error when no values
  returned from IParameterDataSource
* [2761](https://github.com/nunit/nunit/issues/2761) Infinite loop in nunit 3.9
* [2781](https://github.com/nunit/nunit/issues/2781) Fixed pre-compiler typo
* [2786](https://github.com/nunit/nunit/issues/2786) Timeout value not resetting on Retry of failed test
* [2790](https://github.com/nunit/nunit/issues/2790) Removing ITypeInfo abstraction
* [2798](https://github.com/nunit/nunit/issues/2798) [Request] Show actual count value when test fail on
  Has.Exactly(x).Items
* [2814](https://github.com/nunit/nunit/issues/2814) Remove public marker types
* [2819](https://github.com/nunit/nunit/issues/2819) Only run AppVeyor PR build against open PRs
* [2821](https://github.com/nunit/nunit/issues/2821) Save and restore the SynchronizationContext before and after each
  test case
* [2823](https://github.com/nunit/nunit/issues/2823) SetUp failed for test fixture - Array was not a one-dimensional
  array.  Issue seems related to byte[,] method parameters
* [2829](https://github.com/nunit/nunit/issues/2829) Obsoletion warning for DataAttribute
* [2831](https://github.com/nunit/nunit/issues/2831) Regular "BusyExecIdle after 200 milliseconds delay" CI failures
* [2833](https://github.com/nunit/nunit/issues/2833)  Use longer BusyExecIdle to avoid CI failures
* [2836](https://github.com/nunit/nunit/issues/2836) NUnit.Framework.Does cannot be extended
* [2837](https://github.com/nunit/nunit/issues/2837) DictionaryContainsKeyConstraint behavior is inconstant with
  Dictionary.ContainsKey when the dictionary uses a custom Comparer
* [2842](https://github.com/nunit/nunit/issues/2842) Supporting inheritance of Assert and related classes
* [2854](https://github.com/nunit/nunit/issues/2854) Has.All.../Has.None... - show non-matching items in error message
* [2863](https://github.com/nunit/nunit/issues/2863) Make tests robust without depending on the order of attributes
* [2867](https://github.com/nunit/nunit/issues/2867) Skip executing TestCaseSources for tests which are not included in
  the filter
* [2876](https://github.com/nunit/nunit/issues/2876) Implement Discovery-time filtering for NUnitLite
* [2883](https://github.com/nunit/nunit/issues/2883) Our public ConcurrentQueue causes type conflicts
* [2885](https://github.com/nunit/nunit/issues/2885) Copy/paste error in Assert.That documentation
* [2887](https://github.com/nunit/nunit/issues/2887) NETStandard 1.3 support dropped in NUnit 3.10
* [2896](https://github.com/nunit/nunit/issues/2896) Some tests are silently skipped on netstandard1.x since #2796
* [2898](https://github.com/nunit/nunit/issues/2898) AssemblyPath contains invalid characters
* [2901](https://github.com/nunit/nunit/issues/2901) Values attribute support for nullable bool and enum types
* [2923](https://github.com/nunit/nunit/issues/2923) Update outdated CategoryAttribute xml doc
* [2928](https://github.com/nunit/nunit/issues/2928) Improve error message on EmptyConstraint
* [2929](https://github.com/nunit/nunit/issues/2929) Added NUnit XML schemas
* [2940](https://github.com/nunit/nunit/issues/2940) Increase StackTracesAreFiltered amount to 5
* [2955](https://github.com/nunit/nunit/issues/2955) Potential threading issue in IsolatedContext
* [2965](https://github.com/nunit/nunit/issues/2965) NuGet Package : Add `repository` metadata.
* [2970](https://github.com/nunit/nunit/issues/2970) InvalidCastException @
  NUnit.Framework.TestFixtureSourceAttribute.BuildFrom
* [2979](https://github.com/nunit/nunit/issues/2979) Warn.If in Assert.Multiple
* [2994](https://github.com/nunit/nunit/issues/2994) Error in .NET Standard 1.4 DictionaryContainsKeyConstraint
  MetadataToken compatibility methods
* [2996](https://github.com/nunit/nunit/issues/2996) Remove unused enum
* [3009](https://github.com/nunit/nunit/issues/3009) Fix failing CI Builds by upgrading to NUnit Console 3.9.0
* [3020](https://github.com/nunit/nunit/issues/3020) Upgrade nunit-vs-adapter to 3.10 for nUnit 3.11
* [3024](https://github.com/nunit/nunit/issues/3024) Unable to add `.IgnoreCase` modifier to an `AnyOf` constraint in
  collection constraints
* [3032](https://github.com/nunit/nunit/issues/3032) APIs to restore before 3.11

## NUnit 3.10.1 - March 12, 2018

Added a namespace to the props file included in the NuGet package to make it compatible with versions of Visual Studio
prior to VS 2017.

## NUnit 3.10 - March 12, 2018

This release adds a .NET Standard 2.0 version of the framework which re-enables most of the features that have been
missing in our earlier .NET Standard builds like parallelism, timeouts, directory and path based asserts, etc. It also
contains numerous bug fixes and smaller enhancements. We've improved our XML docs, fixed performance issues and added
more detail to Multiple Asserts.

This release also contains source-indexed PDB files allowing developers to debug into the NUnit Framework. This allows
you to track down errors or see how the framework works.

In order to support the .NET Standard 2.0 version, the NUnit project switched to the new CSPROJ format and now requires
Visual Studio 2017 to compile. This only effects people contributing to the project. NUnit still supports building and
compiling your tests in older .NET IDEs and NUnit still supports older versions of the .NET Framework back to 2.0. For
contributors, NUnit can now compile all supported targets on Windows, Linux and Mac using the Cake command line build.

### Issues Resolved

* [1212](https://github.com/nunit/nunit/issues/1212) Separate AssertionHelper project or assembly
* [1373](https://github.com/nunit/nunit/issues/1373) Setting with a null value
* [1382](https://github.com/nunit/nunit/issues/1382) Use array argument contents in name of parameterized tests rather
  than just array type.
* [1578](https://github.com/nunit/nunit/issues/1578) TestContext.CurrentTest exposes too much internal info
* [1678](https://github.com/nunit/nunit/issues/1678) Result Message: OneTimeSetUp: Category name must not contain ',',
  '!', '+' or '-'
* [1944](https://github.com/nunit/nunit/issues/1944) Removing Compact Framework workarounds
* [1958](https://github.com/nunit/nunit/issues/1958) System.Reflection.TargetInvocationException after run finished
* [2033](https://github.com/nunit/nunit/issues/2033) Nameof refactor
* [2202](https://github.com/nunit/nunit/issues/2202) Best practices for XML doc comments
* [2325](https://github.com/nunit/nunit/issues/2325) Retry attribute doesn't retry the test.
* [2331](https://github.com/nunit/nunit/issues/2331) Repo does not build in VS without running `build -t build` first
* [2405](https://github.com/nunit/nunit/issues/2405) Improve PropertyConstraint error output
* [2421](https://github.com/nunit/nunit/issues/2421) Publishing symbols with releases
* [2494](https://github.com/nunit/nunit/issues/2494) CollectionAssert.AllItemsAreUnique() very slow
* [2515](https://github.com/nunit/nunit/issues/2515) Re-target Solution to use the New CSPROJ Format
* [2518](https://github.com/nunit/nunit/issues/2518) Bug in CollectionAssert.AreEqual for ValueTuples.
* [2530](https://github.com/nunit/nunit/issues/2530) Running tests on main thread. Revisiting #2483
* [2542](https://github.com/nunit/nunit/issues/2542) NUnit does not support parallelism on .NET Core 2.0
* [2555](https://github.com/nunit/nunit/issues/2555) CI timeout:
  NUnit.Framework.Assertions.CollectionAssertTest.PerformanceTests
* [2564](https://github.com/nunit/nunit/issues/2564) Add minClientVersion to .nuspec files
* [2566](https://github.com/nunit/nunit/issues/2566) Refactor `SimpleEnumerableWithIEquatable` test object
* [2577](https://github.com/nunit/nunit/issues/2577) Warning in TearDown is inconsistent with Assertion failure
* [2580](https://github.com/nunit/nunit/issues/2580) Remove unused defines
* [2591](https://github.com/nunit/nunit/issues/2591) NUnitEqualityComparer.Default should be replaced with new
  NUnitEqualityComparer()
* [2592](https://github.com/nunit/nunit/issues/2592) Add .props with ProjectCapability to suppress test project service
  GUID item
* [2608](https://github.com/nunit/nunit/issues/2608) Culture differences on .NET Core on non-Windows causes test
  failures
* [2622](https://github.com/nunit/nunit/issues/2622) Fix flakey test
* [2624](https://github.com/nunit/nunit/issues/2624) Prevent emails for successful builds on Travis
* [2626](https://github.com/nunit/nunit/issues/2626) SetUp/TearDown methods are invoked multiple times before/after test
  in .NET Standard targeted projects
* [2627](https://github.com/nunit/nunit/issues/2627) Breaking change in CollectionAssert.AllItemsAreUnique with NUnit
  3.9
* [2628](https://github.com/nunit/nunit/issues/2628) Error during installing tools when running build script
* [2630](https://github.com/nunit/nunit/issues/2630) Framework throws NullReferenceException if test parameter is marked
  with [Values(null)]
* [2632](https://github.com/nunit/nunit/issues/2632) Parallel tests are loading 100% CPU when nested SetUpFixture exists
* [2639](https://github.com/nunit/nunit/issues/2639) ValuesAttribute causes ExpectedResult to have no effect
* [2647](https://github.com/nunit/nunit/issues/2647) Add Current Attempt indicator in TestContext for use with
  RetryAttribute
* [2654](https://github.com/nunit/nunit/issues/2654) Address feedback from `@oznetmaster`
* [2656](https://github.com/nunit/nunit/issues/2656) NuGet package links to outdated license
* [2659](https://github.com/nunit/nunit/issues/2659) Naming Errors
* [2662](https://github.com/nunit/nunit/issues/2662) NullReferenceException after parallel tests have finished executing
* [2663](https://github.com/nunit/nunit/issues/2663) Building NUnit .NET 4.5 in VS2017 fails
* [2669](https://github.com/nunit/nunit/issues/2669) Removed vestigial build script helper method
* [2670](https://github.com/nunit/nunit/issues/2670) Invalid assemblies no longer give an error message
* [2671](https://github.com/nunit/nunit/issues/2671) Ensure that FailureSite.Child is used where appropriate.
* [2685](https://github.com/nunit/nunit/issues/2685) Remove Rebracer file
* [2688](https://github.com/nunit/nunit/issues/2688) Assert.Throws swallows console output
* [2695](https://github.com/nunit/nunit/issues/2695) MultipleAssertException doesn't provide proper details on failures
* [2698](https://github.com/nunit/nunit/issues/2698) Syntax suggestions errors as warnings
* [2704](https://github.com/nunit/nunit/issues/2704) Add Constraint to test whether actual item is contained in expected
  collection
* [2711](https://github.com/nunit/nunit/issues/2711) NUnitLite: Add support for `--nocolor` option
* [2714](https://github.com/nunit/nunit/issues/2714) AnyOfConstraint enumerates multiple times
* [2725](https://github.com/nunit/nunit/issues/2725) Enable 'strict' compilation flag
* [2726](https://github.com/nunit/nunit/issues/2726) Replace the ConcurrentQueue and SpinWait compatibility classes
* [2727](https://github.com/nunit/nunit/issues/2727) Avoid treating warnings as errors inside the IDE
* [2734](https://github.com/nunit/nunit/issues/2734) TestCaseAttribute: ExpectedResult should support same value
  conversion as normal method arguments
* [2742](https://github.com/nunit/nunit/issues/2742) FailureSite not correctly set on containing suites when tests are
  ignored.
* [2749](https://github.com/nunit/nunit/issues/2749) Update Travis SDK versions

## NUnit 3.9 - November 10, 2017

This release addresses numerous parallelization issues that were introduced in 3.8 when method level parallelization was
added. Most of the parallelization issues resolved were tests never completing when using some combinations of parallel
tests and `ApartmentState` not being properly applied to tests in all cases.

### Issues Resolved

* [893](https://github.com/nunit/nunit/issues/893) Inconsistent Tuple behavior.
* [1239](https://github.com/nunit/nunit/issues/1239) NUnit3 sometimes hangs if SetUpFixtures are run in parallel
* [1346](https://github.com/nunit/nunit/issues/1346) NullReferenceException when [TestFixtureSource] refers to data in a
  generic class.
* [1473](https://github.com/nunit/nunit/issues/1473) Allow Is.Ordered to Compare Null Values
* [1899](https://github.com/nunit/nunit/issues/1899) Constraint Throws.Exception does not catch exception with async
  lambdas
* [1905](https://github.com/nunit/nunit/issues/1905) SetupFixture without namespace will make assembly-level
  Parallelizable attribute useless
* [2091](https://github.com/nunit/nunit/issues/2091) When a native exception of corrupted state is thrown, nunit test
  thread crashes and the nunit-console process hangs
* [2102](https://github.com/nunit/nunit/issues/2102) NUnitLite incorrectly reports Win 10 OS name
* [2271](https://github.com/nunit/nunit/issues/2271) When CollectionAssert.AreEqual do compare each element, it will
  ignore the IEquatable of the element too
* [2289](https://github.com/nunit/nunit/issues/2289) ResolveTypeNameDifference does not handle generic types well
* [2311](https://github.com/nunit/nunit/issues/2311) Resolve test projects' namespace situation
* [2319](https://github.com/nunit/nunit/issues/2319) Add .editorconfig to set file encodings so that people don't have
  to think about it
* [2364](https://github.com/nunit/nunit/issues/2364) Parallelizable attribute not invalidating invalid parallel scope
  combinations
* [2372](https://github.com/nunit/nunit/issues/2372) Create testing for compounded ConstraintFilters
* [2388](https://github.com/nunit/nunit/issues/2388) Parallelization causes test cases to stop respecting fixture's
  apartment state
* [2395](https://github.com/nunit/nunit/issues/2395) NUnit 3.8+ does not finish running tests
* [2398](https://github.com/nunit/nunit/issues/2398) NUnit CI spurious failures,
  NUnit.Framework.Internal.ThreadUtilityTests.Kill
* [2402](https://github.com/nunit/nunit/issues/2402) --labels=All doesn't show anything in console output executing
  NUnitLite Console Runner
* [2406](https://github.com/nunit/nunit/issues/2406) Summary descriptions replaced by more detailed ones
* [2411](https://github.com/nunit/nunit/issues/2411) And constraint on Has.Member throws
* [2412](https://github.com/nunit/nunit/issues/2412) Using fluent syntax unintentionally removed in 3.8
* [2418](https://github.com/nunit/nunit/issues/2418) Support equality comparison delegate
* [2422](https://github.com/nunit/nunit/issues/2422) Has.Property causes AmbiguousMatchException for shadowing
  properties
* [2425](https://github.com/nunit/nunit/issues/2425) XML doc typo fix
* [2426](https://github.com/nunit/nunit/issues/2426) Regression in 3.8.1: ApartmentAttribute no longer works when
  applied to an assembly
* [2428](https://github.com/nunit/nunit/issues/2428) Fix NullReferenceExceptions caused by WorkItemQueue not being
  thread-safe
* [2429](https://github.com/nunit/nunit/issues/2429) Stack trace shown for Assert.Warn
* [2438](https://github.com/nunit/nunit/issues/2438) [Parallelizable] hangs after a few tests
* [2441](https://github.com/nunit/nunit/issues/2441) Allows to override load-time/execution-time interfaces in built-in
  tests attributes
* [2446](https://github.com/nunit/nunit/issues/2446) CI failure in mono Warning tests
* [2448](https://github.com/nunit/nunit/issues/2448) Inherited Test SetUp, TearDown, etc. are not executed in .NET Core
  if they are not public
* [2451](https://github.com/nunit/nunit/issues/2451) Compile RegEx to improve performance
* [2454](https://github.com/nunit/nunit/issues/2454) SetUpFixture not respecting NonParallelizable tag on TestFixtures.
* [2459](https://github.com/nunit/nunit/issues/2459) [Parallelizable(ParallelScope.Children)] Unable to finish tests
* [2465](https://github.com/nunit/nunit/issues/2465) Possible wrong properties are returned by reflection in
  ReflectionExtensions.cs
* [2467](https://github.com/nunit/nunit/issues/2467) Test execution hangs when using [SetUpFixture] with NUnit 3.8.x
* [2469](https://github.com/nunit/nunit/issues/2469) Allow RangeAttribute to be specified multiple times for the same
  argument
* [2471](https://github.com/nunit/nunit/issues/2471) Parametrized test cases not running in parallel
* [2475](https://github.com/nunit/nunit/issues/2475) Framework incorrectly identifies Win 10 in xml results
* [2478](https://github.com/nunit/nunit/issues/2478) Attributes on SetUpFixture are not applied
* [2486](https://github.com/nunit/nunit/issues/2486) Message when asserting null with Is.EquivalentTo could be more
  helpful
* [2497](https://github.com/nunit/nunit/issues/2497) Use ConstraintUtils.RequireActual through out the codebase
* [2504](https://github.com/nunit/nunit/issues/2504) Support changing test display name on TestFixtureData
* [2508](https://github.com/nunit/nunit/issues/2508) Correct divergence from shadowed Is / Has members.
* [2516](https://github.com/nunit/nunit/issues/2516) When test writes something to the stdErr there is no guaranteed way
  to link a test-output event to a target test using ITestEventListener
* [2525](https://github.com/nunit/nunit/issues/2525) Remove unwanted space from comment
* [2526](https://github.com/nunit/nunit/issues/2526) SerializationException in low trust floating point equality test
* [2533](https://github.com/nunit/nunit/issues/2533) Matches`<T>(Predicate<T>)` throws ArgumentException or Fails when
  actual is null
* [2534](https://github.com/nunit/nunit/issues/2534) SetUpFixture causes NUnit to lock with Apartment( STA )
* [2551](https://github.com/nunit/nunit/issues/2551) CollectionItemsEqualConstraint is missing Using(Func<T, T, bool>)
* [2554](https://github.com/nunit/nunit/issues/2554) Made TestFixtureData.SetName internal for 3.9

## NUnit 3.8.1 - August 28, 2017

This release fixes two critical regressions in the 3.8 release. The first caused the console runner to crash if you are
using test parameters. The second issue caused collection constraints checking for multiple items in a collection to
fail.

### Issues Resolved

* [2386](https://github.com/nunit/nunit/issues/2386) Contains.Item() fails for collections in NUnit 3.8
* [2390](https://github.com/nunit/nunit/issues/2390) Missing value attribute in test parameters setting causes
  NullReferenceException in console

## NUnit 3.8 - August 27, 2017

This release removes several methods and attributes that were marked obsolete in the original 3.0 release. Support for
iOS and Android has been improved.

An issue that caused unit tests to run slower was addressed as was a bug that prevented the use of Assert.Multiple in
async code.

The Order attribute can now also be applied to the class level to set the order that test fixtures will be run.

### Issues Resolved

* [345](https://github.com/nunit/nunit/issues/345) Order of Fixture Execution
* [1151](https://github.com/nunit/nunit/issues/1151) Include differences in output for Is.EquivalentTo
* [1324](https://github.com/nunit/nunit/issues/1324) Remove CollectionContainsConstraint
* [1670](https://github.com/nunit/nunit/issues/1670) Attaching files to the test result
* [1674](https://github.com/nunit/nunit/issues/1674) InRange-Constraint must work with object
* [1851](https://github.com/nunit/nunit/issues/1851) TestCaseSource unable to pass one element byte array
* [1996](https://github.com/nunit/nunit/issues/1996) Timeout does not work if native code is running at the time
* [2004](https://github.com/nunit/nunit/issues/2004) Has.One as synonym for Has.Exactly(1).Items
* [2062](https://github.com/nunit/nunit/issues/2062) TestCaseSource attribute causes test to pass when source is not
  defined
* [2144](https://github.com/nunit/nunit/issues/2144) Allow option on RandomAttribute to produce distinct values
* [2179](https://github.com/nunit/nunit/issues/2179) Some NUnit project's tests fail on systems with CultureInfo other
  than en
* [2195](https://github.com/nunit/nunit/issues/2195) Contains.Substring with custom StringComparison
* [2196](https://github.com/nunit/nunit/issues/2196) Expose ParallelizableAttribute (and other attribute) constructor
  arguments as properties
* [2201](https://github.com/nunit/nunit/issues/2201) Invalid platform name passed to PlatformAttribute should mark test
  NotRunnable
* [2208](https://github.com/nunit/nunit/issues/2208) StackFilter trims leading spaces from each line
* [2213](https://github.com/nunit/nunit/issues/2213) SetCultureAttribute: CultureInfo ctor should use default culture
  settings
* [2217](https://github.com/nunit/nunit/issues/2217) Console runner performance varies wildly depending on environmental
  characteristics
* [2219](https://github.com/nunit/nunit/issues/2219) Remove Obsolete Attributes
* [2225](https://github.com/nunit/nunit/issues/2225) OneTimeTearDown and Dispose Ordering
* [2237](https://github.com/nunit/nunit/issues/2237) System.Runtime.Loader not available for iOS/Android
* [2242](https://github.com/nunit/nunit/issues/2242) Running tests directly should never surface a
  NullReferenceException
* [2244](https://github.com/nunit/nunit/issues/2244) Add KeyValuePair<TKey, TValue> to the default formatters
* [2251](https://github.com/nunit/nunit/issues/2251) Randomizer.NextGuid()
* [2253](https://github.com/nunit/nunit/issues/2253) Parallelizable(ParallelScope.Fixtures) doesn't work on a
  TestFixture
* [2254](https://github.com/nunit/nunit/issues/2254) EqualTo on ValueTuple with Nullable unexpected
* [2261](https://github.com/nunit/nunit/issues/2261) When an assembly is marked with ParallelScope.None and there are
  Parallelizable tests NUnit hangs
* [2269](https://github.com/nunit/nunit/issues/2269) Parallelizable and NonParallelizable attributes on setup and
  teardown silently ignored
* [2276](https://github.com/nunit/nunit/issues/2276) Intermittent test failures in Travis CI: TestContextTests
* [2281](https://github.com/nunit/nunit/issues/2281) Add type constraint for Throws and any method requiring Exception
* [2288](https://github.com/nunit/nunit/issues/2288) Killing thread cancels test run
* [2292](https://github.com/nunit/nunit/issues/2292) Is.Ordered.By() with a field throws NullReferenceException
* [2298](https://github.com/nunit/nunit/issues/2298) Write TestParametersDictionary to xml result file in readable
  format
* [2299](https://github.com/nunit/nunit/issues/2299) NUnitLite NuGet package no longer installs NUnit NuGet package
* [2304](https://github.com/nunit/nunit/issues/2304) Revert accidental doc removal
* [2305](https://github.com/nunit/nunit/issues/2305) Correct misprint ".con" -> ".com"
* [2312](https://github.com/nunit/nunit/issues/2312) Prevent crash on invalid --result parsing in NUnitLite
* [2313](https://github.com/nunit/nunit/issues/2313) Incorrect xml doc on RetryAttribute
* [2332](https://github.com/nunit/nunit/issues/2332) Update build script to use NUnitConsoleRunner v3.7.0
* [2335](https://github.com/nunit/nunit/issues/2335) Execute OneTimeTearDown as early as possible when running fixtures
  in parallel
* [2342](https://github.com/nunit/nunit/issues/2342) Remove deprecated Is.String* Constraints
* [2348](https://github.com/nunit/nunit/issues/2348) Can't use Assert.Multiple with async code
* [2353](https://github.com/nunit/nunit/issues/2353) Provide additional Result information through TestContext
* [2358](https://github.com/nunit/nunit/issues/2358) Get framework to build under Mono 5.0
* [2360](https://github.com/nunit/nunit/issues/2360) Obsolete CollectionContainsConstraint Constructors
* [2361](https://github.com/nunit/nunit/issues/2361) NUnit Parallelizable and OneTimeSetUp with no namespace results in
  single-threaded test execution
* [2370](https://github.com/nunit/nunit/issues/2370) TestCaseAttribute can't convert int to nullable long

## NUnit 3.7.1 - June 6, 2017

This is a hotfix release that addresses occasional hangs when using test parallelization and fixes crashes in NCrunch
prior to version 3.9.

### Issues Resolved

* 2205 NCrunch: System.Xml.XmlException: Root element is missing, when adding NUnit 3.7.0
* 2209 NUnit occasionally hangs when parallelizable TestFixture has OneTimeSetUp and OneTimeTearDown

## NUnit 3.7 - May 29, 2017

This release of NUnit expands on parallel test execution to allow test methods to be run in parallel. Please see the
[Parallelizable Attribute](xref:parallelizableattribute) for more information.

NUnit 3.7 also drops the Portable build of the framework and replaces it with a .NET Standard 1.3 version to compliment
the .NET Standard 1.6 version. This change enables several constraints and other features in the .NET Standard builds
that weren't available in portable like Path and Directory based asserts.

The AssertionHelper class has been deprecated because it is seldom used and has not received any of the updates that
Asserts and Constraints receive. If your code is using the AssertionHelper class, we recommend that you migrate your
asserts.

### Issues Resolved

* [164](https://github.com/nunit/nunit/issues/164) Run test methods within a fixture in parallel
* [391](https://github.com/nunit/nunit/issues/391) Multiple Assertions
* [652](https://github.com/nunit/nunit/issues/652) Add ability to execute test actions before SetUp or OneTimeSetUp
* [1000](https://github.com/nunit/nunit/issues/1000) Support multiple Author attributes per test
* [1096](https://github.com/nunit/nunit/issues/1096) Treat OneTimeSetup and OneTimeTearDown as separate work items
* [1143](https://github.com/nunit/nunit/issues/1143) NUnitLite - Explore flag does not apply where filter to output
* [1238](https://github.com/nunit/nunit/issues/1238) Feature request: Print LoaderExceptions when fixture loading fails
* [1363](https://github.com/nunit/nunit/issues/1363) Make Timeouts work without running test on its own thread
* [1474](https://github.com/nunit/nunit/issues/1474) Several SetUpFixtures at the same level may be active at the same
  time
* [1819](https://github.com/nunit/nunit/issues/1819) TestContext.Progress.Write writes new line
* [1830](https://github.com/nunit/nunit/issues/1830) Add --labels switch changes to NUnitLite and NUnitLite tests
* [1859](https://github.com/nunit/nunit/issues/1859) ConcurrentQueue is duplicate with System.Threading.dll package
* [1877](https://github.com/nunit/nunit/issues/1877) Resolve differences between NUnit Console and NUnitLite
  implementations of @filename
* [1885](https://github.com/nunit/nunit/issues/1885) Test parameter containing a semicolon
* [1896](https://github.com/nunit/nunit/issues/1896) Test has passed however Reason with an empty message is printed in
  the xml
* [1918](https://github.com/nunit/nunit/issues/1918) Changing DefaultFloatingPointTolerance breaks tests running in
  parallel
* [1932](https://github.com/nunit/nunit/issues/1932) NUnit Warn class should be removed from stack trace by filter
* [1934](https://github.com/nunit/nunit/issues/1934) NullReferenceException when null arguments are used in
  TestFixtureAttribute
* [1952](https://github.com/nunit/nunit/issues/1952) TestContext.Out null when used in task with .NET Core
* [1963](https://github.com/nunit/nunit/issues/1963) Investigate removing SpecialValue
* [1965](https://github.com/nunit/nunit/issues/1965) TestContext does not flow in async method
* [1971](https://github.com/nunit/nunit/issues/1971) Switch CHANGES.txt to Markdown
* [1973](https://github.com/nunit/nunit/issues/1973) Implemented TestExecutionContext to use AsyncLocal<> for
  `NETSTANDARD1_6`
* [1975](https://github.com/nunit/nunit/issues/1975) TestFixtureSource doesn't work with a class that has no namespace
* [1983](https://github.com/nunit/nunit/issues/1983) Add missing ConstraintExpression.Contain overload
* [1990](https://github.com/nunit/nunit/issues/1990) Add namespace filter
* [1997](https://github.com/nunit/nunit/issues/1997) Remove unused --verbose and --full command line options
* [1999](https://github.com/nunit/nunit/issues/1999) Author Tests assume ICustomAttributeProvider.GetCustomAttributes
  return order is defined
* [2003](https://github.com/nunit/nunit/issues/2003) Better user info about ParallelizableAttribute and ParallelScope
* [2005](https://github.com/nunit/nunit/issues/2005) Exclude empty failure messages from results xml
* [2007](https://github.com/nunit/nunit/issues/2007) 3.6 Multiple assertion backwards compatibility
* [2010](https://github.com/nunit/nunit/issues/2010) Add DelayedConstraint in NetStandard 1.6 build
* [2020](https://github.com/nunit/nunit/issues/2020) Better message when timeout fails
* [2023](https://github.com/nunit/nunit/issues/2023) Ability to abort threads running a message pump
* [2025](https://github.com/nunit/nunit/issues/2025) NullReferenceException using Is.EqualTo on two unequal strings
* [2030](https://github.com/nunit/nunit/issues/2030) Add method to mark tests as invalid with a reason
* [2031](https://github.com/nunit/nunit/issues/2031) Limit Language level to C#6
* [2034](https://github.com/nunit/nunit/issues/2034) Remove SilverLight project - no longer used
* [2035](https://github.com/nunit/nunit/issues/2035) NullReferenceException inside failing Assert.That call
* [2040](https://github.com/nunit/nunit/issues/2040) Cannot catch AssertionException
* [2045](https://github.com/nunit/nunit/issues/2045) NUnitLite-runner crashes if no file is provided
* [2050](https://github.com/nunit/nunit/issues/2050) Creation of TestExecutionContext should be explicit
* [2052](https://github.com/nunit/nunit/issues/2052) NullReferenceException with TestCaseSource if a property has no
  setter
* [2061](https://github.com/nunit/nunit/issues/2061) TestContext.WorkDirectory not initialized during build process
* [2079](https://github.com/nunit/nunit/issues/2079) Make TestMethod.Arguments public or otherwise accessible (e.g.
  TestContext)
* [2080](https://github.com/nunit/nunit/issues/2080) Allow comments in @FILE files
* [2087](https://github.com/nunit/nunit/issues/2087) Enhance error message: Test is not runnable in single-threaded
  context. Timeout
* [2092](https://github.com/nunit/nunit/issues/2092) Convert Portable library to .NET Standard 1.3
* [2095](https://github.com/nunit/nunit/issues/2095) Extend use of tolerance to ComparisonConstraints
* [2099](https://github.com/nunit/nunit/issues/2099) Include type in start-suite/start-test report elements
* [2110](https://github.com/nunit/nunit/issues/2110) NullReferenceException when getting TestDirectory from TestContext
* [2115](https://github.com/nunit/nunit/issues/2115) Mark AssertionHelper as Obsolete
* [2121](https://github.com/nunit/nunit/issues/2121) Chained PropertyConstraint constraints report incorrect ActualValue
* [2131](https://github.com/nunit/nunit/issues/2131) Remove "Version 3" suffix from NUnitLite NuGet Package
* [2132](https://github.com/nunit/nunit/issues/2132)
  TestFixtureTests.CapturesArgumentsForConstructorWithMultipleArgsSupplied assumes order of custom attributes
* [2143](https://github.com/nunit/nunit/issues/2143) Non-parallel fixture with parallel children runs in parallel with
  other fixtures
* [2147](https://github.com/nunit/nunit/issues/2147) Test Assembly using NUnitLite & NUnit 3.6.1 hangs under .NET Core
  when `--timeout` is supplied on command line
* [2150](https://github.com/nunit/nunit/issues/2150) Add portable-slow-tests to Cake file
* [2152](https://github.com/nunit/nunit/issues/2152) Allow attaching files to TestResults
* [2154](https://github.com/nunit/nunit/issues/2154) Fix execution of non-parallel test fixtures
* [2157](https://github.com/nunit/nunit/issues/2157) Getting WorkerId inside Assert.Throws / DoesNotThrow returns null
  instead of previous non-null value
* [2158](https://github.com/nunit/nunit/issues/2158) Update SetupFixtureAttribute XML Docs
* [2159](https://github.com/nunit/nunit/issues/2159) Prevent crash in .NET standard with log file path
* [2165](https://github.com/nunit/nunit/issues/2165) Trying to install NUnit 3.6.1 on .NET Framework asks for download
  of 20 more packages
* [2169](https://github.com/nunit/nunit/issues/2169) Incorrect xml docs for SetUpAttribute
* [2170](https://github.com/nunit/nunit/issues/2170) Cake build fails if only Visual Studio 2017 installed
* [2173](https://github.com/nunit/nunit/issues/2173) Remove PreTestAttribute and PostTestAttribute
* [2186](https://github.com/nunit/nunit/issues/2186) Replace special characters as part of converting branch names to
  package versions
* [2191](https://github.com/nunit/nunit/issues/2191) System.Reflection.TargetInvocationException with nunit3-console
  --debug on Mono

## NUnit 3.6.1 - February 26, 2017

This is a hotfix release of the framework that addresses critical issues found in the 3.6 release.

### Issues Resolved

* [1962](https://github.com/nunit/nunit/issues/1962) A Theory with no data passes
* [1986](https://github.com/nunit/nunit/issues/1986) NUnitLite ignores --workers option
* [1994](https://github.com/nunit/nunit/issues/1994) NUnitLite runner crashing when --trace is specified
* [2017](https://github.com/nunit/nunit/issues/2017) Two NUnit project's tests fail on systems with comma decimal mark
  settings
* [2043](https://github.com/nunit/nunit/issues/2043) Regression in 3.6.0 when catching AssertionException

## NUnit 3.6 - January 9, 2017

This release of the framework no longer includes builds for Compact Framework or for SilverLight, but adds a .NET
Standard 1.6 build. If anyone still using Compact Framework or SilverLight and would like to continue development on
those versions of the framework, please contact the NUnit team.

### Framework

* .NET Standard 1.6 is now supported
* Adds support for Multiple Assert blocks
* Added the --params option to NUnitLite
* Theories now support Nullable enums
* Improved assert error messages to help differentiate differences in values
* Added warnings with Warn.If(), Warn.Unless() and Assert.Warn()
* Enabled Path, File and Directory Asserts/Constraints for .NET Core testing
* Added NonTestAssemblyAttribute for use by third-party developers to indicate that their assemblies reference the NUnit
  framework, but do not contain tests

### Issues Resolved

* [406](https://github.com/nunit/nunit/issues/406) Warning-level Assertions
* [890](https://github.com/nunit/nunit/issues/890) Allow file references anywhere in the command line.
* [1380](https://github.com/nunit/nunit/issues/1380) AppVeyor Failures when branch name is too long
* [1589](https://github.com/nunit/nunit/issues/1589) Split the nunit repository into multiple repositories
* [1599](https://github.com/nunit/nunit/issues/1599) Move Compact Framework to separate project
* [1601](https://github.com/nunit/nunit/issues/1601) Move SilverLight to a separate project
* [1609](https://github.com/nunit/nunit/issues/1609) Upgrade Cake build to latest version
* [1661](https://github.com/nunit/nunit/issues/1661) Create .NET Standard Framework Build
* [1668](https://github.com/nunit/nunit/issues/1668) Need implementation-independent way to test number of items in a
  collection
* [1743](https://github.com/nunit/nunit/issues/1743) Provide multiple results for a test case in the XML output
* [1758](https://github.com/nunit/nunit/issues/1758) No direct inverse for Contains.Key
* [1765](https://github.com/nunit/nunit/issues/1765) TestCaseSourceAttribute constructor for method with parameters
* [1802](https://github.com/nunit/nunit/issues/1802) Design Multiple Assert syntax as seen by users
* [1808](https://github.com/nunit/nunit/issues/1808) Disambiguate error messages from EqualConstraint
* [1811](https://github.com/nunit/nunit/issues/1811) Build.ps1 fails if spaces in path
* [1823](https://github.com/nunit/nunit/issues/1823) Remove engine nuspecs and old global.json
* [1827](https://github.com/nunit/nunit/issues/1827) Remove unused repository paths from repositories.config
* [1828](https://github.com/nunit/nunit/issues/1828) Add Retry for failed tests only
* [1829](https://github.com/nunit/nunit/issues/1829) NUnitLite accepts --params option but does not make any use of it.
* [1836](https://github.com/nunit/nunit/issues/1836) Support nullable enums in Theories
* [1837](https://github.com/nunit/nunit/issues/1837) [Request] AfterConstraint to support more readable usage
* [1840](https://github.com/nunit/nunit/issues/1840) Remove SL and CF #Defined source
* [1866](https://github.com/nunit/nunit/issues/1866) [Request] More readable way to set polling interval in After
  constraint
* [1870](https://github.com/nunit/nunit/issues/1870) EqualConstraint result failure message for DateTime doesn't show
  sufficient resolution
* [1872](https://github.com/nunit/nunit/issues/1872) Parameterized method being called with no parameter
* [1876](https://github.com/nunit/nunit/issues/1876) What should we do about Env.cs
* [1880](https://github.com/nunit/nunit/issues/1880) AttributeUsage for various Attributes
* [1889](https://github.com/nunit/nunit/issues/1889) Modify NUnitLite to display multiple assert information
* [1891](https://github.com/nunit/nunit/issues/1891) TestContext.Progress and TestContext.Error silently drop text that
  is not properly XML encoded
* [1901](https://github.com/nunit/nunit/issues/1901) Make NUnitLite-runner Prefer32Bit option consistent across
  Debug/Release
* [1904](https://github.com/nunit/nunit/issues/1904) Add .NET Standard 1.6 Dependencies to the Nuspec Files
* [1907](https://github.com/nunit/nunit/issues/1907) Handle early termination of multiple assert block
* [1911](https://github.com/nunit/nunit/issues/1911) Changing misleading comment that implies that every
  `ICollection<T>` is a list
* [1912](https://github.com/nunit/nunit/issues/1912) Add new warning status and result state
* [1913](https://github.com/nunit/nunit/issues/1913) Report Warnings in NUnitLite
* [1914](https://github.com/nunit/nunit/issues/1914) Extra AssertionResult entries in TestResults
* [1915](https://github.com/nunit/nunit/issues/1915) Enable Path, File and Directory Assert/Constraints in the .NET
  Standard Build
* [1917](https://github.com/nunit/nunit/issues/1917) Use of IsolatedContext breaks tests in user-created AppDomain
* [1924](https://github.com/nunit/nunit/issues/1924) Run tests using the NUnit Console Runner
* [1929](https://github.com/nunit/nunit/issues/1929) Rename zip and remove source zip
* [1933](https://github.com/nunit/nunit/issues/1933) Tests should pass if test case source provides 0 test cases
* [1941](https://github.com/nunit/nunit/issues/1941) Use dictionary-based property for test run parameters
* [1945](https://github.com/nunit/nunit/issues/1945) Use high-quality icon for nuspecs
* [1947](https://github.com/nunit/nunit/issues/1947) Add NonTestAssemblyAttribute
* [1954](https://github.com/nunit/nunit/issues/1954) Change Error Message for Assert.Equals
* [1960](https://github.com/nunit/nunit/issues/1960) Typo fixes
* [1966](https://github.com/nunit/nunit/issues/1966) Xamarin Runner cannot reference NUnit NuGet Package

## Earlier Releases

* Release Notes for [NUnit 2.9.1 through 3.5](xref:pre35releasenotes)
* Release Notes for [NUnit 2.6 through 2.6.4](https://nunit.org/?p=releaseNotes&r=2.6.4)
* Release Notes for [NUnit 2.5 through 2.5.10](https://nunit.org/?p=releaseNotes&r=2.5.10)
* Release Notes for [NUnit 2.4 through 2.4.8](https://nunit.org/?p=releaseNotes&r=2.4.8)
* Release Notes for [NUnit 2.0 through 2.2.10](https://nunit.org/?p=releaseNotes&r=2.2.10)

[TeamLink]: https://docs.nunit.org/articles/developer-info/The-Teams.html#current-team-memberships-listed-in-a-kind-of-chronological-order

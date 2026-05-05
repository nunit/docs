# Attributes

NUnit uses custom attributes to identify tests. All NUnit attributes are contained in the NUnit.Framework namespace.
Each source file that contains tests must include a using statement for that namespace and the project must reference
the framework assembly, `nunit.framework.dll`.

This table lists all the attributes supported by NUnit.

|   Attribute                       |    Usage    |
|-----------------------------------|-------------|
| [Apartment Attribute](xref:apartment-attribute)           | Indicates that the test should run in a particular apartment. |
| [Author Attribute](xref:author-attribute)              | Provides the name of the test author. |
| [CancelAfter Attribute](xref:cancelafterattribute)            | Provides a timeout value in milliseconds for test cases. |
| [Category Attribute](xref:category-attribute)            | Specifies one or more categories for the test. |
| [Combinatorial Attribute](xref:combinatorialattribute)       | Generates test cases for all possible combinations of the values provided. |
| [Culture Attribute](xref:cultureattribute)             | Specifies cultures for which a test or fixture should be run. |
| [Datapoint Attribute](xref:datapointattribute)           | Provides data for [Theories](xref:theoryattribute). |
| [DatapointSource Attribute](xref:datapointsourceattribute)     | Provides data for [Theories](xref:theoryattribute). |
| [DefaultFloatingPointTolerance Attribute](xref:defaultfloatingpointtoleranceattribute) | Indicates that the test should use the specified tolerance as default for float and double comparisons. |
| [Description Attribute](xref:description-attribute)         | Applies descriptive text to a Test, TestFixture or Assembly. |
| [Explicit Attribute](xref:explicitattribute)            | Indicates that a test should be skipped unless explicitly run. |
| [FixtureLifeCycle Attribute](xref:fixturelifecycleattribute)  | Specifies the lifecycle of a fixture allowing a new instance of a test fixture to be constructed for each test case. Useful in situations where test case parallelism is important. |
| [Ignore Attribute](xref:ignoreattribute)              | Indicates that a test shouldn't be run for some reason. |
| [LevelOfParallelism Attribute](xref:levelofparallelismattribute)  | Specifies the level of parallelism at assembly level. |
| [MaxTime Attribute](xref:maxtimeattribute)             | Specifies the maximum time in milliseconds for a test case to succeed. |
| [NonParallelizable Attribute](xref:nonparallelizableattribute)   | Specifies that the test and its descendants may not be run in parallel. |
| [NonTestAssembly Attribute](xref:nontestassembly)     | Specifies that the assembly references the NUnit framework, but that it does not contain tests. |
| [OneTimeSetUp Attribute](xref:onetimesetup-attribute)        | Identifies methods to be called once prior to any child tests. |
| [OneTimeTearDown Attribute](xref:onetimeteardown-attribute)     | Identifies methods to be called once after all child tests. |
| [Order Attribute](xref:orderattribute)               | Specifies the order in which decorated test should be run within the containing fixture or suite. |
| [Pairwise Attribute](xref:pairwiseattribute)            | Generate test cases for all possible pairs of the values provided. |
| [Parallelizable Attribute](xref:parallelizableattribute)      | Indicates whether test and/or its descendants can be run in parallel. |
| [Platform Attribute](xref:platformattribute)            | Specifies platforms for which a test or fixture should be run. |
| [Property Attribute](xref:propertyattribute)            | Allows setting named properties on any test case or fixture. |
| [Random Attribute](xref:randomattribute)              | Specifies generation of random values as arguments to a parameterized test. |
| [Range Attribute](xref:rangeattribute)               | Specifies a range of values as arguments to a parameterized test. |
| [Repeat Attribute](xref:repeatattribute)              | Specifies that the decorated method should be executed multiple times. |
| [RequiresThread Attribute](xref:requiresthread-attribute)      | Indicates that a test method, class or assembly should be run on a separate thread. |
| [Retry Attribute](xref:retryattribute)               | Causes a test to be rerun if it fails, up to a maximum number of times. |
| [Sequential Attribute](xref:sequentialattribute)          | Generates test cases using values in the order provided, without additional combinations. |
| [SetCulture Attribute](xref:setcultureattribute)          | Sets the current Culture for the duration of a test. |
| [SetUICulture Attribute](xref:setuicultureattribute)        | Sets the current UI Culture for the duration of a test. |
| [SetUp Attribute](xref:setup-attribute)               | Indicates a method of a TestFixture called just before each test method. |
| [SetUpFixture Attribute](xref:setupfixture-attribute)        | Marks a class with one-time setup or teardown methods for all the test fixtures in a namespace. |
| [SingleThreaded Attribute](xref:singlethreadedattribute)      | Marks a fixture that requires all its tests to run on the same thread. |
| [TearDown Attribute](xref:teardown-attribute)            | Indicates a method of a TestFixture called just after each test method. |
| [Test Attribute](xref:testattribute)                | Marks a method of a TestFixture that represents a test. |
| [TestCase Attribute](xref:testcaseattribute)            | Marks a method with parameters as a test and provides inline arguments. |
| [TestCaseSource Attribute](xref:testcasesourceattribute)      | Marks a method with parameters as a test and provides a source of arguments. |
| [TestFixture Attribute](xref:testfixtureattribute)         | Marks a class as a test fixture and may provide inline constructor arguments. |
| [TestFixtureSetup Attribute](xref:testfixturesetupattribute)    | Deprecated synonym for [OneTimeSetUp Attribute](xref:onetimesetup-attribute). |
| [TestFixtureSource Attribute](xref:testfixturesourceattribute)   | Marks a class as a test fixture and provides a source for constructor arguments. |
| [TestFixtureTeardown Attribute](xref:testfixtureteardownattribute) | Deprecated synonym for [OneTimeTearDown Attribute](xref:onetimeteardown-attribute). |
| [TestOf Attribute](xref:testof-attribute)              | Indicates the name or Type of the class being tested. |
| [Theory Attribute](xref:theoryattribute)              | Marks a test method as a Theory, a special kind of test in NUnit. |
| [Timeout Attribute](xref:timeout-attribute)             | Provides a timeout value in milliseconds for test cases. |
| [Values Attribute](xref:valuesattribute)              | Provides a set of inline values for a parameter of a test method. |
| [ValueSource Attribute](xref:valuesource)         | Provides a source of values for a parameter of a test method. |

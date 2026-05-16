# Attributes

NUnit uses custom attributes to identify tests. All NUnit attributes are contained in the NUnit.Framework namespace.
Each source file that contains tests must include a using statement for that namespace and the project must reference
the framework assembly, `nunit.framework.dll`.

This table lists all the attributes supported by NUnit.

|   Attribute                       |    Usage    |
|-----------------------------------|-------------|
| [Apartment Attribute](xref:attribute-apartment)           | Indicates that the test should run in a particular apartment. |
| [Author Attribute](xref:attribute-author)              | Provides the name of the test author. |
| [CancelAfter Attribute](xref:attribute-cancelafter)            | Provides a timeout value in milliseconds for test cases. |
| [Category Attribute](xref:attribute-category)            | Specifies one or more categories for the test. |
| [Combinatorial Attribute](xref:attribute-combinatorial)       | Generates test cases for all possible combinations of the values provided. |
| [Culture Attribute](xref:attribute-culture)             | Specifies cultures for which a test or fixture should be run. |
| [Datapoint Attribute](xref:attribute-datapoint)           | Provides data for [Theories](xref:attribute-theory). |
| [DatapointSource Attribute](xref:attribute-datapointsource)     | Provides data for [Theories](xref:attribute-theory). |
| [DefaultFloatingPointTolerance Attribute](xref:attribute-defaultfloatingpointtolerance) | Indicates that the test should use the specified tolerance as default for float and double comparisons. |
| [Description Attribute](xref:attribute-description)         | Applies descriptive text to a Test, TestFixture or Assembly. |
| [Explicit Attribute](xref:attribute-explicit)            | Indicates that a test should be skipped unless explicitly run. |
| [FixtureLifeCycle Attribute](xref:attribute-fixturelifecycle)  | Specifies the lifecycle of a fixture allowing a new instance of a test fixture to be constructed for each test case. Useful in situations where test case parallelism is important. |
| [Ignore Attribute](xref:attribute-ignore)              | Indicates that a test shouldn't be run for some reason. |
| [LevelOfParallelism Attribute](xref:attribute-levelofparallelism)  | Specifies the level of parallelism at assembly level. |
| [MaxTime Attribute](xref:attribute-maxtime)             | Specifies the maximum time in milliseconds for a test case to succeed. |
| [NonParallelizable Attribute](xref:attribute-nonparallelizable)   | Specifies that the test and its descendants may not be run in parallel. |
| [NonTestAssembly Attribute](xref:attribute-nontestassembly)     | Specifies that the assembly references the NUnit framework, but that it does not contain tests. |
| [OneTimeSetUp Attribute](xref:attribute-onetimesetup)        | Identifies methods to be called once prior to any child tests. |
| [OneTimeTearDown Attribute](xref:attribute-onetimeteardown)     | Identifies methods to be called once after all child tests. |
| [Order Attribute](xref:attribute-order)               | Specifies the order in which decorated test should be run within the containing fixture or suite. |
| [Pairwise Attribute](xref:attribute-pairwise)            | Generate test cases for all possible pairs of the values provided. |
| [Parallelizable Attribute](xref:attribute-parallelizable)      | Indicates whether test and/or its descendants can be run in parallel. |
| [Platform Attribute](xref:attribute-platform)            | Specifies platforms for which a test or fixture should be run. |
| [Property Attribute](xref:attribute-property)            | Allows setting named properties on any test case or fixture. |
| [Random Attribute](xref:attribute-random)              | Specifies generation of random values as arguments to a parameterized test. |
| [Range Attribute](xref:attribute-range)               | Specifies a range of values as arguments to a parameterized test. |
| [Repeat Attribute](xref:attribute-repeat)              | Specifies that the decorated method should be executed multiple times. |
| [RequiresThread Attribute](xref:attribute-requiresthread)      | Indicates that a test method, class or assembly should be run on a separate thread. |
| [Retry Attribute](xref:attribute-retry)               | Causes a test to be rerun if it fails, up to a maximum number of times. |
| [Sequential Attribute](xref:attribute-sequential)          | Generates test cases using values in the order provided, without additional combinations. |
| [SetCulture Attribute](xref:attribute-setculture)          | Sets the current Culture for the duration of a test. |
| [SetUICulture Attribute](xref:attribute-setuiculture)        | Sets the current UI Culture for the duration of a test. |
| [SetUp Attribute](xref:attribute-setup)               | Indicates a method of a TestFixture called just before each test method. |
| [SetUpFixture Attribute](xref:attribute-setupfixture)        | Marks a class with one-time setup or teardown methods for all the test fixtures in a namespace. |
| [SingleThreaded Attribute](xref:attribute-singlethreaded)      | Marks a fixture that requires all its tests to run on the same thread. |
| [TearDown Attribute](xref:attribute-teardown)            | Indicates a method of a TestFixture called just after each test method. |
| [Test Attribute](xref:attribute-test)                | Marks a method of a TestFixture that represents a test. |
| [TestCase Attribute](xref:attribute-testcase)            | Marks a method with parameters as a test and provides inline arguments. |
| [TestCaseSource Attribute](xref:attribute-testcasesource)      | Marks a method with parameters as a test and provides a source of arguments. |
| [TestFixture Attribute](xref:attribute-testfixture)         | Marks a class as a test fixture and may provide inline constructor arguments. |
| [TestFixtureSetup Attribute](xref:attribute-testfixturesetup)    | Deprecated synonym for [OneTimeSetUp Attribute](xref:attribute-onetimesetup). |
| [TestFixtureSource Attribute](xref:attribute-testfixturesource)   | Marks a class as a test fixture and provides a source for constructor arguments. |
| [TestFixtureTeardown Attribute](xref:attribute-testfixtureteardown) | Deprecated synonym for [OneTimeTearDown Attribute](xref:attribute-onetimeteardown). |
| [TestOf Attribute](xref:attribute-testof)              | Indicates the name or Type of the class being tested. |
| [Theory Attribute](xref:attribute-theory)              | Marks a test method as a Theory, a special kind of test in NUnit. |
| [Timeout Attribute](xref:attribute-timeout)             | Provides a timeout value in milliseconds for test cases. |
| [Values Attribute](xref:attribute-values)              | Provides a set of inline values for a parameter of a test method. |
| [ValueSource Attribute](xref:attribute-valuesource)         | Provides a source of values for a parameter of a test method. |

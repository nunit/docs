# Attributes

NUnit uses custom attributes to identify tests. All NUnit attributes are contained in the NUnit.Framework namespace.
Each source file that contains tests must include a using statement for that namespace and the project must reference
the framework assembly, `nunit.framework.dll`.

This table lists all the attributes supported by NUnit.

|   Attribute                       |    Usage    |
|-----------------------------------|-------------|
| [Apartment Attribute](apartment.md)           | Indicates that the test should run in a particular apartment. |
| [Author Attribute](author.md)              | Provides the name of the test author. |
| [CancelAfter Attribute](cancelafter.md)            | Provides a timeout value in milliseconds for test cases. |
| [Category Attribute](category.md)            | Specifies one or more categories for the test. |
| [Combinatorial Attribute](combinatorial.md)       | Generates test cases for all possible combinations of the values provided. |
| [Culture Attribute](culture.md)             | Specifies cultures for which a test or fixture should be run. |
| [Datapoint Attribute](datapoint.md)           | Provides data for [Theories](xref:theoryattribute). |
| [DatapointSource Attribute](datapointsource.md)     | Provides data for [Theories](xref:theoryattribute). |
| [DefaultFloatingPointTolerance Attribute](defaultfloatingpointtolerance.md) | Indicates that the test should use the specified tolerance as default for float and double comparisons. |
| [Description Attribute](description.md)         | Applies descriptive text to a Test, TestFixture or Assembly. |
| [Explicit Attribute](explicit.md)            | Indicates that a test should be skipped unless explicitly run. |
| [FixtureLifeCycle Attribute](fixturelifecycle.md)  | Specifies the lifecycle of a fixture allowing a new instance of a test fixture to be constructed for each test case. Useful in situations where test case parallelism is important. |
| [Ignore Attribute](ignore.md)              | Indicates that a test shouldn't be run for some reason. |
| [LevelOfParallelism Attribute](levelofparallelism.md)  | Specifies the level of parallelism at assembly level. |
| [MaxTime Attribute](maxtime.md)             | Specifies the maximum time in milliseconds for a test case to succeed. |
| [NonParallelizable Attribute](nonparallelizable.md)   | Specifies that the test and its descendants may not be run in parallel. |
| [NonTestAssembly Attribute](nontestassembly.md)     | Specifies that the assembly references the NUnit framework, but that it does not contain tests. |
| [OneTimeSetUp Attribute](onetimesetup.md)        | Identifies methods to be called once prior to any child tests. |
| [OneTimeTearDown Attribute](onetimeteardown.md)     | Identifies methods to be called once after all child tests. |
| [Order Attribute](order.md)               | Specifies the order in which decorated test should be run within the containing fixture or suite. |
| [Pairwise Attribute](pairwise.md)            | Generate test cases for all possible pairs of the values provided. |
| [Parallelizable Attribute](parallelizable.md)      | Indicates whether test and/or its descendants can be run in parallel. |
| [Platform Attribute](platform.md)            | Specifies platforms for which a test or fixture should be run. |
| [Property Attribute](property.md)            | Allows setting named properties on any test case or fixture. |
| [Random Attribute](random.md)              | Specifies generation of random values as arguments to a parameterized test. |
| [Range Attribute](range.md)               | Specifies a range of values as arguments to a parameterized test. |
| [Repeat Attribute](repeat.md)              | Specifies that the decorated method should be executed multiple times. |
| [RequiresThread Attribute](requiresthread.md)      | Indicates that a test method, class or assembly should be run on a separate thread. |
| [Retry Attribute](retry.md)               | Causes a test to be rerun if it fails, up to a maximum number of times. |
| [Sequential Attribute](sequential.md)          | Generates test cases using values in the order provided, without additional combinations. |
| [SetCulture Attribute](setculture.md)          | Sets the current Culture for the duration of a test. |
| [SetUICulture Attribute](setuiculture.md)        | Sets the current UI Culture for the duration of a test. |
| [SetUp Attribute](setup.md)               | Indicates a method of a TestFixture called just before each test method. |
| [SetUpFixture Attribute](setupfixture.md)        | Marks a class with one-time setup or teardown methods for all the test fixtures in a namespace. |
| [SingleThreaded Attribute](singlethreaded.md)      | Marks a fixture that requires all its tests to run on the same thread. |
| [TearDown Attribute](teardown.md)            | Indicates a method of a TestFixture called just after each test method. |
| [Test Attribute](test.md)                | Marks a method of a TestFixture that represents a test. |
| [TestCase Attribute](testcase.md)            | Marks a method with parameters as a test and provides inline arguments. |
| [TestCaseSource Attribute](testcasesource.md)      | Marks a method with parameters as a test and provides a source of arguments. |
| [TestFixture Attribute](testfixture.md)         | Marks a class as a test fixture and may provide inline constructor arguments. |
| [TestFixtureSetup Attribute](testfixturesetup.md)    | Deprecated synonym for [OneTimeSetUp Attribute](onetimesetup.md). |
| [TestFixtureSource Attribute](testfixturesource.md)   | Marks a class as a test fixture and provides a source for constructor arguments. |
| [TestFixtureTeardown Attribute](testfixtureteardown.md) | Deprecated synonym for [OneTimeTearDown Attribute](onetimeteardown.md). |
| [TestOf Attribute](testof.md)              | Indicates the name or Type of the class being tested. |
| [Theory Attribute](theory.md)              | Marks a test method as a Theory, a special kind of test in NUnit. |
| [Timeout Attribute](timeout.md)             | Provides a timeout value in milliseconds for test cases. |
| [Values Attribute](values.md)              | Provides a set of inline values for a parameter of a test method. |
| [ValueSource Attribute](valuesource.md)         | Provides a source of values for a parameter of a test method. |

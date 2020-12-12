---
uid: fixturelifecycleattribute
---

# FixtureLifeCycle

Added in **NUnit 3.13**

The `FixtureLifeCycleAttribute` is used to indicate that an instance for a test fixture or all test fixtures in an assembly should be constructed for each test within the fixture or assembly.

This attribute may be applied to a test fixture (class) or to a test assembly. It is useful in combination with the [Parallelizable Attribute](parallelizable.md) so that a new instance of a test fixture is constructed for every test within the test fixture. This allows tests to run in isolation without sharing instance fields and properties during parallel test runs. This make running parallel tests easier because it is easier to make your tests thread safe.

This attribute can be applied to classes or to the entire test assembly. If applied to an assembly, it may be overridden at the class level.

## LifeCycle Enumeration

The constructor of `FixtureLifeCycleAttribute` takes a `LifeCycle` attribute to indicate if a single instance of a test fixture should be created for all tests or if a new instance should be created for each test.

 Value | Meaning
-------|---------
`LifeCycle.SingleInstance`     | A single instance is created and shared for all test cases
`LifeCycle.InstancePerTestCase` | A new instance is created for each test case

## Notes

* When using `LifeCycle.InstancePerTestCase`, the [`OneTimeSetUp`](xref:onetimesetup-attribute) and [`OneTimeTearDown`](xref:onetimeteardown-attribute) methods must be static, and each are only called once. This is required so that the setup or teardown methods do not access instance fields or properties that are reset for every test.

* When using `LifeCycle.InstancePerTestCase`, a class's constructor will be called before every test is executed and `IDisposable` test fixtures will be disposed after the test is finished.

* [`SetUp`](xref:setup-attribute) and [`TearDown`](xref:teardown-attribute) methods are called before and after every test.

* The `Order` attribute is respected.

## See Also

* [Parallelizable Attribute](xref:parallelizableattribute)
* [OneTimeSetUp Attribute](xref:onetimesetup-attribute)
* [OneTimeTearDown Attribute](xref:onetimeteardown-attribute)

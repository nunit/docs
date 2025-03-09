---
uid: gettingstartedengine
---

# Getting Started with the NUnit Engine

Building your own test runner? This guide covers the basics of getting up and running.

## Fundamentals

The engine is designed to be accessed through the methods exposed in the `nunit.engine.api` assembly - which is the only
assembly which should be referenced by runners wishing to use the engine. The API exposed through this assembly will be
maintained in a backwards-compatible way wherever possible.

The actual engine itself is contained within the `nunit.engine` assembly, and its dependencies. This assembly should
**not** be referenced by the runners, as methods exposed here could be subject to changes in future versions. Instead,
the API should be used to locate and load an appropriate version of the engine, which will return an instance of the
`ITestEngine` interface to the runner.

## Packages

The NUnit Engine can be found in the [NUnit.Engine NuGet Package](https://www.nuget.org/packages/NUnit.Engine/). It is
also included within the .zip file found in [nunit-console repository](https://github.com/nunit/nunit-console/releases)
releases.

## Using the API

The `TestEngineActivator` class is first used to obtain an instance of the engine. Tests are specified inside a
`TestPackage`, which can contain one or many different test assemblies. Settings related to how the tests should be run
are attached to the test package.

Once a test package has been created, the engine can generate an instance of an `ITestRunner`, which will be constructed
to reflect the structure of your test package.

Finally, `Run` can be called on the `ITestRunner`, to run tests in the specified package. This will return an `XmlNode`
which contains the results of the test run, in the standard [NUnit Test Results](xref:testresultxmlformat) format.

The following example shows the simplest path of how to get a copy of the engine, create a runner and run tests using
the interfaces:

```csharp
// Get an interface to the engine
ITestEngine engine = TestEngineActivator.CreateInstance();

// Create a simple test package - one assembly, no special settings
TestPackage package = new TestPackage("my.test.assembly.dll");

// Get a runner for the test package
ITestRunner runner = engine.GetRunner(package);

// Run all the tests in the assembly
XmlNode testResult = runner.Run(listener: null, TestFilter.Empty);
```

For further details of what can be achieved with the Engine, see the [Test Engine API Page](xref:testengineapi).

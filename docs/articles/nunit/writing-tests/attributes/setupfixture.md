---
uid: attribute-setupfixture
---

# SetUpFixture

`SetUpFixtureAttribute` marks a class that provides one-time setup/teardown for all fixtures in a namespace (including nested namespaces) within an assembly.

The class may contain at most one `[OneTimeSetUp]` and one `[OneTimeTearDown]` method.

## Usage

This is a parameterless attribute that can only be applied to classes.

```csharp
[SetUpFixture]
```

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly | Helper Classes |
| ------------ | ----------------------- | -------- | -------------- |
| ❌           | ❌                      | ❌       | ✅             |

There are a few restrictions on a class that is used as a setup fixture.

* It must be a publicly exported type or NUnit will not see it.
* It must have a default constructor or NUnit will not be able to construct it.

The OneTimeSetUp method in a SetUpFixture is executed once before any of the fixtures
contained in its namespace. The OneTimeTearDown method is executed once after all the
fixtures have completed execution. In the examples below, the method RunBeforeAnyTests()
is called before any tests or setup methods in the NUnit.Tests namespace. The method
RunAfterAnyTests() is called after all the tests in the namespace as well as their
individual or fixture teardowns have completed execution.

Multiple SetUpFixtures may be created in a given namespace. The order of execution
of such fixtures is indeterminate.

## Scope

* The scope of a SetUpFixture is limited to an assembly.
* A SetUpFixture in a namespace will apply to all tests in that namespace and all contained namespaces within the assembly.
* A SetUpFixture outside of any namespace provides SetUp and TearDown for the entire assembly.

## Example

[!code-csharp[SetUpFixtureExample](~/snippets/Snippets.NUnit/Attributes/SetUpFixtureAttributeExamples.cs#SetUpFixtureExample)]

## Detailed explanation

With respect to the order of execution of setup (also one-time setup) it's deterministic between namespaces (including
 nested namespaces) but non-deterministic if you have two setups at the same level, e.g. two methods in the same class
 marked [SetUp]. That's, however, a usage that should only come up in limited situations and is easy to avoid.

The defined order is as follows...

1. Setup starts at the assembly level SetUpFixture, outside of any namespace.
2. It continues with the top level of any SetUpFixtures in a namespace , proceeds downward into any nested namespaces.
3. Setup code in a TestFixture comes after any SetUpFixtures that control the namespace of the fixture.
4. At each of the above levels, inheritance may also come into play. Base class setups are run before those of the
 derived class.
5. Teardown for any of the above executes in the reverse order.
6. Ordering of TestFixtures or SetUpFixtures within the same namespace is indeterminate.
7. Ordering of multiple setup methods within the same class is indeterminate.

[Items 6 and 7 rarely come into play but the features are available for situations like code generation, where it may
 be more convenient to have multiple setup fixtures and/or methods.]

## Inheritance

`[SetUpFixture]` can be inherited. A class that derives from a class marked `[SetUpFixture]` is itself a setup
fixture, even if it does not repeat the attribute. This lets a shared test-support package provide the one-time setup and
teardown in a base class, with each test project deriving from it:

[!code-csharp[SetUpFixtureInheritanceBase](~/snippets/Snippets.NUnit/Attributes/SetUpFixtureAttributeExamples.cs#SetUpFixtureInheritanceBase)]

[!code-csharp[SetUpFixtureInheritanceDerived](~/snippets/Snippets.NUnit/Attributes/SetUpFixtureAttributeExamples.cs#SetUpFixtureInheritanceDerived)]

NUnit applies these rules:

* **The namespace of the concrete class sets the scope.** NUnit builds the setup fixture from the concrete class, so it
  covers the namespace that class is in and the namespaces below it. The namespace of the base class plays no part. In
  the example, the setup runs once for the tests in `SetUpFixtureInheritance.Consumer`.
* **An abstract base class is not a setup fixture by itself.** NUnit ignores abstract classes when it looks for
  fixtures, so the base class does nothing until a test project derives from it. A base class in another assembly is
  never scanned anyway, because NUnit only looks at the types in the test assembly. If the base class is concrete and
  lives in the test assembly, it is a setup fixture for its own namespace in addition to the derived class.
* **Attributes on the derived class win.** NUnit looks for fixture attributes one level of the inheritance chain at a
  time, starting at the concrete class, and uses the first level that has any. An inherited `[SetUpFixture]` is only
  used when the derived class has no fixture attribute of its own:
  * If the derived class is marked `[TestFixture]`, NUnit builds an ordinary test fixture and the inherited
    `[SetUpFixture]` is ignored. Its tests run, and the base class `[OneTimeSetUp]` runs once for that fixture, like
    any inherited `[OneTimeSetUp]`.
  * If the derived class has `[Test]` methods but no `[TestFixture]`, the inherited `[SetUpFixture]` wins. NUnit builds
    a setup fixture and the tests are **not discovered**. There is no warning; the tests are simply missing from the
    run, and from `dotnet test --list-tests`.

[!code-csharp[SetUpFixtureInheritancePrecedence](~/snippets/Snippets.NUnit/Attributes/SetUpFixtureAttributeExamples.cs#SetUpFixtureInheritancePrecedence)]

> [!TIP]
> Put `[SetUpFixture]` on the concrete class as well. It is not required, but it makes the role of the class visible
> without looking at the base class, and it is easier to spot a `[Test]` method that ended up in the wrong place.

## Sharing setup across projects

When several test projects share one-time setup from a common package, a base class with `[SetUpFixture]` works, but
each project still has to declare a derived class. A `[OneTimeSetUp]` on a shared base *test* class is not an
alternative: NUnit runs it once for **every fixture** that derives from it, not once per run. See
[OneTimeSetUp](xref:attribute-onetimesetup#test-fixture-versus-setup-fixture).

The simplest pattern keeps the package free of NUnit fixture attributes. The package provides a plain class with the
setup and teardown logic:

[!code-csharp[SetUpFixtureSharingPackage](~/snippets/Snippets.NUnit/Attributes/SetUpFixtureAttributeExamples.cs#SetUpFixtureSharingPackage)]

Each test project declares a small `[SetUpFixture]` that calls it. Placed outside any namespace, it runs once for the
whole project:

[!code-csharp[SetUpFixtureSharingConsumer](~/snippets/Snippets.NUnit/Attributes/SetUpFixtureAttributeExamples.cs#SetUpFixtureSharingConsumer)]

If you cannot ask consumers to add a class, start the resource on first use from a static `Lazy<T>` in the base test
class. It starts once per test run, but NUnit offers no hook to stop it at the end of the run, so use this only for
resources the process can abandon:

[!code-csharp[SetUpFixtureSharingLazy](~/snippets/Snippets.NUnit/Attributes/SetUpFixtureAttributeExamples.cs#SetUpFixtureSharingLazy)]

## Notes

1. `SetUpFixture` classes must be public and have a default constructor (or be static).
2. `SetUp` and `TearDown` attributes are not valid inside a `SetUpFixture`.
3. A setup fixture outside any namespace applies to the entire assembly.
4. Multiple setup fixtures at the same namespace level execute in indeterminate order.
5. Prior to NUnit 3.0, setup fixtures used `SetUp`/`TearDown`; NUnit 3+ uses `OneTimeSetUp`/`OneTimeTearDown`.
6. `SetUpFixture` can be inherited. The namespace of the derived class sets the scope; see [Inheritance](#inheritance).

## See Also

* [SetUp Attribute](xref:attribute-setup)
* [TearDown Attribute](xref:attribute-teardown)
* [OneTimeSetUp Attribute](xref:attribute-onetimesetup)
* [OneTimeTearDown Attribute](xref:attribute-onetimeteardown)

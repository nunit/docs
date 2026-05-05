---
uid: setupfixture-attribute
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
|--------------|--------------------------|----------|----------------|
| ❌ | ❌ | ❌ | ✅ |

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

## Notes

1. `SetUpFixture` classes must be public and have a default constructor (or be static).
2. `SetUp` and `TearDown` attributes are not valid inside a `SetUpFixture`.
3. A setup fixture outside any namespace applies to the entire assembly.
4. Multiple setup fixtures at the same namespace level execute in indeterminate order.
5. Prior to NUnit 3.0, setup fixtures used `SetUp`/`TearDown`; NUnit 3+ uses `OneTimeSetUp`/`OneTimeTearDown`.

## See Also

* [SetUp Attribute](xref:setup-attribute)
* [TearDown Attribute](xref:teardown-attribute)
* [OneTimeSetUp Attribute](xref:onetimesetup-attribute)
* [OneTimeTearDown Attribute](xref:onetimeteardown-attribute)

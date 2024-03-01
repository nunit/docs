---
uid: setupfixture-attribute
---

# SetUpFixture

This is the attribute that marks a class that contains the one-time
setup or teardown methods for all the test fixtures in a given
namespace including nested namespaces below.

The class may contain at most one method marked with the
OneTimeSetUpAttribute and one method marked with the OneTimeTearDownAttribute.

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

## Notes

* A SetUpFixture outside of any namespace provides SetUp and TearDown for the entire assembly.
* A SetUpFixture in a namespace will apply tests to that namespace and all contained namespaces.

## Example

```csharp
using System;
using NUnit.Framework;

namespace NUnit.Tests
{
  [SetUpFixture]
  public class MySetUpClass
  {
    [OneTimeSetUp]
    public void RunBeforeAnyTests()
    {
      // ...
    }

    [OneTimeTearDown]
    public void RunAfterAnyTests()
    {
      // ...
    }
  }
}
```

## Detailed explanation

With respect to the order of execution of setup (also one-time setup) it's deterministic between namespaces (including nested namespaces) but non-deterministic if you have two setups at the same level, e.g. two methods in the same class marked [SetUp]. That's, however, a usage that should only come up in limited situations and is easy to avoid.

The defined order is as follows...

1. Setup starts at the assembly level SetUpFixture, outside of any namespace.
2. It continues with the top level of any SetUpFixtures in a namespace , proceeds downward into any nested namespaces.
3. Setup code in a TestFixture comes after any SetUpFixtures that control the namespace of the fixture.
4. At each of the above levels, inheritance may also come into play. Base class setups are run before those of the derived class.
5. Teardown for any of the above executes in the reverse order.
6. Ordering of TestFixtures or SetUpFixtures within the same namespace is indeterminate.
7. Ordering of multiple setup methods within the same class is indeterminate.

[Items 6 and 7 rarely come into play but the features are available for situations like code generation, where it may be more convenient to have multiple setup fixtures and/or methods.]

> [!NOTE]
> Filtering on SetUpFixtures

A `SetUpFixture` is normally not used for filtering tests.  However, if that is done, one should be aware that a
 `SetUpFixture` encapsulates all tests to which it belongs.
 If placed in a namespace it will encapsulate all tests in that namespace and contained namespaces.
 If placed on the assembly level, it will encapsulate all tests in the assembly.

> [!NOTE]
> Prior to NUnit 3.0, `SetUpFixture` used the `SetUp` and `TearDown` attributes rather than `OneTimeSetUp` and `OneTimeTearDown`.
The older attributes are no longer supported in SetUpFixtures in NUnit 3.0 and later.

## See also

* [SetUp Attribute](setup.md)
* [TearDown Attribute](teardown.md)
* [OneTimeSetUp Attribute](onetimesetup.md)
* [OneTimeTearDown Attribute](onetimeteardown.md)

---
uid: onetimesetup-attribute
---

# OneTimeSetUp

This attribute is to identify methods that are called once prior to executing any of the tests
in a fixture. It may appear on methods of a TestFixture or a SetUpFixture.

OneTimeSetUp methods may be either static or
instance methods and you may define more than one of them in a fixture.
Normally, multiple OneTimeSetUp methods are only defined at different levels
of an inheritance hierarchy, as explained below.

If a OneTimeSetUp method fails or throws an exception, none of the tests
in the fixture are executed and a failure or error is reported.

## Example

```csharp
namespace NUnit.Tests
{
  using System;
  using NUnit.Framework;

  [TestFixture]
  public class SuccessTests
  {
    [OneTimeSetUp]
    public void Init()
    { /* ... */ }

    [OneTimeTearDown]
    public void Cleanup()
    { /* ... */ }

    [Test]
    public void Add()
    { /* ... */ }
  }
}
```

### Inheritance

The OneTimeSetUp attribute is inherited from any base class. Therefore, if a base
class has defined a OneTimeSetUp method, that method will be called
before any methods in the derived class.

You may define a OneTimeSetUp method
in the base class and another in the derived class. NUnit will call base
class OneTimeSetUp methods before those in the derived classes.

> [!WARNING]
> If a base class OneTimeSetUp method is overridden in the derived class, NUnit will not call the base class OneTimeSetUp method; NUnit does not anticipate usage that includes hiding the base method. Note that you may have a different name for each method; as long as both have the `[OneTimeSetUp]` attribute present, each will be called in the correct order.

## Notes

* Although it is possible to define multiple [`OneTimeSetUp`](xref:onetimesetup-attribute) methods in the same class, you should rarely do so. Unlike methods defined in separate classes in the inheritance hierarchy, the order in which they are executed is not guaranteed.

* [`OneTimeSetUp`](xref:onetimesetup-attribute) methods may be async if running under .NET 4.0 or higher.

* [`OneTimeSetUp`](xref:onetimesetup-attribute) methods run in the context of the [`TestFixture`](xref:testfixtureattribute) or [`SetUpFixture`](xref:setupfixture-attribute), which is separate from the context of any individual test cases. It's important to keep this in mind when using [`TestContext`](xref:testcontext) methods and properties within the method.

* When using [`FixtureLifeCycle`](xref:fixturelifecycleattribute) with `LifeCycle.InstancePerTestCase`, the [`OneTimeSetUp`](xref:onetimesetup-attribute) method must be static and is only called once. This is required so that the setup method does not access instance fields or properties that are reset for every test.

## See Also

* [SetUp Attribute](setup.md)
* [TearDown Attribute](teardown.md)
* [OneTimeTearDown Attribute](onetimeteardown.md)
* [FixtureLifeCycle Attribute](fixturelifecycle.md)

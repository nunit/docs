---
uid: teardown-attribute
---

# TearDown

This attribute is used inside a [TestFixture](xref:testfixtureattribute) to provide a common set of functions that are performed after each test method.

TearDown methods may be either static or instance methods and you may define more than one of them in a fixture. Normally, multiple TearDown methods are only defined at different levels of an inheritance hierarchy, as explained below.

So long as any SetUp method runs without error, the TearDown method is guaranteed to run. For example, it is not guaranteed to run if a SetUp method fails or throws an exception.

## Example

```csharp
namespace NUnit.Tests
{
  using System;
  using NUnit.Framework;

  [TestFixture]
  public class SuccessTests
  {
    [SetUp] public void Init()
    { /* ... */ }

    [TearDown] public void Cleanup()
    { /* ... */ }

    [Test] public void Add()
    { /* ... */ }
  }
}
```

## Inheritance

The TearDown attribute is inherited from any base class. Therefore, if a base
class has defined a TearDown method, that method will be called
after each test method in the derived class.

You may define a TearDown method
in the base class and another in the derived class. NUnit will call base
class TearDown methods after those in the derived classes.

> [!WARNING]
> If a base class TearDown method is overridden in the derived class, NUnit will not call the base class TearDown method; NUnit does not anticipate usage that includes hiding the base method. Note that you may have a different name for each method; as long as both have the `[TearDown]` attribute present, each will be called in the correct order.

## Notes

1. Although it is possible to define multiple TearDown methods
   in the same class, you should rarely do so. Unlike methods defined in
   separate classes in the inheritance hierarchy, the order in which they
   are executed is not guaranteed.

2. TearDown methods may be async if running under .NET 4.0 or higher.

## See also

* [SetUp Attribute](setup.md)
* [OneTimeSetUp Attribute](onetimesetup.md)
* [OneTimeTearDown Attribute](onetimeteardown.md)
* [TestFixture Attribute](testfixture.md)

---
uid: setup-attribute
---

# SetUp

This attribute is used inside a [TestFixture](xref:testfixtureattribute) to provide a common set of functions that are
performed just before each test method is called.

SetUp methods may be either static or instance methods and you may define more than one of them in a fixture. Normally,
multiple SetUp methods are only defined at different levels of an inheritance hierarchy, as explained below.

If a SetUp method fails or throws an exception, the test is not executed and a failure or error is reported.

## Example

[!code-csharp[SetUpTearDownExample](~/snippets/Snippets.NUnit/AttributeExamples.cs#SetUpTearDownExample)]

## Inheritance

The SetUp attribute is inherited from any base class. Therefore, if a base class has defined a SetUp method, that method
will be called before each test method in the derived class.

You may define a SetUp method in the base class and another in the derived class. NUnit will call base class SetUp
methods before those in the derived classes.

> [!WARNING]
> If a base class SetUp method is overridden in the derived class, NUnit will not call the base class SetUp
> method; NUnit does not anticipate usage that includes hiding the base method. Note that you may have a different name
> for each method; as long as both have the `[SetUp]` attribute present, each will be called in the correct order.

## Notes

1. Although it is possible to define multiple SetUp methods in the same class, you should rarely do so. Unlike methods
   defined in separate classes in the inheritance hierarchy, the order in which they are executed is not guaranteed.

2. You may specify an async method (`async` keyword in c#) if necessary, when running under .NET 4.0 or higher.

## See also

* [TearDown Attribute](teardown.md)
* [OneTimeSetUp Attribute](onetimesetup.md)
* [OneTimeTearDown Attribute](onetimeteardown.md)
* [testfixture attribute](testfixture.md)

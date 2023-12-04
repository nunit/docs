---
uid: testfixtureattribute
---

# TestFixture

This is the attribute that marks a class that contains tests and, optionally, setup or teardown methods.

Most restrictions on a class that is used as a test fixture have now been eliminated. A test fixture class:

* May be public, protected, private or internal.
* May be a static class.
* May be generic, so long as any type parameters are provided or can be inferred from the actual arguments.
* May not be abstract - although the attribute may be applied to an abstract class intended to serve as a base class for
  test fixtures.
* If no arguments are provided with the TestFixtureAttribute, the class must have a default constructor.
* If arguments are provided, they must match one of the constructors.

If any of these restrictions are violated, the class is not runnable as a test and will display as an error.

It is advisable that the constructor not have any side effects, since NUnit may construct the object multiple times in
the course of a session.

Beginning with NUnit 2.5, the **TestFixture** attribute is optional for non-parameterized, non-generic fixtures. So long
as the class contains at least one method marked with the **Test**, **TestCase** or **TestCaseSource** attribute, it
will be treated as a test fixture.

## Example

```csharp
namespace NUnit.Tests
{
  using System;
  using NUnit.Framework;

  [TestFixture]
  public class SuccessTests
  {
    // ...
  }
}
```

## Inheritance

The **TestFixtureAttribute** may be applied to a base class and is inherited by any derived classes. This includes any
abstract base class, so the well-known Abstract Fixture pattern may be implemented if desired.

In order to facilitate use of generic and/or parameterized classes, where the derived class may require a different
number of arguments (or type arguments) from the base class, superfluous **TestFixture** attributes are ignored, using
the following rules:

1. If all TestFixture attributes provide constructor or type arguments, then all of them are used.
2. If some of the attributes provide arguments and others do not, then only those with arguments are used and those
   without arguments are ignored.
3. If none of the attributes provide arguments, one of them is selected for use by NUnit. It is not possible to predict
   which will be used, so this situation should generally be avoided.

This permits code like the following, which would cause an error if the attribute on the base class were not ignored.

```csharp
[TestFixture]
public class AbstractFixtureBase
{
    /* ... */
}

[TestFixture(typeof(string))]
public class DerivedFixture<T> : AbstractFixtureBase
{
    /* ... */
}
```

## Parameterized Test Fixtures

Test fixtures may take constructor arguments. Argument values are specified as arguments to the **TestFixture**
attribute. NUnit will construct a separate instance of the fixture for each set of arguments.

Individual fixture instances in a set of parameterized fixtures may be ignored. Set the **Ignore** named parameter of
the reason for ignoring the instance.

Individual fixture instances may be given categories as well. Set the **Category** named parameter of the attribute to
the name of the category or to a comma-separated list of categories.

### Example

The following test fixture would be instantiated by NUnit five times,
passing in each set of arguments to the appropriate constructor. Note
that there are four different constructors, matching the data types
provided as arguments, and the params keyword can be used to allow
passing different numbers of arguments.

[!code-csharp[MultipleParameterizedTestFixtures](~/snippets/Snippets.NUnit/Attributes/TestFixtureAttributeExamples.cs#MultipleParameterizedTestFixtures)]

## Generic Test Fixtures

You may also use a generic class as a test fixture. In order for NUnit to instantiate the fixture, you must either
specify the types to be used as arguments to **TestFixtureAttribute** or use the named parameter **TypeArgs=** to
specify them. NUnit will construct a separate instance of the fixture for each **TestFixtureAttribute** you provide.

### Example

The following test fixture would be instantiated by NUnit twice, once using an `ArrayList` and once using a `List<int>`.

[!code-csharp[GenericTestFixtures](~/snippets/Snippets.NUnit/Attributes/TestFixtureAttributeExamples.cs#GenericTestFixtures)]

### Generic Test Fixtures with Parameters

If a Generic fixture, uses constructor arguments, there are three approaches to telling NUnit which arguments are type
parameters and which are normal constructor parameters.

* Specify both sets of parameters as arguments to the **TestFixtureAttribute**. Leading **System.Type** arguments are
   used as type parameters, while any remaining arguments are used to construct the instance. In the following example,
   this leads to some obvious duplication...

[!code-csharp[GenericTestFixtureWithParameters](~/snippets/Snippets.NUnit/Attributes/TestFixtureAttributeExamples.cs#GenericTestFixtureWithParameters)]

* Specify normal parameters as arguments to **TestFixtureAttribute** and use the named parameter **TypeArgs=** to
   specify the type arguments. Again, for this example, the type info is duplicated, but it is at least more cleanly
   separated from the normal arguments...

[!code-csharp[SpecifyTypeArgsSeparately](~/snippets/Snippets.NUnit/Attributes/TestFixtureAttributeExamples.cs#SpecifyTypeArgsSeparately)]

* In some cases, when the constructor makes use of all the type parameters NUnit may simply be able to deduce them from
   the arguments provided. That's the case here and the following is the preferred way to write this example...

[!code-csharp[DeducedTypesFromArguments](~/snippets/Snippets.NUnit/Attributes/TestFixtureAttributeExamples.cs#DeducedTypesFromArguments)]

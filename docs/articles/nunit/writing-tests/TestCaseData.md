---
uid: testcasedata
---

# TestCaseData

The `TestCaseData` class provides extended test case information for a parameterized test, although any object deriving
from `TestCaseParameters` may be used. Unlike NUnit 2, you cannot implement `ITestCaseData`, you must derive from
`TestCaseParameters`.

[!code-csharp[TestCaseDataExample](~/snippets/Snippets.NUnit/TestCaseDataExample.cs#TestCaseDataExample)]

This example uses the fluent interface supported by **TestCaseData** to make the program more readable.

**TestCaseData** supports the following properties and methods, which may be appended to an instance in any order.

* **Explicit()** or **Explicit(string)** causes the test case to be marked explicit, optionally specifying the reason
  for doing so.
* **Ignore(string)** causes the test case to be ignored and specifies the reason, which is required. Can be chained
  with **Until(DateTimeOffset)** to specify a date after which the test should run again.
* **Returns** specifies the expected result to be returned from the method, which must have a compatible return type.
* **SetArgDisplayNames(string[])** sets the list of display names to use as the parameters in the test name.
* **SetArgDisplayNames(object[])** sets the list of display names using objects that are automatically formatted.
* **SetCategory(string)** applies a category to the test.
* **SetDescription(string)** sets the description property of the test.
* **SetName(string)** provides a name for the test. If not specified, a name is generated based on the method name and
  the arguments provided. See [Template Based Test Naming](xref:templatebasedtestnaming).
* **SetProperty(string, string)**, **SetProperty(string, int)** and **SetProperty(string, double)** apply a named
  property and value to the test.
* **TypeArgs** specifies the `Type`s to be used when targeting a generic test method. (_NUnit 4.1+_)
* **Until(DateTimeOffset)** can be chained after **Ignore(string)** to specify a date after which the test case
  should no longer be ignored. Once the date passes, the test will run automatically. (_NUnit 4+_)

## Temporarily ignoring test cases with Until

The **Until** method allows you to temporarily ignore a test case until a specific date. This is useful for tests
that are known to fail due to external factors (e.g., waiting for an API release, known bug in a dependency) but
should automatically start running again after a certain date.

[!code-csharp[IgnoreUntilExample](~/snippets/Snippets.NUnit/TestCaseDataExample.cs#IgnoreUntilExample)]

## Generic TestCaseData variants

As of NUnit 4.1, generic versions of `TestCaseData` are available that automatically set the `TypeArgs` property
based on their type parameters. This provides a more concise syntax when working with generic test methods:

| Class | Usage |
|-------|-------|
| `TestCaseData<T>` | Single type parameter |
| `TestCaseData<T1, T2>` | Two type parameters |
| `TestCaseData<T1, T2, T3>` | Three type parameters |
| `TestCaseData<T1, T2, T3, T4>` | Four type parameters |
| `TestCaseData<T1, T2, T3, T4, T5>` | Five type parameters |

[!code-csharp[GenericTestCaseDataExample](~/snippets/Snippets.NUnit/TestCaseDataExample.cs#GenericTestCaseDataExample)]

## SetArgDisplayNames with objects

The `SetArgDisplayNames` method has an overload that accepts `object[]` instead of `string[]`. Objects passed to
this overload are automatically formatted using NUnit's value formatting logic, which is the same logic used for
default test names.

[!code-csharp[SetArgDisplayNamesObjectExample](~/snippets/Snippets.NUnit/TestCaseDataExample.cs#SetArgDisplayNamesObjectExample)]

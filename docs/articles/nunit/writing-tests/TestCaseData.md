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
* **Ignore(string)** causes the test case to be ignored and specifies the reason, which is required.
* **Returns** specifies the expected result to be returned from the method, which must have a compatible return type.
* **SetCategory(string)** applies a category to the test.
* **SetDescription(string)** sets the description property of the test.
* **SetName(string)** provides a name for the test. If not specified, a name is generated based on the method name and
  the arguments provided. See [Template Based Test Naming](xref:templatebasedtestnaming).
* **SetProperty(string, string)**, **SetProperty(string, int)** and **SetProperty(string, double)** apply a named
  property and value to the test.
* **TypeArgs** specifies the `Type`s to be used when targeting a generic test method. (_NUnit 4.1+_)

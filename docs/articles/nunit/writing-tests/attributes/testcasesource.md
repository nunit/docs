---
uid: testcasesourceattribute
---

# TestCaseSource

`TestCaseSourceAttribute` is used on a parameterized test method to
identify the source from which the required arguments will be provided.
The attribute additionally identifies the method as a test method.
The data is kept separate from the test itself and may be used by multiple
test methods. See [Parameterized Tests](xref:parameterizedtests) for a general introduction to
tests with arguments.

## Usage

Consider a test of the divide operation, taking three arguments: the numerator, the denominator and the expected result. We can specify the test and its data using one of the forms of **TestCaseSourceAttribute**:

### Form 1 - `[TestCaseSource(string sourceName)]`

> [!NOTE]
> We use [the `nameof` operator](https://docs.microsoft.com/dotnet/csharp/language-reference/operators/nameof) to avoid introducing [magic strings](https://wikipedia.org/wiki/Magic_string) into code, which offers better resilience when refactoring. While `nameof` is recommended, you could also use the string "DivideCases" to achieve the same outcome.

[!code-csharp[BasicTestCaseSource](~/snippets/Snippets.NUnit/TestCaseSourceExamples.cs#BasicTestCaseSource)]

The single attribute argument in this form is a string representing the name of the source used
to provide test cases. It has the following characteristics:

* It may be a field, property or method in the test class.
* It **must** be static. This is a change from NUnit 2.x.
* It must return an `IEnumerable` or a type that implements `IEnumerable`. For fields an array is generally used. For properties and methods, you may return an array or implement your own iterator.
* The individual items returned by the enumerator must be compatible
   with the signature of the method on which the attribute appears.
   See the **Test Case Construction** section below for details.

Sometimes we would like to parameterize the source, e.g. if we use the same source for multiple tests, to this end it is possible to pass parameters to the source, if the source is a method. The parameters are specified as an array of parameters that are passed to the source method.

[!code-csharp[ParameterizedSource](~/snippets/Snippets.NUnit/TestCaseSourceExamples.cs#ParameterizedSource)]

### Form 2 - `[TestCaseSource(Type sourceType, string sourceName)]`

[!code-csharp[ClassMethodAsTestCaseSource](~/snippets/Snippets.NUnit/TestCaseSourceExamples.cs#ClassMethodAsTestCaseSource)]

The first argument of the attribute in this form is a Type representing the class that will provide
the test cases.

The second argument is a string representing the name of the source used
to provide test cases. It has the following characteristics:

* It may be a field, property or method in the test class.
* It **must** be static. This is a change from NUnit 2.x.
* It must return an `IEnumerable` or a type that implements `IEnumerable`. For fields an array is generally used. For properties and methods, you may return an array or implement your own iterator.
* The individual items returned by the enumerator must be compatible
   with the signature of the method on which the attribute appears.
   See the **Test Case Construction** section below for details.

Similar to Form 1 it is possible to pass parameters to the source, if the source is a method.

### Form 3 - `[TestCaseSource(Type sourceType)]`

[!code-csharp[ClassWithoutMethodAsTestCaseSource](~/snippets/Snippets.NUnit/TestCaseSourceExamples.cs#ClassWithoutMethodAsTestCaseSource)]

The Type argument in this form represents the class that provides test cases.
It must have a default constructor and implement `IEnumerable`. The enumerator
should return test case data compatible with the signature of the test on which the attribute appears.
See the **Test Case Construction** section below for details.

Note that it is not possible to pass parameters to the source, even if the source is a method.

## Named Parameters

TestCaseSourceAttribute supports one named parameter:

* **Category** is used to assign one or more categories to every test case returned from this source.

## Test Case Construction

In constructing tests, NUnit uses each item returned by
the enumerator as follows:

* If it is an object derived from the `TestCaseParameters` class,
   its properties are used to provide the test case. NUnit provides
   the [TestCaseData](xref:testcasedata) type for this purpose.
* If the test has a single argument and the returned value matches the type of
   that argument it is used directly. This can eliminate a bit of extra typing by the programmer,
   as in this example:

[!code-csharp[SingleArgumentMatchingValueShorthand](~/snippets/Snippets.NUnit/TestCaseSourceExamples.cs#SingleArgumentMatchingValueShorthand)]

* If it is an `object[]`, its members are used to provide
   the arguments for the method. This is the approach taken in
   the three examples above.
* If it is an array of some other type, NUnit can use it provided
   that the arguments to the method are all of that type. For example,
   the above examples could be modified to make the three nested arrays
   of type `int[]`.
* If anything else is returned, it is used directly as the sole
   argument to the method. Because every returned value is used,
   NUnit is able to give an error message in cases where the method
   requires a different number of arguments or
   an argument of a different type.

## Notes

1. It is recommended that the SourceType not be the same as the test fixture class. It may be a nested class, however, and probably should be if the data is only used within that fixture.
2. A generic `IEnumerable` and `IEnumerator` may be used but NUnit will actually deal with the underlying `IEnumerator` in the current release.
3. The GetEnumerator method may use yield statements or simply return the enumerator for an array or other collection held by the class.

### Order of Execution

Individual test cases are executed in the order in which NUnit discovers them. This order does **not**
follow the lexical order of the attributes and will often vary between different
compilers or different versions of the CLR.

As a result, when **TestCaseSourceAttribute** appears multiple times on a
method or when other data-providing attributes are used in combination with
**TestCaseSourceAttribute**, the order of the test cases is undefined.

However, when a single **TestCaseSourceAttribute** is used by itself,
the order of the tests follows exactly the order in which the test cases
are returned from the source.

### Object Construction

NUnit locates the test cases at the time the tests are loaded. It creates
instances of each class used with the third form of the attribute and builds a list of
tests to be executed. Each data source class is only created once at this
time and is destroyed after all tests are loaded. By design, no communication is
possible between the load and execution phases except through the tests that
are created.

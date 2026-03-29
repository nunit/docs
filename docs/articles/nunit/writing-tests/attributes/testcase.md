---
uid: testcaseattribute
---

# TestCase

`TestCaseAttribute` serves the dual purpose of marking a method with parameters as a test method and providing inline
data to be used when invoking that method. Here is an example of a test being run three times, with three different sets
of data:

[!code-csharp[BasicTestCase](~/snippets/Snippets.NUnit/Attributes/TestCaseAttributeExamples.cs#BasicTestCase)]

> [!NOTE]
> Because arguments to .NET attributes are limited in terms of the Types that may be used, NUnit will make some
> attempt to convert the supplied values using `Convert.ChangeType()` before supplying it to the test.

**TestCaseAttribute** may appear one or more times on a test method, which may also carry other attributes providing
test data. The method may optionally be marked with the [Test Attribute](test.md) as well.

By using the named parameter `ExpectedResult` this test set may be simplified further:

[!code-csharp[TestCaseWithExpectedResult](~/snippets/Snippets.NUnit/Attributes/TestCaseAttributeExamples.cs#TestCaseWithExpectedResult)]

In the above example, NUnit checks that the return value of the method is equal to the expected result provided on the
attribute.

TestCaseAttribute supports a number of additional named parameters:

* **Author** sets the author of the test.
* **Category** provides a comma-delimited list of categories for this test.
* **Description** sets the description property of the test.
* **ExcludePlatform** specifies a comma-delimited list of platforms on which the test should not run.
* **ExpectedResult** sets the expected result to be returned from the method, which must have a compatible return type.
* **Explicit** is set to true in order to make the individual test case Explicit. Use **Reason** to explain why.
* **Ignore** causes the test case to be ignored and specifies the reason.
* **IgnoreReason** causes this test case to be ignored and specifies the reason.
* **IncludePlatform** specifies a comma-delimited list of platforms on which the test should run.
* **Reason** specifies the reason for not running this test case. Use in conjunction with **Explicit**.
* **TestName** provides a name for the test. If not specified, a name is generated based on the method name and the
  arguments provided. See [Template Based Test Naming](xref:templatebasedtestnaming).
* **TestOf** specifies the Type that this test is testing (this is not used within NUnit during test execution,
  but may serve a purpose for the test author)
* **TypeArgs** specifies the `Type`s to be used when targeting a generic test method. (_NUnit 4.1+_)

## Be aware of mixing the syntax for named parameters and attributes with the same name

### Correct `Ignore` Attribute Usage, by Example

> [!WARNING]
> When using the `Ignore` parameter (and others, see below), note that this has to be a named parameter. It is easy to accidentally add another `Ignore` attribute after the `TestCase` attribute. That will be the same as adding it separately, and it will apply to the complete fixture. This may apply to other named parameters, with names equal to other attributes, like the `Explicit` and `Category` parameters.

Correct example usage:

[!code-csharp[TestCaseWithIgnore](~/snippets/Snippets.NUnit/Attributes/TestCaseAttributeExamples.cs#TestCaseWithIgnore)]

![TestCaseIgnoreDoneCorrect](../../../../images/TestCaseIgnoreDoneCorrect.png)

> [!WARNING]
> **Wrong way!** Below, we demonstrate an incorrect approach.
>
> (1) Adding it on the same line is the same as adding it on a separate line (3), both results in the fixture being ignored (2).

![TestCaseIgnoreGoneWrong](../../../../images/TestCaseIgnoreGoneWrong.png)

<!-- cspell:disable-next-line -->
_Thanks to [Geir Marius Gjul](https://github.com/GeirMG) for raising this question again._

### Correct `Explicit` Attribute Usage, by Example

`Explicit`, used correctly, looks like the following:

[!code-csharp[TestCaseWithExplicit](~/snippets/Snippets.NUnit/Attributes/TestCaseAttributeExamples.cs#TestCaseWithExplicit)]

Note that adding the `Reason` is optional, and Visual Studio TestExplorer will not even show it.

### Correct `Category` Attribute Usage, by Example

Categories can be applied to a single `TestCase` the same way, as a named parameter. Otherwise, it will apply to the whole fixture. Be sure what you're asking for!

[!code-csharp[TestCaseWithCategory](~/snippets/Snippets.NUnit/Attributes/TestCaseAttributeExamples.cs#TestCaseWithCategory)]

## Order of Execution

Individual test cases are executed in the order in which NUnit discovers them. This order does **not** necessarily
follow the lexical order of the attributes and will often vary between different compilers or different versions of the
CLR.

As a result, when **TestCaseAttribute** appears multiple times on a method or when other data-providing attributes are
used in combination with **TestCaseAttribute**, the order of the test cases is undefined.

## Generic TestCase Attributes

NUnit provides generic versions of `TestCaseAttribute` that offer compile-time type safety for test arguments. These are
available as `TestCaseAttribute<T>` through `TestCaseAttribute<T1, T2, T3, T4, T5>`, supporting up to 5 type parameters.

> [!NOTE]
> From NUnit 4.6
> Generic TestCase attributes are only available on .NET 6.0 and later. They are not supported on .NET Framework.

### Single Type Parameter

[!code-csharp[GenericTestCaseSingleType](~/snippets/Snippets.NUnit/Attributes/TestCaseGenericExamples.cs#GenericTestCaseSingleType)]

### Multiple Type Parameters

[!code-csharp[GenericTestCaseTwoTypes](~/snippets/Snippets.NUnit/Attributes/TestCaseGenericExamples.cs#GenericTestCaseTwoTypes)]

### With Expected Result

Generic TestCase attributes support all the same named parameters as the regular `TestCaseAttribute`:

[!code-csharp[GenericTestCaseWithExpectedResult](~/snippets/Snippets.NUnit/Attributes/TestCaseGenericExamples.cs#GenericTestCaseWithExpectedResult)]

### Mixing Generic and Regular TestCase

You can mix generic and regular `TestCase` attributes on the same method:

[!code-csharp[GenericTestCaseMixedWithRegular](~/snippets/Snippets.NUnit/Attributes/TestCaseGenericExamples.cs#GenericTestCaseMixedWithRegular)]

### Benefits of Generic TestCase

* **Compile-time type checking**: Errors are caught at compile time rather than runtime
* **Better IDE support**: IntelliSense provides accurate parameter types
* **Clearer intent**: The expected types are explicit in the attribute declaration
* **Refactoring safety**: Type changes are caught by the compiler

### Comparison with TypeArgs

The `TypeArgs` named parameter provides similar functionality but is specified at runtime:

```csharp
// Using TypeArgs (runtime type specification)
[TestCase(42, TypeArgs = new[] { typeof(int) })]
public void TestWithTypeArgs<T>(T value) { }

// Using generic attribute (compile-time type specification)
[TestCase<int>(42)]
public void TestWithGenericAttribute<T>(T value) { }
```

Both approaches are valid; choose based on your needs:

* Use **generic attributes** when you want compile-time type safety
* Use **TypeArgs** when you need to specify types dynamically or when targeting .NET Framework

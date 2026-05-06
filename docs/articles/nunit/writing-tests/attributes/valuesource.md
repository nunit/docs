---
uid: attribute-valuesource
---

# ValueSource

`ValueSourceAttribute` is used on individual parameters of a test method to identify a named data source for argument values.

## Constructors

```csharp
ValueSourceAttribute(Type sourceType, string sourceName)
ValueSourceAttribute(string sourceName)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `sourceType` | `Type` | Type that provides the source member. Optional. |
| `sourceName` | `string` | Name of source field, property, or method. |

## Applies To

| Method Parameters | Test Methods | Test Fixtures (Classes) | Assembly |
|-------------------|--------------|--------------------------|----------|
| ✅ | ❌ | ❌ | ❌ |

## Example

[!code-csharp[ValueSourceBasic](~/snippets/Snippets.NUnit/Attributes/ValueSourceAttributeExamples.cs#ValueSourceBasic)]

## Source Requirements

- Source may be a field, non-indexed property, or parameterless method.
- Source member must be static.
- Source must return `IEnumerable` (or async forms supported by NUnit).
- Returned items must be compatible with the annotated parameter type.

## Order of Execution

Individual test cases are executed in the order in which NUnit discovers them. This order does **not** follow the
lexical order of the attributes and will often vary between different compilers or different versions of the CLR.

As a result, when **ValueSourceAttribute** appears multiple times on a parameter or when other data-providing attributes
are used in combination with **ValueSourceAttribute**, the order of the arguments is undefined.

However, when a single **ValueSourceAttribute** is used by itself, the order of the arguments follows exactly the order
in which the data is returned from the source.

## Note on Object Construction

NUnit locates the test cases at the time the tests are loaded, creates instances of each class with non-static sources
and builds a list of tests to be executed. Each source object is only created once at this time and is destroyed after
all tests are loaded.

If the data source is in the test fixture itself, the object is created using the appropriate constructor for the
fixture parameters provided on the **TestFixtureAttribute**, or the default constructor if no parameters were specified.
Since this object is destroyed before the tests are run, no communication is possible between these two phases - or
between different runs - except through the parameters themselves.

## See Also

* [TestCaseSource Attribute](xref:attribute-testcasesource)
* [Values Attribute](xref:attribute-values)

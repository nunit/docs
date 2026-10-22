---
uid: attribute-testof
---

# TestOf

`TestOfAttribute` is used to specify the class or type that a test fixture or test method is testing. This metadata helps document the relationship between tests and the code under test, and can be used by test runners and reporting tools to organize test results.

## What It Does

`TestOf` is **informational only**. It has no effect on how NUnit discovers, orders or executes tests, and it does not
check that the named type exists or is actually exercised by the test. The attribute simply records a `TestOf` property
on the test, holding the full name of the type. That property appears in the XML result file and is available to
runners, report generators and other tools that display test properties. It can also be used to select tests by
property in the console runner's [Test Selection Language](xref:testselectionlanguage), in the same way as any other
property.

## Constructors

```csharp
TestOfAttribute(Type type)
TestOfAttribute(string typeName)
```

| Parameter  | Type     | Description                                                  |
| ---------- | -------- | ------------------------------------------------------------ |
| `type`     | `Type`   | The type that is being tested. The full type name is stored. |
| `typeName` | `string` | The name of the type that is being tested.                   |

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
| ------------ | ----------------------- | -------- |
| ✅           | ✅                      | ✅       |

## Alternative Syntax

`TestOf` can also be specified as a named parameter on `[TestFixture]` or `[Test]` attributes:

```csharp
[TestFixture(TestOf = typeof(MyClass))]
[Test(TestOf = typeof(MyClass))]
```

## Examples

### Using the Attribute

[!code-csharp[TestOfBasic](~/snippets/Snippets.NUnit/Attributes/TestOfAttributeExamples.cs#TestOfBasic)]

### Using String Names

[!code-csharp[TestOfString](~/snippets/Snippets.NUnit/Attributes/TestOfAttributeExamples.cs#TestOfString)]

### Using Named Parameter Syntax

[!code-csharp[TestOfNamedParameter](~/snippets/Snippets.NUnit/Attributes/TestOfAttributeExamples.cs#TestOfNamedParameter)]

## Notes

1. This attribute inherits from `PropertyAttribute` and sets the `TestOf` property with the full type name.
2. Using `typeof()` is preferred over string names as it provides compile-time type checking.
3. For string names, consider using `nameof()` for compile-time safety when the type is accessible.
4. Multiple `TestOf` attributes can be applied to the same element when a test covers multiple types.

## See Also

* [Property Attribute](xref:attribute-property)
* [Description Attribute](xref:attribute-description)
* [Category Attribute](xref:attribute-category)

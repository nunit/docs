---
uid: propertyattribute
---

# Property

`PropertyAttribute` provides a generalized approach to setting named properties on any test case or fixture, using a name/value pair. Properties can be used for test filtering, reporting, and custom test organization.

## Constructors

```csharp
PropertyAttribute(string propertyName, string propertyValue)
PropertyAttribute(string propertyName, int propertyValue)
PropertyAttribute(string propertyName, double propertyValue)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `propertyName` | `string` | The name of the property. |
| `propertyValue` | `string`, `int`, or `double` | The value of the property. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Properties` | `IPropertyBag` | Gets the property dictionary for this attribute. |

## Applies To

This attribute can be applied to:

- **Assembly** - Sets properties for all tests in the assembly
- **Test Fixture (Class)** - Sets properties for all tests in the fixture
- **Test Method** - Sets properties for a specific test

Multiple `PropertyAttribute` instances can be applied to the same element (`AllowMultiple = true`).

## Examples

### Basic Usage

[!code-csharp[BasicProperty](~/snippets/Snippets.NUnit/Attributes/PropertyAttributeExamples.cs#BasicProperty)]

### Different Property Value Types

[!code-csharp[PropertyTypes](~/snippets/Snippets.NUnit/Attributes/PropertyAttributeExamples.cs#PropertyTypes)]

### Accessing Properties in Tests

[!code-csharp[AccessingProperties](~/snippets/Snippets.NUnit/Attributes/PropertyAttributeExamples.cs#AccessingProperties)]

### Custom Property Attributes

You can define custom attributes that derive from `PropertyAttribute` for type-safe, domain-specific properties:

[!code-csharp[CustomPropertyAttribute](~/snippets/Snippets.NUnit/Attributes/PropertyAttributeExamples.cs#CustomPropertyAttribute)]

## Notes

1. `PropertyAttribute` is not used by NUnit itself for test execution. Properties are displayed in XML output and the Test Properties dialog.
2. You can use properties with the `--where` option on the command-line to select tests to run. See [Test Selection Language](xref:testselectionlanguage). Filtering only works for properties with `string` values.
3. Tests can access properties through [TestContext](xref:testcontext) using `TestContext.CurrentContext.Test.Properties`.
4. When creating custom property attributes, the property name is derived from the class name with the "Attribute" suffix removed (e.g., `SeverityAttribute` becomes property name `"Severity"`).

## See Also

* [TestContext](xref:testcontext)
* [Test Selection Language](xref:testselectionlanguage)
* [Category Attribute](category.md)
* [Description Attribute](description.md)

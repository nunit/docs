---
uid: description-attribute
---

# Description

`DescriptionAttribute` is used to apply descriptive text to a test, test fixture, or assembly. The description appears in test output and XML result files, providing additional context about what a test does.

## Constructor

```csharp
DescriptionAttribute(string description)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `description` | `string` | The descriptive text for the test or fixture. |

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ✅ | ✅ | ✅ |

## Alternative Syntax

`Description` can also be specified as a named parameter on `[TestFixture]` or `[Test]` attributes:

```csharp
[TestFixture(Description = "Tests for user authentication")]
[Test(Description = "Verifies login with valid credentials")]
```

## Examples

### Fixture Level

[!code-csharp[DescriptionFixture](~/snippets/Snippets.NUnit/Attributes/DescriptionAttributeExamples.cs#DescriptionFixture)]

### Method Level

[!code-csharp[DescriptionMethod](~/snippets/Snippets.NUnit/Attributes/DescriptionAttributeExamples.cs#DescriptionMethod)]

### Using Named Parameter Syntax

[!code-csharp[DescriptionNamedParameter](~/snippets/Snippets.NUnit/Attributes/DescriptionAttributeExamples.cs#DescriptionNamedParameter)]

## Notes

1. This attribute inherits from `PropertyAttribute` and sets the `Description` property.
2. Only one description can be applied per element (`AllowMultiple = false`).
3. If both the `[Description]` attribute and the `Description` property on `[Test]`/`[TestFixture]` are used, the `[Description]` attribute takes precedence.
4. Descriptions are useful for generating readable test reports and documentation.

## See Also

* [Property Attribute](property.md)
* [Author Attribute](author.md)
* [Category Attribute](category.md)

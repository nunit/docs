# SetUICulture

`SetUICultureAttribute` is used to set the current `CultureInfo.CurrentUICulture` for the duration of a test. The UI culture remains set until the test or fixture completes and is then reset to its original value.

This attribute affects resource loading operations. When your application uses `ResourceManager` to load localized strings, images, or other resources, it uses `CurrentUICulture` to determine which localized resources to load.

## Constructor

```csharp
SetUICultureAttribute(string culture)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `culture` | `string` | The name of the UI culture to use (e.g., `"fr-FR"`, `"de-DE"`, `"en-US"`). Must be a valid culture name recognized by `CultureInfo`. |

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ✅ | ✅ | ✅ |

> [!NOTE]
> If `SetUICultureAttribute` is applied at fixture or assembly level, the UI culture setting applies to all contained tests.

When applied at multiple levels, the most specific level takes precedence. The attribute is inherited by derived test fixtures.

## Examples

### Setting UI Culture on a Fixture

[!code-csharp[SetUICultureOnFixture](~/snippets/Snippets.NUnit/Attributes/SetUICultureAttributeExamples.cs#SetUICultureOnFixture)]

### Setting UI Culture on Individual Methods

[!code-csharp[SetUICultureOnMethod](~/snippets/Snippets.NUnit/Attributes/SetUICultureAttributeExamples.cs#SetUICultureOnMethod)]

### Using Both SetCulture and SetUICulture

Use both attributes when you need to test with different formatting and UI cultures:

[!code-csharp[BothCultures](~/snippets/Snippets.NUnit/Attributes/SetUICultureAttributeExamples.cs#BothCultures)]

## Notes

1. Only one UI culture may be specified per attribute. To test with multiple cultures, create separate test methods or use parameterized tests.
2. `SetUICulture` affects `CultureInfo.CurrentUICulture`, which controls resource loading. It does **not** affect `CultureInfo.CurrentCulture` (formatting). Use `SetCulture` for formatting operations.
3. If you need to conditionally run tests based on the current culture (rather than setting it), use the `Culture` attribute instead.

## See Also

* [SetCulture Attribute](setculture.md)
* [Culture Attribute](culture.md)

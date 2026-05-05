# SetCulture

`SetCultureAttribute` is used to set the current `CultureInfo.CurrentCulture` for the duration of a test. The culture remains set until the test or fixture completes and is then reset to its original value.

This attribute affects formatting operations such as number formatting, date formatting, and string comparisons that depend on culture settings.

## Constructor

```csharp
SetCultureAttribute(string culture)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `culture` | `string` | The name of the culture to use (e.g., `"fr-FR"`, `"de-DE"`, `"en-US"`). Must be a valid culture name recognized by `CultureInfo`. |

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ✅ | ✅ | ✅ |

> [!NOTE]
> If `SetCultureAttribute` is applied at fixture or assembly level, the culture setting applies to all contained tests.

When applied at multiple levels, the most specific level takes precedence. The attribute is inherited by derived test fixtures.

## Examples

### Setting Culture on a Fixture

[!code-csharp[SetCultureOnFixture](~/snippets/Snippets.NUnit/Attributes/SetCultureAttributeExamples.cs#SetCultureOnFixture)]

### Setting Culture on Individual Methods

[!code-csharp[SetCultureOnMethod](~/snippets/Snippets.NUnit/Attributes/SetCultureAttributeExamples.cs#SetCultureOnMethod)]

### Combining with SetUICulture

[!code-csharp[SetCultureWithSetUICulture](~/snippets/Snippets.NUnit/Attributes/SetCultureAttributeExamples.cs#SetCultureWithSetUICulture)]

## Notes

1. Only one culture may be specified per attribute. To test with multiple cultures, create separate test methods or use parameterized tests.
2. `SetCulture` affects `CultureInfo.CurrentCulture`, which controls formatting operations. Use `SetUICulture` to control `CultureInfo.CurrentUICulture` for resource loading.
3. If you need to conditionally run tests based on the current culture (rather than setting it), use the `Culture` attribute instead.

## See Also

* [SetUICulture Attribute](setuiculture.md)
* [Culture Attribute](culture.md)

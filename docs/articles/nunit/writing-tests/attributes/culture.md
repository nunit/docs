# Culture

`CultureAttribute` is used to specify cultures for which a test or fixture should be run. It does **not** change the culture setting, but merely uses it to determine whether to run the test. If the specified culture requirements are not met, the test is skipped.

This attribute is useful for providing alternative tests under different cultures, or for skipping tests that are not applicable to certain cultures.

## Constructors

```csharp
CultureAttribute()
CultureAttribute(string cultures)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `cultures` | `string` | A comma-delimited list of culture names to include. You may specify either specific cultures like `"en-GB"` or neutral cultures like `"de"`. |

## Properties

| Property | Type | Description | Default |
|----------|------|-------------|---------|
| `Include` | `string` | Comma-delimited list of cultures on which the test should run. | `null` |
| `Exclude` | `string` | Comma-delimited list of cultures on which the test should **not** run. | `null` |
| `Reason` | `string` | The reason for including or excluding the test. Displayed when the test is skipped. | `null` |

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ✅ | ✅ | ✅ |

## Examples

### Including Specific Cultures

[!code-csharp[CultureInclude](~/snippets/Snippets.NUnit/Attributes/CultureAttributeExamples.cs#CultureInclude)]

### Excluding Cultures

[!code-csharp[CultureExclude](~/snippets/Snippets.NUnit/Attributes/CultureAttributeExamples.cs#CultureExclude)]

### Applying to a Fixture

[!code-csharp[CultureOnFixture](~/snippets/Snippets.NUnit/Attributes/CultureAttributeExamples.cs#CultureOnFixture)]

### Providing a Reason

[!code-csharp[CultureWithReason](~/snippets/Snippets.NUnit/Attributes/CultureAttributeExamples.cs#CultureWithReason)]

## Notes

1. When specifying a neutral culture (e.g., `"fr"`), the test will run on any specific culture variant (e.g., `fr-FR`, `fr-CA`, `fr-BE`).
2. If both `Include` and `Exclude` are specified, `Include` is evaluated first.
3. This attribute does **not** change the culture. To change the culture for a test, use `SetCulture` or `SetUICulture` instead.
4. Tests that are skipped due to culture requirements appear as "Skipped" in test results with the reason displayed.

## See Also

* [SetCulture Attribute](setculture.md)
* [SetUICulture Attribute](setuiculture.md)

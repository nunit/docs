# Datapoint

`DatapointAttribute` is used to mark a field as providing a single data value for [Theory](theory.md) tests. When NUnit executes a Theory, it uses all fields of matching type annotated with `[Datapoint]` to supply argument values.

This attribute is ignored for ordinary tests, including parameterized tests using `[TestCase]`.

## Usage

This is a parameterless attribute that can only be applied to fields.

```csharp
[Datapoint]
```

## Applies To

- **Fields** - The field type must exactly match the Theory parameter type for which data is being supplied.

## Examples

### Basic Usage

[!code-csharp[DatapointBasic](~/snippets/Snippets.NUnit/Attributes/DatapointAttributeExamples.cs#DatapointBasic)]

### With Enums and Automatic Datapoints

[!code-csharp[DatapointWithEnum](~/snippets/Snippets.NUnit/Attributes/DatapointAttributeExamples.cs#DatapointWithEnum)]

### Multiple Types

[!code-csharp[DatapointMultipleTypes](~/snippets/Snippets.NUnit/Attributes/DatapointAttributeExamples.cs#DatapointMultipleTypes)]

## Automatically Supplied Datapoints

NUnit automatically supplies datapoints for certain types:

| Type | Automatic Values |
|------|-----------------|
| `bool` | `true`, `false` |
| Any `enum` | All defined enum values |

If you supply any datapoints for a parameter type, automatic datapoint generation for that type is suppressed.

## Notes

1. Fields must be members of the class containing the Theory.
2. The field type must **exactly** match the parameter type - no implicit conversions are performed.
3. Use `DatapointSource` when you need to provide multiple values from a single source (arrays, collections, or methods).
4. Datapoints from multiple fields of the same type are combined.

## See Also

* [DatapointSource Attribute](datapointsource.md)
* [Theory Attribute](theory.md)
* [Parameterized Tests](xref:parameterizedtests)

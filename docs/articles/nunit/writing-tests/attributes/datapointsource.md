# DatapointSource

`DatapointSourceAttribute` is used to mark a field, property, or method as providing a collection of data values for [Theory](theory.md) tests. The source must return either an array of the required type or an `IEnumerable<T>`.

This attribute is ignored for ordinary tests, including parameterized tests using `[TestCase]`.

## Usage

This is a parameterless attribute that can be applied to fields, properties, or methods.

```csharp
[DatapointSource]
```

## Applies To

- **Fields** - Must be an array or `IEnumerable<T>` of the required type
- **Properties** - Must return an array or `IEnumerable<T>` of the required type
- **Methods** - Must return an array or `IEnumerable<T>` of the required type (parameterless)

The element type must exactly match the Theory parameter type for which data is being supplied.

## Example

[!code-csharp[DatapointSource](~/snippets/Snippets.NUnit/Attributes/DatapointAttributeExamples.cs#DatapointSource)]

## Automatically Supplied Datapoints

NUnit automatically supplies datapoints for certain types:

| Type | Automatic Values |
|------|-----------------|
| `bool` | `true`, `false` |
| Any `enum` | All defined enum values |

If you supply any datapoints for a parameter type, automatic datapoint generation for that type is suppressed.

## Notes

1. The data source must be a member of the class containing the Theory.
2. The element type must **exactly** match the parameter type - no implicit conversions are performed.
3. Multiple `DatapointSource` attributes of the same type are combined.
4. Use `Datapoint` when you only need to provide a single value from a field.
5. The obsolete `DatapointsAttribute` was replaced by `DatapointSourceAttribute` in earlier versions.

## See Also

* [Datapoint Attribute](datapoint.md)
* [Theory Attribute](theory.md)
* [Parameterized Tests](xref:parameterizedtests)

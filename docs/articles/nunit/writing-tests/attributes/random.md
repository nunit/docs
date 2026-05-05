---
uid: randomattribute
---

# Random

`RandomAttribute` is used to specify a set of random values to be provided for an individual parameter of a parameterized test method. It supports numeric types, `Guid`, and enums.

## Constructors

### Count Only (Auto-detect Type)

```csharp
RandomAttribute(int count)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `count` | `int` | The number of random values to generate. The type is inferred from the parameter. |

### With Range (Type-specific)

```csharp
RandomAttribute(int min, int max, int count)
RandomAttribute(double min, double max, int count)
// Also available for: uint, long, ulong, short, ushort, byte, sbyte, float
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `min` | varies | The minimum value (inclusive). |
| `max` | varies | The maximum value (exclusive). |
| `count` | `int` | The number of random values to generate. |

## Properties

| Property | Type | Description | Default |
|----------|------|-------------|---------|
| `Distinct` | `bool` | When `true`, no value will be repeated among the generated values. | `false` |

## Applies To

- **Parameters** - Can only be applied to method parameters.

## Supported Types

| Type | Count-only | With Range |
|------|------------|------------|
| `int`, `uint`, `long`, `ulong` | Yes | Yes |
| `short`, `ushort`, `byte`, `sbyte` | Yes | Yes |
| `double`, `float` | Yes | Yes |
| `decimal` | Yes | No (use `int` or `double` range) |
| `Guid` | Yes | No |
| `enum` | Yes | No |

## Examples

### Basic Usage

[!code-csharp[RandomBasic](~/snippets/Snippets.NUnit/Attributes/RandomAttributeExamples.cs#RandomBasic)]

### With Range

[!code-csharp[RandomWithRange](~/snippets/Snippets.NUnit/Attributes/RandomAttributeExamples.cs#RandomWithRange)]

### Distinct Values

[!code-csharp[RandomDistinct](~/snippets/Snippets.NUnit/Attributes/RandomAttributeExamples.cs#RandomDistinct)]

### Random GUIDs

[!code-csharp[RandomGuid](~/snippets/Snippets.NUnit/Attributes/RandomAttributeExamples.cs#RandomGuid)]

### Combined with Other Attributes

[!code-csharp[RandomCombined](~/snippets/Snippets.NUnit/Attributes/RandomAttributeExamples.cs#RandomCombined)]

## Notes

1. By default, NUnit creates test cases from all combinations of parameter values (combinatorial). Use `[Sequential]` to pair values in order instead.
2. There is no constructor for `decimal` min/max because .NET does not support decimal in attribute constructors. Use an `int` or `double` range instead - values will be converted.
3. `Guid` does not support min/max ranges - only the count-only constructor works.
4. When using `Distinct = true`, ensure the range is large enough to provide the requested number of distinct values.
5. `Guid` support was added in **NUnit 4.0**.

## See Also

* [Values Attribute](values.md)
* [Range Attribute](range.md)
* [Sequential Attribute](sequential.md)
* [Combinatorial Attribute](combinatorial.md)
* [Pairwise Attribute](pairwise.md)
* [Randomizer Methods](xref:randomizermethods)

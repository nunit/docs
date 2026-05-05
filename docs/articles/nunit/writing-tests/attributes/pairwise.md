---
uid: pairwiseattribute
---

# Pairwise

`PairwiseAttribute` tells NUnit to generate test cases so all possible pairs of parameter values are covered, while using fewer cases than full combinatorial generation.

## Usage

This is a parameterless attribute that can only be applied to test methods.

```csharp
[Pairwise]
```

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ✅ | ❌ | ❌ |

## Example

Using the Combinatorial attribute, the following test would be executed 12 (3x2x2) times.
With **Pairwise** it is executed only enough times so that each possible pair is covered..

[!code-csharp[PairwiseBasic](~/snippets/Snippets.NUnit/Attributes/PairwiseAttributeExamples.cs#PairwiseBasic)]

For this test, NUnit currently calls the method six times, producing the following output:

```none
a - x
a + y
b - y
b + x
c - x
c + y
```

Note that this is not the optimal output. The pairs (-, x) and (+, y)
appear twice. NUnit uses a heuristic algorithm to reduce the number of test cases as much
as it can. Improvements may be made in the future.

## Notes

1. Pairwise generation is heuristic and may not produce the theoretical minimum number of test cases.
2. When used on generic methods, ensure generated combinations are valid for all type constraints.
3. Use `Combinatorial` when you need full coverage of all combinations.

## See Also

* [Sequential Attribute](sequential.md)
* [Combinatorial Attribute](combinatorial.md)

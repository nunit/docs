---
uid: constraint-nan
---

# NaN Constraint

`NaNConstraint` tests that a floating-point value is `NaN` (Not a Number).

## Usage

```csharp
Is.NaN
Is.Not.NaN
```

## Examples

[!code-csharp[NaNConstraintExamples](~/snippets/Snippets.NUnit/Constraints/SpecialConstraintSnippets.cs#NaNConstraintExamples)]

## Notes

1. NaN is the only value that is not equal to itself (`NaN != NaN` is true).
2. Both `double.NaN` and `float.NaN` are supported.
3. Infinity values are not NaN.

## See Also

* [EqualConstraint](EqualConstraint.md) - For numeric comparisons with tolerance

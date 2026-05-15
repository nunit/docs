---
uid: constraint-multipleof
---

# MultipleOf Constraint

`MultipleOfConstraint` tests that a numeric value is a multiple of a specified number. It also provides convenient
shortcuts for testing even and odd numbers.

## Usage

```csharp
Is.MultipleOf(int factor)
Is.Even
Is.Odd
```

## Examples

[!code-csharp[MultipleOfConstraintExamples](~/snippets/Snippets.NUnit/Constraints/SpecialConstraintSnippets.cs#MultipleOfConstraintExamples)]

## Notes

1. `Is.Even` is equivalent to `Is.MultipleOf(2)`.
2. `Is.Odd` is the negation - a number that is not a multiple of 2.
3. Works with all integer types (`int`, `long`, `short`, etc.).
4. Zero is considered even (`Is.MultipleOf(n)` passes for any `n` when actual is 0).

## See Also

* [Range Constraint](RangeConstraint.md) - Test if value is within a range
* [GreaterThan Constraint](GreaterThanConstraint.md) - Numeric comparisons

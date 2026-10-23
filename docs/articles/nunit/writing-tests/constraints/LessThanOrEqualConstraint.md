---
uid: constraint-lessthanorequal
---

# LessThanOrEqual Constraint

`LessThanOrEqualConstraint` tests that one value is less than or equal to another. It works with numeric types,
`DateTime`, `TimeSpan`, and any type implementing `IComparable`. For custom types, a user-specified comparer can be
provided using the `Using` modifier.

## Usage

```csharp
Is.LessThanOrEqualTo(object expected)
Is.AtMost(object expected)               // Alias for LessThanOrEqualTo
```

## Modifiers

```csharp
.Using(IComparer comparer)
.Using<T>(IComparer<T> comparer)
.Using<T>(Comparison<T> comparer)
.Within(object tolerance)
      .Percent
```

## Examples

[!code-csharp[LessThanOrEqualConstraintExamples](~/snippets/Snippets.NUnit/Constraints/ComparisonConstraintSnippets.cs#LessThanOrEqualConstraintExamples)]

### Using Custom Comparers

[!code-csharp[With Comparer](~/snippets/Snippets.NUnit/ConstraintExamples.cs#MyComparerExample)]

## Notes

1. `Is.AtMost` is a more readable alias for `Is.LessThanOrEqualTo`.
2. `Within` relaxes the bound by the tolerance, in the actual value's favour: `Is.LessThanOrEqualTo(10).Within(1)` passes
   for any value less than or equal to 11. The tolerance may be linear or `Percent`, and from NUnit 4.1 a `TimeSpan` tolerance
   may be used with `DateTime` and `TimeSpan` bounds. See [Tolerances](Tolerance.md#comparison-constraints).

## See Also

* [LessThan Constraint](LessThanConstraint.md)
* [GreaterThanOrEqual Constraint](GreaterThanOrEqualConstraint.md)
* [Range Constraint](RangeConstraint.md)
* [Tolerances](Tolerance.md)

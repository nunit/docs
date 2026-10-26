---
uid: constraint-lessthan
---

# LessThan Constraint

`LessThanConstraint` tests that one value is less than another. It works with numeric types, `DateTime`, `TimeSpan`, and
any type implementing `IComparable`. For custom types, a user-specified comparer can be provided using the `Using`
modifier.

## Usage

```csharp
Is.LessThan(object expected)
Is.Negative                     // Equivalent to Is.LessThan(0)
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

[!code-csharp[LessThanConstraintExamples](~/snippets/Snippets.NUnit/Constraints/ComparisonConstraintSnippets.cs#LessThanConstraintExamples)]

### Using Custom Comparers

[!code-csharp[With Comparer](~/snippets/Snippets.NUnit/ConstraintExamples.cs#MyComparerExample)]

## Notes

1. `Within` relaxes the bound by the tolerance, in the actual value's favour: `Is.LessThan(10).Within(1)` passes
   for any value less than 11. The tolerance may be linear or `Percent`, and from NUnit 4.1 a `TimeSpan` tolerance
   may be used with `DateTime` and `TimeSpan` bounds. See [Tolerances](Tolerance.md#comparison-constraints).
2. `Is.Negative` is a convenience shorthand for `Is.LessThan(0)`.

## See Also

* [GreaterThan Constraint](GreaterThanConstraint.md)
* [LessThanOrEqual Constraint](LessThanOrEqualConstraint.md)
* [Range Constraint](RangeConstraint.md)
* [Tolerances](Tolerance.md)

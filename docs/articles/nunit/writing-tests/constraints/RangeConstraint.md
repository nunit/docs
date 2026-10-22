---
uid: constraint-range
---

# Range Constraint

`RangeConstraint` tests that a value falls within an inclusive range. Both the lower and upper bounds are included in
the valid range.

## Usage

```csharp
Is.InRange(IComparable from, IComparable to)
```

## Modifiers

```csharp
.Using(IComparer comparer)
.Using<T>(IComparer<T> comparer)
.Using<T>(Comparison<T> comparer)
```

## Examples

[!code-csharp[RangeConstraintExamples](~/snippets/Snippets.NUnit/Constraints/ComparisonConstraintSnippets.cs#RangeConstraintExamples)]

## Notes

1. The range is **inclusive** on both ends: `Is.InRange(1, 10)` passes for values 1, 10, and everything in between.
2. `from` must be less than or equal to `to`, otherwise the constraint throws an `ArgumentException`. Negative bounds
   are fine, but the range must be written in increasing order: use `Is.InRange(-10, 0)`, not `Is.InRange(0, -10)`.
   If the bounds are computed and could end up in either order, sort them first:

   ```csharp
   int lower = Math.Min(a, b);
   int upper = Math.Max(a, b);
   Assert.That(actual, Is.InRange(lower, upper));
   ```

3. For exclusive bounds, combine `Is.GreaterThan` and `Is.LessThan` with `And`:

   ```csharp
   Assert.That(5, Is.GreaterThan(1).And.LessThan(10));  // Exclusive bounds
   ```

## See Also

* [GreaterThan Constraint](GreaterThanConstraint.md)
* [LessThan Constraint](LessThanConstraint.md)
* [GreaterThanOrEqual Constraint](GreaterThanOrEqualConstraint.md)
* [LessThanOrEqual Constraint](LessThanOrEqualConstraint.md)

---
uid: constraint-greaterthan
---

# GreaterThan Constraint

`GreaterThanConstraint` tests that one value is greater than another. It works with numeric types, `DateTime`,
`TimeSpan`, and any type implementing `IComparable`. For custom types, a user-specified comparer can be provided using
the `Using` modifier.

## Usage

```csharp
Is.GreaterThan(object expected)
Is.Positive                      // Equivalent to Is.GreaterThan(0)
```

## Modifiers

```csharp
.Using(IComparer comparer)
.Using<T>(IComparer<T> comparer)
.Using<T>(Comparison<T> comparer)
.Within(object tolerance)
```

## Examples

[!code-csharp[GreaterThanConstraintExamples](~/snippets/Snippets.NUnit/Constraints/ComparisonConstraintSnippets.cs#GreaterThanConstraintExamples)]

### Using Custom Comparers

[!code-csharp[With Comparer](~/snippets/Snippets.NUnit/ConstraintExamples.cs#MyComparerExample)]

## Notes

1. When comparing floating-point numbers, consider using `.Within()` to specify a tolerance.
2. `Is.Positive` is a convenience shorthand for `Is.GreaterThan(0)`.

## See Also

* [LessThan Constraint](LessThanConstraint.md)
* [GreaterThanOrEqual Constraint](GreaterThanOrEqualConstraint.md)
* [Range Constraint](RangeConstraint.md)

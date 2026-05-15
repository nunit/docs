---
uid: constraint-greaterthanorequal
---

# GreaterThanOrEqual Constraint

`GreaterThanOrEqualConstraint` tests that one value is greater than or equal to another. It works with numeric types,
`DateTime`, `TimeSpan`, and any type implementing `IComparable`. For custom types, a user-specified comparer can be
provided using the `Using` modifier.

## Usage

```csharp
Is.GreaterThanOrEqualTo(object expected)
Is.AtLeast(object expected)              // Alias for GreaterThanOrEqualTo
```

## Modifiers

```csharp
.Using(IComparer comparer)
.Using<T>(IComparer<T> comparer)
.Using<T>(Comparison<T> comparer)
.Within(object tolerance)
```

## Examples

[!code-csharp[GreaterThanOrEqualConstraintExamples](~/snippets/Snippets.NUnit/Constraints/ComparisonConstraintSnippets.cs#GreaterThanOrEqualConstraintExamples)]

### Using Custom Comparers

[!code-csharp[With Comparer](~/snippets/Snippets.NUnit/ConstraintExamples.cs#MyComparerExample)]

## Notes

1. `Is.AtLeast` is a more readable alias for `Is.GreaterThanOrEqualTo`.
2. When comparing floating-point numbers, consider using `.Within()` to specify a tolerance.

## See Also

* [GreaterThan Constraint](GreaterThanConstraint.md)
* [LessThanOrEqual Constraint](LessThanOrEqualConstraint.md)
* [Range Constraint](RangeConstraint.md)

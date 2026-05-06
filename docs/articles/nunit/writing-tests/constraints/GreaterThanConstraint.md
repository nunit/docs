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

```csharp
Assert.That(7, Is.GreaterThan(3));
Assert.That(5, Is.Positive);
Assert.That(-3, Is.Not.Positive);

// With DateTime
Assert.That(DateTime.Now, Is.GreaterThan(DateTime.Today));

// With tolerance
Assert.That(10.5, Is.GreaterThan(10.0).Within(0.1));
```

### Using Custom Comparers

[!code-csharp[With Comparer](~/snippets/Snippets.NUnit/ConstraintExamples.cs#MyComparerExample)]

## Notes

1. When comparing floating-point numbers, consider using `.Within()` to specify a tolerance.
2. `Is.Positive` is a convenience shorthand for `Is.GreaterThan(0)`.

## See Also

* [LessThan Constraint](LessThanConstraint.md)
* [GreaterThanOrEqual Constraint](GreaterThanOrEqualConstraint.md)
* [Range Constraint](RangeConstraint.md)

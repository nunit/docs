---
uid: constraint-collectionsuperset
---

# CollectionSuperset Constraint

`CollectionSupersetConstraint` tests that one `IEnumerable` is a superset of another. Every item in the expected
collection must be present in the actual collection. An exception is thrown if the actual value does not implement
`IEnumerable`.

## Usage

```csharp
Is.SupersetOf(IEnumerable expected)
```

## Modifiers

```csharp
.Using(IComparer comparer)
.Using(IEqualityComparer comparer)
.Using<T>(IComparer<T> comparer)
.Using<T>(IEqualityComparer<T> comparer)
.Using<T>(Comparison<T> comparer)
.Using<T>(Func<T, T, bool> comparer)
.UsingPropertiesComparer()     // NUnit 4.1+
```

## Examples

[!code-csharp[CollectionSupersetConstraintExamples](~/snippets/Snippets.NUnit/Constraints/CollectionConstraintSnippets.cs#CollectionSupersetConstraintExamples)]

## Notes

1. A set is always a superset of itself.
2. Every set is a superset of the empty set.
3. Duplicate items are considered: `{1, 2}` is not a superset of `{1, 1}`.

## See Also

* [CollectionSubset Constraint](CollectionSubsetConstraint.md) - Test that collection is a subset
* [CollectionEquivalent Constraint](CollectionEquivalentConstraint.md) - Test exact equivalence

---
uid: constraint-collectionsubset
---

# CollectionSubset Constraint

`CollectionSubsetConstraint` tests that one `IEnumerable` is a subset of another. Every item in the actual collection
must be present in the expected collection. An exception is thrown if the actual value does not implement `IEnumerable`.

## Usage

```csharp
Is.SubsetOf(IEnumerable expected)
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

[!code-csharp[CollectionSubsetConstraintExamples](~/snippets/Snippets.NUnit/Constraints/CollectionConstraintSnippets.cs#CollectionSubsetConstraintExamples)]

## Notes

1. A set is always a subset of itself.
2. The empty set is a subset of every set.
3. Duplicate items are considered: `{1, 1}` is a subset of `{1, 1, 2}` but not of `{1, 2}`.

## See Also

* [CollectionSuperset Constraint](CollectionSupersetConstraint.md) - Test that collection is a superset
* [CollectionEquivalent Constraint](CollectionEquivalentConstraint.md) - Test exact equivalence

---
uid: constraint-collectionequivalent
---

# CollectionEquivalent Constraint

`CollectionEquivalentConstraint` tests that two `IEnumerables` are equivalent - that they contain the same items, in any
order. Two collections are equivalent if they have the same number of elements and every element in one collection has a
matching element in the other.

## Usage

```csharp
Is.EquivalentTo(IEnumerable expected)
Is.Not.EquivalentTo(IEnumerable expected)
```

## Modifiers

```csharp
.IgnoreCase
.IgnoreWhiteSpace                     // From version 4.2
.Using(IEqualityComparer comparer)
.Using(IComparer comparer)
.Using<T>(IEqualityComparer<T> comparer)
.Using<T>(IComparer<T> comparer)
.Using<T>(Comparison<T> comparer)
.Using<T>(Func<T, T, bool> comparer)
.UsingPropertiesComparer()            // From version 4.1
```

## Examples

[!code-csharp[CollectionEquivalentConstraintExamples](~/snippets/Snippets.NUnit/Constraints/CollectionConstraintSnippets.cs#CollectionEquivalentConstraintExamples)]

## Notes

1. To compare items in a specific order, use `Is.EqualTo()` instead.
2. Duplicate items matter: `{1, 2, 2}` is not equivalent to `{1, 2, 3}` even though they have the same length.
3. The constraint checks that each item in one collection has exactly one matching item in the other, accounting for
   duplicates correctly.

## See Also

* [Equal Constraint](EqualConstraint.md) - For ordered comparison
* [CollectionSubset Constraint](CollectionSubsetConstraint.md)
* [CollectionSuperset Constraint](CollectionSupersetConstraint.md)
* [AllItems Constraint](AllItemsConstraint.md)

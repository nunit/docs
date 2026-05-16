---
uid: constraint-uniqueitems
---

# UniqueItems Constraint

`UniqueItemsConstraint` tests that an `IEnumerable` contains no duplicate items.

## Usage

```csharp
Is.Unique
```

## Modifiers

```csharp
.IgnoreCase
.IgnoreWhiteSpace              // NUnit 4.2+
.Using(IComparer comparer)
.Using(IEqualityComparer comparer)
.Using<T>(IComparer<T> comparer)
.Using<T>(IEqualityComparer<T> comparer)
.Using<T>(Comparison<T> comparer)
.Using<T>(Func<T, T, bool> comparer)
.UsingPropertiesComparer()     // NUnit 4.1+
```

## Examples

[!code-csharp[UniqueItemsConstraintExamples](~/snippets/Snippets.NUnit/Constraints/CollectionConstraintSnippets.cs#UniqueItemsConstraintExamples)]

## Notes

1. An empty collection is considered unique (no duplicates possible).
2. Duplicates are determined using the default equality comparer unless a custom comparer is specified.

## See Also

* [CollectionEquivalent Constraint](CollectionEquivalentConstraint.md) - Test collection equivalence
* [AllItems Constraint](AllItemsConstraint.md) - Test all items against a constraint

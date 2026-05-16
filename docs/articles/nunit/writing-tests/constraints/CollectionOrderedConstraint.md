---
uid: constraint-collectionordered
---

# CollectionOrdered Constraint

`CollectionOrderedConstraint` tests that an `IEnumerable` is ordered. An exception is thrown if the actual value does
not implement `IEnumerable`.

## Usage

```csharp
Is.Ordered
Is.Ordered.Ascending
Is.Ordered.Descending
Is.Ordered.By(string propertyName)
```

## Modifiers

```csharp
.Ascending                     // Ascending order (default)
.Descending                    // Descending order
.By(string propertyName)       // Order by property
.Then                          // Begin next ordering step
.Using(IComparer comparer)
.Using<T>(IComparer<T> comparer)
.Using<T>(Comparison<T> comparer)
```

## Examples

### Simple Ordering

[!code-csharp[CollectionOrderedConstraintExamples](~/snippets/Snippets.NUnit/Constraints/CollectionConstraintSnippets.cs#CollectionOrderedConstraintExamples)]

### Multiple Property Ordering

[!code-csharp[CollectionOrderedMultiplePropertiesExamples](~/snippets/Snippets.NUnit/Constraints/CollectionConstraintSnippets.cs#CollectionOrderedMultiplePropertiesExamples)]

## Notes

1. The default ordering is ascending.
2. The `Then` modifier separates ordering steps. Each step can have its own `Ascending`/`Descending` and `Using`
   modifiers.
3. An empty or single-item collection is always considered ordered.

## See Also

* [CollectionEquivalent Constraint](CollectionEquivalentConstraint.md) - Test equivalence regardless of order
* [UniqueItems Constraint](UniqueItemsConstraint.md) - Test for unique items

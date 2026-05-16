---
uid: constraint-someitems
---

# SomeItems Constraint

`SomeItemsConstraint` applies a constraint to each item in an `IEnumerable`, succeeding if at least one item satisfies
the constraint. An exception is thrown if the actual value does not implement `IEnumerable`.

## Usage

```csharp
Has.Some.<constraint>
Has.Member(object expected)
Contains.Item(object expected)
Does.Contain(object expected)
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

[!code-csharp[SomeItemsConstraintExamples](~/snippets/Snippets.NUnit/Constraints/CollectionConstraintSnippets.cs#SomeItemsConstraintExamples)]

### Contains examples

[!code-csharp[Collection Contains Examples](~/snippets/Snippets.NUnit/ConstraintExamples.cs#CollectionContainsExamples)]

## Notes

1. `Has.Member()`, `Contains.Item()`, and `Does.Contain()` are all equivalent to `Has.Some.EqualTo()`.
2. The constraint succeeds as soon as the first matching item is found.
3. An empty collection always fails this constraint.
4. For testing substring containment in strings, see [SubstringConstraint](SubstringConstraint.md).

## See Also

* [AllItems Constraint](AllItemsConstraint.md) - All items must match
* [NoItem Constraint](NoItemConstraint.md) - No items match
* [Contains Constraint](ContainsConstraint.md) - Polymorphic containment testing

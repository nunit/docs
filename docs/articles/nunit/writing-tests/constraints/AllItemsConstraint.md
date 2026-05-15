---
uid: constraint-allitems
---

# AllItems Constraint

`AllItemsConstraint` applies a constraint to each item in an `IEnumerable`, succeeding only if all items satisfy the
constraint. An exception is thrown if the actual value does not implement `IEnumerable`.

## Usage

```csharp
Is.All.<constraint>
Has.All.<constraint>
```

## Examples

[!code-csharp[AllItemsConstraintExamples](~/snippets/Snippets.NUnit/Constraints/CollectionConstraintSnippets.cs#AllItemsConstraintExamples)]

## Notes

1. `Is.All` and `Has.All` are interchangeable.
2. The constraint fails on the first item that doesn't match.
3. An empty collection satisfies `Is.All` for any constraint (vacuous truth).

## See Also

* [SomeItems Constraint](SomeItemsConstraint.md) - At least one item matches
* [NoItem Constraint](NoItemConstraint.md) - No items match
* [ExactCount Constraint](ExactCountConstraint.md) - Specific number of items match

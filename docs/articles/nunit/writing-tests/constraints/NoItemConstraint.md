---
uid: constraint-noitem
---

# NoItem Constraint

`NoItemConstraint` applies a constraint to each item in an `IEnumerable`, succeeding only if no items satisfy the
constraint. An exception is thrown if the actual value does not implement `IEnumerable`.

## Usage

```csharp
Has.None.<constraint>
```

## Examples

[!code-csharp[NoItemConstraintExamples](~/snippets/Snippets.NUnit/Constraints/CollectionConstraintSnippets.cs#NoItemConstraintExamples)]

## Notes

1. `Has.None` is the inverse of `Has.Some` - the constraint passes if no items match.
2. The constraint fails as soon as the first matching item is found.
3. An empty collection satisfies `Has.None` for any constraint.

## See Also

* [AllItems Constraint](AllItemsConstraint.md) - All items must match
* [SomeItems Constraint](SomeItemsConstraint.md) - At least one item matches
* [ExactCount Constraint](ExactCountConstraint.md) - Specific number of items match

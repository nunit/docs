---
uid: constraint-exactcount
---

# ExactCount Constraint

`ExactCountConstraint` tests that an `IEnumerable` contains exactly a specified number of items that match an optional
constraint. An exception is thrown if the actual value does not implement `IEnumerable`.

## Usage

```csharp
Has.Exactly(int count).Items
Has.Exactly(int count).<constraint>
```

## Examples

[!code-csharp[ExactCountConstraintExamples](~/snippets/Snippets.NUnit/Constraints/CollectionConstraintSnippets.cs#ExactCountConstraintExamples)]

## Notes

1. The `Items` keyword is required when counting total items (no constraint). It's optional when a constraint follows.
2. `Has.Exactly(0)` is useful for asserting that no items match a condition.
3. For simple count/length checks, consider using [PropertyConstraint](PropertyConstraint.md) with `Has.Count` or
   `Has.Length`.

## See Also

* [AllItems Constraint](AllItemsConstraint.md) - All items must match
* [SomeItems Constraint](SomeItemsConstraint.md) - At least one item matches
* [Property Constraint](PropertyConstraint.md) - Test `Count` or `Length` properties directly

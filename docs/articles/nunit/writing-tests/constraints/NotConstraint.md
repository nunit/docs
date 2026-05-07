---
uid: constraint-not
---

# Not Constraint

`NotConstraint` negates another constraint. It succeeds when the inner constraint fails, and fails when the inner
constraint succeeds.

## Usage

```csharp
Is.Not.<constraint>
Does.Not.<constraint>
Has.No.<constraint>
```

## Examples

[!code-csharp[NotConstraintExamples](~/snippets/Snippets.NUnit/Constraints/CompoundConstraintSnippets.cs#NotConstraintExamples)]

## Notes

1. `Is.Not`, `Does.Not`, and `Has.No` are all ways to negate constraints.
2. `Has.No` is specifically for collection constraints (equivalent to `Has.None`).
3. Negation applies to the immediately following constraint.

## See Also

* [And Constraint](AndConstraint.md) - Combine constraints
* [Or Constraint](OrConstraint.md) - Alternative constraints

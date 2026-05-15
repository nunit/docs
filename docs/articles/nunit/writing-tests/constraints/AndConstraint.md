---
uid: constraint-and
---

# And Constraint

`AndConstraint` combines two constraints and succeeds only if both succeed.

## Usage

```csharp
<constraint>.And.<constraint>
```

## Examples

[!code-csharp[AndConstraintExamples](~/snippets/Snippets.NUnit/Constraints/CompoundConstraintSnippets.cs#AndConstraintExamples)]

## Evaluation Order and Precedence

Constraints are evaluated **left to right**. This is important for null checks:

[!code-csharp[AndConstraintNullCheckExamples](~/snippets/Snippets.NUnit/Constraints/CompoundConstraintSnippets.cs#AndConstraintNullCheckExamples)]

> [!NOTE]
> `Or` has higher precedence than `And`. The expression `A.And.B.Or.C` is evaluated as `A.And.(B.Or.C)`.

## See Also

* [Or Constraint](OrConstraint.md) - Either condition must be true
* [Not Constraint](NotConstraint.md) - Negate a constraint

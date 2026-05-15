---
uid: constraint-or
---

# Or Constraint

`OrConstraint` combines two constraints and succeeds if either one succeeds.

## Usage

```csharp
<constraint>.Or.<constraint>
```

## Examples

[!code-csharp[OrConstraintExamples](~/snippets/Snippets.NUnit/Constraints/CompoundConstraintSnippets.cs#OrConstraintExamples)]

## Evaluation Order and Precedence

Constraints are evaluated **left to right** and short-circuit when one succeeds:

[!code-csharp[OrConstraintNullPatternExamples](~/snippets/Snippets.NUnit/Constraints/CompoundConstraintSnippets.cs#OrConstraintNullPatternExamples)]

> [!NOTE]
> `Or` has higher precedence than `And`. The expression `A.And.B.Or.C` is evaluated as `A.And.(B.Or.C)`.

## See Also

* [And Constraint](AndConstraint.md) - Both conditions must be true
* [Not Constraint](NotConstraint.md) - Negate a constraint
* [AnyOf Constraint](AnyOfConstraint.md) - Value equals any of several options

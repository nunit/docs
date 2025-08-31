# Not Constraint

`NotConstraint` reverses the effect of another constraint. If the base constraint fails, NotConstraint succeeds. If the
base constraint succeeds, NotConstraint fails.

## Constructor

```csharp
NotConstraint()
```

## Syntax

```csharp
Is.Not...
```

## Examples of Use

[!code-csharp[NotConstraintExamples](~/snippets/Snippets.NUnit/ConstraintExamples.cs#PropertyConstraintExamples)]

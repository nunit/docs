---
uid: constraint-propertyexists
---

# PropertyExists Constraint

`PropertyExistsConstraint` tests for the existence of a named property on an object.

## Usage

```csharp
Has.Property(string propertyName)
```

## Examples

[!code-csharp[PropertyExistsConstraintExamples](~/snippets/Snippets.NUnit/Constraints/SpecialConstraintSnippets.cs#PropertyExistsConstraintExamples)]

## Notes

1. When no constraint is chained after `Has.Property()`, it creates a `PropertyExistsConstraint`.
2. When a constraint follows (e.g., `.EqualTo(5)`), it becomes a [PropertyConstraint](PropertyConstraint.md).
3. The property must be public and readable.

## See Also

* [Property Constraint](PropertyConstraint.md) - Test property values

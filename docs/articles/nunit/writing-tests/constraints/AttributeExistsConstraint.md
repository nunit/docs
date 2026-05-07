---
uid: constraint-attributeexists
---

# AttributeExists Constraint

`AttributeExistsConstraint` tests for the existence of an attribute on a type.

## Usage

```csharp
Has.Attribute(Type attributeType)
Has.Attribute<TAttribute>()
```

## Examples

[!code-csharp[AttributeExistsConstraintExamples](~/snippets/Snippets.NUnit/Constraints/TypeConstraintSnippets.cs#AttributeExistsConstraintExamples)]

## Notes

1. When no further constraint is chained, `Has.Attribute` creates an `AttributeExistsConstraint`.
2. When a constraint is chained (e.g., `.Property("Name")`), it becomes an
   [AttributeConstraint](AttributeConstraint.md).
3. The constraint works on both `Type` objects and instances (testing the instance's type).

## See Also

* [Attribute Constraint](AttributeConstraint.md) - Test attribute properties

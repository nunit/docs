---
uid: constraint-attribute
---

# Attribute Constraint

`AttributeConstraint` tests for the existence of an attribute on a type and then applies a further constraint to that
attribute's properties.

## Usage

```csharp
Has.Attribute(Type attributeType).<constraint>
Has.Attribute<TAttribute>().<constraint>
```

## Examples

[!code-csharp[AttributeConstraintExamples](~/snippets/Snippets.NUnit/Constraints/TypeConstraintSnippets.cs#AttributeConstraintExamples)]

## Notes

1. The constraint first checks that the attribute exists, then applies the chained constraint to the attribute instance.
2. To only check for attribute existence without testing its properties, use
   [AttributeExistsConstraint](AttributeExistsConstraint.md).
3. The constraint works on both `Type` objects and instances (testing the instance's type).

## See Also

* [AttributeExists Constraint](AttributeExistsConstraint.md) - Just test for attribute presence
* [Property Constraint](PropertyConstraint.md) - Test property values

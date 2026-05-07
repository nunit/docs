---
uid: constraint-property
---

# Property Constraint

`PropertyConstraint` tests the value of a named property on an object against a further constraint.

## Usage

```csharp
Has.Property(string propertyName).<constraint>
Has.Length.<constraint>
Has.Count.<constraint>
Has.Message.<constraint>
Has.InnerException.<constraint>
```

## Examples

[!code-csharp[PropertyConstraintExamples](~/snippets/Snippets.NUnit/Constraints/SpecialConstraintSnippets.cs#PropertyConstraintExamples)]

### Built-in Property Shortcuts

```csharp
Has.Length       // Equivalent to Has.Property("Length")
Has.Count        // Equivalent to Has.Property("Count")
Has.Message      // Equivalent to Has.Property("Message")
Has.InnerException // Equivalent to Has.Property("InnerException")
```

## Notes

1. If no constraint follows `Has.Property()`, it becomes a [PropertyExistsConstraint](PropertyExistsConstraint.md).
2. The property must be public and readable.
3. If the property doesn't exist, the constraint fails with a descriptive message.

## See Also

* [PropertyExists Constraint](PropertyExistsConstraint.md) - Just test for property existence
* [ExactCount Constraint](ExactCountConstraint.md) - Count items matching a constraint

---
uid: constraint-assignablefrom
---

# AssignableFrom Constraint

`AssignableFromConstraint` tests that an instance of the specified type can be assigned to the actual value's type. In
other words, the actual value's type is a base type or interface of the expected type.

## Usage

```csharp
Is.AssignableFrom(Type expectedType)
Is.AssignableFrom<T>()
```

## Examples

[!code-csharp[AssignableFromConstraintExamples](~/snippets/Snippets.NUnit/Constraints/TypeConstraintSnippets.cs#AssignableFromConstraintExamples)]

## Notes

1. `Is.AssignableFrom<T>()` is true when `actualType.IsAssignableFrom(typeof(T))`.
2. This tests "can I assign an instance of T to this variable?".
3. This is the reverse of [AssignableToConstraint](AssignableToConstraint.md).

## See Also

* [AssignableTo Constraint](AssignableToConstraint.md) - Reverse direction check
* [InstanceOfType Constraint](InstanceOfTypeConstraint.md) - Test if object is instance of type
* [ExactType Constraint](ExactTypeConstraint.md) - Test for exact type match

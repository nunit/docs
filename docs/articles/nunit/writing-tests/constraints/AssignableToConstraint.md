---
uid: constraint-assignableto
---

# AssignableTo Constraint

`AssignableToConstraint` tests that the actual value can be assigned to a variable of the specified type. In other
words, the actual value's type derives from or implements the expected type.

## Usage

```csharp
Is.AssignableTo(Type expectedType)
Is.AssignableTo<T>()
```

## Examples

[!code-csharp[AssignableToConstraintExamples](~/snippets/Snippets.NUnit/Constraints/TypeConstraintSnippets.cs#AssignableToConstraintExamples)]

## Notes

1. `Is.AssignableTo<T>()` is true when `typeof(T).IsAssignableFrom(actual.GetType())`.
2. This tests "can this value be assigned to a variable of type T?".
3. This is the reverse of [AssignableFromConstraint](AssignableFromConstraint.md).

## See Also

* [AssignableFrom Constraint](AssignableFromConstraint.md) - Reverse direction check
* [InstanceOfType Constraint](InstanceOfTypeConstraint.md) - Test if object is instance of type
* [ExactType Constraint](ExactTypeConstraint.md) - Test for exact type match

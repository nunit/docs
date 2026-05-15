---
uid: constraint-instanceoftype
---

# InstanceOfType Constraint

`InstanceOfTypeConstraint` tests that an object is an instance of the specified type or any derived type. This is
equivalent to the C# `is` operator.

## Usage

```csharp
Is.InstanceOf(Type expectedType)
Is.InstanceOf<T>()
```

## Examples

[!code-csharp[InstanceOfTypeConstraintExamples](~/snippets/Snippets.NUnit/Constraints/TypeConstraintSnippets.cs#InstanceOfTypeConstraintExamples)]

## Notes

1. `Is.InstanceOf<T>()` is equivalent to C#'s `value is T` expression.
2. For exact type matching (no inheritance), use [ExactTypeConstraint](ExactTypeConstraint.md).
3. `null` always fails `Is.InstanceOf` for any type.

## See Also

* [ExactType Constraint](ExactTypeConstraint.md) - Exact type match, no inheritance
* [AssignableTo Constraint](AssignableToConstraint.md) - Type assignability check
* [AssignableFrom Constraint](AssignableFromConstraint.md) - Reverse assignability check

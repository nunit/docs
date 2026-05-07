---
uid: constraint-exacttype
---

# ExactType Constraint

`ExactTypeConstraint` tests that an object is exactly the specified type, not a derived type.

## Usage

```csharp
Is.TypeOf(Type expectedType)
Is.TypeOf<T>()
```

## Examples

[!code-csharp[ExactTypeConstraintExamples](~/snippets/Snippets.NUnit/Constraints/TypeConstraintSnippets.cs#ExactTypeConstraintExamples)]

## Notes

1. `Is.TypeOf<T>()` checks that `actual.GetType() == typeof(T)`.
2. For inheritance-aware type checking (like C# `is`), use [InstanceOfTypeConstraint](InstanceOfTypeConstraint.md).
3. `null` values throw an exception since they have no type.

## See Also

* [InstanceOfType Constraint](InstanceOfTypeConstraint.md) - Inheritance-aware type checking
* [AssignableTo Constraint](AssignableToConstraint.md) - Type assignability check

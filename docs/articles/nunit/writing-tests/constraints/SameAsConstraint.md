---
uid: constraint-sameas
---

# SameAs Constraint

`SameAsConstraint` tests whether the actual value is the same object instance as the expected value (reference
equality). This is different from `Is.EqualTo`, which tests for value equality.

## Usage

```csharp
Is.SameAs<T>(T? expected) where T : class?
Is.Not.SameAs<T>(T? expected) where T : class?
```

`Is.SameAs` only accepts reference types. Using it with a value type, such as an `int` or an `int?`, is a compiler
error. Use `Is.EqualTo` for value types.

> [!NOTE]
> In NUnit 4 and earlier, the signature was `Is.SameAs(object expected)`. It also accepted value types, but the
> assertion always failed, because value types are boxed into different objects.

## Examples

[!code-csharp[SameAsConstraintExamples](~/snippets/Snippets.NUnit/Constraints/SpecialConstraintSnippets.cs#SameAsConstraintExamples)]

## Notes

1. `Is.SameAs` uses `object.ReferenceEquals()` internally - it tests object identity, not equality.
2. `Is.SameAs` can't be used with value types. The compiler rejects them.
3. Use `Is.EqualTo` when you want to compare values; use `Is.SameAs` when you need to verify the exact same instance.

## See Also

* [Equal Constraint](EqualConstraint.md) - For value equality

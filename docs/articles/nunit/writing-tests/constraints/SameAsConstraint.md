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

> [!NOTE]
> From version 5, `Is.SameAs` only accepts reference types. Using it with a value type, such as an `int` or a nullable
> struct, is a compiler error instead of an assertion that always fails. Use `Is.EqualTo` for value types.
>
> In NUnit 4 and earlier, the signature was `Is.SameAs(object expected)`, which also accepted boxed value types.

## Examples

[!code-csharp[SameAsConstraintExamples](~/snippets/Snippets.NUnit/Constraints/SpecialConstraintSnippets.cs#SameAsConstraintExamples)]

## Notes

1. `Is.SameAs` uses `object.ReferenceEquals()` internally - it tests object identity, not equality.
2. `Is.SameAs` can't be used with value types (from version 5). In NUnit 4 and earlier it compiled, but always failed,
   because value types are boxed into different objects.
3. Use `Is.EqualTo` when you want to compare values; use `Is.SameAs` when you need to verify the exact same instance.

## See Also

* [Equal Constraint](EqualConstraint.md) - For value equality

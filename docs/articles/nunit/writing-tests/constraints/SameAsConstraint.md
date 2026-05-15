---
uid: constraint-sameas
---

# SameAs Constraint

`SameAsConstraint` tests whether the actual value is the same object instance as the expected value (reference
equality). This is different from `Is.EqualTo`, which tests for value equality.

## Usage

```csharp
Is.SameAs(object expected)
Is.Not.SameAs(object expected)
```

## Examples

[!code-csharp[SameAsConstraintExamples](~/snippets/Snippets.NUnit/Constraints/SpecialConstraintSnippets.cs#SameAsConstraintExamples)]

## Notes

1. `Is.SameAs` uses `object.ReferenceEquals()` internally - it tests object identity, not equality.
2. For value types, `Is.SameAs` will always fail because value types are boxed into different objects.
3. Use `Is.EqualTo` when you want to compare values; use `Is.SameAs` when you need to verify the exact same instance.

## See Also

* [Equal Constraint](EqualConstraint.md) - For value equality

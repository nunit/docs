---
uid: constraint-throwsnothing
---

# ThrowsNothing Constraint

`ThrowsNothingConstraint` tests that the code under test does not throw any exception.

## Usage

```csharp
Throws.Nothing
```

## Examples

[!code-csharp[ThrowsNothingConstraintExamples](~/snippets/Snippets.NUnit/Constraints/SpecialConstraintSnippets.cs#ThrowsNothingConstraintExamples)]

## Notes

1. Use `Throws.Nothing` to explicitly verify that code doesn't throw.
2. This is different from not testing at all - it documents the expectation.
3. If the delegate throws any exception, the constraint fails with the exception details.

## See Also

* [Throws Constraint](ThrowsConstraint.md) - Test that code throws specific exceptions

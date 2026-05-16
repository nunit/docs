---
uid: constraint-emptycollection
---

# EmptyCollection Constraint

`EmptyCollectionConstraint` tests that an `IEnumerable` contains no items. An `ArgumentException` is thrown if the
actual value is not an `IEnumerable` or is null.

## Usage

```csharp
Is.Empty
Is.Not.Empty
```

## Examples

[!code-csharp[EmptyCollectionConstraintExamples](~/snippets/Snippets.NUnit/Constraints/CollectionConstraintSnippets.cs#EmptyCollectionConstraintExamples)]

## Notes

1. `Is.Empty` is a polymorphic constraint that works with strings, collections, and directories.
2. When applied to an `IEnumerable`, it creates an `EmptyCollectionConstraint` internally.
3. Passing `null` throws an `ArgumentException`. Use `Is.Null.Or.Empty` pattern if null is acceptable.

## See Also

* [Empty Constraint](EmptyConstraint.md) - Polymorphic empty constraint
* [EmptyString Constraint](EmptyStringConstraint.md) - For string-specific empty tests
* [ExactCount Constraint](ExactCountConstraint.md) - Test for specific item count

---
uid: constraint-emptystring
---

# EmptyString Constraint

`EmptyStringConstraint` tests that a string has zero length. This is a specialized constraint created when `Is.Empty` is
applied to a string value.

## Usage

```csharp
Is.Empty
Is.Not.Empty
```

## Examples

[!code-csharp[EmptyStringConstraintExamples](~/snippets/Snippets.NUnit/Constraints/StringConstraintSnippets.cs#EmptyStringConstraintExamples)]

## Notes

1. `Is.Empty` is a polymorphic constraint that tests for empty strings, collections, or directories depending on the
   actual value type.
2. For checking null-or-empty strings, you can combine constraints: `Is.Null.Or.Empty`.
3. To test for whitespace-only strings, use [WhiteSpaceConstraint](WhiteSpaceConstraint.md).

## See Also

* [Empty Constraint](EmptyConstraint.md) - Polymorphic constraint for strings, collections, directories
* [WhiteSpace Constraint](WhiteSpaceConstraint.md)
* [Null Constraint](NullConstraint.md)

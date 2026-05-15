---
uid: constraint-whitespace
---

# WhiteSpace Constraint

`WhiteSpaceConstraint` tests that a string is null, empty, or contains only whitespace characters. It is equivalent to
`string.IsNullOrWhiteSpace()`.

> [!NOTE]
> This constraint was added in NUnit 4.2.

## Usage

```csharp
Is.WhiteSpace
Is.Not.WhiteSpace
```

## Examples

[!code-csharp[WhiteSpaceConstraintExamples](~/snippets/Snippets.NUnit/Constraints/StringConstraintSnippets.cs#WhiteSpaceConstraintExamples)]

## Notes

1. Whitespace characters are defined by the Unicode standard as interpreted by `Char.IsWhiteSpace()`.
2. Unlike `Is.Empty`, `Is.WhiteSpace` also returns true for `null` values.
3. Common whitespace characters include: space (` `), tab (`\t`), newline (`\n`), carriage return (`\r`).

## See Also

* [EmptyString Constraint](EmptyStringConstraint.md)
* [Empty Constraint](EmptyConstraint.md)
* [Null Constraint](NullConstraint.md)

---
uid: constraint-regex
---

# Regex Constraint

`RegexConstraint` tests that a string matches a regular expression pattern.

## Usage

```csharp
Does.Match(string pattern)
Does.Not.Match(string pattern)
```

## Modifiers

```csharp
.IgnoreCase
```

## Examples

[!code-csharp[RegexConstraintExamples](~/snippets/Snippets.NUnit/Constraints/StringConstraintSnippets.cs#RegexConstraintExamples)]

### Common Pattern Examples

[!code-csharp[RegexConstraintPatternExamples](~/snippets/Snippets.NUnit/Constraints/StringConstraintSnippets.cs#RegexConstraintPatternExamples)]

## Notes

1. The pattern uses .NET regular expression syntax.
2. The entire string does not need to match - use `^` and `$` anchors if you need a full match.
3. For simple substring matching, consider using [SubstringConstraint](SubstringConstraint.md) instead.

## See Also

* [Substring Constraint](SubstringConstraint.md)
* [StartsWith Constraint](StartsWithConstraint.md)
* [EndsWith Constraint](EndsWithConstraint.md)

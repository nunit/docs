---
uid: constraint-substring
---

# Substring Constraint

`SubstringConstraint` tests that a string contains the expected substring.

## Usage

```csharp
Does.Contain(string expected)
Does.Not.Contain(string expected)
```

## Modifiers

```csharp
.IgnoreCase
.Using(StringComparison comparisonType)
.Using(CultureInfo culture)
```

## Examples

[!code-csharp[SubstringConstraintExamples](~/snippets/Snippets.NUnit/Constraints/StringConstraintSnippets.cs#SubstringConstraintExamples)]

### Specifying a StringComparison

[!code-csharp[SubstringConstraintStringComparisonExamples](~/snippets/Snippets.NUnit/Constraints/StringConstraintSnippets.cs#SubstringConstraintStringComparisonExamples)]

### Specifying a CultureInfo

The `Using(CultureInfo)` modifier allows for culture-specific string comparisons.
It can be combined with `.IgnoreCase` for case-insensitive culture-aware comparisons:

```csharp
// Using Turkish culture where 'i' and 'I' have special casing rules
Assert.That("Hello TITLE World", Does.Contain("title").IgnoreCase.Using(new CultureInfo("tr-TR")));

// Culture-specific comparison without case-insensitivity
Assert.That("Straße Street", Does.Contain("Straße").Using(new CultureInfo("de-DE")));
```

## Notes

1. Only one `Using` modifier may be specified. Attempting to use multiple `Using` modifiers will throw an
   `InvalidOperationException`.
2. When using `Does.Contain()` with a non-string actual value, it tests for collection membership instead. See
   [ContainsConstraint](ContainsConstraint.md) for details.

## See Also

* [StartsWith Constraint](StartsWithConstraint.md)
* [EndsWith Constraint](EndsWithConstraint.md)
* [Regex Constraint](RegexConstraint.md)
* [Contains Constraint](ContainsConstraint.md)

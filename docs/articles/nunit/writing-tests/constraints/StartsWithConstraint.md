---
uid: constraint-startswith
---

# StartsWith Constraint

`StartsWithConstraint` tests that a string begins with the expected substring.

## Usage

```csharp
Does.StartWith(string expected)
Does.Not.StartWith(string expected)
```

## Modifiers

```csharp
.IgnoreCase
.Using(StringComparison comparisonType)
.Using(CultureInfo culture)
```

## Examples

[!code-csharp[StartsWithConstraintExamples](~/snippets/Snippets.NUnit/Constraints/StringConstraintSnippets.cs#StartsWithConstraintExamples)]

### Specifying a StringComparison

[!code-csharp[StartsWithConstraintStringComparisonExamples](~/snippets/Snippets.NUnit/Constraints/StringConstraintSnippets.cs#StartsWithConstraintStringComparisonExamples)]

### Specifying a CultureInfo

The `Using(CultureInfo)` modifier allows for culture-specific string comparisons.
It can be combined with `.IgnoreCase` for case-insensitive culture-aware comparisons:

```csharp
// Using Turkish culture where 'i' and 'I' have special casing rules
Assert.That("TITLE text", Does.StartWith("title").IgnoreCase.Using(new CultureInfo("tr-TR")));

// Culture-specific comparison without case-insensitivity
Assert.That("Straße Street", Does.StartWith("Straße").Using(new CultureInfo("de-DE")));
```

## Notes

1. Only one `Using` modifier may be specified. Attempting to use multiple `Using` modifiers will throw an
   `InvalidOperationException`.

## See Also

* [EndsWith Constraint](EndsWithConstraint.md)
* [Substring Constraint](SubstringConstraint.md)
* [Regex Constraint](RegexConstraint.md)

---
uid: constraint-endswith
---

# EndsWith Constraint

`EndsWithConstraint` tests that a string ends with the expected substring.

## Usage

```csharp
Does.EndWith(string expected)
Does.Not.EndWith(string expected)
```

## Modifiers

```csharp
.IgnoreCase
.Using(StringComparison comparisonType)
.Using(CultureInfo culture)
```

## Examples

[!code-csharp[EndsWithConstraintExamples](~/snippets/Snippets.NUnit/Constraints/StringConstraintSnippets.cs#EndsWithConstraintExamples)]

### Specifying a StringComparison

```csharp
Assert.That("Hello World!", Does.EndWith("WORLD!").Using(StringComparison.OrdinalIgnoreCase));
Assert.That("Hello World!", Does.EndWith("World!").Using(StringComparison.Ordinal));
```

### Specifying a CultureInfo

The `Using(CultureInfo)` modifier allows for culture-specific string comparisons.
It can be combined with `.IgnoreCase` for case-insensitive culture-aware comparisons:

```csharp
// Using Turkish culture where 'i' and 'I' have special casing rules
Assert.That("text TITLE", Does.EndWith("title").IgnoreCase.Using(new CultureInfo("tr-TR")));

// Culture-specific comparison without case-insensitivity
Assert.That("Main Straße", Does.EndWith("Straße").Using(new CultureInfo("de-DE")));
```

## Notes

1. Only one `Using` modifier may be specified. Attempting to use multiple `Using` modifiers will throw an
   `InvalidOperationException`.

## See Also

* [StartsWith Constraint](StartsWithConstraint.md)
* [Substring Constraint](SubstringConstraint.md)
* [Regex Constraint](RegexConstraint.md)

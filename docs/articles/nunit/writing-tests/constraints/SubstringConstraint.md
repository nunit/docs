# Substring Constraint

`SubstringConstraint` tests for a substring.

## Constructor

```csharp
SubstringConstraint(string expected)
```

## Syntax

```csharp
Does.Contain(string expected)
```

## Modifiers

```csharp
...IgnoreCase
...Using(StringComparison comparisonType)
...Using(CultureInfo culture)
```

## Examples of Use

[!code-csharp[StringConstraintExamples](~/snippets/Snippets.NUnit/ConstraintExamples.cs#StringConstraintExamples)]

### Specifying a StringComparison

```csharp
Assert.That("Hello World!", Does.Contain("WORLD").Using(StringComparison.OrdinalIgnoreCase));
Assert.That("Hello World!", Does.Contain("World").Using(StringComparison.Ordinal));
```

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

1. Only one `Using` modifier may be specified. Attempting to use multiple `Using` modifiers
   will throw an `InvalidOperationException`.

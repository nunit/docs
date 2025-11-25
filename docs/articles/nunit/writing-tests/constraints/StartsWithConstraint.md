# StartsWith Constraint

`StartsWithConstraint` tests for an initial string.

## Constructor

```csharp
StartsWithConstraint(string expected)
```

## Syntax

```csharp
Does.StartWith(string expected)
StartsWith(string expected)
```

## Modifiers

```csharp
...IgnoreCase
...Using(StringComparison comparisonType)
...Using(CultureInfo culture)
```

## Examples of Use

```csharp
string phrase = "Make your tests fail before passing!";

Assert.That(phrase, Does.StartWith("Make"));
Assert.That(phrase, Does.Not.StartWith("Break"));
```

### Specifying a StringComparison

```csharp
Assert.That("Hello World!", Does.StartWith("HELLO").Using(StringComparison.OrdinalIgnoreCase));
Assert.That("Hello World!", Does.StartWith("Hello").Using(StringComparison.Ordinal));
```

### Specifying a CultureInfo

The `Using(CultureInfo)` modifier allows for culture-specific string comparisons:

```csharp
// Using Turkish culture where 'i' and 'I' have special casing rules
Assert.That("TITLE", Does.StartWith("title").IgnoreCase.Using(new CultureInfo("tr-TR")));
```

## Notes

1. **StartsWith** may appear only in the body of a constraint
   expression or when the inherited syntax is used.
2. Only one `Using` modifier may be specified. Attempting to use multiple `Using` modifiers
   will throw an `InvalidOperationException`.

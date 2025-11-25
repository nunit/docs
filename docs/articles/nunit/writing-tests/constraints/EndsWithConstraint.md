# EndsWith Constraint

`EndsWithConstraint` tests for an ending string.

## Constructor

```csharp
EndsWithConstraint(string expected)
```

## Syntax

```csharp
Does.EndWith(string expected)
EndsWith(string expected)
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

Assert.That(phrase, Does.EndWith("!"));
Assert.That(phrase, Does.EndWith("PASSING!").IgnoreCase);
```

### Specifying a StringComparison

```csharp
Assert.That("Hello World!", Does.EndWith("WORLD!").Using(StringComparison.OrdinalIgnoreCase));
Assert.That("Hello World!", Does.EndWith("World!").Using(StringComparison.Ordinal));
```

### Specifying a CultureInfo

```csharp
Assert.That("Test Straße", Does.EndWith("ss").Using(new CultureInfo("de-DE")));
```

## Notes

1. **EndsWith** may appear only in the body of a constraint expression or when the inherited syntax is used.
2. Only one `Using` modifier may be specified. Attempting to use multiple `Using` modifiers
   will throw an `InvalidOperationException`.

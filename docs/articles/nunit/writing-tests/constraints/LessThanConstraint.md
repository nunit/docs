# LessThan Constraint

`LessThanConstraint` tests that one value is less than another.

## Constructor

```csharp
LessThanConstraint(object expected)
```

## Syntax

```csharp
Is.LessThan(object expected)
Is.Negative // Equivalent to Is.LessThan(0)
```

## Modifiers

```csharp
...Using(IComparer comparer)
...Using<T>(IComparer<T> comparer)
...Using<T>(Comparison<T> comparer)
...Within(object tolerance)
```

## Examples of Use

```csharp
Assert.That(3, Is.LessThan(7));
Assert.That(myOwnObject, Is.LessThan(theExpected).Using(myComparer));
Assert.That(-5, Is.Negative);
Assert.That(myDateTime, Is.LessThan(expectedDateTime).Within(TimeSpan.FromSeconds(1)))
```

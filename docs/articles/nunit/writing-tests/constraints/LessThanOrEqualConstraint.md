# LessThanOrEqual Constraint

`LessThanOrEqualConstraint` tests that one value is less than or equal to another.

## Constructor

```csharp
LessThanOrEqualConstraint(object expected)
```

## Syntax

```csharp
Is.LessThanOrEqualTo(object expected)
Is.AtMost(object expected)
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
Assert.That(3, Is.LessThanOrEqualTo(7));
Assert.That(3, Is.AtMost(7));
Assert.That(3, Is.LessThanOrEqualTo(3));
Assert.That(3, Is.AtMost(3));
Assert.That(myOwnObject, Is.LessThanOrEqualTo(theExpected).Using(myComparer));
Assert.That(myDateTime, Is.LessThanOrEqualTo(expectedDateTime).Within(TimeSpan.FromSeconds(1)))
```

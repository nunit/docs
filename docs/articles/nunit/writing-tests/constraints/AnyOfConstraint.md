# AnyOf Constraint

`AnyOfConstraint` is used to determine whether a value is equal to any of the expected values.
Note: Do provide the expected values as separate values, not as an array.

## Constructor

```csharp
AnyOfConstraint(object[] expected)
```

## Syntax

```csharp
Is.AnyOf(object[] expected)
```

## Modifiers

```csharp
...Using(IComparer comparer)
...Using<T>(IEqualityComparer comparer)
...Using<T>(Func<T, T, bool>)
...Using<T>(IComparer<T> comparer)
...Using<T>(Comparison<T> comparer)
...Using<T>(IEqualityComparer<T> comparer)
```

## Examples of Use

```csharp
Assert.That(42, Is.AnyOf(0, -1, 42, 100));

int[] iarray = new int[] { 0, -1, 42, 100 }
Assert.That(myOwnObject, Is.AnyOf(myArray).Using(myComparer));
```

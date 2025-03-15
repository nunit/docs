# UniqueItems Constraint

**UniqueItemsConstraint** tests that an array, collection or other IEnumerable is composed
of unique items with no duplicates.

## Constructor

```csharp
UniqueItemsConstraint()
```

## Syntax

```csharp
Is.Unique
```

## Modifiers

```csharp
...IgnoreCase
...IgnoreWhiteSpace  // From version 4.2
...Using(IEqualityComparer comparer)
...Using(IComparer comparer)
...Using<T>(IEqualityComparer<T> comparer)
...Using<T>(IComparer<T> comparer)
...Using<T>(Comparison<T> comparer)
...Using<T>(Func<T, T, bool> comparer)
...UsingPropertiesComparer()  // From version 4.1
...UsingPropertiesComparer(
      Func<PropertiesComparerConfiguration,
           PropertiesComparerConfiguration> configure) // From version 4.4
```

## Example of Use

```csharp
int[] iarray = new int[] { 1, 2, 3 };
Assert.That(iarray, Is.Unique);
```

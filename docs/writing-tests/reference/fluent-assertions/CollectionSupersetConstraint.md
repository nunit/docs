# CollectionSuperset Constraint

`CollectionSupersetConstraint` tests that one `IEnumerable` is a superset of another. If the actual value passed does
not implement `IEnumerable`, an exception is thrown.

## Constructor

```csharp
CollectionSupersetConstraint(IEnumerable)
```

## Syntax

```csharp
Is.SupersetOf(IEnumerable)
```

## Modifiers

```csharp
...Using(IEqualityComparer comparer)
...Using(IComparer comparer)
...Using<T>(IEqualityComparer<T> comparer)
...Using<T>(IComparer<T> comparer)
...Using<T>(Comparison<T> comparer)
...Using<T>(Func<T, T, bool> comparer)
...Using<TSupersetElement, TSubsetElement>(Func<TSupersetElement, TSubsetElement, bool> comparison)
...UsingPropertiesComparer()  // From version 4.1
```

## Example of Use

```csharp
int[] iarray = new int[] { 1, 2, 3 };
Assert.That(iarray, Is.SupersetOf(new int[] { 1, 3 }));
```

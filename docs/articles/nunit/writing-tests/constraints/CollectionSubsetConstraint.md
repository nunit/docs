# CollectionSubset Constraint

`CollectionSubsetConstraint` tests that one `IEnumerable` is a subset of another. If the actual value passed does not
implement `IEnumerable`, an exception is thrown.

## Constructor

```csharp
CollectionSubsetConstraint(IEnumerable)
```

## Syntax

```csharp
Is.SubsetOf(IEnumerable)
```

## Modifiers

```csharp
...Using(IEqualityComparer comparer)
...Using(IComparer comparer)
...Using<T>(IEqualityComparer<T> comparer)
...Using<T>(IComparer<T> comparer)
...Using<T>(Comparison<T> comparer)
...Using<T>(Func<T, T, bool> comparer)
...Using<TSubsetElement, TSupersetElement>(Func<TSubsetElement, TSupersetElement, bool> comparison)
...UsingPropertiesComparer()  // From version 4.1
```

## Example of Use

```csharp
int[] iarray = new int[] { 1, 3 };
Assert.That(iarray, Is.SubsetOf(new int[] { 1, 2, 3 }));
```

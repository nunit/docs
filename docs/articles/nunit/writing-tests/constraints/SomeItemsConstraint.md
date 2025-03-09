# SomeItems Constraint

`SomeItemsConstraint` applies a constraint to each item in an `IEnumerable`, succeeding if at least one of them
succeeds. An exception is thrown if the actual value passed does not implement `IEnumerable`.

## Constructor

```csharp
SomeItemsConstraint(Constraint itemConstraint)
```

## Syntax

```csharp
Has.Some...
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
...Using<TActualCollectionElement, TExpectedElement>(Func<TActualCollectionElement, TExpectedElement, bool> comparer)
...UsingPropertiesComparer()  // From version 4.1
```

## Examples of Use

```csharp
int[] iarray = new int[] { 1, 2, 3 };
string[] sarray = new string[] { "a", "b", "c" };
Assert.That(iarray, Has.Some.GreaterThan(2));
Assert.That(sarray, Has.Some.Length.EqualTo(1));
```

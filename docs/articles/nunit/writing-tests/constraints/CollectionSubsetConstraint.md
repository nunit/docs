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
...UsingPropertiesComparer()  // From version 4.1
```

## Example of Use

```csharp
int[] iarray = new int[] { 1, 3 };
Assert.That(iarray, Is.SubsetOf(new int[] { 1, 2, 3 }));
```

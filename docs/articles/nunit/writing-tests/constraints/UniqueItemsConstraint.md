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
...UsingPropertiesComparer()  // From version 4.1
```

## Example of Use

```csharp
int[] iarray = new int[] { 1, 2, 3 };
Assert.That(iarray, Is.Unique);
```

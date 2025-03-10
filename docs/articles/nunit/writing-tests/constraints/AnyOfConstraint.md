# AnyOf Constraint

`AnyOfConstraint` is used to determine whether a value is equal to any of the expected values.

> [!NOTE]
> Values provided must be as parameters to the method, not as e.g. a separate array. If you are instead looking
> to see if a collection contains a value, see the [CollectionContains Constraint](xref:collectioncontainsconstraint).

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

## Examples of Use

```csharp
Assert.That(42, Is.AnyOf(0, -1, 42, 100));

// You can use a custom comparer as well
Assert.That(myOwnObject, Is.AnyOf(myArray).Using(myComparer));
```

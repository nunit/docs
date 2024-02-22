# DictionaryContainsKey Constraint

`DictionaryContainsKeyConstraint` is used to test whether a dictionary
contains an expected object as a key.

## Constructor

```csharp
DictionaryContainsKeyConstraint(object)
```

## Syntax

```csharp
Contains.Key(object)
Does.ContainKey(object)
Does.Not.ContainKey(object)
```

## Modifiers

```csharp
...Using(IComparer comparer)
...Using(IEqualityComparer comparer)
...UsingPropertiesComparer()  // From version 4.1
...Using<T>(IComparer<T> comparer)
...Using<T>(Comparison<T> comparer)
...Using<T>(Func<T, T, bool> comparer)
...Using<T>(IEqualityComparer<T> comparer)
...Using<TCollectionType, TMemberType>(Func<TCollectionType, TMemberType, bool> comparison)
...WithValue(object expectedValue)
```

## Examples of Use

```csharp
IDictionary<int, int> idict = new IDictionary<int, int> { { 1, 4 }, { 2, 5 } };

Assert.That(idict, Contains.Key(1));
Assert.That(idict, Does.ContainKey(2));
Assert.That(idict, Does.Not.ContainKey(3));
Assert.That(mydict, Contains.Key(myOwnObject).Using(myComparer));
Assert.That(mydict, Does.ContainKey("Hello").WithValue("World"));
```

## See also

* [DictionaryContainsValueConstraint](DictionaryContainsValueConstraint.md)
* [DictionaryContainsKeyValuePairConstraint](DictionaryContainsKeyValuePairConstraint.md)

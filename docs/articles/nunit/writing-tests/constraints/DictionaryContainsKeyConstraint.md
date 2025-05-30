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
...WithValue(object expectedValue)
```

As of version 4.4.0 of NUnit the other modifiers were removed as they were non-functional.
NUnit's `ContainKey` works the same as the `ContainsKey` method on `Dictionary`
It uses the comparer specified when the dictionary was created.

## Examples of Use

```csharp
var caseSensitiveDictionary = new Dictionary<string, string>(StringComparer.Ordinal)
{
    ["Hello"] = "World",
};

Assert.That(caseSensitiveDictionary, Does.ContainKey("Hello"));
Assert.That(caseSensitiveDictionary, Does.Not.ContainKey("hello"));

var caseInsensitiveDictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
{
    ["Hello"] = "World",
};

Assert.That(caseInsensitiveDictionary, Does.ContainKey("Hello"));
Assert.That(caseInsensitiveDictionary, Does.ContainKey("hello"));
Assert.That(caseInsensitiveDictionary, Does.Not.ContainKey("hallo"));

// Note that the 'IgnoreCase' here is on the Value part, not the Key.
Assert.That(caseInsensitiveDictionary, Does.ContainKey("hello").WithValue("world").IgnoreCase);
```

## See also

* [DictionaryContainsValueConstraint](DictionaryContainsValueConstraint.md)
* [DictionaryContainsKeyValuePairConstraint](DictionaryContainsKeyValuePairConstraint.md)

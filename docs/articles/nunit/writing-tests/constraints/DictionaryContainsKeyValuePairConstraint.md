# DictionaryContainsKeyValuePairConstraint Constraint

`DictionaryContainsKeyValuePairConstraint` is used to test whether a dictionary
contains an expected key along with an expected corresponding value.

## Constructor

```csharp
public DictionaryContainsKeyValuePairConstraint(object key, object value)
    : this(new KeyValuePair<object, object>(key, value))
{
}

protected DictionaryContainsKeyValuePairConstraint(KeyValuePair<object, object> arg)
    : base(arg)
{
    Expected = arg;
}
```

## Syntax

```csharp
Assert.That(dictionary, new DictionaryContainsKeyValuePairConstraint("Hi", "Universe"));
Assert.That(dictionary, Does.ContainKey("Hola").WithValue("Mundo"));
Assert.That(dictionary, Does.Not.ContainKey("Hello").WithValue("NotValue"));
Assert.That(dictionary, new DictionaryContainsKeyValuePairConstraint("HI", "UNIVERSE").IgnoreCase);
Assert.That(dictionary, new DictionaryContainsKeyValuePairConstraint("HI", "UNIVERSE").Using<string>((x, y) => StringUtil.Compare(x, y, true)));
```

## Modifiers

```csharp
...IgnoreCase
...IgnoreWhiteSpace  // From version 4.2
...Using(IComparer comparer)
...Using(IEqualityComparer comparer)
...Using<T>(IComparer<T> comparer)
...Using<T>(Comparison<T> comparer)
...Using<T>(Func<T, T, bool> comparer)
...Using<T>(IEqualityComparer<T> comparer)
...UsingPropertiesComparer()  // From version 4.1
...UsingPropertiesComparer(
      Func<PropertiesComparerConfiguration,
           PropertiesComparerConfiguration> configure) // From version 4.4
```

## See also

* [DictionaryContainsValueConstraint](DictionaryContainsValueConstraint.md)
* [DictionaryContainsKeyConstraint](DictionaryContainsKeyConstraint.md)

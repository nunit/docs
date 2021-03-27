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

## See also

* [DictionaryContainsValueConstraint](DictionaryContainsValueConstraint.md)
* [DictionaryContainsKeyConstraint](DictionaryContainsKeyConstraint.md)

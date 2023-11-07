# ClassicAssert.IsNotEmpty

**ClassicAssert.IsNotEmpty** may be used to test either a string or a collection or IEnumerable. When used with a
string, it succeeds if the string is not the empty string. When used with a collection, it succeeds if the collection is
not empty.

```csharp
ClassicAssert.IsNotEmpty(string aString);
ClassicAssert.IsNotEmpty(string aString, string message, params object[] args);

ClassicAssert.IsNotEmpty(IEnumerable collection);
ClassicAssert.IsNotEmpty(IEnumerable collection, string message,
                  params object[] args);
```

> [!NOTE]
> When used with an IEnumerable that is not also an ICollection, **ClassicAssert.IsEmpty** attempts to enumerate
> the contents. It should not be used in cases where this results in an unwanted side effect.

## See Also

* [Condition Constraints](xref:constraints#condition-constraints)

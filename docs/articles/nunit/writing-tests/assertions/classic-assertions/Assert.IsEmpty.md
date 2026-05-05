---
uid: classic-assert-is-empty
---

# Assert.IsEmpty

**Assert.IsEmpty** may be used to test either a string or a collection or IEnumerable. When used with a string,
it succeeds if the string is the empty string. When used with a collection, it succeeds if the collection is empty.

> [!NOTE]
> From version 4.5.0, using C# 14, you don't need to use the ClassicAssert class, nor the NUnit.Framework.Legacy
> namespace, but can use the former Assert class. This applies for many of the asserts, but a few still require the use of
> the ClassicAssert class. These will be fixed in upcoming releases. In the list below, and in the examples, the 4.5.0
> syntax will be used. If you use an earlier 4.x version, replace Assert with ClassicAssert and include the
> NUnit.Framework.Legacy namespace.

```csharp
Assert.IsEmpty(string aString);
Assert.IsEmpty(string aString, string message, params object[] args);

Assert.IsEmpty(IEnumerable collection);
Assert.IsEmpty(IEnumerable collection, string message,
               params object[] args);
```

> [!NOTE]
> When used with an IEnumerable that is not also an ICollection, **Assert.IsEmpty** attempts to enumerate
> the contents. It should not be used in cases where this results in an unwanted side effect.

## See Also

* [Condition Constraints](xref:constraints#condition-constraints)

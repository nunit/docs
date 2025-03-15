# ClassicAssert.NotNull

**ClassicAssert.NotNull** and **ClassicAssert.IsNotNull** test that the specified object is non-null.
The two forms are provided for compatibility with past versions of NUnit and
NUnitLite.

```csharp
ClassicAssert.NotNull(object anObject);
ClassicAssert.NotNull(object anObject, string message, params object[] params);

ClassicAssert.IsNotNull(object anObject);
ClassicAssert.IsNotNull(object anObject, string message, params object[] params);
```

## See Also

* [Condition Constraints](xref:constraints#condition-constraints)

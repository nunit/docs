# ClassicAssert.Null

**ClassicAssert.Null** and **ClassicAssert.IsNull** test that the specified object is null.
The two forms are provided for compatibility with past versions of NUnit and
NUnitLite.

```csharp
ClassicAssert.Null(object anObject);
ClassicAssert.Null(object anObject, string message, params object[] params);

ClassicAssert.IsNull(object anObject);
ClassicAssert.IsNull(object anObject, string message, params object[] params);
```

## See Also

* [Condition Constraints](xref:constraints#condition-constraints)

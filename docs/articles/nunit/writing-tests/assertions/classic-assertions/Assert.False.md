# ClassicAssert.False

**ClassicAssert.False** and **ClassicAssert.IsFalse** test that the specified condition is false.
The two forms are provided for compatibility with past versions of NUnit and
NUnitLite.

```csharp
ClassicAssert.False(bool condition);
ClassicAssert.False(bool condition, string message, params object[] params);

ClassicAssert.IsFalse(bool condition);
ClassicAssert.IsFalse(bool condition, string message, params object[] params);
```

## See Also

* [Condition Constraints](xref:constraints#condition-constraints)

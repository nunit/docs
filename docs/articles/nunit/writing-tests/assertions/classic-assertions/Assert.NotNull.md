---
uid: classic-assert-not-null
---

# Assert.NotNull

**Assert.NotNull** and **Assert.IsNotNull** test that the specified object is non-null.
The two forms are provided for compatibility with past versions of NUnit and
NUnitLite.

> [!NOTE]
> From version 4.5.0, using C# 14, you don't need to use the ClassicAssert class, nor the NUnit.Framework.Legacy
> namespace, but can use the former Assert class. This applies for many of the asserts, but a few still require the use of
> the ClassicAssert class. These will be fixed in upcoming releases. In the list below, and in the examples, the 4.5.0
> syntax will be used. If you use an earlier 4.x version, replace Assert with ClassicAssert and include the
> NUnit.Framework.Legacy namespace.

```csharp
Assert.NotNull(object anObject);
Assert.NotNull(object anObject, string message, params object[] params);

Assert.IsNotNull(object anObject);
Assert.IsNotNull(object anObject, string message, params object[] params);
```

## See Also

* [Condition Constraints](xref:constraints#condition-constraints)

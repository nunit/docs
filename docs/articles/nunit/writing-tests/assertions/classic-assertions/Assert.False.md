# Assert.False

**Assert.False** and **Assert.IsFalse** test that the specified condition is false.
The two forms are provided for compatibility with past versions of NUnit and
NUnitLite.

> [!NOTE]
> From version 4.5.0, using C# 14, you don't need to use the ClassicAssert class, nor the NUnit.Framework.Legacy
> namespace, but can use the former Assert class. This applies for many of the asserts, but a few still require the use of
> the ClassicAssert class. These will be fixed in upcoming releases. In the list below, and in the examples, the 4.5.0
> syntax will be used. If you use an earlier 4.x version, replace Assert with ClassicAssert and include the
> NUnit.Framework.Legacy namespace.

```csharp
Assert.False(bool condition);
Assert.False(bool condition, string message, params object[] params);

Assert.IsFalse(bool condition);
Assert.IsFalse(bool condition, string message, params object[] params);
```

## See Also

* [Condition Constraints](xref:constraints#condition-constraints)

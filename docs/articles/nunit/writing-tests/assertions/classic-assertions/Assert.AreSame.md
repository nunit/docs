# Assert.AreSame

**Assert.AreSame** tests that the two arguments reference the same object.

> [!NOTE]
> From version 4.5.0, using C# 14, you don't need to use the ClassicAssert class, nor the NUnit.Framework.Legacy
> namespace, but can use the former Assert class. This applies for many of the asserts, but a few still require the use of
> the ClassicAssert class. These will be fixed in upcoming releases. In the list below, and in the examples, the 4.5.0
> syntax will be used. If you use an earlier 4.x version, replace Assert with ClassicAssert and include the
> NUnit.Framework.Legacy namespace.

```csharp
Assert.AreSame(object expected, object actual);
Assert.AreSame(object expected, object actual,
               string message, params object[] params);
```

## See Also

* [SameAs Constraint](xref:constraint-sameas)

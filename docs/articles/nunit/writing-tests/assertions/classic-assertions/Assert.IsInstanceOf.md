---
uid: classic-assert-is-instance-of
---

# Assert.IsInstanceOf

**Assert.IsInstanceOf** succeeds if the object provided as an actual value is an instance of the expected type.

> [!NOTE]
> From version 4.5.0, using C# 14, you don't need to use the ClassicAssert class, nor the NUnit.Framework.Legacy
> namespace, but can use the former Assert class. This applies for many of the asserts, but a few still require the use of
> the ClassicAssert class. These will be fixed in upcoming releases. In the list below, and in the examples, the 4.5.0
> syntax will be used. If you use an earlier 4.x version, replace Assert with ClassicAssert and include the
> NUnit.Framework.Legacy namespace.

```csharp
Assert.IsInstanceOf(Type expected, object actual);
Assert.IsInstanceOf(Type expected, object actual,
                    string message, params object[] params);
Assert.IsInstanceOf<T>(object actual);
Assert.IsInstanceOf<T>(object actual,
                       string message, params object[] params);
```

## See Also

* [Type Constraints](xref:constraints#type-constraints)

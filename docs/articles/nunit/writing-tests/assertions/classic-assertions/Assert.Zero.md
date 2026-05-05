---
uid: classic-assert-zero
---

# Assert.Zero

**Assert.Zero** tests that a value is zero.

> [!NOTE]
> From version 4.5.0, using C# 14, you don't need to use the ClassicAssert class, nor the NUnit.Framework.Legacy
> namespace, but can use the former Assert class. This applies for many of the asserts, but a few still require the use of
> the ClassicAssert class. These will be fixed in upcoming releases. In the list below, and in the examples, the 4.5.0
> syntax will be used. If you use an earlier 4.x version, replace Assert with ClassicAssert and include the
> NUnit.Framework.Legacy namespace.

```csharp
Assert.Zero(int actual);
Assert.Zero(int actual, string message, params object[] args);

Assert.Zero(uint actual);
Assert.Zero(uint actual, string message, params object[] args);

Assert.Zero(long actual);
Assert.Zero(long actual, string message, params object[] args);

Assert.Zero(ulong actual);
Assert.Zero(ulong actual, string message, params object[] args);

Assert.Zero(decimal actual);
Assert.Zero(decimal actual, string message, params object[] args);

Assert.Zero(double actual);
Assert.Zero(double actual, string message, params object[] args);

Assert.Zero(float actual);
Assert.Zero(float actual, string message, params object[] args);
```

You may also use **Assert.That** with a Is.Zero constraint to achieve the
same result.

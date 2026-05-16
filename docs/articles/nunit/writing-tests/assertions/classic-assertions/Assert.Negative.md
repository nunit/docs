---
uid: classic-assert-negative
---

# Assert.Negative

Asserts that a number is negative.

> [!NOTE]
> From version 4.5.0, using C# 14, you don't need to use the ClassicAssert class, nor the NUnit.Framework.Legacy
> namespace, but can use the former Assert class. This applies for many of the asserts, but a few still require the use of
> the ClassicAssert class. These will be fixed in upcoming releases. In the list below, and in the examples, the 4.5.0
> syntax will be used. If you use an earlier 4.x version, replace Assert with ClassicAssert and include the
> NUnit.Framework.Legacy namespace.

```csharp
//true
Assert.Negative(-1);
//false
Assert.Negative(1);
```

All the overloads of the method are

```csharp
Assert.Negative(int actual);
Assert.Negative(int actual, string message, params object[] args);

Assert.Negative(uint actual);
Assert.Negative(uint actual, string message, params object[] args);

Assert.Negative(long actual);
Assert.Negative(long actual, string message, params object[] args);

Assert.Negative(ulong actual);
Assert.Negative(ulong actual, string message, params object[] args);

Assert.Negative(decimal actual);
Assert.Negative(decimal actual, string message, params object[] args);

Assert.Negative(double actual);
Assert.Negative(double actual, string message, params object[] args);

Assert.Negative(float actual);
Assert.Negative(float actual, string message, params object[] args);
```

You may also use **Assert.That** with a **Is.Negative** constraint to achieve the same result.

## See Also

* [Assert.Positive](Assert.Positive.md)
* [Assert.Zero](Assert.Zero.md)
* [Assert.NotZero](Assert.NotZero.md)
* [Assert.IsNaN](Assert.IsNaN.md)

# Assert.Positive

Asserts that a number is positive.

:NOTE: From version 4.5.0, using C# 14, you don't need to use the ClassicAssert class, nor the NUnit.Framework.Legacy
namespace, but can use the former Assert class. This applies for many of the asserts, but a few still require the use of
the ClassicAssert class. These will be fixed in upcoming releases. In the list below, and in the examples, the 4.5.0
syntax will be used. If you use an earlier 4.x version, replace Assert with ClassicAssert and include the
NUnit.Framework.Legacy namespace.

```csharp
//false
Assert.Positive(-1);
//true
Assert.Positive(1);
```

All the overloads of the method are

```csharp
Assert.Positive(int actual);
Assert.Positive(int actual, string message, params object[] args);

Assert.Positive(uint actual);
Assert.Positive(uint actual, string message, params object[] args);

Assert.Positive(long actual);
Assert.Positive(long actual, string message, params object[] args);

Assert.Positive(ulong actual);
Assert.Positive(ulong actual, string message, params object[] args);

Assert.Positive(decimal actual);
Assert.Positive(decimal actual, string message, params object[] args);

Assert.Positive(double actual);
Assert.Positive(double actual, string message, params object[] args);

Assert.Positive(float actual);
Assert.Positive(float actual, string message, params object[] args);
```

You may also use **Assert.That** with a **Is.Positive** constraint to achieve the same result.

## See Also

* [Assert.Negative](Assert.Negative.md)
* [Assert.Zero](Assert.Zero.md)
* [Assert.NotZero](Assert.NotZero.md)
* [Assert.IsNaN](Assert.IsNaN.md)

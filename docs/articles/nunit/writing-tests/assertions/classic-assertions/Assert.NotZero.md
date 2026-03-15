# Assert.NotZero

**Assert.NotZero** tests that a value is not zero.

:NOTE: From version 4.5.0, using C# 14, you don't need to use the ClassicAssert class, nor the NUnit.Framework.Legacy
namespace, but can use the former Assert class. This applies for many of the asserts, but a few still require the use of
the ClassicAssert class. These will be fixed in upcoming releases. In the list below, and in the examples, the 4.5.0
syntax will be used. If you use an earlier 4.x version, replace Assert with ClassicAssert and include the
NUnit.Framework.Legacy namespace.

```csharp
Assert.NotZero(int actual);
Assert.NotZero(int actual, string message, params object[] args);

Assert.NotZero(uint actual);
Assert.NotZero(uint actual, string message, params object[] args);

Assert.NotZero(long actual);
Assert.NotZero(long actual, string message, params object[] args);

Assert.NotZero(ulong actual);
Assert.NotZero(ulong actual, string message, params object[] args);

Assert.NotZero(decimal actual);
Assert.NotZero(decimal actual, string message, params object[] args);

Assert.NotZero(double actual);
Assert.NotZero(double actual, string message, params object[] args);

Assert.NotZero(float actual);
Assert.NotZero(float actual, string message, params object[] args);
```

You may also use **Assert.That** with a `Is.Not.Zero` constraint to achieve the
same result.

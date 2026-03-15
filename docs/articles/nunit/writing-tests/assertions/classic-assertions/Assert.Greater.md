# Assert.Greater

**Assert.Greater** tests whether one object is greater than another.
Contrary to the normal order of Asserts, these methods are designed to be
read in the "natural" English-language or mathematical order. Thus
**Assert.Greater(x, y)** asserts that x is greater than y (x > y).

:NOTE: From version 4.5.0, using C# 14, you don't need to use the ClassicAssert class, nor the NUnit.Framework.Legacy
namespace, but can use the former Assert class. This applies for many of the asserts, but a few still require the use of
the ClassicAssert class. These will be fixed in upcoming releases. In the list below, and in the examples, the 4.5.0
syntax will be used. If you use an earlier 4.x version, replace Assert with ClassicAssert and include the
NUnit.Framework.Legacy namespace.

```csharp
Assert.Greater(int arg1, int arg2);
Assert.Greater(int arg1, int arg2,
               string message, params object[] params);

Assert.Greater(uint arg1, uint arg2);
Assert.Greater(uint arg1, uint arg2,
               string message, params object[] params);

Assert.Greater(long arg1, long arg2);
Assert.Greater(long arg1, long arg2,
               string message, params object[] params);

Assert.Greater(ulong arg1, ulong arg2);
Assert.Greater(ulong arg1, ulong arg2,
               string message, params object[] params);

Assert.Greater(decimal arg1, decimal arg2);
Assert.Greater(decimal arg1, decimal arg2,
               string message, params object[] params);

Assert.Greater(double arg1, double arg2);
Assert.Greater(double arg1, double arg2,
               string message, params object[] params);

Assert.Greater(float arg1, float arg2);
Assert.Greater(float arg1, float arg2,
               string message, params object[] params);

Assert.Greater(IComparable arg1, IComparable arg2);
Assert.Greater(IComparable arg1, IComparable arg2,
               string message, params object[] params);
```

## See Also

* [Assert.GreaterOrEqual](Assert.GreaterOrEqual.md)
* [Assert.Less](Assert.Less.md)
* [Assert.LessOrEqual](Assert.LessOrEqual.md)
* [Comparison Constraints](xref:constraints#comparison-constraints)

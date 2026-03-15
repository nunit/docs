# Assert.Less

**Assert.Less** tests whether one object is less than another.
Contrary to the normal order of Asserts, these methods are designed to be
read in the "natural" English-language or mathematical order. Thus
**Assert.Less(x, y)** asserts that x is less than y (x < y).

:NOTE: From version 4.5.0, using C# 14, you don't need to use the ClassicAssert class, nor the NUnit.Framework.Legacy
namespace, but can use the former Assert class. This applies for many of the asserts, but a few still require the use of
the ClassicAssert class. These will be fixed in upcoming releases. In the list below, and in the examples, the 4.5.0
syntax will be used. If you use an earlier 4.x version, replace Assert with ClassicAssert and include the
NUnit.Framework.Legacy namespace.

```csharp
Assert.Less(int arg1, int arg2);
Assert.Less(int arg1, int arg2, string message, params object[] params);

Assert.Less(uint arg1, uint arg2);
Assert.Less(uint arg1, uint arg2, string message, params object[] params);

Assert.Less(long arg1, long arg2);
Assert.Less(long arg1, long arg2, string message, params object[] params);

Assert.Less(ulong arg1, ulong arg2);
Assert.Less(ulong arg1, ulong arg2, string message, params object[] params);

Assert.Less(decimal arg1, decimal arg2);
Assert.Less(decimal arg1, decimal arg2,
            string message, params object[] params);

Assert.Less(double arg1, double arg2);
Assert.Less(double arg1, double arg2,
            string message, params object[] params);

Assert.Less(float arg1, float arg2);
Assert.Less(float arg1, float arg2,
            string message, params object[] params);

Assert.Less(IComparable arg1, IComparable arg2);
Assert.Less(IComparable arg1, IComparable arg2,
            string message, params object[] params);
```

## See Also

* [Assert.Greater](Assert.Greater.md)
* [Assert.GreaterOrEqual](Assert.GreaterOrEqual.md)
* [Assert.LessOrEqual](Assert.LessOrEqual.md)
* [Comparison Constraints](xref:constraints#comparison-constraints)

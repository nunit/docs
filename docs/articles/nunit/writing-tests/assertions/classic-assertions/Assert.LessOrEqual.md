---
uid: classic-assert-less-or-equal
---

# Assert.LessOrEqual

**Assert.LessOrEqual** tests whether one object is less than or equal to another.
Contrary to the normal order of Asserts, these methods are designed to be
read in the "natural" English-language or mathematical order. Thus
**Assert.LessOrEqual(x, y)** asserts that x is less than or equal to y (x <= y).

> [!NOTE]
> From version 4.5.0, using C# 14, you don't need to use the ClassicAssert class, nor the NUnit.Framework.Legacy
> namespace, but can use the former Assert class. This applies for many of the asserts, but a few still require the use of
> the ClassicAssert class. These will be fixed in upcoming releases. In the list below, and in the examples, the 4.5.0
> syntax will be used. If you use an earlier 4.x version, replace Assert with ClassicAssert and include the
> NUnit.Framework.Legacy namespace.

```csharp
Assert.LessOrEqual(int arg1, int arg2);
Assert.LessOrEqual(int arg1, int arg2,
                   string message, params object[] params);

Assert.LessOrEqual(uint arg1, uint arg2);
Assert.LessOrEqual(uint arg1, uint arg2,
                   string message, params object[] params);

Assert.LessOrEqual(long arg1, long arg2);
Assert.LessOrEqual(long arg1, long arg2,
                   string message, params object[] params);

Assert.LessOrEqual(ulong arg1, ulong arg2);
Assert.LessOrEqual(ulong arg1, ulong arg2,
                   string message, params object[] params);

Assert.LessOrEqual(decimal arg1, decimal arg2);
Assert.LessOrEqual(decimal arg1, decimal arg2,
                   string message, params object[] params);

Assert.LessOrEqual(double arg1, double arg2);
Assert.LessOrEqual(double arg1, double arg2,
                   string message, params object[] params);

Assert.LessOrEqual(float arg1, float arg2);
Assert.LessOrEqual(float arg1, float arg2,
                   string message, params object[] params);

Assert.LessOrEqual(IComparable arg1, IComparable arg2);
Assert.LessOrEqual(IComparable arg1, IComparable arg2,
                   string message, params object[] params);
```

## See Also

* [Assert.Greater](Assert.Greater.md)
* [Assert.GreaterOrEqual](Assert.GreaterOrEqual.md)
* [Assert.Less](Assert.Less.md)
* [Comparison Constraints](xref:constraints#comparison-constraints)

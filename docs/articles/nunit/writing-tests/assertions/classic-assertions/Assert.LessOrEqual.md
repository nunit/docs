# ClassicAssert.LessOrEqual

**ClassicAssert.LessOrEqual** tests whether one object is less than or equal to another.
Contrary to the normal order of Asserts, these methods are designed to be
read in the "natural" English-language or mathematical order. Thus
**ClassicAssert.LessOrEqual(x, y)** asserts that x is less than or equal to y (x <= y).

```csharp
ClassicAssert.LessOrEqual(int arg1, int arg2);
ClassicAssert.LessOrEqual(int arg1, int arg2,
                   string message, params object[] params);

ClassicAssert.LessOrEqual(uint arg1, uint arg2);
ClassicAssert.LessOrEqual(uint arg1, uint arg2,
                   string message, params object[] params);

ClassicAssert.LessOrEqual(long arg1, long arg2);
ClassicAssert.LessOrEqual(long arg1, long arg2,
                   string message, params object[] params);

ClassicAssert.LessOrEqual(ulong arg1, ulong arg2);
ClassicAssert.LessOrEqual(ulong arg1, ulong arg2,
                   string message, params object[] params);

ClassicAssert.LessOrEqual(decimal arg1, decimal arg2);
ClassicAssert.LessOrEqual(decimal arg1, decimal arg2,
                   string message, params object[] params);

ClassicAssert.LessOrEqual(double arg1, double arg2);
ClassicAssert.LessOrEqual(double arg1, double arg2,
                   string message, params object[] params);

ClassicAssert.LessOrEqual(float arg1, float arg2);
ClassicAssert.LessOrEqual(float arg1, float arg2,
                   string message, params object[] params);

ClassicAssert.LessOrEqual(IComparable arg1, IComparable arg2);
ClassicAssert.LessOrEqual(IComparable arg1, IComparable arg2,
                   string message, params object[] params);
```

## See Also

* [ClassicAssert.Greater](Assert.Greater.md)
* [ClassicAssert.GreaterOrEqual](Assert.GreaterOrEqual.md)
* [ClassicAssert.Less](Assert.Less.md)
* [Comparison Constraints](xref:constraints#comparison-constraints)

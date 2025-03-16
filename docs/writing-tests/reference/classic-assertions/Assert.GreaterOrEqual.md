# ClassicAssert.GreaterOrEqual

**ClassicAssert.GreaterOrEqual** tests whether one object is greater than or equal to another.
Contrary to the normal order of Asserts, these methods are designed to be
read in the "natural" English-language or mathematical order. Thus
**ClassicAssert.GreaterOrEqual(x, y)** asserts that x is greater than or equal to y (x >= y).

```csharp
ClassicAssert.GreaterOrEqual(int arg1, int arg2);
ClassicAssert.GreaterOrEqual(int arg1, int arg2,
                      string message, params object[] params);

ClassicAssert.GreaterOrEqual(uint arg1, uint arg2);
ClassicAssert.GreaterOrEqual(uint arg1, uint arg2,
                      string message, params object[] params);

ClassicAssert.GreaterOrEqual(long arg1, long arg2);
ClassicAssert.GreaterOrEqual(long arg1, long arg2,
                      string message, params object[] params);

ClassicAssert.GreaterOrEqual(ulong arg1, ulong arg2);
ClassicAssert.GreaterOrEqual(ulong arg1, ulong arg2,
                      string message, params object[] params);

ClassicAssert.GreaterOrEqual(decimal arg1, decimal arg2);
ClassicAssert.GreaterOrEqual(decimal arg1, decimal arg2,
                      string message, params object[] params);

ClassicAssert.GreaterOrEqual(double arg1, double arg2);
ClassicAssert.GreaterOrEqual(double arg1, double arg2,
                      string message, params object[] params);

ClassicAssert.GreaterOrEqual(float arg1, float arg2);
ClassicAssert.GreaterOrEqual(float arg1, float arg2,
                      string message, params object[] params);

ClassicAssert.GreaterOrEqual(IComparable arg1, IComparable arg2);
ClassicAssert.GreaterOrEqual(IComparable arg1, IComparable arg2,
                      string message, params object[] params);
```

## See Also

* [ClassicAssert.Greater](Assert.Greater.md)
* [ClassicAssert.Less](Assert.Less.md)
* [ClassicAssert.LessOrEqual](Assert.LessOrEqual.md)
* [Comparison Constraints](xref:constraints#comparison-constraints)

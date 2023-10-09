# ClassicAssert.Greater

**ClassicAssert.Greater** tests whether one object is greater than another.
Contrary to the normal order of Asserts, these methods are designed to be
read in the "natural" English-language or mathematical order. Thus
**ClassicAssert.Greater(x, y)** asserts that x is greater than y (x > y).

```csharp
ClassicAssert.Greater(int arg1, int arg2);
ClassicAssert.Greater(int arg1, int arg2,
               string message, params object[] params);

ClassicAssert.Greater(uint arg1, uint arg2);
ClassicAssert.Greater(uint arg1, uint arg2,
               string message, params object[] params);

ClassicAssert.Greater(long arg1, long arg2);
ClassicAssert.Greater(long arg1, long arg2,
               string message, params object[] params);

ClassicAssert.Greater(ulong arg1, ulong arg2);
ClassicAssert.Greater(ulong arg1, ulong arg2,
               string message, params object[] params);

ClassicAssert.Greater(decimal arg1, decimal arg2);
ClassicAssert.Greater(decimal arg1, decimal arg2,
               string message, params object[] params);

ClassicAssert.Greater(double arg1, double arg2);
ClassicAssert.Greater(double arg1, double arg2,
               string message, params object[] params);

ClassicAssert.Greater(float arg1, float arg2);
ClassicAssert.Greater(float arg1, float arg2,
               string message, params object[] params);

ClassicAssert.Greater(IComparable arg1, IComparable arg2);
ClassicAssert.Greater(IComparable arg1, IComparable arg2,
               string message, params object[] params);
```

## See Also

* [ClassicAssert.GreaterOrEqual](Assert.GreaterOrEqual.md)
* [ClassicAssert.Less](Assert.Less.md)
* [ClassicAssert.LessOrEqual](Assert.LessOrEqual.md)
* [Comparison Constraints](xref:constraints#comparison-constraints)

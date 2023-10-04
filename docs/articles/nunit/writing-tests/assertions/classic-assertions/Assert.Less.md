# ClassicAssert.Less

**ClassicAssert.Less** tests whether one object is less than another.
Contrary to the normal order of Asserts, these methods are designed to be
read in the "natural" English-language or mathematical order. Thus
**ClassicAssert.Less(x, y)** asserts that x is less than y (x < y).

```csharp
ClassicAssert.Less(int arg1, int arg2);
ClassicAssert.Less(int arg1, int arg2, string message, params object[] params);

ClassicAssert.Less(uint arg1, uint arg2);
ClassicAssert.Less(uint arg1, uint arg2, string message, params object[] params);

ClassicAssert.Less(long arg1, long arg2);
ClassicAssert.Less(long arg1, long arg2, string message, params object[] params);

ClassicAssert.Less(ulong arg1, ulong arg2);
ClassicAssert.Less(ulong arg1, ulong arg2, string message, params object[] params);

ClassicAssert.Less(decimal arg1, decimal arg2);
ClassicAssert.Less(decimal arg1, decimal arg2,
            string message, params object[] params);

ClassicAssert.Less(double arg1, double arg2);
ClassicAssert.Less(double arg1, double arg2,
            string message, params object[] params);

ClassicAssert.Less(float arg1, float arg2);
ClassicAssert.Less(float arg1, float arg2,
            string message, params object[] params);

ClassicAssert.Less(IComparable arg1, IComparable arg2);
ClassicAssert.Less(IComparable arg1, IComparable arg2,
            string message, params object[] params);
```

## See Also

* [ClassicAssert.Greater](Assert.Greater.md)
* [ClassicAssert.GreaterOrEqual](Assert.GreaterOrEqual.md)
* [ClassicAssert.LessOrEqual](Assert.LessOrEqual.md)
* [Comparison Constraints](xref:constraints#comparison-constraints)

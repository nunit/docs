# Assert.Less


**Assert.Less** tests whether one object is less than another.
Contrary to the normal order of Asserts, these methods are designed to be
read in the "natural" English-language or mathematical order. Thus
**Assert.Less(x, y)** asserts that x is less than y (x < y).

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

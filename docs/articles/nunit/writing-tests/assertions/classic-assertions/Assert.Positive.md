# ClassicAssert.Positive

Asserts that a number is positive.

```csharp
//false
ClassicAssert.Positive(-1);
//true
ClassicAssert.Positive(1);
```

All the overloads of the method are

```csharp
ClassicAssert.Positive(int actual);
ClassicAssert.Positive(int actual, string message, params object[] args);

ClassicAssert.Positive(uint actual);
ClassicAssert.Positive(uint actual, string message, params object[] args);

ClassicAssert.Positive(long actual);
ClassicAssert.Positive(long actual, string message, params object[] args);

ClassicAssert.Positive(ulong actual);
ClassicAssert.Positive(ulong actual, string message, params object[] args);

ClassicAssert.Positive(decimal actual);
ClassicAssert.Positive(decimal actual, string message, params object[] args);

ClassicAssert.Positive(double actual);
ClassicAssert.Positive(double actual, string message, params object[] args);

ClassicAssert.Positive(float actual);
ClassicAssert.Positive(float actual, string message, params object[] args);
```

You may also use **ClassicAssert.That** with a **Is.Positive** constraint to achieve the same result.

## See Also

* [ClassicAssert.Negative](Assert.Negative.md)
* [ClassicAssert.Zero](Assert.Zero.md)
* [ClassicAssert.NotZero](Assert.NotZero.md)
* [ClassicAssert.IsNaN](Assert.IsNaN.md)

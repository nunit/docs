# ClassicAssert.Negative

Asserts that a number is negative.

```csharp
//true
ClassicAssert.Negative(-1);
//false
ClassicAssert.Negative(1);
```

All the overloads of the method are

```csharp
ClassicAssert.Negative(int actual);
ClassicAssert.Negative(int actual, string message, params object[] args);

ClassicAssert.Negative(uint actual);
ClassicAssert.Negative(uint actual, string message, params object[] args);

ClassicAssert.Negative(long actual);
ClassicAssert.Negative(long actual, string message, params object[] args);

ClassicAssert.Negative(ulong actual);
ClassicAssert.Negative(ulong actual, string message, params object[] args);

ClassicAssert.Negative(decimal actual);
ClassicAssert.Negative(decimal actual, string message, params object[] args);

ClassicAssert.Negative(double actual);
ClassicAssert.Negative(double actual, string message, params object[] args);

ClassicAssert.Negative(float actual);
ClassicAssert.Negative(float actual, string message, params object[] args);
```

You may also use **ClassicAssert.That** with a **Is.Negative** constraint to achieve the same result.

## See Also

* [ClassicAssert.Positive](Assert.Positive.md)
* [ClassicAssert.Zero](Assert.Zero.md)
* [ClassicAssert.NotZero](Assert.NotZero.md)
* [ClassicAssert.IsNaN](Assert.IsNaN.md)

# ClassicAssert.Zero

**ClassicAssert.Zero** tests that a value is zero.

```csharp
ClassicAssert.Zero(int actual);
ClassicAssert.Zero(int actual, string message, params object[] args);

ClassicAssert.Zero(uint actual);
ClassicAssert.Zero(uint actual, string message, params object[] args);

ClassicAssert.Zero(long actual);
ClassicAssert.Zero(long actual, string message, params object[] args);

ClassicAssert.Zero(ulong actual);
ClassicAssert.Zero(ulong actual, string message, params object[] args);

ClassicAssert.Zero(decimal actual);
ClassicAssert.Zero(decimal actual, string message, params object[] args);

ClassicAssert.Zero(double actual);
ClassicAssert.Zero(double actual, string message, params object[] args);

ClassicAssert.Zero(float actual);
ClassicAssert.Zero(float actual, string message, params object[] args);
```

You may also use **Assert.That** with a Is.Zero constraint to achieve the
same result.

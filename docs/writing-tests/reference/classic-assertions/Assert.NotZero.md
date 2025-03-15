# ClassicAssert.NotZero

**ClassicAssert.NotZero** tests that a value is not zero.

```csharp
ClassicAssert.NotZero(int actual);
ClassicAssert.NotZero(int actual, string message, params object[] args);

ClassicAssert.NotZero(uint actual);
ClassicAssert.NotZero(uint actual, string message, params object[] args);

ClassicAssert.NotZero(long actual);
ClassicAssert.NotZero(long actual, string message, params object[] args);

ClassicAssert.NotZero(ulong actual);
ClassicAssert.NotZero(ulong actual, string message, params object[] args);

ClassicAssert.NotZero(decimal actual);
ClassicAssert.NotZero(decimal actual, string message, params object[] args);

ClassicAssert.NotZero(double actual);
ClassicAssert.NotZero(double actual, string message, params object[] args);

ClassicAssert.NotZero(float actual);
ClassicAssert.NotZero(float actual, string message, params object[] args);
```

You may also use **ClassicAssert.That** with a `Is.Not.Zero` constraint to achieve the
same result.

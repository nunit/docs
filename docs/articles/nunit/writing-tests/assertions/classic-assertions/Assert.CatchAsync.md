# Assert.CatchAsync

**Assert.CatchAsync** is similar to [Assert.ThrowsAsync](Assert.ThrowsAsync.md) but will pass for an exception
that is derived from the one specified.

```csharp
Exception Assert.CatchAsync(AsyncTestDelegate code);
Exception Assert.CatchAsync(AsyncTestDelegate code,
                            string message, params object[] params);

Exception Assert.CatchAsync(Type expectedExceptionType, AsyncTestDelegate code);
Exception Assert.CatchAsync(Type expectedExceptionType, AsyncTestDelegate code,
                            string message, params object[] params);

T Assert.CatchAsync<T>(AsyncTestDelegate code);
T Assert.CatchAsync<T>(AsyncTestDelegate code,
                       string message, params object[] params);
```

## See Also

* [Assert.Catch](Assert.Catch.md)
* [Assert.Throws](Assert.Throws.md)
* [Assert.ThrowsAsync](Assert.ThrowsAsync.md)
* [ThrowsConstraint](xref:ThrowsConstraint)

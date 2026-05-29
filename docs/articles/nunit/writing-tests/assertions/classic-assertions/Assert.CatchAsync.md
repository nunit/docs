---
uid: classic-assert-catch-async
---

# Assert.CatchAsync

**Assert.CatchAsync** is similar to [Assert.ThrowsAsync](Assert.ThrowsAsync.md) but will pass for an exception that is derived from the one specified.

```csharp
Task<Exception> Assert.CatchAsync(Func<Task> asyncCode);
Task<Exception> Assert.CatchAsync(Func<Task> asyncCode,
                            string message, params object[] params);

Task<Exception> Assert.CatchAsync(Type expectedExceptionType, Func<Task> asyncCode);
Task<Exception> Assert.CatchAsync(Type expectedExceptionType, Func<Task> asyncCode,
                            string message, params object[] params);

Task<T> Assert.CatchAsync<T>(Func<Task> asyncCode);
Task<T> Assert.CatchAsync<T>(Func<Task> asyncCode,
                       string message, params object[] params);
```

## NUnit 4 and earlier

In NUnit 4 and earlier this assertion would not need to be awaited and would return the `Exception` or `TActual` instance directly. The callback to invoke would also be passed as an `AsyncTestDelegate` instead of a `Func<Task>`. These behaviors were both changed in NUnit 5 to better align the API with
modern .NET standards and conventions.

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
* [ThrowsConstraint](xref:constraint-throws)

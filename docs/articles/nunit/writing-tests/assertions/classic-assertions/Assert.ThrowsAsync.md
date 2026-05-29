---
uid: classic-assert-throws-async
---

# Assert.ThrowsAsync

The **Assert.ThrowsAsync** is the async equivalent to [Assert.Throws](Assert.Throws.md)
for asynchronous code. See [Assert.Throws](Assert.Throws.md) for more information.

```csharp
Task<Exception> Assert.ThrowsAsync(Type expectedExceptionType, Func<Task> asyncCode);
Task<Exception> Assert.ThrowsAsync(Type expectedExceptionType, Func<Task> asyncCode,
                             string message, params object[] params);

Task<Exception> Assert.ThrowsAsync(IResolveConstraint constraint, Func<Task> asyncCode);
Task<Exception> Assert.ThrowsAsync(IResolveConstraint constraint, Func<Task> asyncCode,
                             string message, params object[] params);

Task<TActual> Assert.ThrowsAsync<TActual>(Func<Task> asyncCode);
Task<TActual> Assert.ThrowsAsync<TActual>(Func<Task> asyncCode,
                                    string message, params object[] params);
```

In the above code `Func<Task>` is an async delegate, which is used to execute the code
in question. This will likely be a lambda expression.

The following example shows the most common way of writing tests.

[!code-csharp[AssertThrowsAsync](~/snippets/Snippets.NUnit/AssertThrowsAsync.cs#AssertThrowsAsync)]

This example shows use of the return value to perform additional verification of the exception.

[!code-csharp[AssertThrowsAsync](~/snippets/Snippets.NUnit/AssertThrowsAsync.cs#UsingReturnValue)]

## NUnit 4 and earlier

In NUnit 4 and earlier this assertion would not need to be awaited and would return the `Exception` or `TActual` instance directly. The callback to invoke would also be passed as an `AsyncTestDelegate` instead of a `Func<Task>`. These behaviors were both changed in NUnit 5 to better align the API with
modern .NET standards and conventions.

```csharp
Exception Assert.ThrowsAsync(Type expectedExceptionType, AsyncTestDelegate code);
Exception Assert.ThrowsAsync(Type expectedExceptionType, AsyncTestDelegate code,
                             string message, params object[] params);

Exception Assert.ThrowsAsync(IResolveConstraint constraint, AsyncTestDelegate code);
Exception Assert.ThrowsAsync(IResolveConstraint constraint, AsyncTestDelegate code,
                             string message, params object[] params);

TActual Assert.ThrowsAsync<TActual>(AsyncTestDelegate code);
TActual Assert.ThrowsAsync<TActual>(AsyncTestDelegate code,
                                    string message, params object[] params);
```

For example:

The following example shows the previous way to simply assert that an exception of a given type was thrown.

```csharp
[Test]
public void Tests()
{
    // Using a method as a delegate
    Assert.ThrowsAsync<ArgumentException>(async () => await MethodThatThrows());
}

private async Task MethodThatThrows()
{
    await Task.Delay(100);
    throw new ArgumentException();
}

```

This example shows use of the return value to perform additional verification of the exception.

```csharp
[Test]
public void TestException()
{
    MyException ex = Assert.ThrowsAsync<MyException>(async () => await MethodThatThrows());

    Assert.That(ex.Message, Is.EqualTo("message"));
    Assert.That(ex.MyParam, Is.EqualTo(42));
}

private async Task MethodThatThrows()
{
    await Task.Delay(100);
    throw new MyException("message", 42);
}
```

## See Also

* [Assert.Catch](Assert.Catch.md)
* [Assert.CatchAsync](Assert.CatchAsync.md)
* [Assert.Throws](Assert.Throws.md)
* [ThrowsConstraint](xref:constraint-throws)

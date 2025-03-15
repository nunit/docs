# Assert.ThrowsAsync

The **Assert.ThrowsAsync** is the async equivalent to [Assert.Throws](Assert.Throws.md)
for asynchronous code. See [Assert.Throws](Assert.Throws.md) for more information.

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

In the above code **AsyncTestDelegate** is a delegate of the form
**Task AsyncTestDelegate()**, which is used to execute the code
in question. This will likely be a lambda expression.

The following example shows the most common way of writing tests.

[!code-csharp[AssertThrowsAsync](~/snippets/Snippets.NUnit/AssertThrowsAsync.cs#AssertThrowsAsync)]

This example shows use of the return value to perform
additional verification of the exception. Note that you do not need to await the result.

[!code-csharp[AssertThrowsAsync](~/snippets/Snippets.NUnit/AssertThrowsAsync.cs#UsingReturnValue)]

## See Also

* [Assert.Catch](Assert.Catch.md)
* [Assert.CatchAsync](Assert.CatchAsync.md)
* [Assert.Throws](Assert.Throws.md)
* [ThrowsConstraint](xref:throwsconstraint)

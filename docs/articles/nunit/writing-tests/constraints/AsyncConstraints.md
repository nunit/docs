---
uid: constraint-async
---

# Async Constraint Support

NUnit constraints fully support testing asynchronous code. This page covers patterns for using constraints with async
methods, tasks, and delegates.

The examples on this page use this small service and calculator:

[!code-csharp[AsyncSampleService](~/snippets/Snippets.NUnit/Constraints/AsyncConstraintSnippets.cs#AsyncSampleService)]

## Testing Async Methods

### Basic Async Assertions

Use `async` lambdas with `Assert.That` to test async code:

[!code-csharp[AsyncBasicAssertions](~/snippets/Snippets.NUnit/Constraints/AsyncConstraintSnippets.cs#AsyncBasicAssertions)]

### Testing Task Results

You can also await tasks directly before asserting:

[!code-csharp[AsyncTaskResults](~/snippets/Snippets.NUnit/Constraints/AsyncConstraintSnippets.cs#AsyncTaskResults)]

## Exception Testing with Async Code

### ThrowsConstraint with Async

[!code-csharp[AsyncThrowsConstraint](~/snippets/Snippets.NUnit/Constraints/AsyncConstraintSnippets.cs#AsyncThrowsConstraint)]

### ThrowsNothing with Async

[!code-csharp[AsyncThrowsNothing](~/snippets/Snippets.NUnit/Constraints/AsyncConstraintSnippets.cs#AsyncThrowsNothing)]

## Delayed Constraints with Async

Use `DelayedConstraint` for testing eventually-consistent async operations:

[!code-csharp[AsyncDelayedConstraint](~/snippets/Snippets.NUnit/Constraints/AsyncConstraintSnippets.cs#AsyncDelayedConstraint)]

## Collection Constraints with Async Enumerables

For `IAsyncEnumerable<T>`, materialize the collection first. `ToListAsync` is built into .NET 10; on earlier
versions it comes from the `System.Linq.Async` package:

[!code-csharp[AsyncEnumerable](~/snippets/Snippets.NUnit/Constraints/AsyncConstraintSnippets.cs#AsyncEnumerable)]

## Best Practices

1. **Use async lambdas** when testing methods that return `Task` or `Task<T>`:

   ```csharp
   Assert.That(async () => await method(), constraint);
   ```

2. **Avoid blocking calls** like `.Result` or `.Wait()` - they can cause deadlocks:

   ```csharp
   // BAD - can deadlock
   Assert.That(service.GetValueAsync().Result, Is.EqualTo(42));

   // GOOD - use async lambda
   Assert.That(async () => await service.GetValueAsync(), Is.EqualTo(42));
   ```

3. **Use `Throws.Nothing`** to explicitly verify async code doesn't throw:

   ```csharp
   Assert.That(async () => await service.ProcessAsync(), Throws.Nothing);
   ```

4. **Use `DelayedConstraint`** for eventually-consistent operations instead of `Task.Delay`:

   ```csharp
   // BAD - arbitrary wait
   await Task.Delay(1000);
   Assert.That(value, Is.True);

   // GOOD - polls until true or timeout
   Assert.That(() => value, Is.True.After(2).Seconds.PollEvery(100).MilliSeconds);
   ```

## See Also

* [Throws Constraint](ThrowsConstraint.md) - Exception testing
* [ThrowsNothing Constraint](ThrowsNothingConstraint.md) - Verify no exception
* [Delayed Constraint](DelayedConstraint.md) - Polling and timeouts

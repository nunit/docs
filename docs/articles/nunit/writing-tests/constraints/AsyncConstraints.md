---
uid: constraint-async
---

# Async Constraint Support

NUnit constraints fully support testing asynchronous code. This page covers patterns for using constraints with async
methods, tasks, and delegates.

## Testing Async Methods

### Basic Async Assertions

Use `async` lambdas with `Assert.That` to test async code:

```csharp
// Test async method return values
Assert.That(async () => await service.GetValueAsync(), Is.EqualTo(42));

// Test that async method completes without throwing
Assert.That(async () => await service.InitializeAsync(), Throws.Nothing);

// Test async exception throwing
Assert.That(async () => await service.InvalidOperationAsync(),
    Throws.TypeOf<InvalidOperationException>());
```

### Testing Task Results

You can also await tasks directly before asserting:

```csharp
// Await first, then assert
var result = await calculator.AddAsync(2, 3);
Assert.That(result, Is.EqualTo(5));

// Or use Assert.ThatAsync (NUnit 4.0+)
await Assert.ThatAsync(async () => await calculator.AddAsync(2, 3), Is.EqualTo(5));
```

## Exception Testing with Async Code

### ThrowsConstraint with Async

```csharp
// Test for specific exception type
Assert.That(async () => await service.FailingMethodAsync(),
    Throws.TypeOf<InvalidOperationException>());

// Test exception message
Assert.That(async () => await service.FailingMethodAsync(),
    Throws.TypeOf<InvalidOperationException>()
        .With.Message.Contains("expected error"));

// Test inner exception
Assert.That(async () => await service.FailingMethodAsync(),
    Throws.TypeOf<AggregateException>()
        .With.InnerException.TypeOf<TimeoutException>());
```

### ThrowsNothing with Async

```csharp
// Verify async method completes successfully
Assert.That(async () => await service.SafeMethodAsync(), Throws.Nothing);
```

## Delayed Constraints with Async

Use `DelayedConstraint` for testing eventually-consistent async operations:

```csharp
// Poll until condition is true (or timeout)
Assert.That(async () => await service.IsReadyAsync(),
    Is.True.After(5).Seconds.PollEvery(100).MilliSeconds);

// Wait for value to appear
Assert.That(async () => await cache.GetCountAsync(),
    Is.GreaterThan(0).After(2000, 100));
```

## Collection Constraints with Async Enumerables

For `IAsyncEnumerable<T>`, materialize the collection first:

```csharp
// Convert to list first
var items = await asyncEnumerable.ToListAsync();
Assert.That(items, Has.Count.EqualTo(5));
Assert.That(items, Is.All.Positive);

// Or use helper method
Assert.That(await ToListAsync(service.GetItemsAsync()), Has.Some.GreaterThan(100));
```

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

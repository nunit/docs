---
uid: unhandledexceptionhandlingattribute
---

# UnhandledExceptionHandling

The `UnhandledExceptionHandlingAttribute` specifies how NUnit should handle unhandled exceptions that occur on
background threads during test execution. By default, NUnit treats unhandled exceptions as test errors, but this
attribute allows you to change that behavior.

> [!NOTE]
> This attribute was introduced in NUnit 4.6 to address scenarios where background thread exceptions, particularly
> `ThreadAbortException` from `Thread.Abort()` calls, would cause tests to be incorrectly marked as cancelled.

> [!WARNING]
> This attribute only affects exceptions raised on threads other than the main test thread. Exceptions on the main test
> thread will always cause the test to fail, regardless of this attribute's setting.

## Handling Modes

The attribute accepts an `UnhandledExceptionHandling` enum value:

| Mode | Description |
| ------ | ------------- |
| `Error` | Unhandled exceptions cause the test to fail (default behavior) |
| `Ignore` | Unhandled exceptions are ignored and do not affect the test result |
| `Default` | Same as `Error` |

## Basic Usage

### Error Mode (Default)

[!code-csharp[UnhandledExceptionError](~/snippets/Snippets.NUnit/Attributes/UnhandledExceptionHandlingAttributeExamples.cs#UnhandledExceptionError)]

### Ignore Mode

Use with caution - ignoring exceptions may hide real issues:

[!code-csharp[UnhandledExceptionIgnore](~/snippets/Snippets.NUnit/Attributes/UnhandledExceptionHandlingAttributeExamples.cs#UnhandledExceptionIgnore)]

## Filtering by Exception Type

You can specify which exception types should be handled differently:

[!code-csharp[UnhandledExceptionSpecificTypes](~/snippets/Snippets.NUnit/Attributes/UnhandledExceptionHandlingAttributeExamples.cs#UnhandledExceptionSpecificTypes)]

When exception types are specified:

* Only the specified exception types are affected by the handling mode
* Other exception types follow the default behavior (Error)
* Multiple exception types can be specified

## Fixture-Level Application

Apply to an entire fixture to affect all tests within it:

[!code-csharp[UnhandledExceptionFixtureLevel](~/snippets/Snippets.NUnit/Attributes/UnhandledExceptionHandlingAttributeExamples.cs#UnhandledExceptionFixtureLevel)]

## Common Scenarios

### Handling Thread.Abort Scenarios

When testing code that uses `Thread.Abort()`, the `ThreadAbortException` thrown on the background thread can cause NUnit
to mark the test as "cancelled by user" even though the test completed successfully. This attribute allows you to
ignore `ThreadAbortException` specifically:

[!code-csharp[UnhandledExceptionThreadAbort](~/snippets/Snippets.NUnit/Attributes/UnhandledExceptionHandlingAttributeExamples.cs#UnhandledExceptionThreadAbort)]

> [!NOTE]
> `Thread.Abort()` is obsolete in .NET 5+ and throws `PlatformNotSupportedException` on those platforms.
> Consider migrating to `CancellationToken`-based cancellation patterns instead.

### Testing Fire-and-Forget Operations

When testing code that intentionally spawns background work that might fail independently:

```csharp
[Test]
[UnhandledExceptionHandling(UnhandledExceptionHandling.Ignore)]
public void TestFireAndForgetLogging()
{
    // The system under test fires off logging that we don't want to wait for
    var sut = new ServiceWithBackgroundLogging();
    var result = sut.DoWork();

    Assert.That(result, Is.EqualTo(expected));
    // Background logging exceptions won't fail this test
}
```

### Testing Cancellation Scenarios

When `OperationCanceledException` on background threads is expected and should be ignored:

```csharp
[Test]
[UnhandledExceptionHandling(UnhandledExceptionHandling.Ignore, typeof(OperationCanceledException))]
public async Task TestCancellationInBackgroundWork()
{
    using var cts = new CancellationTokenSource();

    // Fire-and-forget background work that observes the cancellation token
    _ = Task.Run(() => LongRunningOperationAsync(cts.Token));

    // Trigger cancellation while the test continues
    cts.Cancel();

    // Perform other assertions that do not await the background work
    await Task.Delay(50);
    Assert.That(SomeResult(), Is.EqualTo(expected));

    // Any OperationCanceledException thrown on the background task
    // will be ignored by NUnit due to the UnhandledExceptionHandling setting
}
```

### Legacy Code Integration

When integrating with legacy code that has known background thread issues:

```csharp
[TestFixture]
[UnhandledExceptionHandling(UnhandledExceptionHandling.Ignore)]
public class LegacySystemTests
{
    // Legacy system has known issues with background thread cleanup
    // that we accept for now
}
```

## Inheritance and Scope

The attribute can be applied at multiple levels:

| Level | Scope |
|-------|-------|
| Assembly | Affects all tests in the assembly |
| Class | Affects all tests in the fixture |
| Method | Affects only the specific test |

When multiple levels specify the attribute, they are combined - each level's configuration is additive.

## Best Practices

> [!WARNING]
> Using `Ignore` mode can hide real bugs in your code. Use it sparingly and only when you understand the implications.

1. **Prefer `Error` mode** - The default behavior ensures you're aware of all exceptions
2. **Be specific with exception types** - When using `Ignore`, specify only the exception types you expect
3. **Document why** - Add comments explaining why certain exceptions are being ignored
4. **Review regularly** - Periodically review uses of `Ignore` mode to ensure they're still necessary

## See Also

* [Assert.Throws](../assertions/classic-assertions/Assert.Throws.md)
* [Assert.ThrowsAsync](../assertions/classic-assertions/Assert.ThrowsAsync.md)

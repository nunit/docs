---
uid: attribute-unhandledexceptionhandling
---

<!-- markdownlint-disable MD028 -->

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

## Constructors

```csharp
UnhandledExceptionHandlingAttribute(UnhandledExceptionHandling handling)
UnhandledExceptionHandlingAttribute(UnhandledExceptionHandling handling, params Type[] exceptions)
```

| Parameter    | Type                         | Description                                                                                    |
| ------------ | ---------------------------- | ---------------------------------------------------------------------------------------------- |
| `handling`   | `UnhandledExceptionHandling` | How NUnit treats a matching unhandled exception.                                               |
| `exceptions` | `Type[]`                     | Exception types this entry applies to. When omitted, the entry applies to all exception types. |

The attribute may be applied more than once to the same element, so that different exception types get different
handling.

## Handling Modes

The attribute accepts an `UnhandledExceptionHandling` enum value:

| Mode      | Description                                                        |
| --------- | ------------------------------------------------------------------ |
| `Error`   | Unhandled exceptions cause the test to fail (default behavior)     |
| `Ignore`  | Unhandled exceptions are ignored and do not affect the test result |
| `Default` | Same as `Error`                                                    |

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
| ------------ | ----------------------- | -------- |
| ✅           | ✅                      | ✅       |

## Platform Support

What this attribute can do depends on what the runtime allows.

* **.NET Framework:** an unhandled exception on another thread is reported to NUnit, which attributes it to the test
  that was running and either records an error or, with `Ignore`, lets the test complete normally. This is the platform
  the attribute was designed for, and the only one where `Ignore` keeps the process alive.
* **.NET Core and .NET 5 and later:** an unhandled exception on a thread **terminates the test process**, whatever this
  attribute says. NUnit still receives the exception first and records an error when the mode is `Error`, but `Ignore`
  cannot prevent the crash. .NET 10 added an API that lets a handler mark such an exception as handled, but NUnit does
  not use it yet.
* **Unobserved `Task` exceptions:** these do not terminate the process on modern .NET. They are reported on the finalizer
  thread, where NUnit usually cannot tell which test started the task, so they are logged and do not fail any test,
  regardless of this attribute.

In practice the attribute matters for exceptions thrown on threads your test code creates itself, such as `new Thread`,
and for `ThreadAbortException` on .NET Framework.

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

### Background Threads Started by the Code Under Test (.NET Framework)

When the system under test starts its own threads and a failure on one of them is a known, accepted condition:

```csharp
[TestFixture]
[UnhandledExceptionHandling(UnhandledExceptionHandling.Ignore, typeof(ObjectDisposedException))]
public class LegacySystemTests
{
    // The legacy component's cleanup thread sometimes throws ObjectDisposedException
    // after the test has finished with it. On .NET Framework that no longer fails the test.
}
```

On .NET Core and later the same exception would terminate the process, so the only real fix there is to stop the
exception from escaping the thread, for example by catching it in the thread procedure.

## Precedence When Applied at Several Levels

The attribute can be applied at the assembly, fixture and method level. When an unhandled exception arrives, NUnit
looks for a matching entry starting at the **test method**, then the **fixture**, then the **assembly**, and uses the
first level that has one:

1. At a given level, an entry that names the exception type wins over an entry that covers all exception types.
2. If a level has no entry for that exception, NUnit moves up to the next level.
3. If no level matches, the default `Error` applies.

Settings are **not** merged across levels. A method-level `[UnhandledExceptionHandling(Ignore)]` covers every exception
type for that test, so a fixture-level entry for a specific type is never consulted for it. To ignore everything except
one type at the same level, give that type its own `Error` entry:

```csharp
[Test]
[UnhandledExceptionHandling(UnhandledExceptionHandling.Ignore)]
[UnhandledExceptionHandling(UnhandledExceptionHandling.Error, typeof(InvalidOperationException))]
public void IgnoresEverythingExceptInvalidOperation()
{
    // ...
}
```

## When to Use It

> [!WARNING]
> Using `Ignore` mode can hide real bugs in your code. Use it sparingly and only when you understand the implications.

The attribute is appropriate when:

* You are on .NET Framework and test code that uses `Thread.Abort()`, so `ThreadAbortException` is expected.
* The code under test runs a background thread whose failure is already known, cannot be fixed in the test, and is
  unrelated to what the test verifies. Name the exception type rather than ignoring everything.

It is **not** a substitute for awaiting tasks or joining threads before the test ends. If the test can observe the
background work, do that instead, so a failure is reported where it happened.

1. **Prefer `Error` mode** - The default behavior ensures you're aware of all exceptions
2. **Be specific with exception types** - When using `Ignore`, specify only the exception types you expect
3. **Document why** - Add comments explaining why certain exceptions are being ignored
4. **Review regularly** - Periodically review uses of `Ignore` mode to ensure they're still necessary

## See Also

* [CancelAfter Attribute](xref:attribute-cancelafter)
* [Timeout Attribute](xref:attribute-timeout)
* [Property Attribute](xref:attribute-property)

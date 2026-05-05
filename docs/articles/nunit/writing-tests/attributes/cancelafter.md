---
uid: cancelafterattribute
---

# CancelAfter

`CancelAfterAttribute` sets a timeout after which NUnit marks a `CancellationToken` as canceled. The test must observe that token (directly or indirectly) for cancellation to take effect.

## Constructor

```csharp
CancelAfterAttribute(int timeout)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `timeout` | `int` | Timeout in milliseconds. When exceeded, the cancellation token supplied to the test is canceled (cooperative cancellation). |

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ✅ | ✅ | ❌ |

> [!NOTE]
> Applying `CancelAfter` to a fixture sets the default timeout for tests in that fixture unless overridden at method level.

## Background

For .NET Core and later,
[`Thread.Abort`](https://learn.microsoft.com/en-us/dotnet/api/system.threading.thread.abort?view=net-8.0) as used by the
[`TimeoutAttribute`](xref:timeout-attribute) can no longer be used, and there is therefore no way to interrupt an endless loop.

For all tests, one could use the `--blame-hang(-timeout)`  options of [`dotnet
test`](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-test#options). However, this will stop any further
execution of the remaining tests.

To still be able to cancel tests, one has to move to cooperative cancellation. See [Cancellation in Managed
Threads](https://learn.microsoft.com/en-us/dotnet/standard/threading/cancellation-in-managed-threads) using a
[`CancellationToken`](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-8.0).

The `CancelAfterAttribute` is used to specify a timeout value in milliseconds for a test case. If the test case runs
longer than the time specified, the supplied `CancellationToken` is set to canceled. It is however up to the test code
to check this token, either directly or indirectly.

The specified timeout value covers the test setup and teardown as well as the test method itself. Before and after
actions may also be included, depending on where they were specified. Since the timeout may occur during any of these
execution phases, no guarantees can be made as to what will be run and any of these phases of execution may be
incomplete. If only used on a test, once a test has timed out, its teardown methods are executed. NUnit will ensure
that the cancellation token will be available across all these phases. This also means that the token will be in the
"cancelled" state in one phase (ex: `TearDown`) if it were marked as cancelled during a previous phase. It therefore
should be used with caution in `TearDown` phases when getting passed down to other methods which perform cleanup as
an already-cancelled token may prevent HTTP or DB calls from being performed.

The attribute may also be specified on a fixture, in which case it indicates the default timeout for any subordinate
test cases. When using the console runner, it is also possible to specify a default timeout on the command-line.

When used on test methods, NUnit automatically adds an extra argument to your method containing the NUnit
`CancellationToken`. If you want to check for cancellation in `SetUp` methods, you can use
`TestContext.CurrentContext.CancellationToken`

## Examples

The `CancelAfterAttribute` supports cooperative cancellation in several test styles.

### Simple test

[!code-csharp[TestWithCancellationToken](~/snippets/Snippets.NUnit/Attributes/CancelAfterAttributeExamples.cs#TestWithCancellationToken)]

### Parameterized test with `TestCase`

[!code-csharp[TestCaseWithCancellationToken](~/snippets/Snippets.NUnit/Attributes/CancelAfterAttributeExamples.cs#TestCaseWithCancellationToken)]

### Parameterized test with `TestCaseSource`

[!code-csharp[TestCaseSourceWithCancellationToken](~/snippets/Snippets.NUnit/Attributes/CancelAfterAttributeExamples.cs#TestCaseSourceWithCancellationToken)]

## Notes

1. When a debugger is attached, the timeout is not enforced.
2. Use `TestContext.CurrentContext.CancellationToken` in `SetUp` / `TearDown` when you need the same token outside the test method.

## See Also

* [Timeout Attribute](xref:timeout-attribute)
* [MaxTime Attribute](xref:maxtimeattribute)

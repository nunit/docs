# Timeout

> [!NOTE]
> The Timeout attribute does not work from .NET 5 and upwards due to limitations in the runtime.
> Beginning in NUnit version 4.5, usage of Timeout attribute on .NET 5 or higher is reported as a failure.

## Alternatives to the Timeout attribute for .net 5 and above

If you want to cancel the Test in the same manner, use the [CancelAfter Attribute](./cancelafter.md).
It is cooperative cancelling, so your test needs to handle the CancellationToken.

If you just want to be informed of tests that have run over an expected time, use the [MaxTime Attribute](./maxtime.md).

If you want to cancel the whole test run use the `dotnet test --blame-hang-timeout <TIMESPAN>`.
Any test that use more than the TIMESPAN will abort the run.
See [dotnet test docs](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-test-vstest).

### Reason

The Timeout attribute uses the `Thread.Abort()` method to kill tests.  `Thread.Abort()` was removed in .NET 5 and replaced with
cooperative cancellation.

## For projects that target .NET Framework only

Normally, NUnit simply runs tests and waits for them to terminate -- the test is allowed to run indefinitely. For
certain kinds of tests, however, it may be desirable to specify a timeout value.

The **TimeoutAttribute** is used to specify a timeout value in milliseconds for a test case. If the test case runs
longer than the time specified it is immediately cancelled and reported as a failure, with a message indicating that the
timeout was exceeded.

The specified timeout value covers the test setup and teardown as well as the test method itself. Before and after
actions may also be included, depending on where they were specified. Since the timeout may occur during any of these
execution phases, no guarantees can be made as to what will be run and any of these phases of execution may be
incomplete. If only used on a test, once a test has timed out, its teardown methods are executed.

The attribute may also be specified on a fixture or assembly, in which case it indicates the default timeout for any
subordinate test cases. When using the console runner, it is also possible to specify a default timeout on the
command-line.

## Example

```csharp
[Test, Timeout(2000)]
public void PotentiallyLongRunningTest()
{
    /* ... */
}
```

> [!NOTE]
> When debugging a unit test, i.e. when a debugger is attached to the process, then the timeout is not enforced.

## See Also

* [MaxTime Attribute](./maxtime.md)
* [CancelAfter Attribute](./cancelafter.md)

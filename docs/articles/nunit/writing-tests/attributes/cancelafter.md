# CancelAfter

Normally, NUnit simply runs tests and waits for them to terminate -- the test is allowed to run indefinitely. For
certain kinds of tests, however, it may be desirable to specify a timeout value.

For .NET Core and later,
[`Thread.Abort`](https://learn.microsoft.com/en-us/dotnet/api/system.threading.thread.abort?view=net-7.0) as used by the
[`TimeoutAttribue`](./timeout.md) can no longer be used, and there is therefore no way to interrupt an endless loop.

For all tests, one could use the `--blame-hang(-timeout)`  options of [`dotnet
test`](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-test#options). However, this will stop any further
execution of the remaining tests.

To still be able to cancel tests, one has to move to cooperative cancellation. See [Cancellation in Managed
Threads](https://learn.microsoft.com/en-us/dotnet/standard/threading/cancellation-in-managed-threads) using a
[`CancellationToken``](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-7.0).

The `CancelAfterAttribute` is used to specify a timeout value in milliseconds for a test case. If the test case runs
longer than the time specified, the supplied `CancellationToken` is set to canceled. It is however up to the test code
to check this token, either directly or indirectly.

The specified timeout value covers the test setup and teardown as well as the test method itself. Before and after
actions may also be included, depending on where they were specified. Since the timeout may occur during any of these
execution phases, no guarantees can be made as to what will be run and any of these phases of execution may be
incomplete. If only used on a test, once a test has timed out, its teardown methods are executed.

The attribute may also be specified on a fixture, in which case it indicates the default timeout for any subordinate
test cases. When using the console runner, it is also possible to specify a default timeout on the command-line.

When used on test methods, NUnit automatically adds an extra argument to your method containing the NUnit
`CancellationToken`. If you want to check for cancellation in `SetUp` methods, you can use
`TestContext.CurrentContext.CancellationToken`

## Example

```csharp
[Test, CancelAfter(2000)]
public void RunningTestUntilCanceled(CancellationToken token)
{
    while (!token.IsCancellationRequested)
    {
        /* */
    }
}

[CancelAfter(2000)]
[TestCase("http://server1")]
[TestCase("http://server2")]
public async Task PotentiallyLongRunningTest(string uri, CancellationToken token)
{
    HttpClient client = _httpClientFactory.CreateClient();
    HttpContent content = CreateContent();
    await client.PostAync(uri, content, token);
    HttpResponseMessage response = await client.GetAsync(uri, token);
    /* */
}
```

> [!NOTE]
> When debugging a unit test, i.e. when a debugger is attached to the process, the timeout is not enforced.

## See Also

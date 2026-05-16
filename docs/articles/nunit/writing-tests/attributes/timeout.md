---
uid: attribute-timeout
---

# Timeout

> [!WARNING]
> This attribute is **obsolete on .NET 5 and later**. Starting from NUnit 4.5, usage of the Timeout attribute on .NET 5+ is reported as a test failure. Use [CancelAfter](xref:attribute-cancelafter) or [MaxTime](xref:attribute-maxtime) instead.

`TimeoutAttribute` is used to specify a timeout value in milliseconds for a test case. If the test runs longer than the specified time, it is immediately cancelled and reported as a failure.

## Constructor

```csharp
TimeoutAttribute(int timeout)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `timeout` | `int` | The timeout value in milliseconds. |

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ✅ | ✅ | ✅ |

## .NET 5+ Alternatives

Since `Thread.Abort()` was removed in .NET 5, this attribute no longer works reliably. Use these alternatives:

| Alternative | Description |
|-------------|-------------|
| [CancelAfter](xref:attribute-cancelafter) | Cooperative cancellation via `CancellationToken`. Your test must handle the token. |
| [MaxTime](xref:attribute-maxtime) | Reports tests that exceed expected time, but doesn't cancel them. |
| `dotnet test --blame-hang-timeout` | Aborts the entire test run if any test exceeds the timeout. |

## Example (.NET Framework Only)

```csharp
[Test, Timeout(2000)]
public void PotentiallyLongRunningTest()
{
    // Test will be cancelled if it runs longer than 2 seconds
}

[TestFixture, Timeout(5000)]
public class TimeSensitiveTests
{
    [Test]
    public void Test1()
    {
        // Inherits 5 second timeout from fixture
    }

    [Test, Timeout(1000)]
    public void QuickTest()
    {
        // Overrides fixture timeout with 1 second
    }
}
```

## Notes

1. **Deprecated on .NET 5+**: This attribute uses `Thread.Abort()`, which was removed in .NET 5. On .NET 5+, the test will be cancelled for reporting purposes, but the code continues running in the background.
2. The timeout covers setup, teardown, and the test method itself. Before/after actions may also be included depending on where they were specified.
3. When a timeout occurs during execution, no guarantees can be made about which phases completed.
4. When debugging (debugger attached), the timeout is not enforced.
5. A default timeout can also be set via the console runner's `--timeout` option or in a `.runsettings` file when using `dotnet test`.

## See Also

* [CancelAfter Attribute](xref:attribute-cancelafter)
* [MaxTime Attribute](xref:attribute-maxtime)

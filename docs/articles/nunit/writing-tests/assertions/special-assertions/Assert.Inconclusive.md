---
uid: special-assert-inconclusive
---

# Assert.Inconclusive

The `Assert.Inconclusive` method indicates that the test could not be
completed with the data available. It should be used in situations where
another run with different data might run to completion, with either a
success or failure outcome.

```csharp
Assert.Inconclusive();
Assert.Inconclusive(string message);
```

`Assert.Inconclusive` ends the test immediately by throwing an `InconclusiveException`, so nothing after the call runs.
Like `Assert.Ignore`, it may not be used inside a [multiple assert block](xref:multipleasserts).

An inconclusive result does not affect the result of the containing fixture. Unlike an ignored test, it is not treated
as a warning by runners. The VS Test Adapter reports it as Not Run. See
[Ignored, Inconclusive, or not run?](Assert.Ignore.md#ignored-inconclusive-or-not-run) for a comparison.

In NUnit 5 and later, any [warnings](../../Warnings.md) issued before the call are included in the result message. In
earlier versions only the inconclusive message is kept.

## See Also

* [Assert.Pass](Assert.Pass.md)
* [Assert.Fail](Assert.Fail.md)
* [Assert.Ignore](Assert.Ignore.md)
* [Assumptions](../../Assumptions.md)

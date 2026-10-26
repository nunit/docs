---
uid: special-assert-pass
---

# Assert.Pass

The `Assert.Pass` method allows you to immediately end the test, recording
it as successful. Since it causes an exception to be thrown, it is more
efficient to simply allow the test to return. However, Assert.Pass allows
you to record a message in the test result and may also make the test
easier to read in some situations. Additionally, like the other methods
on this page, it can be invoked from a nested method call with the
result of immediately terminating test execution.

```csharp
Assert.Pass();
Assert.Pass(string message);
```

`Assert.Pass` may not be used inside a [multiple assert block](xref:multipleasserts).

In NUnit 5 and later, any [warnings](../../Warnings.md) issued before the call are included in the result message, and
the test is still reported as Passed. In earlier versions only the pass message is kept. See
[Warnings issued before Assert.Ignore](Assert.Ignore.md#warnings-issued-before-assertignore) for details.

## See Also

* [Assert.Fail](Assert.Fail.md)
* [Assert.Ignore](Assert.Ignore.md)
* [Assert.Inconclusive](Assert.Inconclusive.md)

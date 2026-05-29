---
uid: classic-assert-does-not-throw-async
---

# Assert.DoesNotThrowAsync

**Assert.DoesNotThrowAsync** verifies that the delegate provided as an argument
does not throw an exception. See [Assert.DoesNotThrow](Assert.DoesNotThrow.md) for synchronous code.

```csharp
Task Assert.DoesNotThrowAsync(Func<Task> asyncCode);
Task Assert.DoesNotThrowAsync(Func<Task> asyncCode,
                              string message, params object[] params);
```

## NUnit 4 and earlier

In NUnit 4 and earlier this assertion would not need to be awaited and would return `void` instead of `Task`. The callback to invoke would also be passed as an `AsyncTestDelegate` instead of a `Func<Task>`. These behaviors were both changed in NUnit 5 to better align the API with
modern .NET standards and conventions.

```csharp
void Assert.DoesNotThrowAsync(AsyncTestDelegate code);
void Assert.DoesNotThrowAsync(AsyncTestDelegate code,
                              string message, params object[] params);
```

## See Also

* [Assert.ThrowsAsync](Assert.ThrowsAsync.md)
* [ThrowsConstraint](xref:constraint-throws)

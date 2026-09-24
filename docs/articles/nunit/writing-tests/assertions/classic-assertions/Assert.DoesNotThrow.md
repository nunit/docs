---
uid: classic-assert-does-not-throw
---

# Assert.DoesNotThrow

**Assert.DoesNotThrow** verifies that the delegate provided as an argument
does not throw an exception. See [Assert.DoesNotThrowAsync](Assert.DoesNotThrowAsync.md) for asynchronous code.

```csharp
void Assert.DoesNotThrow(Action code);
void Assert.DoesNotThrow(Action code,
                         string message, params object[] params);
```

> [!NOTE]
> From version 5, the code to execute is passed as an `Action`.

## NUnit 4 and earlier

In NUnit 4 and earlier, the code to execute was passed as a `TestDelegate`, which was removed in NUnit 5. Code that
passes a lambda works unchanged, but explicit uses of `TestDelegate` must be changed to `Action`.

```csharp
void Assert.DoesNotThrow(TestDelegate code);
void Assert.DoesNotThrow(TestDelegate code,
                         string message, params object[] params);
```

## See Also

* [Assert.Throws](Assert.Throws.md)
* [ThrowsConstraint](xref:constraint-throws)

---
uid: classic-assert-catch
---

# Assert.Catch

**Assert.Catch** is similar to **Assert.Throws** but will pass for an exception
that is derived from the one specified.

```csharp
Exception Assert.Catch(Action code);
Exception Assert.Catch(Action code,
                       string message, params object[] params);

Exception Assert.Catch(Type expectedExceptionType, Action code);
Exception Assert.Catch(Type expectedExceptionType, Action code,
                       string message, params object[] params);

T Assert.Catch<T>(Action code);
T Assert.Catch<T>(Action code,
                  string message, params object[] params);
```

> [!NOTE]
> From version 5, the code to execute is passed as an `Action`.

## NUnit 4 and earlier

In NUnit 4 and earlier, the code to execute was passed as a `TestDelegate`, which was removed in NUnit 5. Code that
passes a lambda works unchanged, but explicit uses of `TestDelegate` must be changed to `Action`.

```csharp
Exception Assert.Catch(TestDelegate code);
Exception Assert.Catch(TestDelegate code,
                       string message, params object[] params);

Exception Assert.Catch(Type expectedExceptionType, TestDelegate code);
Exception Assert.Catch(Type expectedExceptionType, TestDelegate code,
                       string message, params object[] params);

T Assert.Catch<T>(TestDelegate code);
T Assert.Catch<T>(TestDelegate code,
                  string message, params object[] params);
```

## See Also

* [Assert.CatchAsync](Assert.CatchAsync.md)
* [Assert.Throws](Assert.Throws.md)
* [Assert.ThrowsAsync](Assert.ThrowsAsync.md)
* [ThrowsConstraint](xref:constraint-throws)

# Assert.DoesNotThrowAsync

**Assert.DoesNotThrowAsync** verifies that the delegate provided as an argument
does not throw an exception. See [Assert.DoesNotThrow](Assert.DoesNotThrow.md) for synchronous code.

```csharp
void Assert.DoesNotThrowAsync(AsyncTestDelegate code);
void Assert.DoesNotThrowAsync(AsyncTestDelegate code,
                              string message, params object[] params);
```

## See Also

* [Assert.ThrowsAsync](Assert.ThrowsAsync.md)
* [ThrowsConstraint](xref:throwsconstraint)

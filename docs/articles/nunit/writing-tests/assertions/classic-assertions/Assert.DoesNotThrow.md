# Assert.DoesNotThrow


**Assert.DoesNotThrow** verifies that the delegate provided as an argument 
does not throw an exception. See [Assert.DoesNotThrowAsync](Assert.DoesNotThrowAsync.md) for asynchronous code.

```csharp
void Assert.DoesNotThrow(TestDelegate code);
void Assert.DoesNotThrow(TestDelegate code,
                         string message, params object[] params);
```

#### See also...
 * [Assert.Throws](Assert.Throws.md)
 * [ThrowsConstraint](xref:ThrowsConstraint)

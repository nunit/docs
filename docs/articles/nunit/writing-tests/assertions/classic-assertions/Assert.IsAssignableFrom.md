# Assert.IsAssignableFrom

**Assert.IsAssignableFrom** succeeds if the object provided may be assigned a value of the expected type.

```csharp
Assert.IsAssignableFrom(Type expected, object actual);
Assert.IsAssignableFrom(Type expected, object actual,
                        string message, params object[] params);
Assert.IsAssignableFrom<T>(object actual);
Assert.IsAssignableFrom<T>(object actual,
                           string message, params object[] params);
```

## See Also

* [Type Constraints](xref:constraints#type-constraints)

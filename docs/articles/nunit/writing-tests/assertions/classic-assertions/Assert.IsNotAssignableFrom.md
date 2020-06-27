# Assert.IsNotAssignableFrom

**Assert.IsNotAssignableFrom** succeeds if the object provided may not be assigned a value of the expected type.

```csharp
Assert.IsNotAssignableFrom(Type expected, object actual);
Assert.IsNotAssignableFrom(Type expected, object actual,
                           string message, params object[] params);
Assert.IsNotAssignableFrom<T>(object actual);
Assert.IsNotAssignableFrom<T>(object actual,
                              string message, params object[] params);
```

## See also

* [Type Constraints](xref:constraints#type-constraints)

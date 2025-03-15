# ClassicAssert.IsAssignableFrom

**ClassicAssert.IsAssignableFrom** succeeds if the object provided may be assigned a value of the expected type.

```csharp
ClassicAssert.IsAssignableFrom(Type expected, object actual);
ClassicAssert.IsAssignableFrom(Type expected, object actual,
                        string message, params object[] params);
ClassicAssert.IsAssignableFrom<T>(object actual);
ClassicAssert.IsAssignableFrom<T>(object actual,
                           string message, params object[] params);
```

## See Also

* [Type Constraints](xref:constraints#type-constraints)

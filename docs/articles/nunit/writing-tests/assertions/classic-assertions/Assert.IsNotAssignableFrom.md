# ClassicAssert.IsNotAssignableFrom

**ClassicAssert.IsNotAssignableFrom** succeeds if the object provided may not be assigned a value of the expected type.

```csharp
ClassicAssert.IsNotAssignableFrom(Type expected, object actual);
ClassicAssert.IsNotAssignableFrom(Type expected, object actual,
                           string message, params object[] params);
ClassicAssert.IsNotAssignableFrom<T>(object actual);
ClassicAssert.IsNotAssignableFrom<T>(object actual,
                              string message, params object[] params);
```

## See also

* [Type Constraints](xref:constraints#type-constraints)

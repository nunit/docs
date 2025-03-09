# ClassicAssert.IsNotInstanceOf

**ClassicAssert.IsNotInstanceOf** succeeds if the object provided as an actual value is not an instance of the expected type.

```csharp
ClassicAssert.IsNotInstanceOf(Type expected, object actual);
ClassicAssert.IsNotInstanceOf(Type expected, object actual,
                       string message, params object[] params);
ClassicAssert.IsNotInstanceOf<T>(object actual);
ClassicAssert.IsNotInstanceOf<T>(object actual,
                          string message, params object[] params);
```

## See Also

* [Type Constraints](xref:constraints#type-constraints)

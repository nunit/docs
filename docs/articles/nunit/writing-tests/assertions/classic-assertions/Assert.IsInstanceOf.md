# ClassicAssert.IsInstanceOf

**ClassicAssert.IsInstanceOf** succeeds if the object provided as an actual value is an instance of the expected type.

```csharp
ClassicAssert.IsInstanceOf(Type expected, object actual);
ClassicAssert.IsInstanceOf(Type expected, object actual,
                    string message, params object[] params);
ClassicAssert.IsInstanceOf<T>(object actual);
ClassicAssert.IsInstanceOf<T>(object actual,
                       string message, params object[] params);
```

## See Also

* [Type Constraints](xref:constraints#type-constraints)

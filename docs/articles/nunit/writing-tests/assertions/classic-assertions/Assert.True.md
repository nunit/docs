# Assert.True

**Assert.True** and **Assert.IsTrue** test that the specified condition is true.
The two forms are provided for compatibility with past versions of NUnit and
NUnitLite. The message parameter is used for whenever the assertion fails.

```csharp
Assert.True(bool condition);
Assert.True(bool condition, string message, params object[] params);

Assert.IsTrue(bool condition);
Assert.IsTrue(bool condition, string message, params object[] params);
```

You may also use **Assert.That** with a boolean argument to achieve the
same result.

## See Also

* [Condition Constraints](xref:constraints#condition-constraints)

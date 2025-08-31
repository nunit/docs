# ClassicAssert.True

**ClassicAssert.True** and **ClassicAssert.IsTrue** test that the specified condition is true.
The two forms are provided for compatibility with past versions of NUnit and
NUnitLite.

```csharp
ClassicAssert.True(bool condition);
ClassicAssert.True(bool condition, string message, params object[] params);

ClassicAssert.IsTrue(bool condition);
ClassicAssert.IsTrue(bool condition, string message, params object[] params);
```

You can also use **Assert.That** with a Boolean argument to achieve the
same result.

[!code-csharp[TrueExamples](~/snippets/Snippets.NUnit/ClassicAssertExamples.cs#TrueExamples)]

## See Also

* [Condition Constraints](xref:constraints#condition-constraints)

# Assert.True

**Assert.True** and **Assert.IsTrue** test that the specified condition is true.
The two forms are provided for compatibility with past versions of NUnit and
NUnitLite.

> [!NOTE]
> From version 4.5.0, using C# 14, you don't need to use the ClassicAssert class, nor the NUnit.Framework.Legacy
> namespace, but can use the former Assert class. This applies for many of the asserts, but a few still require the use of
> the ClassicAssert class. These will be fixed in upcoming releases. In the list below, and in the examples, the 4.5.0
> syntax will be used. If you use an earlier 4.x version, replace Assert with ClassicAssert and include the
> NUnit.Framework.Legacy namespace.

```csharp
Assert.True(bool condition);
Assert.True(bool condition, string message, params object[] params);

Assert.IsTrue(bool condition);
Assert.IsTrue(bool condition, string message, params object[] params);
```

You can also use **Assert.That** with a Boolean argument to achieve the
same result.

[!code-csharp[TrueExamples](~/snippets/Snippets.NUnit/ClassicAssertExamples.cs#TrueExamples)]

## See Also

* [Condition Constraints](xref:constraints#condition-constraints)

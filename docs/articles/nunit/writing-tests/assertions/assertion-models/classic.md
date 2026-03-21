---
uid: classicmodel
---

# Classic Model

The classic Assert model uses a separate method to express each individual assertion of which it is capable.

Here's a simple assert using the classic model:

```csharp
StringAssert.AreEqualIgnoringCase("Hello", myString);
```

> [!NOTE]
> From version 4.5.0, using C# 14, you don't need to use the ClassicAssert class, nor the NUnit.Framework.Legacy
> namespace, but can use the former Assert class. This applies for many of the asserts, but a few still require the use of
> the ClassicAssert class. These will be fixed in upcoming releases. In the list below, and in the examples, the 4.5.0
> syntax will be used. If you use an earlier 4.x version, replace Assert with ClassicAssert and include the
> NUnit.Framework.Legacy namespace.
>
> The `ClassicAssert` and `NUnit.Framework.Legacy` are still available in 4.5.0, so you don't need to change code
> that already use this.
>
> See [classic extensions](classic_extensions.md) for a full table over all extension mappings.

The Assert class provides the most common classic assertions in NUnit:

* [Assert.True](../classic-assertions/Assert.True.md)
* [Assert.False](../classic-assertions/Assert.False.md)
* [Assert.Null](../classic-assertions/Assert.Null.md)
* [Assert.NotNull](../classic-assertions/Assert.NotNull.md)
* [Assert.Zero](../classic-assertions/Assert.Zero.md)
* [Assert.NotZero](../classic-assertions/Assert.NotZero.md)
* [Assert.IsNaN](../classic-assertions/Assert.IsNaN.md)
* [Assert.IsEmpty](../classic-assertions/Assert.IsEmpty.md)
* [Assert.IsNotEmpty](../classic-assertions/Assert.IsNotEmpty.md)
* [Assert.AreEqual](../classic-assertions/Assert.AreEqual.md)
* [Assert.AreNotEqual](../classic-assertions/Assert.AreNotEqual.md)
* [Assert.AreSame](../classic-assertions/Assert.AreSame.md)
* [Assert.AreNotSame](../classic-assertions/Assert.AreNotSame.md)
* [Assert.Contains](../classic-assertions/Assert.Contains.md)
* [Assert.Greater](../classic-assertions/Assert.Greater.md)
* [Assert.GreaterOrEqual](../classic-assertions/Assert.GreaterOrEqual.md)
* [Assert.Less](../classic-assertions/Assert.Less.md)
* [Assert.LessOrEqual](../classic-assertions/Assert.LessOrEqual.md)
* [Assert.Positive](../classic-assertions/Assert.Positive.md)
* [Assert.Negative](../classic-assertions/Assert.Negative.md)
* [Assert.IsInstanceOf](../classic-assertions/Assert.IsInstanceOf.md)
* [Assert.IsNotInstanceOf](../classic-assertions/Assert.IsNotInstanceOf.md)
* [Assert.IsAssignableFrom](../classic-assertions/Assert.IsAssignableFrom.md)
* [Assert.IsNotAssignableFrom](../classic-assertions/Assert.IsNotAssignableFrom.md)
* [Assert.Throws](../classic-assertions/Assert.Throws.md)
* [Assert.ThrowsAsync](../classic-assertions/Assert.ThrowsAsync.md)
* [Assert.DoesNotThrow](../classic-assertions/Assert.DoesNotThrow.md)
* [Assert.DoesNotThrowAsync](../classic-assertions/Assert.DoesNotThrowAsync.md)
* [Assert.Catch](../classic-assertions/Assert.Catch.md)
* [Assert.CatchAsync](../classic-assertions/Assert.CatchAsync.md)

Additional assertions are provided by the following classes, which are in the `NUnit.Framework.Legacy` namespace:

* [String Assert](../classic-assertions/String-Assert.md)
* [Collection Assert](../classic-assertions/Collection-Assert.md)
* [File Assert](../classic-assertions/File-Assert.md)
* [Directory Assert](../classic-assertions/Directory-Assert.md)

## See Also

* [Constraint Model](xref:constraintmodel)

## Notes

* The exception-family of classic asserts have not been moved to the legacy namespace.

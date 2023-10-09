---
uid: classicmodel
---

# Classic Model

The classic Assert model uses a separate method to express each individual assertion of which it is capable.

Here's a simple assert using the classic model:

```csharp
StringAssert.AreEqualIgnoringCase("Hello", myString);
```

The Assert class provides the most common assertions in NUnit:

* [ClassicAssert.True](../classic-assertions/Assert.True.md)
* [ClassicAssert.False](../classic-assertions/Assert.False.md)
* [ClassicAssert.Null](../classic-assertions/Assert.Null.md)
* [ClassicAssert.NotNull](../classic-assertions/Assert.NotNull.md)
* [ClassicAssert.Zero](../classic-assertions/Assert.Zero.md)
* [ClassicAssert.NotZero](../classic-assertions/Assert.NotZero.md)
* [ClassicAssert.IsNaN](../classic-assertions/Assert.IsNaN.md)
* [ClassicAssert.IsEmpty](../classic-assertions/Assert.IsEmpty.md)
* [ClassicAssert.IsNotEmpty](../classic-assertions/Assert.IsNotEmpty.md)
* [ClassicAssert.AreEqual](../classic-assertions/Assert.AreEqual.md)
* [ClassicAssert.AreNotEqual](../classic-assertions/Assert.AreNotEqual.md)
* [ClassicAssert.AreSame](../classic-assertions/Assert.AreSame.md)
* [ClassicAssert.AreNotSame](../classic-assertions/Assert.AreNotSame.md)
* [ClassicAssert.Contains](../classic-assertions/Assert.Contains.md)
* [ClassicAssert.Greater](../classic-assertions/Assert.Greater.md)
* [ClassicAssert.GreaterOrEqual](../classic-assertions/Assert.GreaterOrEqual.md)
* [ClassicAssert.Less](../classic-assertions/Assert.Less.md)
* [ClassicAssert.LessOrEqual](../classic-assertions/Assert.LessOrEqual.md)
* [ClassicAssert.Positive](../classic-assertions/Assert.Positive.md)
* [ClassicAssert.Negative](../classic-assertions/Assert.Negative.md)
* [ClassicAssert.IsInstanceOf](../classic-assertions/Assert.IsInstanceOf.md)
* [ClassicAssert.IsNotInstanceOf](../classic-assertions/Assert.IsNotInstanceOf.md)
* [ClassicAssert.IsAssignableFrom](../classic-assertions/Assert.IsAssignableFrom.md)
* [ClassicAssert.IsNotAssignableFrom](../classic-assertions/Assert.IsNotAssignableFrom.md)
* [Assert.Throws](../classic-assertions/Assert.Throws.md)
* [Assert.ThrowsAsync](../classic-assertions/Assert.ThrowsAsync.md)
* [Assert.DoesNotThrow](../classic-assertions/Assert.DoesNotThrow.md)
* [Assert.DoesNotThrowAsync](../classic-assertions/Assert.DoesNotThrowAsync.md)
* [Assert.Catch](../classic-assertions/Assert.Catch.md)
* [Assert.CatchAsync](../classic-assertions/Assert.CatchAsync.md)

Additional assertions are provided by the following classes, which are also in the `NUnit.Framework.Legacy` namespace:

* [String Assert](../classic-assertions/String-Assert.md)
* [Collection Assert](../classic-assertions/Collection-Assert.md)
* [File Assert](../classic-assertions/File-Assert.md)
* [Directory Assert](../classic-assertions/Directory-Assert.md)

## See Also

* [Constraint Model](xref:constraintmodel)

## Notes

* The exception-family of classic asserts have not yet been moved to the legacy namespace.  They have not yet full equivalents in the constraint model.

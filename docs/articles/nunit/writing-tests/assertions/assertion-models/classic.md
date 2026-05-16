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

* [Assert.True](xref:classic-assert-true)
* [Assert.False](xref:classic-assert-false)
* [Assert.Null](xref:classic-assert-null)
* [Assert.NotNull](xref:classic-assert-not-null)
* [Assert.Zero](xref:classic-assert-zero)
* [Assert.NotZero](xref:classic-assert-not-zero)
* [Assert.IsNaN](xref:classic-assert-is-nan)
* [Assert.IsEmpty](xref:classic-assert-is-empty)
* [Assert.IsNotEmpty](xref:classic-assert-is-not-empty)
* [Assert.AreEqual](xref:classic-assert-are-equal)
* [Assert.AreNotEqual](xref:classic-assert-are-not-equal)
* [Assert.AreSame](xref:classic-assert-are-same)
* [Assert.AreNotSame](xref:classic-assert-are-not-same)
* [Assert.Contains](xref:classic-assert-contains)
* [Assert.Greater](xref:classic-assert-greater)
* [Assert.GreaterOrEqual](xref:classic-assert-greater-or-equal)
* [Assert.Less](xref:classic-assert-less)
* [Assert.LessOrEqual](xref:classic-assert-less-or-equal)
* [Assert.Positive](xref:classic-assert-positive)
* [Assert.Negative](xref:classic-assert-negative)
* [Assert.IsInstanceOf](xref:classic-assert-is-instance-of)
* [Assert.IsNotInstanceOf](xref:classic-assert-is-not-instance-of)
* [Assert.IsAssignableFrom](xref:classic-assert-is-assignable-from)
* [Assert.IsNotAssignableFrom](xref:classic-assert-is-not-assignable-from)
* [Assert.Throws](xref:classic-assert-throws)
* [Assert.ThrowsAsync](xref:classic-assert-throws-async)
* [Assert.DoesNotThrow](xref:classic-assert-does-not-throw)
* [Assert.DoesNotThrowAsync](xref:classic-assert-does-not-throw-async)
* [Assert.Catch](xref:classic-assert-catch)
* [Assert.CatchAsync](xref:classic-assert-catch-async)

Additional assertions are provided by the following classes, which are in the `NUnit.Framework.Legacy` namespace:

* [String Assert](xref:classic-string-assert)
* [Collection Assert](xref:classic-collection-assert)
* [File Assert](xref:classic-file-assert)
* [Directory Assert](xref:classic-directory-assert)

## See Also

* [Constraint Model](xref:constraintmodel)

## Notes

* The exception-family of classic asserts have not been moved to the legacy namespace.

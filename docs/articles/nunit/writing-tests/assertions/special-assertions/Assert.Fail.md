---
uid: special-assert-fail
---

# Assert.Fail

The `Assert.Fail` method provides you with the ability to generate a failure based
on tests that are not encapsulated by the other methods. It is also useful in
developing your own project-specific assertions.

```csharp
Assert.Fail();
Assert.Fail(string message);

```

Here's an example of its use to create a private assertion that tests whether a
string contains an expected value.

[!code-csharp[AssertFailHelper](~/snippets/Snippets.NUnit/SpecialAssertionExamples.cs#AssertFailHelper)]

## See Also

* [Assert.Pass](Assert.Pass.md)
* [Assert.Ignore](Assert.Ignore.md)
* [Assert.Inconclusive](Assert.Inconclusive.md)

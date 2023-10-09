# Assumptions

Assumptions are intended to express the state a test must be in to provide a meaningful result. They are functionally similar to assertions, however an unmet assumption will produce an `Inconclusive` test result, as opposed to a `Failure`.

Assumptions make use of the `Assume` static class.

## Syntax Example

[!code-csharp[AssumptionsTests](~/snippets/Snippets.NUnit/Assumptions.cs#TestThatUsesAssume)]

`Assume.That()` has the same set of overloads as `Assert.That()`. For further details, see the [Constraint Model](xref:constraintmodel) documentation.

> [!NOTE]
> Failing assumptions indicate that running tests is invalid,  while [Multiple Asserts](xref:multipleasserts) allow testing to continue after a failure. For that reason, the two features are incompatible and assumptions may not be used within a [multiple assert](xref:multipleasserts) block.

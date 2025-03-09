---
uid: multipleasserts
---

# Multiple Asserts

Usually, once an assertion fails, we want the test to terminate. But sometimes, it's desirable to continue and
accumulate any additional failures so they may all be fixed at once. This is particularly useful for testing things like
object initialization and UI appearance as well as certain kinds of integration testing.

## Syntax / Example

Multiple asserts are implemented using the `Assert.EnterMultipleScope` method.

Let's assume we have production code that looks like the following:

[!code-csharp[MultipleAssertsProdCode](~/snippets/Snippets.NUnit/MultipleAsserts.cs#MultipleAssertsProdCode)]

In that case, we could write a test with multiple assertions, such as:

[!code-csharp[MultipleAssertsScopes](~/snippets/Snippets.NUnit/MultipleAsserts.cs#MultipleAssertsScopes)]

Functionally, this results in NUnit storing any failures encountered in the block and reporting all of them together
upon exit from the block. If both asserts failed, then both would be reported. The test itself would terminate at the
end of the block if any failures were encountered, but would continue otherwise.

### Older NUnit versions

Earlier than  NUnit 4.2 you can must  use  `Assert.Multiple`:

[!code-csharp[MultipleAssertsTests](~/snippets/Snippets.NUnit/MultipleAsserts.cs#MultipleAssertsTests)]

## Notes

1. For more information on `EnterMultipleScope` see this [Feature Request](https://github.com/nunit/nunit/issues/4587).

2. The multiple assert block may contain any arbitrary code, not just asserts.

3. Multiple assert blocks may be nested. Failure is not reported until the outermost block exits.

4. If the code in the block calls a method, that method may also contain multiple assert blocks.

5. The test will be terminated immediately if any exception is thrown that is not handled. An unexpected exception is
   often an indication that the test itself is in error, so it must be terminated. If the exception occurs after one or
   more assertion failures have been recorded, those failures will be reported along with the terminating exception
   itself.

6. Assert.Fail is handled just as any other assert failure. The message and stack trace are recorded but the test
   continues to execute until the end of the block.

7. An error is reported if any of the following are used inside a multiple assert block:
   * Assert.Pass
   * Assert.Ignore
   * Assert.Inconclusive
   * Assume.That

8. Use of Warnings (Assert.Warn, Warn.If, Warn.Unless) is permitted inside a multiple assert block. Warnings are
   reported normally along with any failures that occur inside the block.

### Runner Support

Multiple assertion failures per test are stored in the representation of the test result using new XML elements, which
are not recognized by older runners. The following runners are known to support display of the new elements:

* NUnit3 Visual Studio Adapter 3.7++ (Used by Visual Studio and `dotnet test`)
* NUnit Console Runner 3.6++

#### Compatibility

Older runners generally display a single failure message and stack trace for each test. For compatibility purposes, the
framework creates a single message that lists all the failures. The stack trace in such a case will indicate the end of
the assert multiple block.

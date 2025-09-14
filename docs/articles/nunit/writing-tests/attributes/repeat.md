# Repeat

**RepeatAttribute** is used on a test method to specify that it should be
executed multiple times.

By default, the test is repeated until a failure occurs. If no failures occur, it runs for the specified number of repetitions.

You can change this behavior in case of a failure, so that it continues to run after the failure by setting the property `StopOnFailure` to `false`.  (From version 4.3.0)

## Examples

### The default behavior

[!code-csharp[RepeatDefaultAttributeExample](~/snippets/Snippets.NUnit/Attributes/RepeatAttributeExample.cs#RepeatDefaultAttributeExample)]

### Run all regardless of failures

[!code-csharp[RepeatWithFaultAttributeExample](~/snippets/Snippets.NUnit/Attributes/RepeatAttributeExample.cs#RepeatWithFaultAttributeExample)]

> [!WARNING]
> There is currently (as of 4.4.0) a [bug](https://github.com/nunit/nunit/issues/5031) which causes only the last successful console statement to be output.  Also, in case of failures, only the latest failure is shown.
> [!NOTE]
> If RepeatAttribute is used on a parameterized method,
> each individual test case created for that method is repeated.
> It is not currently possible to use RepeatAttribute on a TestFixture or any higher level suite. Only test cases may be repeated.

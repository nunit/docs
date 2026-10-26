# Warnings

Sometimes - especially in integration testing - it's desirable to give a warning message but continue execution.
Beginning with release 3.6, NUnit supports this with the `Warn` class and the `Assert.Warn` method.

## Syntax

[!code-csharp[WarningExamples](~/snippets/Snippets.NUnit/WarningExamples.cs#WarningExamples)]

Each of the above items would fail. The test would continue to execute, however, and the warning messages would only be
reported at the end of the test. If the test subsequently fails, the warnings will be reported along with the failure
message or - in the case of `Assert.Multiple` - messages.

All of the overloads above also have a variant that accepts a function, `Func<string>`, that is used to build the
message included with the Exception.

> [!NOTE]
> The framework reports warnings by including information about them in the XML result that is sent to the
> runner in use. If you are using this facility, make sure the runner you use supports warnings. Generally, the runners
> released by the NUnit team after the release of the 3.6 framework will have this support. Earlier releases will not.
> Many third party runners will not know what to do with warnings either.

## Warnings followed by Assert.Ignore, Assert.Inconclusive or Assert.Pass

`Assert.Ignore`, `Assert.Inconclusive` and `Assert.Pass` all end the test immediately by throwing. The final result
state is the one the call asks for: Ignored, Inconclusive or Passed. What happens to warnings recorded earlier in the
test depends on the framework version:

* **NUnit 5 and later**: the warnings are kept and listed in the result message together with the message passed to the
  call, in the same numbered format used for multiple failures.
* **NUnit 4 and earlier**: the result message contains only the message passed to the call. Earlier warnings are not
  shown.

See [Assert.Ignore](xref:special-assert-ignore) for the full behavior, including how ignored and warning results appear
in Visual Studio Test Explorer.

---
uid: special-assert-ignore
---

# Assert.Ignore

`Assert.Ignore` ends the current test immediately and reports it as **Ignored**. Use it when a test discovers at run
time that it cannot meaningfully run in the current environment, for example because a database, service or license
is not available.

Ignoring is also widely used to park a test that is still under development or not yet passing, so that it stays in
the code base and in the results without failing the build. That condition is known before the test runs, so the
[`Ignore` attribute](xref:attribute-ignore) is the better tool for it. Either way, treat it as temporary: NUnit reports
an ignored test as a warning precisely so that it is not forgotten.

```csharp
Assert.Ignore();
Assert.Ignore(string message);
```

The message becomes the reason shown in the test result. Always supply one, so that whoever looks at the result later
knows why the test did not run.

[!code-csharp[AssertIgnoreInTest](~/snippets/Snippets.NUnit/AssertIgnoreExamples.cs#AssertIgnoreInTest)]

We recommend using `Assert.Ignore` only in isolated cases. Conditions that are known before the test runs are better
expressed with attributes, which runners can show accurately without executing any test code. See
[Alternatives to Assert.Ignore](#alternatives-to-assertignore) below.

## What happens when you call it

* `Assert.Ignore` throws an `IgnoreException`. NUnit catches it and records the test with the result state
  `Skipped:Ignored` and your message. Nothing after the call runs, including any remaining assertions.
* Because it works by throwing, the call can be made from a helper method, not only from the test body itself.
* For the same reason, do not wrap it in a `catch (Exception)` block. Swallowing the `IgnoreException` makes the test
  pass as if nothing had happened. If you must catch exceptions around the call, rethrow or exclude `IgnoreException`.
* `Assert.Ignore` may not be used inside an [`Assert.Multiple` block or `Assert.EnterMultipleScope`](xref:multipleasserts).
  Doing so produces an error result, not an ignored one.

## Where you can call it

| Called from               | Effect                                                                                                                                                              |
| ------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| A test method             | That test is ignored.                                                                                                                                               |
| A `[SetUp]` method        | The test being set up is ignored. Its `[TearDown]` methods still run.                                                                                               |
| A `[OneTimeSetUp]` method | The whole fixture is ignored. Every test in it is reported as ignored with the message `OneTimeSetUp: SetUp : <your reason>`, and `[OneTimeTearDown]` still runs. |
| A `[SetUpFixture]` setup  | Every fixture in that namespace is ignored, in the same way as for a single fixture.                                                                                |

Ignoring from `[OneTimeSetUp]` is the usual way to skip a whole group of tests that share one unavailable dependency:

[!code-csharp[AssertIgnoreInOneTimeSetUp](~/snippets/Snippets.NUnit/AssertIgnoreExamples.cs#AssertIgnoreInOneTimeSetUp)]

When the whole fixture is known up front not to be ready, put the [`Ignore` attribute](xref:attribute-ignore) on the
class instead. Every test in it is then reported as ignored without any setup code running:

[!code-csharp[IgnoreAttributeOnFixture](~/snippets/Snippets.NUnit/AssertIgnoreExamples.cs#IgnoreAttributeOnFixture)]

Each test in an ignored fixture carries the message `OneTimeSetUp: <your reason>`, even though the fixture declares no
`[OneTimeSetUp]` method. NUnit reports an ignored fixture the same way as a fixture whose one-time setup did not
complete, and the prefix reflects that.

## Ignored, Inconclusive, or not run?

NUnit treats an ignored test as a kind of warning: a test that should have run did not, and someone should look at why.
That is why runners highlight ignored tests, typically in yellow, and why `Assert.Ignore` and the
[`Ignore` attribute](xref:attribute-ignore) produce the same result state. A test that was filtered out, excluded by
[`Platform`](xref:attribute-platform), or marked [`Explicit`](xref:attribute-explicit) is plain `Skipped` with no
`Ignored` label, and runners treat it as neutral.

Pick the outcome that says what you mean:

| You want to say                                                   | Use                                                                                      | NUnit result      |
| ----------------------------------------------------------------- | ---------------------------------------------------------------------------------------- | ----------------- |
| "This test should run, but can't here. Someone should know."      | `Assert.Ignore` or `[Ignore]`                                                            | `Skipped:Ignored` |
| "This test is under development and can't run yet."               | `[Ignore]` on the test or fixture                                                        | `Skipped:Ignored` |
| "The test ran but couldn't reach a verdict. Another run might."   | [`Assert.Inconclusive`](Assert.Inconclusive.md) or [`Assume.That`](../../Assumptions.md) | `Inconclusive`    |
| "This test is not meant to run in this environment or selection." | `[Platform]`, `[Explicit]`, `[Category]` with a filter                                   | `Skipped`         |
| "Keep going, but flag this."                                      | [`Warn` or `Assert.Warn`](../../Warnings.md)                                             | `Warning`         |

### How the VS Test Adapter and `dotnet test` show these results

Visual Studio Test Explorer only knows the outcomes Passed, Failed, Skipped, None (shown as Not Run) and NotFound, so
the NUnit3TestAdapter has to collapse NUnit's richer set of results:

| NUnit result                                     | Test Explorer outcome                                                                   |
| ------------------------------------------------ | --------------------------------------------------------------------------------------- |
| `Skipped:Ignored` (`Assert.Ignore`, `[Ignore]`)  | Skipped, with the reason as the error message                                           |
| `Skipped` (filtered, `[Platform]`, `[Explicit]`) | None (Not Run)                                                                          |
| `Inconclusive`                                   | None (Not Run)                                                                          |
| `Warning`                                        | Skipped by default; configurable with [`MapWarningTo`](xref:tipsandtricks#mapwarningto) |

What `dotnet test` prints depends on the verbosity of its console logger. At the default verbosity it prints a
`Skipped <test name>` line for every one of these results, with no reason, followed by the summary counts. Tests with
outcome None appear in that list but are not counted in the summary totals; ignored and warned tests are. If a count in
the summary looks wrong, this is usually why.

```text
  Skipped AssertIgnored [18 ms]
  Skipped ExplicitTest [< 1 ms]

Passed!  - Failed:     0, Passed:     1, Skipped:     1, Total:     2, Duration: 24 ms - MyTests.dll (net10.0)
```

To see the reasons, raise the verbosity with `--logger "console;verbosity=normal"`. The NUnit adapter then prints each
reason on its own line, as `<test name>: <reason>`, before the `Skipped` lines. At `verbosity=detailed` the reason is
also repeated under each test as its error message.

```text
AssertIgnored: Reporting DB not available here.
ExplicitTest: Only on demand
  Skipped AssertIgnored [11 ms]
  Skipped ExplicitTest [< 1 ms]
  Passed Passes [< 1 ms]
```

Because so many users only ever see results through Test Explorer, the difference between Ignored and Skipped is easy to
miss. It still matters for the NUnit console runner, for runners that read the NUnit XML result, and for anyone reading
the result message.

## Warnings issued before Assert.Ignore

`Assert.Ignore` ends the test by throwing, so any [warnings](../../Warnings.md) already recorded with `Warn` or
`Assert.Warn` have to be merged into the final result.

* **NUnit 5 and later**: the result is still `Skipped:Ignored`, and the message lists the warnings followed by the ignore
  reason, in the same numbered format used for multiple assertion failures. The call also counts as an assertion.
* **NUnit 4 and earlier**: the message holds only the ignore reason. The warnings are dropped from the message.

The same applies to [`Assert.Inconclusive`](Assert.Inconclusive.md) and [`Assert.Pass`](Assert.Pass.md), which also end
the test by throwing. In NUnit 5 a test that warns and then calls `Assert.Pass` is still reported as Passed, with the
warnings in its message.

[!code-csharp[WarningsThenIgnore](~/snippets/Snippets.NUnit/AssertIgnoreExamples.cs#WarningsThenIgnore)]

In NUnit 5 the test above is reported as ignored with a message like:

```text
Multiple failures or warnings in test:
  1) The cache was cold, so timings below are not representative.
  2) Results cannot be trusted on this run.
```

## Ignoring conditionally

NUnit has no built-in `Ignore.If`, because `Warn` records an assertion while ignoring changes the outcome of the whole
test. A small helper gives you the same shape:

[!code-csharp[IgnoreIfHelper](~/snippets/Snippets.NUnit/AssertIgnoreExamples.cs#IgnoreIfHelper)]

> [!NOTE]
> If you name the helper class `Ignore`, keep it out of namespaces where you also use the `[Ignore]` attribute, or the
> attribute becomes ambiguous with the class and the code no longer compiles.

For data-driven tests, prefer marking the individual cases instead of checking inside the test. `TestCaseData.Ignore`
takes a reason, and `Until` can lift the ignore automatically on a given date:

[!code-csharp[IgnoreUntilExample](~/snippets/Snippets.NUnit/TestCaseDataExample.cs#IgnoreUntilExample)]

See [TestCaseData](xref:testcasedata) and the `Ignore` named parameter of [`TestCase`](xref:attribute-testcase).

## Alternatives to Assert.Ignore

Attributes are evaluated when tests are discovered, so runners can show the outcome without executing any test code,
and nothing in the test body has to run first. Prefer them whenever the condition is known up front:

* [`Ignore`](xref:attribute-ignore) for a test that is known not to work, optionally with `Until` for a date.
* [`Platform`](xref:attribute-platform) for tests that only apply to some operating systems or runtimes.
* [`Explicit`](xref:attribute-explicit) for tests that should only run when selected by name or filter.
* [`Category`](xref:attribute-category) together with a runner filter for sets of tests that run on different
  occasions, or simply divide them into separate assemblies.

## See Also

* [Assert.Pass](Assert.Pass.md)
* [Assert.Fail](Assert.Fail.md)
* [Assert.Inconclusive](Assert.Inconclusive.md)
* [Warnings](../../Warnings.md)
* [Ignore Attribute](xref:attribute-ignore)

---
uid: flakyandslowtests
---

# Flaky and Slow Tests

Some tests don't give the same result every time. They call a service that sometimes times out, test something that is
non-deterministic by nature, or now and then take far too long. NUnit has attributes for each of these cases.

> [!TIP]
> A flaky test is often a sign of a real problem, such as a race condition or state shared between tests. Use these
> attributes to keep your build reliable while you investigate, not to hide bugs.

## Retrying a test that sometimes fails

[`[Retry]`](xref:attribute-retry) runs the test again when an assertion fails, up to the number of attempts you give.
The test passes as soon as one attempt passes.

[!code-csharp[FlakyRetry](~/snippets/Snippets.NUnit/WritingTestsGuideExamples.cs#FlakyRetry)]

The count is the total number of attempts, so `[Retry(3)]` means one run and up to two retries. By default, only
assertion failures cause a retry. List the exceptions that should also cause a retry in `RetryExceptions`.

## Allowing some failures

For systems that are non-deterministic by design, such as tests of AI-based features, you can accept that a test
sometimes fails. [`[Repeat]`](xref:attribute-repeat) with `RequiredPassPercentage` runs the test several times and
passes when enough of the runs pass.

[!code-csharp[FlakyRepeatThreshold](~/snippets/Snippets.NUnit/WritingTestsGuideExamples.cs#FlakyRepeatThreshold)]

Set `StopWhenOverallResultDetermined = true` to stop repeating as soon as the outcome is certain. `[Repeat]` without a
percentage is also a good way to *find* a flaky test: repeat it a hundred times and see whether it ever fails.

> [!NOTE]
> `RequiredPassPercentage` and `StopWhenOverallResultDetermined` were added in NUnit 5.0.

## Tests that take too long

[`[MaxTime]`](xref:attribute-maxtime) fails a test that takes longer than the time you give, in milliseconds. With
`WarningTime`, a test that is slower than expected, but still within the limit, gives a warning instead. The test is
never interrupted: NUnit measures the time when it finishes.

[!code-csharp[SlowMaxTime](~/snippets/Snippets.NUnit/WritingTestsGuideExamples.cs#SlowMaxTime)]

## Tests that hang

To stop a test that runs too long, use [`[CancelAfter]`](xref:attribute-cancelafter). NUnit passes a
`CancellationToken` to the test and cancels it when the time is up. The test must pass the token on to the code it
calls, so that the work actually stops.

[!code-csharp[SlowCancelAfter](~/snippets/Snippets.NUnit/WritingTestsGuideExamples.cs#SlowCancelAfter)]

> [!NOTE]
> The older [`[Timeout]`](xref:attribute-timeout) attribute only works on .NET Framework, and is reported as a test
> failure on .NET 5 and later. For code that can't be cancelled, `dotnet test --blame-hang-timeout` stops the whole
> test run when a test hangs.

## See also

- The [Retry](xref:attribute-retry), [Repeat](xref:attribute-repeat), [MaxTime](xref:attribute-maxtime) and
  [CancelAfter](xref:attribute-cancelafter) reference pages
- [Warnings](Warnings.md), for how warning results are reported

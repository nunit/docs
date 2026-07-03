---
uid: attribute-repeat
---

# Repeat

`RepeatAttribute` is used on a test method to specify that it should be executed multiple times. By default, the test repeats until a failure occurs or all repetitions complete successfully.

## Constructors

```csharp
RepeatAttribute(int count)
RepeatAttribute(int count, bool stopOnFailure)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `count` | `int` | The number of times to run the test. |
| `stopOnFailure` | `bool` | Whether to stop repeating when a test fails. Default is `true`. |

## Properties

| Property | Type | Description | Default |
|----------|------|-------------|---------|
| `StopOnFailure` | `bool` | Whether to stop repeating when a test fails. When `false`, all repetitions run regardless of failures. | `true` |
| `RequiredPassPercentage` | `int` | The minimum percentage of runs (1–100) that must pass for the test to succeed. When set below 100, `StopOnFailure` is treated as `false` (and must not be explicitly set to `true`); iterations run up to the repeat count unless `StopWhenOverallResultDetermined` is enabled. | `100` |
| `StopWhenOverallResultDetermined` | `bool` | When `true` and `RequiredPassPercentage` is below 100, stops iterating as soon as the final outcome is determined — either because the pass threshold is already guaranteed or can no longer be reached. | `false` |

-----
> [!NOTE]
> The `StopOnFailure` property was added in **NUnit 4.3.0**.
-----
> [!NOTE]
> The `RequiredPassPercentage` and `StopWhenOverallResultDetermined` properties were added in **NUnit 5.0**.

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ✅ | ❌ | ❌ |

## Examples

### Default Behavior (Stop on Failure)

[!code-csharp[RepeatDefaultAttributeExample](~/snippets/Snippets.NUnit/Attributes/RepeatAttributeExample.cs#RepeatDefaultAttributeExample)]

### Continue on Failure

[!code-csharp[RepeatWithFaultAttributeExample](~/snippets/Snippets.NUnit/Attributes/RepeatAttributeExample.cs#RepeatWithFaultAttributeExample)]

### Pass Threshold

When testing non-deterministic systems (such as LLM-based tests or flaky integrations), you can allow a percentage of runs to fail. The test passes as long as at least `RequiredPassPercentage` percent of the runs succeed.

[!code-csharp[RepeatWithPassThresholdExample](~/snippets/Snippets.NUnit/Attributes/RepeatAttributeExample.cs#RepeatWithPassThresholdExample)]

### Early Stop When Outcome Is Determined

When `StopWhenOverallResultDetermined` is `true`, NUnit stops iterating as soon as it knows whether the threshold will be met or missed, saving unnecessary test runs.

[!code-csharp[RepeatWithStopWhenDeterminedExample](~/snippets/Snippets.NUnit/Attributes/RepeatAttributeExample.cs#RepeatWithStopWhenDeterminedExample)]

## Notes

1. When `StopOnFailure` is `true` (default), the test stops at the first failure.
2. When `StopOnFailure` is `false`, all repetitions run and all failures are collected.
3. When `RequiredPassPercentage` is set below 100, `StopOnFailure` must not be explicitly set to `true` — combining the two is a configuration error that produces `ResultState.Error` without running the test. Setting `StopOnFailure=false` explicitly alongside a threshold is valid. When `StopOnFailure` is left at its default (not explicitly set), it is silently treated as `false` so repetitions continue after failures (unless `StopWhenOverallResultDetermined` is enabled).
4. When `RequiredPassPercentage` is below 100 and `StopWhenOverallResultDetermined` is `true`, NUnit exits the loop as soon as the result is certain:
   - **Early success**: the number of passes already guarantees the threshold regardless of the remaining runs.
   - **Early failure**: even if all remaining runs pass, the threshold can no longer be reached.
5. If `RepeatAttribute` is used on a parameterized method, each individual test case is repeated independently.
6. It is not currently possible to use `RepeatAttribute` on a `TestFixture` or any higher level suite. Only test methods may be repeated.

## See Also

- [Retry Attribute](xref:attribute-retry)

# MaxTime

`MaxTimeAttribute` is used on test methods to specify a maximum time in milliseconds for a test case. If the test takes longer than the specified time to complete, it is reported as a failure.

Unlike `CancelAfter`, this attribute does **not** cancel the test - it waits for the test to complete and then checks the elapsed time.

## Constructor

```csharp
MaxTimeAttribute(int milliseconds)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `milliseconds` | `int` | The maximum elapsed time in milliseconds. If the test exceeds this time, it fails. |

## Applies To

- **Test Methods** - Cannot be applied to fixtures or assemblies.

## Examples

### Basic Usage

[!code-csharp[MaxTimeBasic](~/snippets/Snippets.NUnit/Attributes/MaxTimeAttributeExamples.cs#MaxTimeBasic)]

### Assertion Failures Take Precedence

[!code-csharp[MaxTimeVsAssertions](~/snippets/Snippets.NUnit/Attributes/MaxTimeAttributeExamples.cs#MaxTimeVsAssertions)]

## Notes

1. Any assertion failures take precedence over the elapsed time check. If a test both fails an assertion and exceeds the time limit, the assertion failure is reported.
2. This attribute does **not** cancel or abort the test if the time is exceeded. It waits for the test to complete, then compares the elapsed time to the maximum.
3. For tests that need to be cancelled when they exceed a time limit, use [CancelAfter Attribute](cancelafter.md) instead.
4. The timing includes the test method execution only, not `SetUp` or `TearDown` methods.
5. The [Timeout Attribute](timeout.md) uses `Thread.Abort` and only works on .NET Framework.

## See Also

* [CancelAfter Attribute](cancelafter.md)
* [Timeout Attribute](timeout.md)

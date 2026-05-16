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

> [!NOTE]
> The `StopOnFailure` property was added in **NUnit 4.3.0**.

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ✅ | ❌ | ❌ |

## Examples

### Default Behavior (Stop on Failure)

[!code-csharp[RepeatDefaultAttributeExample](~/snippets/Snippets.NUnit/Attributes/RepeatAttributeExample.cs#RepeatDefaultAttributeExample)]

### Continue on Failure

[!code-csharp[RepeatWithFaultAttributeExample](~/snippets/Snippets.NUnit/Attributes/RepeatAttributeExample.cs#RepeatWithFaultAttributeExample)]

## Notes

1. When `StopOnFailure` is `true` (default), the test stops at the first failure.
2. When `StopOnFailure` is `false`, all repetitions run and all failures are collected.
3. If `RepeatAttribute` is used on a parameterized method, each individual test case is repeated.
4. It is not currently possible to use `RepeatAttribute` on a `TestFixture` or any higher level suite. Only test methods may be repeated.

## See Also

* [Retry Attribute](xref:attribute-retry)

---
uid: attribute-retry
---

# Retry

`RetryAttribute` is used on a test method to specify that it should be rerun on failure up to a maximum number of times.

## Constructor

```csharp
RetryAttribute(int tryCount)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `tryCount` | `int` | The maximum number of times the test should be run if it fails. This is the total number of attempts, **not** the number of retries after an initial failure. Therefore, `[Retry(1)]` does nothing and should not be used. |

## Properties

| Property | Type | Description | Default |
|----------|------|-------------|---------|
| `RetryExceptions` | `Type[]` | An array of exception types that trigger a retry when thrown. These are in addition to the normal behavior of retrying only on an assertion failure. | `[]` (empty array) |

> [!NOTE]
> The `RetryExceptions` property was added in **NUnit 4.5.0**.

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ✅ | ❌ | ❌ |

## Example

[!code-csharp[Retry](~/snippets/Snippets.NUnit/Attributes/RetryAttributeExamples.cs#Retry)]

### Using RetryExceptions

When you need to retry on specific exception types (such as `TimeoutException` or `OperationCanceledException`), you can set the `RetryExceptions` property:

[!code-csharp[RetryWithRetryExceptions](~/snippets/Snippets.NUnit/Attributes/RetryAttributeExamples.cs#RetryWithRetryExceptions)]

## Notes

1. It is not currently possible to use `RetryAttribute` on a `TestFixture` or any other type of test suite. Only single test methods may be retried.
2. If a test has an unexpected exception, an error result is returned and it is not retried — unless that exception type is specified in the `RetryExceptions` property.

## See Also

* [Repeat Attribute](xref:attribute-repeat)

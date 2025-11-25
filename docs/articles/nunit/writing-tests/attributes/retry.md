# Retry

RetryAttribute is used on a test method to specify that it should be rerun if it fails, up to a maximum number of times.

[!code-csharp[Retry](~/snippets/Snippets.NUnit/Attributes/RetryAttributeExamples.cs#Retry)]

Notes:

1. The argument you specify is the total number of attempts and __not__ the number of retries after an initial failure.
   So `[Retry(1)]` does nothing and should not be used.
2. It is not currently possible to use `RetryAttribute` on a `TestFixture` or any other type of test suite.
 Only single tests may be repeated.
3. If a test has an unexpected exception, an error result is returned and it is not retried.

   From NUnit 4.5.0 you can enable retry on an expected exception such as `TimeoutException`
   by setting the `RetryExceptions` property. The value of this property is an array of anticipated exceptions that should be retried.

[!code-csharp[RetryWithRetryExceptions](~/snippets/Snippets.NUnit/Attributes/RetryAttributeExamples.cs#RetryWithRetryExceptions)]

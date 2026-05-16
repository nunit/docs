---
uid: attribute-test
---

# Test

The `Test` attribute marks a method inside a test fixture as a test. It is normally used for simple (non-parameterized)
tests but may also be applied to parameterized tests without causing extra test cases to be generated. See
[Parameterized Tests](xref:parameterizedtests) for more information.

The test method may be either an instance or a static method.

Test methods may be **async**; NUnit waits for the method to complete before recording the result. Async test methods
must return `Task` or `Task<T>`.

If a test method does not have a valid signature, it is treated as not runnable.

## Usage

```csharp
[Test]
```

Use **named parameters** (properties on the attribute) for metadata and for checking a return value.

## Properties

| Property | Type | Description | Default |
|----------|------|-------------|---------|
| `Description` | `string?` | Descriptive text for the test. Equivalent to applying [`Description`](xref:attribute-description). | `null` |
| `Author` | `string?` | Author metadata. Equivalent to applying [`Author`](xref:attribute-author). | `null` |
| `TestOf` | `Type?` | Type under test. Equivalent to applying [`TestOf`](xref:attribute-testof). | `null` |
| `ExpectedResult` | `object?` | Expected return value; NUnit compares it to the method result. **Not valid** if the test method has parameters. | (unset) |

If the test method returns a value and you set `ExpectedResult`, NUnit checks equality with the return value.

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ✅ | ❌ | ❌ |

## Example

[!code-csharp[BasicTest](~/snippets/Snippets.NUnit/Attributes/TestAttributeExamples.cs#BasicTest)]

[!code-csharp[TestWithDescription](~/snippets/Snippets.NUnit/Attributes/TestAttributeExamples.cs#TestWithDescription)]

[!code-csharp[AsyncTest](~/snippets/Snippets.NUnit/Attributes/TestAttributeExamples.cs#AsyncTest)]

[!code-csharp[ExpectedResultTest](~/snippets/Snippets.NUnit/Attributes/TestAttributeExamples.cs#ExpectedResultTest)]

## See Also

* [TestCase Attribute](xref:attribute-testcase)
* [TestCaseSource Attribute](xref:attribute-testcasesource)
* [Theory Attribute](xref:attribute-theory)

---
uid: notestsattribute
---

# NoTests

The `NoTestsAttribute` specifies the default status for a parameterized test method or test fixture when it contains no
executable child tests. This is useful when test cases are generated dynamically and may sometimes produce an empty
set.

By default, NUnit treats a `Theory` with no test cases as a failure. For other parameterized tests, behavior may
vary. `NoTestsAttribute` chooses the `TestStatus` reported when no executable child tests are produced.

> [!NOTE]
> Introduced in **NUnit 4.6**.

## Constructor

```csharp
NoTestsAttribute(TestStatus defaultStatus)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `defaultStatus` | `TestStatus` | Result when no child tests exist (`Skipped`, `Inconclusive`, `Passed`, or `Failed`). |

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ✅ | ✅ | ✅ |

Most specific scope (method) wins over fixture and assembly.

## TestStatus Values

Typical uses:

| Value | Meaning |
|-------|---------|
| `TestStatus.Skipped` | Marked skipped when no cases |
| `TestStatus.Inconclusive` | Indeterminate empty data |
| `TestStatus.Passed` | Passed with no cases (use carefully) |
| `TestStatus.Failed` | Default for `Theory` with no cases |

## Test Fixture Syntax

Apply to a fixture to affect all parameterized tests within it:

[!code-csharp[NoTestsSkipped](~/snippets/Snippets.NUnit/Attributes/NoTestsAttributeExamples.cs#NoTestsSkipped)]

## Test Method Syntax

Apply directly to a test method:

[!code-csharp[NoTestsOnMethod](~/snippets/Snippets.NUnit/Attributes/NoTestsAttributeExamples.cs#NoTestsOnMethod)]

## Inconclusive Status

Use `TestStatus.Inconclusive` when empty test cases indicate an indeterminate state rather than a skip:

[!code-csharp[NoTestsInconclusive](~/snippets/Snippets.NUnit/Attributes/NoTestsAttributeExamples.cs#NoTestsInconclusive)]

## Common Scenarios

### Dynamic Test Data

Typical when test cases come from a source that can legitimately be empty (a database, API, config file, or similar).

[!code-csharp[NoTestsDynamicData](~/snippets/Snippets.NUnit/Attributes/NoTestsAttributeExamples.cs#NoTestsDynamicData)]

### Conditional Execution

Typical when cases are only produced for some platforms, environments, or other prerequisites.

[!code-csharp[NoTestsConditionalExecution](~/snippets/Snippets.NUnit/Attributes/NoTestsAttributeExamples.cs#NoTestsConditionalExecution)]

### Feature Flags

Typical when data-driven cases depend on feature flags or rollout state and may sometimes yield none.

[!code-csharp[NoTestsFeatureFlag](~/snippets/Snippets.NUnit/Attributes/NoTestsAttributeExamples.cs#NoTestsFeatureFlag)]

## Scope Precedence

* **Assembly** — parameterized tests across the assembly
* **Fixture (class)** — parameterized tests in that fixture
* **Method** — that method only

The most specific level wins when multiple attributes apply.

## See Also

* [TestCaseSource Attribute](xref:testcasesourceattribute)
* [TestCase Attribute](xref:testcaseattribute)
* [Theory Attribute](xref:theoryattribute)

---
uid: attribute-ignore
---

# Ignore

`IgnoreAttribute` indicates that a test should not be executed. In NUnit 3 and later, a reason must be provided.

Ignored tests are shown as warnings by runners, which helps highlight tests that need to be fixed or re-enabled.

## Constructor

```csharp
IgnoreAttribute(string reason)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `reason` | `string` | The reason the test or fixture is ignored. This value is required. |

## Properties

| Property | Type | Description | Default |
|----------|------|-------------|---------|
| `Until` | `string` | Optional date/time string. The test is ignored until this date/time, then runs normally. | `null` |

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ✅ | ✅ | ✅ |

> [!NOTE]
> When applied to a fixture or assembly, all contained tests are ignored.

## Test Fixture Syntax

[!code-csharp[IgnoreFixtureExample](~/snippets/Snippets.NUnit/Attributes/IgnoreAttributeExamples.cs#IgnoreFixtureExample)]

## Test Syntax

[!code-csharp[IgnoreTestExample](~/snippets/Snippets.NUnit/Attributes/IgnoreAttributeExamples.cs#IgnoreTestExample)]

## Ignore Until

The `Until` named parameter allows you to ignore a test for a specific period of time, after which the test will run
normally. The until date must be a string that can be parsed to a date.

[!code-csharp[IgnoreUntilExample](~/snippets/Snippets.NUnit/Attributes/IgnoreAttributeExamples.cs#IgnoreUntilExample)]

In the above example, it's assumed that the test would fail if run. With the IgnoreAttribute, it will give a warning
until the specified date. After that time, it will run normally and either pass or fail.

## Ignoring Individual Test Cases

The **IgnoreAttribute** causes all the test cases using the method on which it is placed to be ignored. Ignoring
individual test cases is possible, depending on how they are specified.

| Attribute | How to ignore a case |
|-----------|----------------------|
| **TestCase** | Use the **Ignore** named parameter of `TestCaseAttribute`. |
| **TestCaseSource** | Use `TestCaseData` for the source and set the **Ignore** property. |

## Notes

1. Applying `IgnoreAttribute` to a test method ignores all test cases produced by that method.
2. To ignore individual cases, use `Ignore` on `TestCaseAttribute` or `TestCaseData`.
3. The `Until` value must be parseable as a date/time; after that instant, the test runs normally.

## See Also

* [Explicit Attribute](xref:attribute-explicit)
* [TestCase Attribute](xref:attribute-testcase)
* [TestCaseSource Attribute](xref:attribute-testcasesource)

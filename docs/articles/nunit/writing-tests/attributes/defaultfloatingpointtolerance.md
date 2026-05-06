---
uid: attribute-defaultfloatingpointtolerance
---

# DefaultFloatingPointTolerance

`DefaultFloatingPointToleranceAttribute` sets the default tolerance for floating-point equality comparisons (`float` and `double`) unless a comparison explicitly specifies a tolerance.

You can apply it at method, fixture, or assembly scope.

## Constructor

```csharp
DefaultFloatingPointToleranceAttribute(double tolerance)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `tolerance` | `double` | The default tolerance used for floating-point comparisons when no explicit tolerance is specified. |

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ✅ | ✅ | ✅ |

> [!NOTE]
> When applied at fixture or assembly level, this default tolerance applies to all contained tests unless overridden by a more specific scope or by an explicit tolerance in an assertion.

## Examples

### Fixture Default Tolerance

[!code-csharp[DefaultFloatingPointToleranceFixture](~/snippets/Snippets.NUnit/Attributes/DefaultFloatingPointToleranceAttributeExamples.cs#DefaultFloatingPointToleranceFixture)]

### Method Override

[!code-csharp[DefaultFloatingPointToleranceMethodOverride](~/snippets/Snippets.NUnit/Attributes/DefaultFloatingPointToleranceAttributeExamples.cs#DefaultFloatingPointToleranceMethodOverride)]

## Notes

1. This attribute affects default tolerance for floating-point equality comparisons only.
2. Integer comparisons are not affected.
3. An explicit tolerance in an assertion (for example, `.Within(...)`) overrides the default tolerance.

## See Also

* [Assert.AreEqual](xref:classic-assert-are-equal)
* [EqualConstraint](xref:equalconstraint) — numeric **`Within`** tolerances and floating-point comparison behavior (including the **Comparing floating-point values** section)

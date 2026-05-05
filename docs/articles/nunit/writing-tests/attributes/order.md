---
uid: orderattribute
---

# Order

`OrderAttribute` is used on test methods or fixtures to specify the order in which tests are run within their containing suite. Tests are started in ascending order of the `order` value.

## Constructor

```csharp
OrderAttribute(int order)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `order` | `int` | The order value. Tests are started in ascending order of this value. Lower values run first. |

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ✅ | ✅ | ❌ |

> [!NOTE]
> For fixtures, `Order` orders fixtures within their containing namespace. For test methods, it orders tests within their containing fixture.

## Examples

### Basic Ordering

[!code-csharp[OrderBasic](~/snippets/Snippets.NUnit/Attributes/OrderAttributeExamples.cs#OrderBasic)]

### Ordering Fixtures

[!code-csharp[OrderOnFixtures](~/snippets/Snippets.NUnit/Attributes/OrderAttributeExamples.cs#OrderOnFixtures)]

### Using Gaps for Future Insertions

[!code-csharp[OrderWithGaps](~/snippets/Snippets.NUnit/Attributes/OrderAttributeExamples.cs#OrderWithGaps)]

## Notes

1. Ordering is **local** to the containing suite. For test methods, ordering applies within the fixture. For fixtures, it applies within the namespace. There is no facility to order tests globally.
2. Tests with `[Order]` are started **before** any tests without the attribute.
3. Ordered tests are started in **ascending** order of the `order` value.
4. Among tests with the same `order` value, or among tests without the attribute, execution order is indeterminate.
5. Tests do **not** wait for prior tests to finish. When using parallel execution, a test may start while earlier tests are still running.
6. Negative order values are valid and will run before positive values.

## See Also

* [Parallelizable Attribute](xref:parallelizableattribute)
* [NonParallelizable Attribute](xref:nonparallelizableattribute)

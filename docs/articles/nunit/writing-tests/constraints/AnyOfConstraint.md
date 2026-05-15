---
uid: constraint-anyof
---

# AnyOf Constraint

`AnyOfConstraint` tests that a value equals any one of a set of expected values.

> [!NOTE]
> Pass expected values as individual parameters, not as an array. To test if a collection contains a specific
> value, use [SomeItemsConstraint](SomeItemsConstraint.md) instead.

## Usage

```csharp
Is.AnyOf(params object[] expected)
```

## Modifiers

```csharp
.IgnoreCase
.IgnoreWhiteSpace              // NUnit 4.2+
.Using(IComparer comparer)
.Using(IEqualityComparer comparer)
.Using<T>(IComparer<T> comparer)
.Using<T>(IEqualityComparer<T> comparer)
.Using<T>(Comparison<T> comparer)
.Using<T>(Func<T, T, bool> comparer)
.UsingPropertiesComparer()     // NUnit 4.1+
```

## Examples

[!code-csharp[AnyOfConstraintExamples](~/snippets/Snippets.NUnit/Constraints/SpecialConstraintSnippets.cs#AnyOfConstraintExamples)]

## Notes

1. This is for testing a single value against multiple options.
2. For testing if a collection contains a value, use `Has.Member()` or `Does.Contain()`.
3. All comparison modifiers apply to the equality check between the actual and each expected value.

## See Also

* [SomeItems Constraint](SomeItemsConstraint.md) - Test if collection contains a value
* [Equal Constraint](EqualConstraint.md) - Test equality with single value
* [Or Constraint](OrConstraint.md) - Alternative way to express multiple options

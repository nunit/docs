---
uid: constraint-null
---

# Null Constraint

`NullConstraint` tests that a value is `null`. This is one of the most commonly used constraints for verifying that
references have not been assigned or have been explicitly set to `null`.

## Usage

```csharp
Is.Null
Is.Not.Null
```

## Examples

```csharp
object? obj = null;
Assert.That(obj, Is.Null);

string? name = GetName();
Assert.That(name, Is.Not.Null);

// Combining with other constraints
Assert.That(result, Is.Not.Null.And.Not.Empty);
Assert.That(GetOptionalValue(), Is.Null.Or.GreaterThan(0));
```

## Notes

1. For value types, consider using `Is.Default` instead, which tests for the default value of the type.
2. When testing nullable value types (`int?`, `bool?`, etc.), `Is.Null` works as expected.

## See Also

* [Default Constraint](DefaultConstraint.md)

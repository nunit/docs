---
uid: constraint-false
---

# False Constraint

`FalseConstraint` tests that a value is `false`. Use this constraint when asserting that a boolean condition or
expression evaluates to `false`.

## Usage

```csharp
Is.False
Is.Not.False  // equivalent to Is.True
```

## Examples

```csharp
Assert.That(2 + 2 == 5, Is.False);
Assert.That(isDisabled, Is.False);
Assert.That(list.IsReadOnly, Is.False);

// With nullable booleans
bool? isDeleted = false;
Assert.That(isDeleted, Is.False);
```

## Notes

1. `Is.Not.False` is equivalent to `Is.True` for non-nullable booleans.
2. For nullable booleans (`bool?`), `Is.False` only passes when the value is exactly `false`, not when it's `null`.

## See Also

* [True Constraint](TrueConstraint.md)

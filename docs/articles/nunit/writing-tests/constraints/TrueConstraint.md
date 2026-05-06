---
uid: constraint-true
---

# True Constraint

`TrueConstraint` tests that a value is `true`. Use this constraint when asserting boolean conditions or the result of
boolean expressions.

## Usage

```csharp
Is.True
Is.Not.True  // equivalent to Is.False
```

## Examples

```csharp
Assert.That(2 + 2 == 4, Is.True);
Assert.That(isValid, Is.True);
Assert.That(list.Contains(item), Is.True);

// With nullable booleans
bool? hasValue = true;
Assert.That(hasValue, Is.True);
```

## Notes

1. `Is.Not.True` is equivalent to `Is.False` for non-nullable booleans.
2. For nullable booleans (`bool?`), `Is.True` only passes when the value is exactly `true`, not when it's `null`.

## See Also

* [False Constraint](FalseConstraint.md)

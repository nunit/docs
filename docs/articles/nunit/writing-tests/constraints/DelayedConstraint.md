---
uid: constraint-delayed
---

# Delayed Constraint

`DelayedConstraint` delays evaluation of another constraint, optionally polling until the constraint passes or the
timeout expires. This is useful for testing asynchronous operations or eventual consistency.

## Usage

```csharp
<constraint>.After(int delayInMilliseconds)
<constraint>.After(int delayInMilliseconds, int pollingInterval)
<constraint>.After(int delay).Seconds
<constraint>.After(int delay).Minutes.PollEvery(int interval).MilliSeconds
```

## Examples

[!code-csharp[DelayedConstraintExamples](~/snippets/Snippets.NUnit/Constraints/SpecialConstraintSnippets.cs#DelayedConstraintExamples)]

### Fluent Time Syntax

[!code-csharp[DelayedConstraintFluentExamples](~/snippets/Snippets.NUnit/Constraints/SpecialConstraintSnippets.cs#DelayedConstraintFluentExamples)]

## Time Modifiers

```csharp
.Seconds
.Minutes
.MilliSeconds    // Note capital 'S'
```

Default unit is milliseconds when no modifier is specified.

## Notes

1. Use delegates (`() => value`) not direct values, since values are captured at call time.
2. When polling, the delegate may be called multiple times - avoid side effects.
3. The `.After()` modifier applies to the entire constraint expression preceding it.
4. Without polling, the constraint waits the full delay before checking once.

## See Also

* [Throws Constraint](ThrowsConstraint.md) - For exception testing
* [True Constraint](TrueConstraint.md) - For boolean conditions

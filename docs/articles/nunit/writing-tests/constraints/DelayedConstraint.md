# Delayed Constraint

`DelayedConstraint` delays the application of another constraint until a certain
amount of time has passed. In its simplest form, it replaces use of a Sleep
in the code but it also supports polling, which may allow use of a longer
maximum time while still keeping the tests as fast as possible.

The **After** modifier is permitted on any constraint, and the delay applies to
the entire expression up to the point where **After** appears.

Use of a **DelayedConstraint** with a value argument makes no sense, since
the value will be extracted at the point of call. Its intended use is with
delegates and references. If a delegate is used with polling, it may be called
multiple times so only methods without side effects should be used in this way.

| Syntax Helper | Constructor | Operation |
| ------------- | ------------| --------- |
| After(int) | DelayedConstraint(Constraint, int) | tests that a constraint is satisfied after a delay. |
| After(int, int) | DelayedConstraint(Constraint, int, int) | tests that a constraint is satisfied after a delay using polling. |

## Enhanced Syntax

With NUnit 3.6, an enhanced syntax is available that allows expressing the delay and polling interval more fluently.

```csharp
   After(4).Seconds
   After(1).Minutes.PollEvery(500).MilliSeconds
```

Only Minutes, Seconds and MilliSeconds (note capital-S) are accepted as time modifiers. The default is to use MilliSeconds.

## Examples of Use

[!code-csharp[DelayedConstraintExamples](~/snippets/Snippets.NUnit/ConstraintExamples.cs#DelayedConstraintExamples)]

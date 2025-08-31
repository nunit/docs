# GreaterThan Constraint

`GreaterThanConstraint` tests that one value is greater than another.

## Constructor

```csharp
GreaterThanConstraint(object expected)
```

## Syntax

```csharp
Is.GreaterThan(object expected)
Is.Positive // Equivalent to Is.GreaterThan(0)
```

## Modifiers

```csharp
...Using(IComparer comparer)
...Using<T>(IComparer<T> comparer)
...Using<T>(Comparison<T> comparer)
...Within(object tolerance)
```

## Examples of Use

[!code-csharp[GreaterThanExamples](~/snippets/Snippets.NUnit/ConstraintExamples.cs#GreaterThanExamples)]

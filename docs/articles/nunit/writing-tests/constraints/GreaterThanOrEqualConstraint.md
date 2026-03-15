# GreaterThanOrEqual Constraint

`GreaterThanOrEqualConstraint` tests that one value is greater than or equal to another.

## Constructor

```csharp
GreaterThanOrEqualConstraint(object expected)
```

## Syntax

```csharp
Is.GreaterThanOrEqualTo(object expected)
Is.AtLeast(object expected)
```

## Modifiers

```csharp
...Using(IComparer comparer)
...Using<T>(IComparer<T> comparer)
...Using<T>(Comparison<T> comparer)
...Within(object tolerance)
```

## Examples of Use

[!code-csharp[GreaterThanOrEqualExamples](~/snippets/Snippets.NUnit/ConstraintExamples.cs#GreaterThanOrEqualExamples)]

# LessThanOrEqual Constraint

`LessThanOrEqualConstraint` tests that one value is less than or equal to another.

## Constructor

```csharp
LessThanOrEqualConstraint(object expected)
```

## Syntax

```csharp
Is.LessThanOrEqualTo(object expected)
Is.AtMost(object expected)
```

## Modifiers

```csharp
...Using(IComparer comparer)
...Using<T>(IComparer<T> comparer)
...Using<T>(Comparison<T> comparer)
...Within(object tolerance)
```

## Examples of Use

[!code-csharp[GreaterThanOrEqualExamples](~/snippets/Snippets.NUnit/ConstraintExamples.cs#LessThanOrEqualExamples)]
[!code-csharp[With Comparer](~/snippets/Snippets.NUnit/ConstraintExamples.cs#MyComparerExample)]

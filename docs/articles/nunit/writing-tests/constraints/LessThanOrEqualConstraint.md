---
uid: constraint-lessthanorequal
---

# LessThanOrEqual Constraint

`LessThanOrEqualConstraint` tests that one value is less than or equal to another.

It works with numeric types, `DateTime`, `TimeSpan`, and any type implementing `IComparable`. For custom types, a
user-specified comparer can be provided using the `Using` modifier.

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

[!code-csharp[LessThanOrEqualExamples](~/snippets/Snippets.NUnit/ConstraintExamples.cs#LessThanOrEqualExamples)]
[!code-csharp[With Comparer](~/snippets/Snippets.NUnit/ConstraintExamples.cs#MyComparerExample)]

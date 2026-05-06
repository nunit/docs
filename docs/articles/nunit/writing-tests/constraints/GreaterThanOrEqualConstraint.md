---
uid: constraint-greaterthanorequal
---

# GreaterThanOrEqual Constraint

`GreaterThanOrEqualConstraint` tests that one value is greater than or equal to another.

It works with numeric types, `DateTime`, `TimeSpan`, and any type implementing `IComparable`. For custom types, a
user-specified comparer can be provided using the `Using` modifier.

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
[!code-csharp[With Comparer](~/snippets/Snippets.NUnit/ConstraintExamples.cs#MyComparerExample)]

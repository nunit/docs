---
uid: constraint-lessthan
---

# LessThan Constraint

`LessThanConstraint` tests that one value is less than another.

It works with numeric types, `DateTime`, `TimeSpan`, and any type implementing `IComparable`. For custom types, a
user-specified comparer can be provided using the `Using` modifier.

## Constructor

```csharp
LessThanConstraint(object expected)
```

## Syntax

```csharp
Is.LessThan(object expected)
Is.Negative // Equivalent to Is.LessThan(0)
```

## Modifiers

```csharp
...Using(IComparer comparer)
...Using<T>(IComparer<T> comparer)
...Using<T>(Comparison<T> comparer)
...Within(object tolerance)
```

## Examples of Use

[!code-csharp[LessThanExamples](~/snippets/Snippets.NUnit/ConstraintExamples.cs#LessThanExamples)]
[!code-csharp[With Comparer](~/snippets/Snippets.NUnit/ConstraintExamples.cs#MyComparerExample)]

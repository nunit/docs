# Range Constraint

`RangeConstraint` tests that a value is in an (inclusive) range.

## Constructor

```csharp
RangeConstraint(IComparable from, IComparable to)
```

## Syntax

```csharp
Is.InRange(IComparable from, IComparable to)
```

## Modifiers

```csharp
...Using(IComparer comparer)
...Using<T>(IComparer<T> comparer)
...Using<T>(Comparison<T> comparer)
```

## Examples of Use

[!code-csharp[RangeConstraintExamples](~/snippets/Snippets.NUnit/ConstraintExamples.cs#RangeConstraintExamples)]

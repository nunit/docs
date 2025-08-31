# NoItem Constraint

`NoItemConstraint` applies a constraint to each item in a collection, succeeding only if all of them fail. An exception
is thrown if the actual value passed does not implement `IEnumerable`.

## Constructor

```csharp
NoItemConstraint(Constraint itemConstraint)
```

## Syntax

```csharp
Has.None...
```

## Examples of Use

[!code-csharp[NotConstraintExamples](~/snippets/Snippets.NUnit/ConstraintExamples.cs#NotConstraintExamples)]

# AllItems Constraint

`AllItemsConstraint` applies a constraint to each item in an `IEnumerable`, succeeding only if all of them succeed. An exception is thrown if the actual value passed does not implement `IEnumerable`.

## Constructor

```csharp
AllItemsConstraint(Constraint itemConstraint)
```

## Syntax

You can use `Is.All` or `Has.All` to refer to all items in an `IEnumerable`.

## Examples of Use

[!code-csharp[IsBasedFormat](~/snippets/Snippets.NUnit/Constraints/AllItemsConstraintExamples.cs#AllItemsIsExample)]

[!code-csharp[HasBasedFormat](~/snippets/Snippets.NUnit/Constraints/AllItemsConstraintExamples.cs#AllItemsHasExample)]
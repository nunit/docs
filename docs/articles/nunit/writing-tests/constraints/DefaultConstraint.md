# DefaultConstraint

`DefaultConstraint` tests that the actual value is the default value for the type.

It is implemented equal to the C# keyword `default`.

## Constructor

```csharp
DefaultConstrint()
```

## Syntax

```csharp
Is.Default
Has.Length.Default
Has.Count.Default
Is.Not.Default
```

All resolvable properties of `Has` can be used with the `Default` property.
`Default` can be used with the `Not` operator.
`Default` can be used with the combinatorial operators.

## Examples of use

[!code-csharp[DefaultConstraintExample](~/snippets/Snippets.NUnit/DefaultConstraintExamples.cs#DefaultConstraintExample)]

## Version

From version 4.0.0

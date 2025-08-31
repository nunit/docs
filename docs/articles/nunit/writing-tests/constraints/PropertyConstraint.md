# Property Constraint

`PropertyConstraint` tests for the existence of a named property on an object and then applies a constraint test to the
property value.

## Constructor

```csharp
PropertyConstraint(string name, IConstraint baseConstraint)
```

## Syntax

```csharp
Has.Property(string name)... // followed by further constraint syntax
```

## Examples of Use

[!code-csharp[PropertyConstraintExamples](~/snippets/Snippets.NUnit/ConstraintExamples.cs#PropertyConstraintExamples)]

As shown in the example, certain common properties are known to NUnit and may be tested using a shorter form. The
following properties are supported:

```csharp
Has.Length...
Has.Count...
Has.Message...
Has.InnerException...
```

## See also

* [PropertyExistsConstraint](PropertyExistsConstraint.md)

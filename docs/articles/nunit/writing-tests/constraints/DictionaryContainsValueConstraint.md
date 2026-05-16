---
uid: constraint-dictionarycontainsvalue
---

# DictionaryContainsValue Constraint

`DictionaryContainsValueConstraint` tests whether a dictionary contains an expected value.

## Usage

```csharp
Contains.Value(object expectedValue)
Does.ContainValue(object expectedValue)
Does.Not.ContainValue(object expectedValue)
```

## Modifiers

```csharp
.IgnoreCase
.Using(IComparer comparer)
.Using(IEqualityComparer comparer)
.Using<T>(IComparer<T> comparer)
.Using<T>(IEqualityComparer<T> comparer)
.Using<T>(Comparison<T> comparer)
.Using<T>(Func<T, T, bool> comparer)
.UsingPropertiesComparer()     // NUnit 4.1+
```

## Examples

[!code-csharp[DictionaryContainsValueConstraintExamples](~/snippets/Snippets.NUnit/Constraints/DictionaryConstraintSnippets.cs#DictionaryContainsValueConstraintExamples)]

## Notes

1. Unlike key comparison, value comparison can use NUnit's comparison modifiers.
2. The constraint checks if any value in the dictionary matches.

## See Also

* [DictionaryContainsKey Constraint](DictionaryContainsKeyConstraint.md)
* [DictionaryContainsKeyValuePair Constraint](DictionaryContainsKeyValuePairConstraint.md)

---
uid: constraint-dictionarycontainskeyvaluepair
---

# DictionaryContainsKeyValuePair Constraint

`DictionaryContainsKeyValuePairConstraint` tests whether a dictionary contains a specific key-value pair.

## Usage

```csharp
Does.ContainKey(object key).WithValue(object value)
Does.Not.ContainKey(object key).WithValue(object value)
```

## Modifiers

These modifiers apply to the **value** comparison:

```csharp
.IgnoreCase
.IgnoreWhiteSpace              // NUnit 4.2+
.Using(IComparer comparer)
.Using(IEqualityComparer comparer)
.Using<T>(IComparer<T> comparer)
.Using<T>(IEqualityComparer<T> comparer)
.Using<T>(Comparison<T> comparer)
.Using<T>(Func<T, T, bool> comparer)
.UsingPropertiesComparer()     // NUnit 4.1+
```

## Examples

[!code-csharp[DictionaryContainsKeyValuePairConstraintExamples](~/snippets/Snippets.NUnit/Constraints/DictionaryConstraintSnippets.cs#DictionaryContainsKeyValuePairConstraintExamples)]

## Notes

1. Key comparison uses the dictionary's comparer (cannot be overridden).
2. Value comparison modifiers (`.IgnoreCase`, `.Using()`, etc.) only apply to the value.
3. The preferred syntax is `Does.ContainKey(key).WithValue(value)` rather than the constructor form.

## See Also

* [DictionaryContainsKey Constraint](DictionaryContainsKeyConstraint.md)
* [DictionaryContainsValue Constraint](DictionaryContainsValueConstraint.md)

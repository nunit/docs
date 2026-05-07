---
uid: constraint-dictionarycontainskey
---

# DictionaryContainsKey Constraint

`DictionaryContainsKeyConstraint` tests whether a dictionary contains an expected key.

## Usage

```csharp
Contains.Key(object expectedKey)
Does.ContainKey(object expectedKey)
Does.Not.ContainKey(object expectedKey)
```

## Modifiers

```csharp
.WithValue(object expectedValue)   // Also check the corresponding value
```

## Examples

[!code-csharp[DictionaryContainsKeyConstraintExamples](~/snippets/Snippets.NUnit/Constraints/DictionaryConstraintSnippets.cs#DictionaryContainsKeyConstraintExamples)]

### Dictionary Comparer Behavior

Key comparison uses the dictionary's own comparer:

[!code-csharp[DictionaryContainsKeyComparerExamples](~/snippets/Snippets.NUnit/Constraints/DictionaryConstraintSnippets.cs#DictionaryContainsKeyComparerExamples)]

## Notes

1. Key comparison always uses the dictionary's comparer, not NUnit's modifiers.
2. The `.WithValue()` modifier converts this to a key-value pair check.
3. As of NUnit 4.4, comparison modifiers on keys were removed as they were non-functional.

## See Also

* [DictionaryContainsValue Constraint](DictionaryContainsValueConstraint.md)
* [DictionaryContainsKeyValuePair Constraint](DictionaryContainsKeyValuePairConstraint.md)

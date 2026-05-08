---
uid: constraint-contains-helper
---

# Contains Helper

The `Contains` helper class provides a fluent syntax for containment assertions. It offers shortcuts for common
containment tests on strings, collections, and dictionaries.

## Overview

`Contains` is one of NUnit's syntax helper classes (alongside `Is`, `Has`, and `Does`). It provides entry points for
constraints that test whether something contains an expected element.

## Usage

```csharp
Contains.Item(object expected)      // Collection contains item
Contains.Key(object expectedKey)    // Dictionary contains key
Contains.Value(object expectedValue) // Dictionary contains value
Contains.Substring(string expected) // String contains substring
```

## String Containment

[!code-csharp[ContainsHelperStringExamples](~/snippets/Snippets.NUnit/Constraints/ContainsHelperSnippets.cs#ContainsHelperStringExamples)]

## Collection Containment

[!code-csharp[ContainsHelperCollectionExamples](~/snippets/Snippets.NUnit/Constraints/ContainsHelperSnippets.cs#ContainsHelperCollectionExamples)]

## Dictionary Containment

[!code-csharp[ContainsHelperDictionaryExamples](~/snippets/Snippets.NUnit/Constraints/ContainsHelperSnippets.cs#ContainsHelperDictionaryExamples)]

## Comparison with Other Helpers

| Syntax | Description | Use Case |
|--------|-------------|----------|
| `Contains.Item(x)` | Collection contains x | General collection membership |
| `Contains.Key(k)` | Dictionary has key k | Dictionary key lookup |
| `Contains.Value(v)` | Dictionary has value v | Dictionary value search |
| `Contains.Substring(s)` | String contains s | Substring matching |
| `Does.Contain(x)` | Smart containment | Auto-routes based on type |
| `Has.Member(x)` | Collection contains x | Same as Contains.Item |

## Smart Routing with Does.Contain

`Does.Contain()` automatically routes to the appropriate constraint:

[!code-csharp[ContainsHelperSmartRoutingExamples](~/snippets/Snippets.NUnit/Constraints/ContainsHelperSnippets.cs#ContainsHelperSmartRoutingExamples)]

## Modifiers

### For String Containment

```csharp
Contains.Substring("text").IgnoreCase
Contains.Substring("text").Using(StringComparison.OrdinalIgnoreCase)
```

### For Collection Containment

```csharp
Contains.Item(obj).Using(comparer)
Contains.Item(obj).UsingPropertiesComparer()
```

### For Dictionary Values

```csharp
Contains.Value(obj).Using(comparer)
Contains.Value(obj).IgnoreCase  // For string values
```

## See Also

* [Contains Constraint](ContainsConstraint.md) - How Does.Contain routes to different constraints
* [Substring Constraint](SubstringConstraint.md) - String containment details
* [SomeItems Constraint](SomeItemsConstraint.md) - Collection membership details
* [DictionaryContainsKey Constraint](DictionaryContainsKeyConstraint.md) - Dictionary key testing
* [DictionaryContainsValue Constraint](DictionaryContainsValueConstraint.md) - Dictionary value testing

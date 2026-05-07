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

```csharp
string text = "Hello World";

// Test for substring
Assert.That(text, Contains.Substring("World"));
Assert.That(text, Contains.Substring("WORLD").IgnoreCase);

// Equivalent to Does.Contain for strings
Assert.That(text, Does.Contain("World"));
```

## Collection Containment

```csharp
int[] numbers = { 1, 2, 3, 4, 5 };

// Test for item in collection
Assert.That(numbers, Contains.Item(3));
Assert.That(numbers, Contains.Item(3).And.Contains.Item(5));

// Equivalent forms
Assert.That(numbers, Does.Contain(3));
Assert.That(numbers, Has.Member(3));
```

## Dictionary Containment

```csharp
var dict = new Dictionary<string, int>
{
    ["Alice"] = 30,
    ["Bob"] = 25
};

// Test for key
Assert.That(dict, Contains.Key("Alice"));

// Test for value
Assert.That(dict, Contains.Value(30));

// Test for key-value pair
Assert.That(dict, Contains.Key("Alice").WithValue(30));
```

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

```csharp
// String -> SubstringConstraint
Assert.That("Hello World", Does.Contain("World"));

// Collection -> SomeItemsConstraint
Assert.That(new[] { 1, 2, 3 }, Does.Contain(2));

// Dictionary key check
Assert.That(dict, Does.ContainKey("Alice"));
Assert.That(dict, Does.ContainValue(30));
```

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

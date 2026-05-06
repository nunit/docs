---
uid: constraint-contains
---

# Contains Constraint

`ContainsConstraint` is a smart constraint that adapts its behavior based on the type being tested. When the actual
value is a string, it tests for a substring. When the actual value is a collection, it tests for item membership.

## Usage

```csharp
Does.Contain(object expected)
Does.Not.Contain(object expected)
```

## Modifiers

```csharp
.IgnoreCase                  // Case-insensitive matching
.IgnoreWhiteSpace            // Ignore whitespace differences (collections only)
.IgnoreLineEndingFormat      // Ignore line ending differences (collections only)
```

## Examples

### String Containment

When the actual value is a string, `Does.Contain` tests for a substring:

```csharp
Assert.That("Hello World", Does.Contain("World"));
Assert.That("Hello World", Does.Contain("world").IgnoreCase);
Assert.That("Hello World", Does.Not.Contain("Goodbye"));
```

### Collection Membership

When the actual value is a collection, `Does.Contain` tests for item membership:

```csharp
int[] numbers = { 1, 2, 3, 4, 5 };
Assert.That(numbers, Does.Contain(3));
Assert.That(numbers, Does.Not.Contain(99));

string[] names = { "Alice", "Bob", "Charlie" };
Assert.That(names, Does.Contain("Bob"));
Assert.That(names, Does.Contain("bob").IgnoreCase);
```

## How It Works

`ContainsConstraint` defers its behavior until the actual value's type is known:

| Actual Type | Behavior |
|-------------|----------|
| `string` | Uses [SubstringConstraint](SubstringConstraint.md) to test for substring |
| Collection/IEnumerable | Uses [SomeItemsConstraint](SomeItemsConstraint.md) to test for item presence |

## Notes

1. When testing strings, the expected value must also be a string. For type safety, consider using
   `Does.Contain(string)` explicitly.
2. The `.IgnoreWhiteSpace` and `.IgnoreLineEndingFormat` modifiers only work with collections, not strings. Using them
   with string containment will throw an `InvalidOperationException`.
3. For more explicit control, use the specific constraints directly:
   - [SubstringConstraint](SubstringConstraint.md) for string containment
   - [SomeItemsConstraint](SomeItemsConstraint.md) for collection membership

## See Also

* [Substring Constraint](SubstringConstraint.md)
* [SomeItems Constraint](SomeItemsConstraint.md)
* [DictionaryContainsKey Constraint](DictionaryContainsKeyConstraint.md)
* [DictionaryContainsValue Constraint](DictionaryContainsValueConstraint.md)

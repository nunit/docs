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
.IgnoreCase                  // Case-insensitive matching (strings and collections)
.IgnoreWhiteSpace            // Ignore whitespace in item equality (collections only)
.IgnoreLineEndingFormat      // Ignore line endings in item equality (collections only)
```

> [!NOTE]
> `.IgnoreWhiteSpace` and `.IgnoreLineEndingFormat` only work when testing collection membership, not substring
> containment. For strings, these modifiers throw an `InvalidOperationException`.

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
2. **Important**: `.IgnoreWhiteSpace` and `.IgnoreLineEndingFormat` only work with collections, not strings. When used
   with string containment, they throw `InvalidOperationException`. This is because `SubstringConstraint` doesn't
   support these modifiers, while `EqualConstraint` (used for collection item comparison) does.
3. For collections of strings, `.IgnoreWhiteSpace` affects item equality comparison:
   ```csharp
   // Works: checks if any item equals "hello world" ignoring whitespace
   Assert.That(new[] { "hello  world" }, Does.Contain("hello world").IgnoreWhiteSpace);
   ```
4. For more explicit control, use the specific constraints directly:
   - [SubstringConstraint](SubstringConstraint.md) for string containment
   - [SomeItemsConstraint](SomeItemsConstraint.md) for collection membership

## See Also

* [Substring Constraint](SubstringConstraint.md)
* [SomeItems Constraint](SomeItemsConstraint.md)
* [DictionaryContainsKey Constraint](DictionaryContainsKeyConstraint.md)
* [DictionaryContainsValue Constraint](DictionaryContainsValueConstraint.md)

---
uid: constraint-collectionequivalent
---

# CollectionEquivalent Constraint

`CollectionEquivalentConstraint` tests that two `IEnumerables` are equivalent - that they contain the same items, in any
order. Two collections are equivalent if they have the same number of elements and every element in one collection has a
matching element in the other.

## Usage

```csharp
Is.EquivalentTo(IEnumerable expected)
Is.Not.EquivalentTo(IEnumerable expected)
```

## Modifiers

```csharp
.IgnoreCase
.IgnoreWhiteSpace                     // From version 4.2
.Using(IEqualityComparer comparer)
.Using(IComparer comparer)
.Using<T>(IEqualityComparer<T> comparer)
.Using<T>(IComparer<T> comparer)
.Using<T>(Comparison<T> comparer)
.Using<T>(Func<T, T, bool> comparer)
.UsingPropertiesComparer()            // From version 4.1
```

## Examples

```csharp
// Basic equivalence - order doesn't matter
int[] expected = { 1, 2, 3 };
Assert.That(new[] { 3, 1, 2 }, Is.EquivalentTo(expected));

// Not equivalent - different counts matter
Assert.That(new[] { 1, 2, 2 }, Is.Not.EquivalentTo(expected));

// String comparison with case insensitivity
string[] names = { "Alice", "Bob", "Charlie" };
Assert.That(new[] { "alice", "BOB", "CHARLIE" }, Is.EquivalentTo(names).IgnoreCase);

// With custom comparer for complex objects
Assert.That(actualPeople, Is.EquivalentTo(expectedPeople).UsingPropertiesComparer());
```

## Notes

1. To compare items in a specific order, use `Is.EqualTo()` instead.
2. Duplicate items matter: `{1, 2, 2}` is not equivalent to `{1, 2, 3}` even though they have the same length.
3. The constraint checks that each item in one collection has exactly one matching item in the other, accounting for
   duplicates correctly.
4. There is no `Within` modifier. Equivalence matches items by grouping equal values, which requires equality to be
   transitive, and a tolerance is not. A tolerant comparer passed to `Using` is accepted but can give results that
   depend on the order of the items. To compare approximate values regardless of order, sort both collections and use
   `Is.EqualTo(...).Within(...)`, or check each expected value with `Has.Exactly(1).EqualTo(...).Within(...)`. See
   [Tolerances](Tolerance.md#unordered-collections).

## See Also

* [Equal Constraint](EqualConstraint.md) - For ordered comparison
* [Tolerances](Tolerance.md) - Approximate comparisons of unordered collections
* [CollectionSubset Constraint](CollectionSubsetConstraint.md)
* [CollectionSuperset Constraint](CollectionSupersetConstraint.md)
* [AllItems Constraint](AllItemsConstraint.md)

---
uid: classic-collection-assert
---

# CollectionAssert

The CollectionAssert class provides a number of methods that are useful when examining collections and their contents or
for comparing two collections. These methods may be used with any object implementing `IEnumerable`.

The **AreEqual** overloads succeed if the corresponding elements of the two collections are equal. **AreEquivalent**
tests whether the collection contents are equal, but without regard to order. In both cases, elements are compared using
NUnit's default equality comparison.

`CollectionAssert` is in the `NUnit.Framework` namespace, so `using NUnit.Framework;` is enough. It ships in
`nunit.framework.legacy.dll`, which is part of the NUnit package.

> [!NOTE]
> In NUnit 4, `CollectionAssert` was in the `NUnit.Framework.Legacy` namespace and needed `using NUnit.Framework.Legacy;`.

```csharp
CollectionAssert.AllItemsAreInstancesOfType(IEnumerable collection, Type expectedType);
CollectionAssert.AllItemsAreInstancesOfType(
    IEnumerable collection, Type expectedType, string message, params object[] args);

CollectionAssert.AllItemsAreNotNull(IEnumerable collection);
CollectionAssert.AllItemsAreNotNull(
    IEnumerable collection, string message, params object[] args);

CollectionAssert.AllItemsAreUnique(IEnumerable collection);
CollectionAssert.AllItemsAreUnique(
    IEnumerable collection, string message, params object[] args);

CollectionAssert.AreEqual(IEnumerable expected, IEnumerable actual);
CollectionAssert.AreEqual(
    IEnumerable expected, IEnumerable actual, string message, params object[] args);

CollectionAssert.AreEquivalent(IEnumerable expected, IEnumerable actual);
CollectionAssert.AreEquivalent(
    IEnumerable expected, IEnumerable actual, string message, params object[] args);

CollectionAssert.AreNotEqual(IEnumerable expected, IEnumerable actual);
CollectionAssert.AreNotEqual(
    IEnumerable expected, IEnumerable actual, string message, params object[] args);

CollectionAssert.AreNotEquivalent(IEnumerable expected, IEnumerable actual);
CollectionAssert.AreNotEquivalent(
    IEnumerable expected, IEnumerable actual, string message, params object[] args);

CollectionAssert.Contains(IEnumerable collection, object actual);
CollectionAssert.Contains(
    IEnumerable collection, object actual, string message, params object[] args);

CollectionAssert.DoesNotContain(IEnumerable collection, object actual);
CollectionAssert.DoesNotContain(
    IEnumerable collection, object actual, string message, params object[] args);

CollectionAssert.IsSubsetOf(IEnumerable subset, IEnumerable superset);
CollectionAssert.IsSubsetOf(
    IEnumerable subset, IEnumerable superset, string message, params object[] args);

CollectionAssert.IsNotSubsetOf(IEnumerable subset, IEnumerable superset);
CollectionAssert.IsNotSubsetOf(
    IEnumerable subset, IEnumerable superset, string message, params object[] args);

CollectionAssert.IsEmpty(IEnumerable collection);
CollectionAssert.IsEmpty(
    IEnumerable collection, string message, params object[] args);

CollectionAssert.IsNotEmpty(IEnumerable collection);
CollectionAssert.IsNotEmpty(
    IEnumerable collection, string message, params object[] args);

CollectionAssert.IsOrdered(IEnumerable collection);
CollectionAssert.IsOrdered(
    IEnumerable collection, string message, params object[] args);

CollectionAssert.IsOrdered(IEnumerable collection, IComparer comparer);
CollectionAssert.IsOrdered(IEnumerable collection,
    IComparer comparer, string message, params object[] args);
```

## Contains and DoesNotContain

The parameters of `Contains` and `DoesNotContain` do not follow the usual *expected, actual* pattern of the other
classic assertions. The first argument is the collection to search, and the second, named `actual`, is the single item
being looked for. Despite its name, that item is what the assertion *expects* to find, so the failure message reports it
on the **Expected** line and the collection on the **But was** line:

```csharp
CollectionAssert.Contains(new[] { 1, 2 }, 3);

// Expected: some item equal to 3
//   But was:  < 1, 2 >
```

Passing a collection as the second argument does not check that one collection contains another. It checks whether the
collection contains that collection as a single element. The parameter names are kept for compatibility, since renaming
them would break callers that use named arguments. The constraint-based equivalents read more naturally:

```csharp
Assert.That(new[] { 1, 2 }, Does.Contain(3));
Assert.That(new[] { 1, 2 }, Has.Member(3));
```

## See Also

* [Collection Constraints](xref:constraints#collection-constraints)

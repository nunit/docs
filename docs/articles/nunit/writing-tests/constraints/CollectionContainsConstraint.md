---
uid: collectioncontainsconstraint
---

# CollectionContains Constraint

`CollectionContainsConstraint` tests that an `IEnumerable` contains an object. If the actual value passed does not
implement `IEnumerable`, an exception is thrown.

## Constructor

```csharp
CollectionContainsConstraint(object)
```

## Syntax

```csharp
Has.Member(object)
Contains.Item(object)
Does.Contain(object)
```

## Modifiers

```csharp
...Using(IComparer comparer)
...Using<T>(IComparer<T> comparer)
...Using<T>(Comparison<T> comparer)
```

## Examples of Use

[!code-csharp[CollectionContainsExamples](~/snippets/Snippets.NUnit/ConstraintExamples.cs#CollectionContainsExamples)]

## Note

`Has.Member()`, `Contains.Item()` and `Does.Contain()` work the same as `Has.Some.EqualTo()`. The last statement
generates a [SomeItemsConstraint](SomeItemsConstraint.md) based on an [EqualConstraint](EqualConstraint.md) and offers
additional options such as ignoring case or specifying a tolerance. The syntax on this page may be viewed as a shortcut
for specifying simpler cases.

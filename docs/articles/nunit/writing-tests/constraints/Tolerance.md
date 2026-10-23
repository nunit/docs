---
uid: tolerance
---

# Tolerances

A tolerance lets an assertion pass when the actual value is *close enough* to the expected value rather than exactly
equal to it. Tolerances are essential for floating point arithmetic, for values that pass through storage with lower
precision (a database that keeps microseconds, a JSON serializer that rounds), and for timestamps that are taken a
moment apart.

NUnit expresses a tolerance with the `Within` modifier, optionally followed by a modifier that says how the amount
should be interpreted:

```csharp
Assert.That(actual, Is.EqualTo(expected).Within(0.01));          // plus or minus 0.01
Assert.That(actual, Is.EqualTo(expected).Within(1).Percent);     // plus or minus 1 percent of expected
Assert.That(actual, Is.EqualTo(expected).Within(2).Ulps);        // within 2 representable floating point values
Assert.That(actual, Is.EqualTo(expected).Within(5).Seconds);     // plus or minus 5 seconds
```

This page describes how tolerances work across NUnit, which types support them, what happens when a tolerance cannot be
applied, and how to get tolerant comparisons for types NUnit does not know about.

## Where tolerances can be used

| Constraint or API                                                                                   | Syntax                                                | Notes                                                                                           |
| --------------------------------------------------------------------------------------------------- | ----------------------------------------------------- | ----------------------------------------------------------------------------------------------- |
| [EqualConstraint](EqualConstraint.md)                                                               | `Is.EqualTo(x).Within(t)`                             | Supports all tolerance modes. Applies to elements of arrays, collections, dictionaries, tuples. |
| [GreaterThan](GreaterThanConstraint.md), [LessThan](LessThanConstraint.md) and the `OrEqual` forms | `Is.GreaterThan(x).Within(t)`                         | Linear and `Percent` tolerances. See [Comparison constraints](#comparison-constraints).         |
| Properties comparer                                                                                 | `Is.EqualTo(x).Within(t).UsingPropertiesComparer()`   | Applies the tolerance to every property that can take one.                                      |
| Properties comparer configuration                                                                   | `.UsingPropertiesComparer(o => o.Within(t))`          | From NUnit 4.4. Separate tolerances for numeric and time properties.                            |
| Item constraints such as `Has.Some`, `Has.Exactly(n)` and `Is.All`                                  | `Has.Some.EqualTo(x).Within(t)`                       | The tolerance belongs to the per-item `EqualTo`.                                                |
| [Assert.AreEqual](xref:classic-assert-are-equal) (classic)                                          | `Assert.AreEqual(expected, actual, delta)`            | Linear tolerance for `double` only.                                                             |

The following do **not** accept a tolerance:

* [CollectionEquivalentConstraint](CollectionEquivalentConstraint.md) (`Is.EquivalentTo`), as well as `Is.SubsetOf`,
  `Is.SupersetOf` and `Is.Unique`. See [Unordered collections](#unordered-collections) for alternatives.
* [RangeConstraint](RangeConstraint.md) (`Is.InRange`). Widen the bounds instead.
* String constraints. `Is.EqualTo("text").Within(1)` does not compile from NUnit 4.3.

## Tolerance modes

### Linear

A plain `Within(amount)` is a linear (absolute) tolerance. The assertion passes when the difference between the actual
and expected values, in either direction, is no greater than the amount. The tolerance and the values may be of
different numeric types.

[!code-csharp[ToleranceLinear](~/snippets/Snippets.NUnit/Constraints/ToleranceSnippets.cs#ToleranceLinear)]

### Percent

`Within(amount).Percent` interprets the amount as a percentage of the **expected** value. Because the allowed deviation
is relative to the expected value, an expected value of zero only matches an actual value of zero.

[!code-csharp[TolerancePercent](~/snippets/Snippets.NUnit/Constraints/ToleranceSnippets.cs#TolerancePercent)]

### Ulps

`Within(amount).Ulps` interprets the amount as a number of *units in the last place*: the number of representable
`float` or `double` values between the expected and actual values. One ULP is the smallest step a value of that
magnitude can take, so an ULP tolerance automatically scales with the size of the numbers being compared. For numerical
work this is often safer than a fixed tolerance, which is either too loose for small values or too strict for large
ones.

[!code-csharp[ToleranceUlps](~/snippets/Snippets.NUnit/Constraints/ToleranceSnippets.cs#ToleranceUlps)]

ULP tolerances apply to `float` and `double` values only.

### Time units

For `DateTime`, `DateTimeOffset` and `TimeSpan` values the tolerance is a `TimeSpan`. You can pass one directly, or pass
a number followed by one of the unit modifiers `Days`, `Hours`, `Minutes`, `Seconds`, `Milliseconds` or `Ticks`.

[!code-csharp[ToleranceTime](~/snippets/Snippets.NUnit/Constraints/ToleranceSnippets.cs#ToleranceTime)]

> [!NOTE]
> From NUnit 4.3, `Is.EqualTo` has dedicated overloads for `DateTime`, `DateTimeOffset` and `TimeSpan`. On those, a
> numeric tolerance *must* be followed by a unit: `Is.EqualTo(someDateTime).Within(5)` is not a usable constraint and
> the assertion does not compile. Conversely, the unit modifiers are not available on numeric values, so
> `Is.EqualTo(5).Within(1).Seconds` does not compile either. If the expected value is typed as `object`, these mistakes
> are caught at run time instead, as described [below](#when-a-tolerance-cannot-be-applied).

## Supported types

NUnit can apply a numeric tolerance to the built-in numeric types: `byte`, `sbyte`, `short`, `ushort`, `int`, `uint`,
`long`, `ulong`, `decimal`, `float` and `double`. Values of different numeric types may be compared with each other and
the tolerance may be of yet another numeric type. `char` values are compared exactly, even though they convert to
numbers.

A `TimeSpan` tolerance can be applied to `DateTime`, `DateTimeOffset` and `TimeSpan` values.

### Arrays, collections, dictionaries and tuples

`EqualConstraint` compares arrays, collections, dictionaries and tuples recursively, and the tolerance travels with it.
Each pair of corresponding elements is compared using the tolerance. Dictionary keys are always compared exactly.

An array, collection or dictionary has a single element type, so the tolerance must apply to all of its elements or to
none of them: a numeric tolerance on a `DateTime[]` is an error, just as it is on a single `DateTime`. Tuples are
different, because each member has its own type. A tuple member that cannot take the tolerance, such as a string, is
compared exactly while the numeric members use the tolerance.

[!code-csharp[ToleranceCollections](~/snippets/Snippets.NUnit/Constraints/ToleranceSnippets.cs#ToleranceCollections)]

### Objects compared property by property

When you use `UsingPropertiesComparer`, a tolerance on the constraint is applied to every property that can accept it
and ignored for properties that cannot. From NUnit 4.4 you can also set tolerances in the comparer's configuration,
which allows one tolerance for numeric properties and another, a `TimeSpan`, for time properties.

[!code-csharp[TolerancePropertiesComparer](~/snippets/Snippets.NUnit/Constraints/ToleranceSnippets.cs#TolerancePropertiesComparer)]

See [Properties Comparer](EqualConstraint.md#properties-comparer) for the rest of the configuration options.

## Default tolerance for floating point values

When a `float` or `double` comparison specifies no tolerance, NUnit uses the default floating point tolerance in effect
for the test, which is exact equality unless you change it. Apply
[DefaultFloatingPointToleranceAttribute](xref:attribute-defaultfloatingpointtolerance) to a test, a fixture or the
assembly to set a different default. An explicit `Within` always wins over the default.

## When a tolerance cannot be applied

Equality for many types is defined by the type itself, through `IEquatable<T>` or an `Equals` override, and NUnit has no
way to make such a comparison approximate. This covers strings, chars, enums, `Stream`, `DirectoryInfo`, your own
classes and structs (including records), and third-party value types such as NodaTime's `Instant` or `Duration`. The
same is true when you supply your own comparer with `Using`: the comparer decides what is equal and NUnit cannot inject
a tolerance into it.

Before NUnit 4.0 a tolerance in these situations was silently ignored, so a test such as

```csharp
Assert.That(secondInstant, Is.EqualTo(firstInstant).Within(Duration.FromSeconds(2)));
```

compared the two values exactly and failed for a reason that was hard to spot. From NUnit 4.0 the assertion errors
instead with a `NotSupportedException` whose message starts with
`Specified Tolerance of type ... not supported for instances of type ...`.

[!code-csharp[ToleranceNotSupported](~/snippets/Snippets.NUnit/Constraints/ToleranceSnippets.cs#ToleranceNotSupported)]

An error rather than a failure tells you that the assertion itself is wrong, not the code under test. The
[NUnit analyzers](xref:nunitanalyzers) report the same situation at compile time as warning
[NUnit2047](https://github.com/nunit/nunit.analyzers/blob/master/documentation/NUnit2047.md) when the types are known
to the compiler.

## Tolerances for your own types

When NUnit cannot apply a tolerance to a type, you have several options:

1. **Put the tolerance in a comparer** and pass it with `Using`. Do not also use `Within`; the comparer is responsible
   for the whole comparison, and combining the two is an error. A reusable `IEqualityComparer<T>` works for single
   values and for collections of the type alike.
2. **Compare the underlying value** that carries the precision, for example a `double` property or the result of a
   subtraction, with a normal `Within`.
3. **Use the properties comparer** so that NUnit compares the object's numeric and time properties one by one, applying
   the tolerance to each.
4. **Write a [custom constraint](xref:customconstraints)** when the comparison is complex enough to deserve its own
   name and failure message.

[!code-csharp[ToleranceCustomType](~/snippets/Snippets.NUnit/Constraints/ToleranceSnippets.cs#ToleranceCustomType)]

> [!NOTE]
> A tolerant comparer is not transitive: `a` may be within tolerance of `b`, and `b` of `c`, while `a` and `c` are not.
> That is harmless for `Is.EqualTo`, which only ever compares corresponding pairs of values, but it matters for the
> unordered collection constraints discussed next.

## Unordered collections

`Is.EquivalentTo`, `Is.SubsetOf`, `Is.SupersetOf` and `Is.Unique` have no `Within` modifier. They match items by
grouping equal values, which only gives a well-defined answer when equality is transitive. You can pass a tolerant
comparer with `Using`, and NUnit will not stop you, but the result then depends on which items happen to be paired first
and may differ from what you expect.

When order does not matter but the values are approximate, either sort both collections and compare them in order with
`Is.EqualTo(...).Within(...)`, or assert each expected value individually with an item constraint:

[!code-csharp[ToleranceUnorderedCollections](~/snippets/Snippets.NUnit/Constraints/ToleranceSnippets.cs#ToleranceUnorderedCollections)]

## Comparison constraints

`Is.GreaterThan`, `Is.GreaterThanOrEqualTo`, `Is.LessThan` and `Is.LessThanOrEqualTo` accept a linear or `Percent`
tolerance. The tolerance relaxes the bound in the actual value's favour: `Is.GreaterThan(10).Within(1)` passes for any
value greater than 9, and `Is.LessThan(10).Within(1)` for any value less than 11. From NUnit 4.1 the bound may be a
`DateTime` or `TimeSpan` with a `TimeSpan` tolerance.

[!code-csharp[ToleranceComparison](~/snippets/Snippets.NUnit/Constraints/ToleranceSnippets.cs#ToleranceComparison)]

## Rules

* A tolerance amount must not be negative. From NUnit 4.3 a negative amount throws an `ArgumentException`.
* `Within` may appear only once in a constraint expression.
* A mode (`Percent`, `Ulps` or a time unit) must follow a `Within` amount, and only one mode may be used.
* `Percent`, `Ulps` and the time units require a numeric amount.
* A tolerance of zero is an exact comparison. In particular, `Within(0)` on a floating point comparison overrides a
  non-zero default floating point tolerance.

[!code-csharp[ToleranceRules](~/snippets/Snippets.NUnit/Constraints/ToleranceSnippets.cs#ToleranceRules)]

## See also

* [EqualConstraint](EqualConstraint.md)
* [DefaultFloatingPointTolerance attribute](xref:attribute-defaultfloatingpointtolerance)
* [CollectionEquivalentConstraint](CollectionEquivalentConstraint.md)
* [GreaterThanConstraint](GreaterThanConstraint.md), [LessThanConstraint](LessThanConstraint.md)
* [Custom Constraints](xref:customconstraints)

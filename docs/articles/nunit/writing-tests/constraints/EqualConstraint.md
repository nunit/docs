---
uid: equalconstraint
---

# Equal Constraint

An EqualConstraint is used to test whether an actual value is equal to the expected value supplied in its constructor,
optionally within a specified tolerance.

## Constructor

```csharp
EqualConstraint(object expected)
```

## Syntax

```csharp
Is.EqualTo(object expected)
Is.Zero // Equivalent to Is.EqualTo(0)
```

## Modifiers

```csharp
...IgnoreCase
...IgnoreWhiteSpace  // From version 4.2
...AsCollection
...NoClip
...WithSameOffset
...Within(object tolerance)
      .Ulps
      .Percent
      .Days
      .Hours
      .Minutes
      .Seconds
      .Milliseconds
      .Ticks
...IgnoreCase
...IgnoreWhiteSpace
...Using(IEqualityComparer comparer)
...Using(IComparer comparer)
...Using<T>(IEqualityComparer<T> comparer)
...Using<T>(IComparer<T> comparer)
...Using<T>(Comparison<T> comparer)
...Using<T>(Func<T, T, bool> comparer)
...Using<TActual, TExpected>(Func<TActual, TExpected, bool> comparer)
...UsingPropertiesComparer()  // From version 4.1
```

## Comparing Numerics

Numerics are compared based on their values. Different types may be compared successfully if their values are equal.

Using the **Within** modifier, numerics may be tested for equality within a fixed or percent tolerance.

```csharp
Assert.That(2 + 2, Is.EqualTo(4.0));
Assert.That(2 + 2 == 4);
Assert.That(2 + 2, Is.Not.EqualTo(5));
Assert.That(2 + 2 != 5);
Assert.That(5.0, Is.EqualTo(5));
Assert.That(5.5, Is.EqualTo(5).Within(0.075));
Assert.That(5.5, Is.EqualTo(5).Within(1.5).Percent);
```

## Comparing Floating Point Values

Values of type float and double are normally compared using a tolerance specified by the **Within** modifier. The
special values PositiveInfinity, NegativeInfinity and NaN compare as equal to themselves.

Floating-point values may be compared using a tolerance in "Units in the Last Place" or ULPs. For certain types of
numerical work, this is safer than a fixed tolerance because it automatically compensates for the added inaccuracy of
larger numbers.

```csharp
Assert.That(2.1 + 1.2, Is.EqualTo(3.3).Within(.0005));
Assert.That(double.PositiveInfinity, Is.EqualTo(double.PositiveInfinity));
Assert.That(double.NegativeInfinity, Is.EqualTo(double.NegativeInfinity));
Assert.That(double.NaN, Is.EqualTo(double.NaN));
Assert.That(20000000000000004.0, Is.EqualTo(20000000000000000.0).Within(1).Ulps);
```

## Comparing Strings

String comparisons normally respect case. The `IgnoreCase` modifier causes the comparison to be case-insensitive. It may
also be used when comparing arrays or collections of strings.

```csharp
Assert.That("Hello!", Is.Not.EqualTo("HELLO!"));
Assert.That("Hello!", Is.EqualTo("HELLO!").IgnoreCase);

string[] expected = new string[] { "Hello", "World" };
string[] actual = new string[] { "HELLO", "world" };
```

Sometimes we need to compare strings irrespective of white space characters, e.g.: when comparing Json strings.
This can be done with the `IgnoreWhiteSpace` modifier.
It allows using pretty formatted Json in NUnit tests regardless
whether the code under test uses different formatting or no white space at all.

```csharp
const string prettyJson = """
    "persons":[
      {
        "name": "John",
        "surname": "Smith"
      },
      {
        "name": "Jane",
        "surname": "Doe"
      }
    ]
    """;
    
const string condensedJson = """
    "persons":[{"name":"John","surname":"Smith",},{"name": "Jane","surname": "Doe"}]
    """;

Assert.That(condensedJson, Is.EqualTo(prettyJson).IgnoreWhiteSpace);
```

The above tests fails and the messages has been updated to include two carrets
to indicate the mismatched location in both _expected_ and _actual_ values:

```text
 Assert.That(condensedJson, Is.EqualTo(prettyJson).IgnoreWhiteSpace)
 Expected string length 122 but was 79. Strings differ at index 65.
 Expected: "...,\r\n    "surname": "Smith"\r\n  },\r\n  {\r\n    "name": "Jane",\r...", ignoring white-space
 -----------------------------------------------^
 But was:  ""persons":[{"name":"John","surname":"Smith",},{"name": "Jane"..."
 ------------------------------------------------------^
 ```

The `IgnoreWhiteSpace` can also be specified when comparing collections of strings.

## Comparing DateTimes and TimeSpans

**DateTimes** and **TimeSpans** may be compared either with or without a tolerance. A tolerance is specified using
**Within** with either a **TimeSpan** as an argument or with a numeric value followed by a one of the time conversion
modifiers: **Days**, **Hours**, **Minutes**, **Seconds**, **Milliseconds** or **Ticks**.

When comparing **DateTimeOffsets** you can use the optional **WithSameOffset** modifier to check the offset along with
the date and time.

```csharp
DateTime now = DateTime.Now;
DateTime later = now + TimeSpan.FromHours(1.0);

Assert.That(now, Is.EqualTo(now));
Assert.That(later, Is.EqualTo(now).Within(TimeSpan.FromHours(3.0));
Assert.That(later, Is.EqualTo(now).Within(3).Hours);
```

## Comparing Arrays, Collections and IEnumerables

Since version 2.2, NUnit has been able to compare two single-dimensioned arrays. Beginning with version 2.4,
multi-dimensioned arrays, nested arrays (arrays of arrays) and collections may be compared. With version 2.5, any
IEnumerable is supported. Two arrays, collections or IEnumerables are considered equal if they have the same dimensions
and if each of the corresponding elements is equal.

If you want to treat two arrays of different shapes as simple collections for purposes of comparison, use the
**AsCollection** modifier, which causes the comparison to be made element by element, without regard for the rank or
dimensions of the array. Note that jagged arrays (arrays of arrays) do not have a single underlying collection. The
modifier would be applied to each array separately, which has no effect in most cases.

The `AsCollection` modifier is also useful on classes implementing both `IEnumerable` and `IEquatable`. Without the
modifier, the `IEquatable` implementation is used to test equality. With the modifier specified, `IEquatable` is ignored
and the contents of the enumeration are compared one by one.

```csharp
int[] i3 = new int[] { 1, 2, 3 };
double[] d3 = new double[] { 1.0, 2.0, 3.0 };
int[] iunequal = new int[] { 1, 3, 2 };
Assert.That(i3, Is.EqualTo(d3));
Assert.That(i3, Is.Not.EqualTo(iunequal));

int[,] array2x2 = new int[,] { { 1, 2 }, { 3, 4 } };
int[] array4 = new int[] { 1, 2, 3, 4 };
Assert.That(array2x2, Is.Not.EqualTo(array4));
Assert.That(array2x2, Is.EqualTo(array4).AsCollection);
```

## Comparing Dictionaries

Two dictionaries are considered equal if

 1. The list of keys is the same - without regard to ordering.
 2. The values associated with each key are equal.

You can use this capability to compare any two objects implementing **IDictionary**. Generic and non-generic
dictionaries (Hashtables) may be successfully compared.

## Comparing DirectoryInfo

Two DirectoryInfo objects are considered equal if both have the same path, creation time and last access time.

```csharp
Assert.That(new DirectoryInfo(actual), Is.EqualTo(expected));
```

## Comparing Classes/Structures

If a class/structure implements `IEquatable<T>` then it is up to the class to define equality.
If not, then the standard .NET `Equals` is called which means for classes,
it is reference equality and for structures it is value equality.

```csharp
private sealed class Person
{
    public Person(string name) => Name = name;

    public string Name { get; }
}

[Test]
public void ComparePersons()
{
    var person1 = new Person("Charlie");
    var person2 = new Person("Charlie");

    Assert.That(person2, Is.EqualTo(person1));
}
```

The above test fails because even though _person1_ and _person2_ have the same property values,
they are different instances.
If we want to have value equality there are three options:

1. Implement `IEquality<Person>` on the `Person` class\
   This is not always wanted, we may require reference comparison
   in most code, but need value equality for NUnit tests.
1. Specify a specific comparer. See [User-Specified Comparers](#user-specified-comparers) below.\
   This does require writing separate comparers each time one wants
   to compare a class for value equality.
1. Add the `.UsingPropertiesComparer()` suffix.\
   This is a special built-in comparer which iterates over all _public_ properties of a class and
   compares them one by one. It is useful to get value equality for nunit test, e.g. when
   serializing/deserializing instances, but when value equality is not wanted in normal code.
   Even if two persons are called _Charlie_ that doesn't mean they are one and the same person.

## User-Specified Comparers

If the default NUnit or .NET behavior for testing equality doesn't meet your needs, you can supply a comparer of your
own through the `Using` modifier. When used with `EqualConstraint`, you may supply an `IEqualityComparer`,
`IEqualityComparer<T>`, `IComparer`, `IComparer<T>` or `Comparison<T>` as the argument to `Using`.

```csharp
Assert.That(myObj1, Is.EqualTo(myObj2).Using(myComparer));
```

Prior to NUnit 2.6, only one comparer could be used. If multiple comparers were specified, all but one was ignored.
Beginning with NUnit 2.6, multiple generic comparers for different types may be specified. NUnit will use the
appropriate comparer for any two types being compared. As a result, it is now possible to provide a comparer for an
array, a collection type or a dictionary. The user-provided comparer will be used directly, bypassing the default NUnit
logic for array, collection or dictionary equality.

```csharp
class ListOfIntComparer : IEqualityComparer<List<int>>
{
    /* ... */
}

var list1 = new List<int>();
var list2 = new List<int>();
var myComparer = new ListOfIntComparer();
/* ... */
Assert.That(list1, Is.EqualTo(list2).Using(myComparer));
```

## Properties Comparer

The properties comparer is enabled when suffixing the constraint with `.UsingPropertiesComparer()`.
It is only called for instances of the same type which do not implement `IEquatable<T>`

This comparer iterates over all public properties of a class.
For each property, it gets the value for both instances and compares them for equality.
This can be recursive, e.g. if one has a class `Group` holding a collection of `Persons`.

The comparer will use the specified tolerance as specified using `.WithIn(amount)` if possible.
This can be useful when comparing floating point numbers of calculation results.

The comparer can deal with recursive data structures,
it will stop comparing if it already previously has compared two the same instances.

## Notes

1. When checking the equality of user-defined classes, NUnit first examines each class to determine whether it
   implements `IEquatable<T>` (unless the `AsCollection` modifier is used). If either object implements the interface
   for the type of the other object, then that implementation is used in making the comparison. If neither class
   implements the appropriate interface, NUnit makes use of the `Equals` override on the expected object. If you neglect
   to either implement `IEquatable<T>` or to override `Equals`, you can expect failures comparing non-identical objects.
   In particular, overriding `operator ==` without overriding `Equals` or implementing the interface has no effect.
2. The **Within** modifier was originally designed for use with floating point values only. Beginning with NUnit 2.4,
   comparisons of **DateTime** values may use a **TimeSpan** as a tolerance. Beginning with NUnit 2.4.2, non-float
   numeric comparisons may also specify a tolerance.
3. Float and double comparisons for which no tolerance is specified use a default value, which can be specified with
   **DefaultFloatingPointToleranceAttribute**. If this is not in place, a tolerance of 0.0d is used. (Prior to NUnit
   3.7, default tolerance was instead set via `GlobalSettings.DefaultFloatingPointTolerance`.)
4. Prior to NUnit 2.2.3, comparison of two NaN values would always fail, as specified by IEEE floating point standards.
   The new behavior, was introduced after some discussion because it seems more useful in tests. To avoid confusion,
   consider using **Is.NaN** where appropriate.
5. When an equality test between two strings fails, the relevant portion of both strings is displayed in the error
   message, clipping the strings to fit the length of the line as needed. Beginning with 2.4.4, this behavior may be
   modified by use of the **NoClip** modifier on the constraint. In addition, the maximum line length may be modified
   for all tests by setting the value of **TextMessageWriter.MaximumLineLength** in the appropriate level of setup.
6. When used with arrays, collections or dictionaries, EqualConstraint operates recursively. Any modifiers are saved and
   used as they apply to individual items.
7. A user-specified comparer will not be called by **EqualConstraint** if either or both arguments are null. If both are
   null, the Constraint succeeds. If only one is null, it fails.
8. NUnit has special semantics for comparing **Streams** and **DirectoryInfos**. For a **Stream**, the contents are
   compared. For a **DirectoryInfo**, the first-level directory contents are compared.

## See also

* [Assert.AreEqual](../assertions/classic-assertions/Assert.AreEqual.md)
* [DefaultFloatingPointTolerance Attribute](../attributes/defaultfloatingpointtolerance.md)

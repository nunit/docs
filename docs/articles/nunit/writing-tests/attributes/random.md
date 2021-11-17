---
uid: randomattribute
---

# Random

The **RandomAttribute** is used to specify a set of random values to be provided
for an individual numeric parameter, or `Guid` of a parameterized test method. Since
NUnit combines the data provided for each parameter into a set of
test cases, data must be provided for all parameters if it is
provided for any of them.

By default, NUnit creates test cases from all possible combinations
of the datapoints provided on parameters - the combinatorial approach.
This default may be modified by use of specific attributes on the
test method itself.

RandomAttribute supports the following constructors:

```csharp
public Random(int count);
public Random(int min, int max, int count);
public Random(uint min, uint max, int count);
public Random(long min, long max, int count);
public Random(ulong min, ulong max, int count);
public Random(short min, short max, int count);
public Random(ushort min, ushort max, int count);
public Random(byte min, byte max, int count);
public Random(sbyte min, sbyte max, int count);
public Random(double min, double max, int count);
public Random(float min, float max, int count);
```

In the first form, without minimum and maximum values, the attribute automatically generates values of the appropriate numeric Type or `Guid` for the argument provided, using the `Randomizer` object associated with the current context. See [Randomizer Methods](xref:randomizermethods) for details.

In general, the forms that specify a minimum and maximum should be used on arguments of the same type. However, the following exceptions are supported:

* You may use an int range on arguments of type short, ushort, byte, sbyte and decimal.

* You may use a double range on arguments of type decimal.

Note that there is no constructor taking decimal values for min and max. This is because .NET does not support use of decimal in an attribute constructor.

> [!NOTE]
> `Guid` support for `RandomAttribute` is possible only from NUnit version 4.0.

## Example

The following test will be executed fifteen times, three times
for each value of x, each combined with 5 random doubles from -1.0 to +1.0.

```csharp
[Test]
public void MyTest(
    [Values(1, 2, 3)] int x,
    [Random(-1.0, 1.0, 5)] double d)
{
    ...
}
```

## See Also

* [Values Attribute](values.md)
* [Range Attribute](range.md)
* [Sequential Attribute](sequential.md)
* [Combinatorial Attribute](combinatorial.md)
* [Pairwise Attribute](pairwise.md)

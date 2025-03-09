# ClassicAssert.AreEqual

**ClassicAssert.AreEqual** tests whether the two arguments are equal.

```csharp
ClassicAssert.AreEqual(double expected, double actual, double tolerance);
ClassicAssert.AreEqual(double expected, double actual, double tolerance,
                string message, params object[] params);

ClassicAssert.AreEqual(object expected, object actual);
ClassicAssert.AreEqual(object expected, object actual,
                string message, params object[] params);
```

## Comparing Numerics of Different Types

The method overloads that compare two objects make special provision so that numeric
values of different types compare as expected. This assert succeeds:

```csharp
ClassicAssert.AreEqual(5, 5.0);
```

## Comparing Floating Point Values

Values of type float and double are compared using an additional
argument that indicates a tolerance within which they will be considered
as equal.

Special values are handled so that the following Asserts succeed:

```csharp
ClassicAssert.AreEqual(double.PositiveInfinity, double.PositiveInfinity);
ClassicAssert.AreEqual(double.NegativeInfinity, double.NegativeInfinity);
ClassicAssert.AreEqual(double.NaN, double.NaN);
```

## Comparing Arrays and Collections

NUnit is able to compare single-dimensioned arrays, multi-dimensioned arrays,
nested arrays (arrays of arrays) and collections. Two arrays or collections are considered equal
if they have the same dimensions and if each pair of corresponding elements is equal.

NUnit 3.0 adds the ability to compare generic collections and dictionaries.

## See Also

* [Equal Constraint](xref:equalconstraint)
* [DefaultFloatingPointTolerance Attribute](../../attributes/defaultfloatingpointtolerance.md)

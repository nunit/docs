using NUnit.Framework;

#pragma warning disable NUnit2045 // Use Assert.Multiple
#pragma warning disable NUnit2047 // Incompatible types for Within constraint: several examples show this on purpose

namespace Snippets.NUnit.Constraints;

public class ToleranceSnippets
{
    #region ToleranceLinear
    [Test]
    public void Tolerance_Linear()
    {
        // The actual value may differ from the expected value by at most the tolerance, in either direction
        Assert.That(4.99, Is.EqualTo(5.0).Within(0.01));
        Assert.That(5.01, Is.EqualTo(5.0).Within(0.01));
        Assert.That(5.02, Is.Not.EqualTo(5.0).Within(0.01));

        // Integers accept an integer tolerance
        Assert.That(98, Is.EqualTo(100).Within(2));

        // Numeric types may be mixed freely
        Assert.That(5.5, Is.EqualTo(5).Within(0.5));
        Assert.That(10m, Is.EqualTo(10.4).Within(0.5));
    }
    #endregion

    #region TolerancePercent
    [Test]
    public void Tolerance_Percent()
    {
        // 5 percent of the expected value 100 means anything from 95 to 105 passes
        Assert.That(97.0, Is.EqualTo(100.0).Within(5).Percent);
        Assert.That(104, Is.EqualTo(100).Within(5).Percent);
        Assert.That(106, Is.Not.EqualTo(100).Within(5).Percent);

        // The percentage is relative to the expected value, so an expected value of zero only matches zero
        Assert.That(0.0, Is.EqualTo(0.0).Within(5).Percent);
        Assert.That(0.001, Is.Not.EqualTo(0.0).Within(5).Percent);
    }
    #endregion

    #region ToleranceUlps
    [Test]
    public void Tolerance_Ulps()
    {
        // 0.1 + 0.2 is not exactly 0.3 in binary floating point...
        Assert.That(0.1 + 0.2, Is.Not.EqualTo(0.3));

        // ...but it is the very next representable double, one "unit in the last place" away
        Assert.That(0.1 + 0.2, Is.EqualTo(0.3).Within(1).Ulps);

        // A fixed tolerance that suits small numbers is meaningless for large ones; ULPs scale with the value
        Assert.That(20000000000000004.0, Is.EqualTo(20000000000000000.0).Within(1).Ulps);
    }
    #endregion

    #region ToleranceTime
    [Test]
    public void Tolerance_Time()
    {
        DateTime expected = new(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc);
        DateTime actual = expected.AddSeconds(45);

        // Pass a TimeSpan...
        Assert.That(actual, Is.EqualTo(expected).Within(TimeSpan.FromMinutes(1)));

        // ...or a number followed by a unit
        Assert.That(actual, Is.EqualTo(expected).Within(1).Minutes);
        Assert.That(actual, Is.EqualTo(expected).Within(60).Seconds);
        Assert.That(actual, Is.Not.EqualTo(expected).Within(30).Seconds);

        // TimeSpan and DateTimeOffset values work the same way
        Assert.That(TimeSpan.FromMinutes(59), Is.EqualTo(TimeSpan.FromHours(1)).Within(1).Minutes);

        DateTimeOffset expectedOffset = new(expected);
        Assert.That(expectedOffset.AddMilliseconds(400), Is.EqualTo(expectedOffset).Within(500).Milliseconds);
    }
    #endregion

    #region ToleranceComparison
    [Test]
    public void Tolerance_ComparisonConstraints()
    {
        // The tolerance relaxes the bound: 9.95 counts as greater than 10.0 when the tolerance is 0.1
        Assert.That(9.95, Is.GreaterThan(10.0).Within(0.1));
        Assert.That(10.05, Is.LessThan(10.0).Within(0.1));
        Assert.That(9.5, Is.GreaterThanOrEqualTo(10).Within(5).Percent);

        // Time values accept a TimeSpan tolerance
        DateTime deadline = new(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc);
        Assert.That(deadline.AddSeconds(2), Is.LessThanOrEqualTo(deadline).Within(TimeSpan.FromSeconds(5)));
    }
    #endregion

    #region ToleranceCollections
    [Test]
    public void Tolerance_Collections()
    {
        // The tolerance is applied to each pair of corresponding elements
        double[] expected = [1.0, 2.0, 3.0];
        double[] actual = [1.01, 1.99, 3.0];
        Assert.That(actual, Is.EqualTo(expected).Within(0.05));

        // This includes values nested in dictionaries and tuples
        var expectedPrices = new Dictionary<string, decimal> { ["apple"] = 1.00m, ["pear"] = 1.50m };
        var actualPrices = new Dictionary<string, decimal> { ["apple"] = 1.01m, ["pear"] = 1.49m };
        Assert.That(actualPrices, Is.EqualTo(expectedPrices).Within(0.02m));

        // Members that cannot take a tolerance, such as the string here, are compared exactly
        Assert.That((1.001, "a"), Is.EqualTo((1.0, "a")).Within(0.01));
    }
    #endregion

    #region ToleranceUnorderedCollections
    [Test]
    public void Tolerance_UnorderedCollections()
    {
        double[] expected = [3.0, 1.0, 2.0];
        double[] actual = [1.01, 2.0, 2.99];

        // Is.EquivalentTo has no Within modifier. Sort both sides and compare them in order instead...
        Assert.That(actual.Order(), Is.EqualTo(expected.Order()).Within(0.05));

        // ...or check that each expected value is present exactly once
        foreach (double value in expected)
        {
            Assert.That(actual, Has.Exactly(1).EqualTo(value).Within(0.05));
        }
    }
    #endregion

    #region TolerancePropertiesComparer
    private sealed record Measurement(string Sensor, double Value, DateTime TakenAt);

    [Test]
    public void Tolerance_PropertiesComparer()
    {
        DateTime now = new(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc);
        var expected = new Measurement("probe-1", 21.5, now);
        var actual = new Measurement("probe-1", 21.52, now);

        // The tolerance applies to every property that can accept it; the others are compared exactly
        Assert.That(actual, Is.EqualTo(expected).Within(0.05).UsingPropertiesComparer());

        // Numeric and time properties can each have their own tolerance
        var later = actual with { TakenAt = now.AddMilliseconds(300) };
        Assert.That(later, Is.EqualTo(expected).UsingPropertiesComparer(
            o => o.Within(0.05).Within(TimeSpan.FromSeconds(1))));
    }
    #endregion

    #region ToleranceNotSupported
    private readonly record struct Celsius(double Degrees);

    [Test]
    public void Tolerance_NotSupportedForCustomTypes()
    {
        var expected = new Celsius(20.0);
        var actual = new Celsius(20.4);

        // Celsius defines its own equality, so NUnit has no way to apply a numeric tolerance to it.
        // Rather than silently ignoring the tolerance, the assertion errors.
        Assert.That(() => Assert.That(actual, Is.EqualTo(expected).Within(0.5)),
            Throws.TypeOf<NotSupportedException>().With.Message.Contains("Tolerance"));
    }
    #endregion

    #region ToleranceCustomType
    private sealed class CelsiusComparer(double tolerance) : IEqualityComparer<Celsius>
    {
        public bool Equals(Celsius x, Celsius y) => Math.Abs(x.Degrees - y.Degrees) <= tolerance;

        // Any two values might be equal, so they must all produce the same hash code
        public int GetHashCode(Celsius obj) => 0;
    }

    [Test]
    public void Tolerance_CustomType()
    {
        var expected = new Celsius(20.0);
        var actual = new Celsius(20.4);

        // Option 1: build the tolerance into the comparer passed to Using
        Assert.That(actual, Is.EqualTo(expected).Using<Celsius>((a, b) => Math.Abs(a.Degrees - b.Degrees) <= 0.5));
        Assert.That(actual, Is.EqualTo(expected).Using(new CelsiusComparer(0.5)));

        // A reusable comparer also works for collections of the type
        Celsius[] expectedReadings = [new(20.0), new(21.0)];
        Celsius[] actualReadings = [new(20.4), new(20.7)];
        Assert.That(actualReadings, Is.EqualTo(expectedReadings).Using(new CelsiusComparer(0.5)));

        // Option 2: compare the underlying value
        Assert.That(actual.Degrees, Is.EqualTo(expected.Degrees).Within(0.5));

        // Option 3: let the properties comparer apply the tolerance to the numeric members
        Assert.That(actual, Is.EqualTo(expected).Within(0.5).UsingPropertiesComparer());

        // Combining Using with Within is an error: the comparer alone decides what is equal
        Assert.That(() => Assert.That(actual, Is.EqualTo(expected).Using(new CelsiusComparer(0.5)).Within(0.5)),
            Throws.TypeOf<NotSupportedException>());
    }
    #endregion

    #region ToleranceRules
    [Test]
    public void Tolerance_Rules()
    {
        // A tolerance must not be negative
        Assert.That(() => Is.EqualTo(5.0).Within(-0.1), Throws.ArgumentException);

        // Within may appear only once in a constraint
        Assert.That(() => Is.EqualTo(5.0).Within(0.1).Within(0.2), Throws.InvalidOperationException);

        // A mode must follow Within, and only one mode may be used
        Assert.That(() => Is.EqualTo(5.0).Percent, Throws.InvalidOperationException);
        Assert.That(() => Is.EqualTo(5.0).Within(1).Percent.Ulps, Throws.InvalidOperationException);
    }
    #endregion
}

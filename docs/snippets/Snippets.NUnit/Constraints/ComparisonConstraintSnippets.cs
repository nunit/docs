using System.Collections.Generic;
using NUnit.Framework;

#pragma warning disable NUnit2045

namespace Snippets.NUnit.Constraints;

public class ComparisonConstraintSnippets
{
    #region GreaterThanConstraintExamples
    [Test]
    public void GreaterThanConstraint_Examples()
    {
        Assert.That(7, Is.GreaterThan(3));
        Assert.That(5, Is.Positive);
        Assert.That(-3, Is.Not.Positive);

        // With DateTime
        Assert.That(DateTime.Now, Is.GreaterThan(DateTime.Today));

        // With tolerance
        Assert.That(10.5, Is.GreaterThan(10.0).Within(0.1));
    }
    #endregion

    #region LessThanConstraintExamples
    [Test]
    public void LessThanConstraint_Examples()
    {
        Assert.That(3, Is.LessThan(7));
        Assert.That(-5, Is.Negative);
        Assert.That(5, Is.Not.Negative);

        // With DateTime
        Assert.That(DateTime.Today, Is.LessThan(DateTime.Now));

        // With tolerance
        Assert.That(9.5, Is.LessThan(10.0).Within(0.1));
    }
    #endregion

    #region GreaterThanOrEqualConstraintExamples
    [Test]
    public void GreaterThanOrEqualConstraint_Examples()
    {
        Assert.That(7, Is.GreaterThanOrEqualTo(7));
        Assert.That(7, Is.GreaterThanOrEqualTo(3));
        Assert.That(7, Is.AtLeast(7));

        // With DateTime
        Assert.That(DateTime.Now, Is.GreaterThanOrEqualTo(DateTime.Today));

        // With tolerance
        Assert.That(10.1, Is.GreaterThanOrEqualTo(10.0).Within(0.5));
    }
    #endregion

    #region LessThanOrEqualConstraintExamples
    [Test]
    public void LessThanOrEqualConstraint_Examples()
    {
        Assert.That(7, Is.LessThanOrEqualTo(7));
        Assert.That(3, Is.LessThanOrEqualTo(7));
        Assert.That(3, Is.AtMost(7));

        // With DateTime
        Assert.That(DateTime.Today, Is.LessThanOrEqualTo(DateTime.Now));

        // With tolerance
        Assert.That(9.9, Is.LessThanOrEqualTo(10.0).Within(0.5));
    }
    #endregion

    #region RangeConstraintExamples
    [Test]
    public void RangeConstraint_Examples()
    {
        // Numeric ranges (inclusive)
        Assert.That(5, Is.InRange(1, 10));
        Assert.That(1, Is.InRange(1, 10));   // Lower bound is included
        Assert.That(10, Is.InRange(1, 10));  // Upper bound is included
        Assert.That(0, Is.Not.InRange(1, 10));

        // DateTime ranges
        var start = new DateTime(2024, 1, 1);
        var end = new DateTime(2024, 12, 31);
        Assert.That(new DateTime(2024, 6, 15), Is.InRange(start, end));

        // String ranges (alphabetical comparison)
        Assert.That("banana", Is.InRange("apple", "cherry"));
    }
    #endregion

    #region NullConstraintExamples
    [Test]
    public void NullConstraint_Examples()
    {
        object? obj = null;
        Assert.That(obj, Is.Null);

        string name = "Alice";
        Assert.That(name, Is.Not.Null);

        // Combining with other constraints
        object? result = "value";
        Assert.That(result, Is.Not.Null.And.Not.EqualTo(""));
    }
    #endregion

    #region TrueConstraintExamples
    [Test]
    public void TrueConstraint_Examples()
    {
        Assert.That(2 + 2 == 4, Is.True);
        var isValid = true;
        Assert.That(isValid, Is.True);
        var list = new List<int> { 1, 2, 3 };
        Assert.That(list.Contains(2), Is.True);

        // With nullable booleans
        bool? hasValue = true;
        Assert.That(hasValue, Is.True);
    }
    #endregion

    #region FalseConstraintExamples
    [Test]
    public void FalseConstraint_Examples()
    {
        Assert.That(2 + 2 == 5, Is.False);
        var isDisabled = false;
        Assert.That(isDisabled, Is.False);
        ICollection<int> list = new List<int>();
        Assert.That(list.IsReadOnly, Is.False);

        // With nullable booleans
        bool? isDeleted = false;
        Assert.That(isDeleted, Is.False);
    }
    #endregion

    #region ContainsConstraintStringExamples
    [Test]
    public void ContainsConstraint_String_Examples()
    {
        Assert.That("Hello World", Does.Contain("World"));
        Assert.That("Hello World", Does.Contain("world").IgnoreCase);
        Assert.That("Hello World", Does.Not.Contain("Goodbye"));
    }
    #endregion

    #region ContainsConstraintCollectionExamples
    [Test]
    public void ContainsConstraint_Collection_Examples()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        Assert.That(numbers, Does.Contain(3));
        Assert.That(numbers, Does.Not.Contain(99));

        string[] names = { "Alice", "Bob", "Charlie" };
        Assert.That(names, Does.Contain("Bob"));
        Assert.That(names, Does.Contain("bob").IgnoreCase);
    }
    #endregion

    #region ThrowsConstraintBasicExamples
    [Test]
    public void ThrowsConstraint_Basic_Examples()
    {
        // Test for specific exception type
        Assert.That(() => ThrowArgumentException(), Throws.TypeOf<ArgumentException>());
        Assert.That(() => ThrowArgumentException(), Throws.InstanceOf<Exception>());

        // Test exception message
        Assert.That(() => throw new ArgumentException("bad value"),
            Throws.ArgumentException.With.Message.EqualTo("bad value"));

        // Test with lambda expression
        Assert.That(() => int.Parse("abc"), Throws.TypeOf<FormatException>());

        // Assert no exception is thrown
        Assert.That(() => SafeMethod(), Throws.Nothing);
    }

    private static void ThrowArgumentException() => throw new ArgumentException("test");
    private static void SafeMethod() { }
    #endregion
}

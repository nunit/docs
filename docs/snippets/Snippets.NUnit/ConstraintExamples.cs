using NUnit.Framework;
using System.Collections;

#pragma warning disable CA1822
#pragma warning disable NUnit2045
#pragma warning disable CA2211
#pragma warning disable NUnit2007
#pragma warning disable NUnit2009

namespace Snippets.NUnit;

public class ConstraintExamples
{
    #region EqualConstraintNumerics
    [Test]
    public void EqualConstraint_Numerics()
    {
        Assert.That(2 + 2, Is.EqualTo(4.0));
        Assert.That(2 + 2 == 4);
        Assert.That(2 + 2, Is.Not.EqualTo(5));
        Assert.That(2 + 2 != 5);
        Assert.That(5.0, Is.EqualTo(5));
        Assert.That(5.5, Is.EqualTo(5).Within(0.5));
        Assert.That(5.5, Is.EqualTo(5).Within(10).Percent);
    }
    #endregion

    #region EqualConstraintFloatingPoint
    [Test]
    public void EqualConstraint_FloatingPoint()
    {
        Assert.That(2.1 + 1.2, Is.EqualTo(3.3).Within(.0005));
        Assert.That(double.PositiveInfinity, Is.EqualTo(double.PositiveInfinity));
        Assert.That(double.NegativeInfinity, Is.EqualTo(double.NegativeInfinity));
        Assert.That(double.NaN, Is.EqualTo(double.NaN));
        Assert.That(20000000000000004.0, Is.EqualTo(20000000000000000.0).Within(1).Ulps);
    }
    #endregion

    #region EqualConstraintStrings
    [Test]
    public void EqualConstraint_Strings()
    {
        var hello = "Hello!";
        Assert.That(hello, Is.Not.EqualTo("HELLO!"));
        Assert.That(hello, Is.EqualTo("HELLO!").IgnoreCase);  // Ignores case in both actual and expected before comparing

        string[] expected = ["Hello", "World"];
        string[] actual = ["HELLO", "world"];
        Assert.That(actual, Is.EqualTo(expected).IgnoreCase);
        var actualiws = "Hello  my world is \r\n on fire!";
        var expectediws = "Hellomy    world \r\n  is   on    fire!";
        Assert.That(actualiws, Is.EqualTo(expectediws).IgnoreWhiteSpace);  // Ignores white space in both actual and expected before comparing
    }
    #endregion

    #region AndConstraintExamples
    [Test]
    public void AndConstraint_Examples()
    {
        Assert.That(2.3, Is.GreaterThan(2.0).And.LessThan(3.0));

        int? i = 10;
        Assert.That(i, Is.Not.Null.And.GreaterThan(9));
    }
    #endregion

    #region CollectionContainsExamples
    [Test]
    public void CollectionContains_Examples()
    {
        int[] intArray = [1, 2, 3];
        string[] stringArray = ["a", "b", "c"];

        Assert.That(intArray, Has.Member(3));
        Assert.That(stringArray, Has.Member("b"));
        Assert.That(stringArray, Contains.Item("c"));
        Assert.That(stringArray, Has.No.Member("x"));
        Assert.That(intArray, Does.Contain(3));
    }
    #endregion

    #region GreaterThanExamples
    [Test]
    public void GreaterThan_Examples()
    {
        Assert.That(7, Is.GreaterThan(3));
        Assert.That(42, Is.Positive);

        var expectedDateTime = DateTime.Now.AddMinutes(-1);
        var myDateTime = DateTime.Now;
        Assert.That(myDateTime, Is.GreaterThan(expectedDateTime).Within(TimeSpan.FromSeconds(1)));

        var myOwnObject = new MyOwnObject(42);

        // Using an untyped comparer that can handle both MyOwnObject and int types, comparing based on the Age property of MyOwnObject instances.
        var myComparer = new MyComparerUnTyped();
        Assert.That(myOwnObject, Is.GreaterThan(41).Using(myComparer));

        // Using a lambda expression to compare MyOwnObject instances based on their Age property
        var myParentObject = new MyOwnObject(84);
        Assert.That(myParentObject, Is.GreaterThan(myOwnObject).Using<MyOwnObject>((x, y) => x.Age.CompareTo(y.Age)));

        // Using a typed comparer
        var myTypedComparer = new MyComparerTyped();
        Assert.That(myParentObject, Is.GreaterThan(myOwnObject).Using(myTypedComparer));
    }
    #endregion

    #region GreaterThanOrEqualExamples
    [Test]
    public void GreaterThanOrEqual_Examples()
    {
        Assert.That(7, Is.GreaterThan(3));
        Assert.That(42, Is.Positive);

        var expectedDateTime = DateTime.Now;
        var myDateTime = DateTime.Now;
        Assert.That(myDateTime, Is.GreaterThan(expectedDateTime).Within(TimeSpan.FromSeconds(1)));

        Assert.That(7, Is.GreaterThanOrEqualTo(3));
        Assert.That(7, Is.AtLeast(3));
        Assert.That(7, Is.GreaterThanOrEqualTo(7));
        Assert.That(7, Is.AtLeast(7));

        var myOwnObject = new MyOwnObject(42);

        // Using an untyped comparer that can handle both MyOwnObject and int types, comparing based on the Age property of MyOwnObject instances.
        var myComparer = new MyComparerUntyped();
        Assert.That(myOwnObject, Is.GreaterThanOrEqualTo(42).Using(myComparer));

        // Using a lambda expression to compare MyOwnObject instances based on their Age property
        var myParentObject = new MyOwnObject(84);
        Assert.That(myParentObject, Is.GreaterThanOrEqualTo(myOwnObject).Using<MyOwnObject>((x, y) => x.Age.CompareTo(y.Age)));

        // Using a typed comparer
        var myTypedComparer = new MyComparerTyped();
        Assert.That(myParentObject, Is.GreaterThanOrEqualTo(myOwnObject).Using(myTypedComparer));
    }
    #endregion

    #region MyComparerExample
    public class MyOwnObject(int age)
    {
        public int Age => age;
    }

    /// <summary>
    /// Comparer handling different types of objects (MyOwnObject and int) and comparing them based on the Age property of MyOwnObject instances.
    /// </summary>
    public class MyComparerUntyped : IComparer
    {
        public int Compare(object? x, object? y)
        {
            // Handle nulls
            if (ReferenceEquals(x, y)) return 0;
            if (x is null) return -1;
            if (y is null) return 1;
            // Identify which one is the object and which is the int
            int actualAge = x is MyOwnObject obj ? obj.Age : (int)x;
            int expectedAge = y is MyOwnObject objY ? objY.Age : (int)y;

            return actualAge.CompareTo(expectedAge);
        }
    }

    /// <summary>
    /// High performance comparer for equal typed objects that only compares the Age property of MyOwnObject instances.
    /// </summary>
    public class MyComparerTyped : IComparer<MyOwnObject>
    {
        public int Compare(MyOwnObject? x, MyOwnObject? y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (x is null) return -1;
            if (y is null) return 1;

            return x.Age.CompareTo(y.Age);
        }
    }

    #endregion


#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
    #region NullConstraintExamples
    [Test]
    public void NullConstraint_Examples()
    {
        object anObject = null;
        Assert.That(anObject, Is.Null);

        anObject = "something";
        Assert.That(anObject, Is.Not.Null);
    }
    #endregion
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

    #region LessThanExamples
    [Test]
    public void LessThan_Examples()
    {
        Assert.That(3, Is.LessThan(7));
        Assert.That(-5, Is.Negative);

        var myDateTime = DateTime.Now;
        var expectedDateTime = DateTime.Now;
        Assert.That(myDateTime, Is.LessThan(expectedDateTime).Within(TimeSpan.FromSeconds(1)));

        var myOwnObject = new MyOwnObject(42);

        // Using an untyped comparer that can handle both MyOwnObject and int types, comparing based on the Age property of MyOwnObject instances.
        var myComparer = new MyComparerUnTyped();
        Assert.That(myOwnObject, Is.LessThan(43).Using(myComparer));

        // Using a lambda expression to compare MyOwnObject instances based on their Age property
        var myParentObject = new MyOwnObject(84);
        Assert.That(myOwnObject, Is.LessThan(myParentObject).Using<MyOwnObject>((x, y) => x.Age.CompareTo(y.Age)));

        // Using a typed comparer
        var myTypedComparer = new MyComparerTyped();
        Assert.That(myOwnObject, Is.LessThan(myParentObject).Using(myTypedComparer));
    }
    #endregion

    #region LessThanOrEqualExamples
    [Test]
    public void LessThanOrEqual_Examples()
    {
        Assert.That(3, Is.LessThanOrEqualTo(7));
        Assert.That(3, Is.AtMost(7));
        Assert.That(3, Is.LessThanOrEqualTo(3));
        Assert.That(3, Is.AtMost(3));

        var myDateTime = DateTime.Now.AddMinutes(-1);
        var expectedDateTime = DateTime.Now;
        Assert.That(myDateTime, Is.LessThanOrEqualTo(expectedDateTime).Within(TimeSpan.FromSeconds(1)));

        var myOwnObject = new MyOwnObject(42);

        // Using an untyped comparer that can handle both MyOwnObject and int types, comparing based on the Age property of MyOwnObject instances.
        var myComparer = new MyComparerUnTyped();
        Assert.That(myOwnObject, Is.LessThanOrEqualTo(42).Using(myComparer));

        // Using a lambda expression to compare MyOwnObject instances based on their Age property
        var myParentObject = new MyOwnObject(84);
        Assert.That(myOwnObject, Is.LessThanOrEqualTo(myParentObject).Using<MyOwnObject>((x, y) => x.Age.CompareTo(y.Age)));

        // Using a typed comparer
        var myTypedComparer = new MyComparerTyped();
        Assert.That(myOwnObject, Is.LessThanOrEqualTo(myParentObject).Using(myTypedComparer));
    }
    #endregion




    #region StringConstraintExamples
    [Test]
    public void StringConstraint_Examples()
    {
        Assert.That("Hello World!", Does.StartWith("Hello"));
        Assert.That("Hello World!", Does.EndWith("World!"));
        Assert.That("Hello World!", Does.Contain("lo Wor"));
        Assert.That("Hello World!", Does.Match("H.*!"));
    }
    #endregion

    #region TrueConstraintExamples
    [Test]
    public void TrueConstraint_Examples()
    {
        Assert.That(2 + 2 == 4, Is.True);
        Assert.That(2 + 2 == 5, Is.False);
    }
    #endregion

    #region TypeConstraintExamples
    [Test]
    public void TypeConstraint_Examples()
    {
        Assert.That("Hello", Is.TypeOf<string>());
        Assert.That("Hello", Is.TypeOf(typeof(string)));
        Assert.That("Hello", Is.InstanceOf<string>());
        Assert.That("Hello", Is.InstanceOf<object>());
        Assert.That("Hello", Is.AssignableTo<object>());
    }
    #endregion

    #region RangeConstraintExamples
    [Test]
    public void RangeConstraint_Examples()
    {
        int[] intArray = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        Assert.That(5, Is.InRange(1, 10));
        Assert.That(42, Is.Not.InRange(1, 10));
        Assert.That(intArray, Has.All.InRange(1, 10));
    }
    #endregion

    #region CollectionConstraintExamples
    [Test]
    public void CollectionConstraint_Examples()
    {
        int[] intArray = [1, 2, 3];
        string[] stringArray = ["a", "b", "c"];

        Assert.That(intArray, Is.All.GreaterThan(0));
        Assert.That(stringArray, Is.All.InstanceOf<string>());
        Assert.That(intArray, Has.Some.EqualTo(2));
        Assert.That(intArray, Has.None.EqualTo(4));
        Assert.That(intArray, Is.Unique);
        Assert.That(new int[] { }, Is.Empty);
        Assert.That(intArray, Has.Exactly(3).Items);
        Assert.That(intArray, Has.Some.GreaterThan(2));
    }
    #endregion

    #region FileConstraintExamples
    [Test]
    public void FileConstraint_Examples()
    {
        var tempFile = Path.GetTempFileName();
        File.WriteAllText(tempFile, "test content");

        try
        {
            Assert.That(tempFile, Does.Exist);
            Assert.That("nonexistent.txt", Does.Not.Exist);
        }
        finally
        {
            if (File.Exists(tempFile))
                File.Delete(tempFile);
        }
    }
    #endregion

    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable UnusedAutoPropertyAccessor.Global
    #region PropertyConstraintExamples
    public class Person
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public string Email { get; set; } = "";
    }

    [Test]
    public void PropertyConstraint_Examples()
    {
        var person = new Person { Name = "John", Age = 25, Email = "john@example.com" };

        Assert.That(person, Has.Property("Name").EqualTo("John"));
        Assert.That(person, Has.Property("Age").GreaterThan(18));
        Assert.That(person, Has.Property("Email").Contains("@"));
    }
    #endregion
    // ReSharper restore UnusedAutoPropertyAccessor.Global

    #region EmptyConstraintExamples
    [Test]
    public void EmptyConstraint_Examples()
    {
        Assert.That("", Is.Empty);
        Assert.That(new int[] { }, Is.Empty);
        Assert.That(new List<string>(), Is.Empty);
        Assert.That("Hello", Is.Not.Empty);
    }
    #endregion

    #region OrConstraintExamples
    [Test]
    public void OrConstraint_Examples()
    {
        Assert.That(3, Is.LessThan(5).Or.GreaterThan(10));
        Assert.That(12, Is.LessThan(5).Or.GreaterThan(10));
    }
    #endregion

    #region NotConstraintExamples
    [Test]
    public void NotConstraint_Examples()
    {
        Assert.That(42, Is.Not.EqualTo(99));
        Assert.That("Hello", Is.Not.Null);
        Assert.That(new[] { 1, 2, 3 }, Is.Not.Empty);
    }
    #endregion

    #region ThrowsConstraintExamples
    [Test]
    public void ThrowsConstraint_Examples()
    {
        Assert.That(() => throw new ArgumentException(), Throws.ArgumentException);
        Assert.That(() => throw new InvalidOperationException("test"),
                   Throws.InvalidOperationException.With.Message.EqualTo("test"));
        Assert.That(() => { }, Throws.Nothing);
    }
    #endregion

    #region DelayedConstraintExamples
    [Test]
    public void DelayedConstraint_Examples()
    {
        var flag = false;
        Task.Run(async () =>
        {
            await Task.Delay(100);
            flag = true;
        });

        Assert.That(() => flag, Is.True.After(200).MilliSeconds);
    }
    #endregion
}
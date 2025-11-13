using NUnit.Framework;
using NUnit.Framework.Legacy;

#pragma warning disable CA1822
#pragma warning disable NUnit2045
#pragma warning disable NUnit2005
#pragma warning disable NUnit2006
#pragma warning disable NUnit2015
#pragma warning disable NUnit2031
#pragma warning disable NUnit2049

namespace Snippets.NUnit;

public class ClassicAssertExamples
{
    #region AreEqualExamples
    [Test]
    public void AreEqual_Examples()
    {
        // Comparing numerics of different types
        ClassicAssert.AreEqual(5, 5.0);
        
        // Floating point special values
        ClassicAssert.AreEqual(double.PositiveInfinity, double.PositiveInfinity);
        ClassicAssert.AreEqual(double.NegativeInfinity, double.NegativeInfinity);
        ClassicAssert.AreEqual(double.NaN, double.NaN);
        
        // Basic equality
        ClassicAssert.AreEqual("expected", "expected");
        ClassicAssert.AreEqual(42, 42);
        
        // With tolerance for floating point
        ClassicAssert.AreEqual(2.1 + 1.2, 3.3, 0.001);
    }
    #endregion

    #region AreNotEqualExamples
    [Test]
    public void AreNotEqual_Examples()
    {
        ClassicAssert.AreNotEqual(5, 3);
        ClassicAssert.AreNotEqual("Hello", "World");
        ClassicAssert.AreNotEqual(null, "something");
    }
    #endregion

    #region TrueExamples
    [Test]
    public void True_Examples()
    {
        ClassicAssert.True(2 + 2 == 4);
        ClassicAssert.IsTrue(true);
        ClassicAssert.True("Hello".StartsWith("H"));
        
    }
    #endregion

    #region FalseExamples
    [Test]
    public void False_Examples()
    {
        ClassicAssert.False(2 + 2 == 5);
        ClassicAssert.IsFalse(false);
        ClassicAssert.False("Hello".StartsWith("X"));
    }
    #endregion

#pragma warning disable CS8600
#pragma warning disable CS8625

    #region NullExamples
    [Test]
    public void Null_Examples()
    {
        object obj = null;
        ClassicAssert.Null(obj);
        ClassicAssert.IsNull(obj);
        
        obj = "something";
        ClassicAssert.NotNull(obj);
        ClassicAssert.IsNotNull(obj);
    }
    #endregion
#pragma warning restore CS8600
#pragma warning restore CS8625
    
    #region SameExamples
    [Test]
    public void Same_Examples()
    {
        object obj1 = new object();
        object obj2 = obj1;
        object obj3 = new object();
        
        ClassicAssert.AreSame(obj1, obj2);
        ClassicAssert.AreNotSame(obj1, obj3);
    }
    #endregion

    #region GreaterExamples
    [Test]
    public void Greater_Examples()
    {
        ClassicAssert.Greater(7, 3);
        ClassicAssert.Greater(3.5, 2.1);
        ClassicAssert.Greater("b", "a");
        ClassicAssert.Greater(DateTime.Now, DateTime.Now.AddDays(-1));
    }
    #endregion

    #region GreaterOrEqualExamples
    [Test]
    public void GreaterOrEqual_Examples()
    {
        ClassicAssert.GreaterOrEqual(7, 3);
        ClassicAssert.GreaterOrEqual(7, 7);
        ClassicAssert.GreaterOrEqual("b", "a");
        ClassicAssert.GreaterOrEqual("b", "b");
    }
    #endregion

    #region LessExamples
    [Test]
    public void Less_Examples()
    {
        ClassicAssert.Less(3, 7);
        ClassicAssert.Less(2.1, 3.5);
        ClassicAssert.Less("a", "b");
    }
    #endregion

    #region LessOrEqualExamples
    [Test]
    public void LessOrEqual_Examples()
    {
        ClassicAssert.LessOrEqual(3, 7);
        ClassicAssert.LessOrEqual(7, 7);
        ClassicAssert.LessOrEqual("a", "b");
        ClassicAssert.LessOrEqual("a", "a");
    }
    #endregion

    #region ContainsExamples
    [Test]
    public void Contains_Examples()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 };
        ClassicAssert.Contains(3, list);
        
        var array = new string[] { "apple", "banana", "cherry" };
        ClassicAssert.Contains("banana", array);
    }
    #endregion

    #region PositiveNegativeZeroExamples
    [Test]
    public void PositiveNegativeZero_Examples()
    {
        ClassicAssert.Positive(5);
        ClassicAssert.Positive(0.1);
        
        ClassicAssert.Negative(-5);
        ClassicAssert.Negative(-0.1);
        
        ClassicAssert.Zero(0);
        ClassicAssert.Zero(0.0);
        
        ClassicAssert.NotZero(5);
        ClassicAssert.NotZero(-3);
    }
    #endregion

    #region NaNExamples
    [Test]
    public void NaN_Examples()
    {
        ClassicAssert.IsNaN(double.NaN);
        ClassicAssert.IsNaN(float.NaN);
    }
    #endregion

    #region EmptyExamples
    [Test]
    public void Empty_Examples()
    {
        ClassicAssert.IsEmpty("");
        ClassicAssert.IsEmpty(new int[] { });
        ClassicAssert.IsEmpty(new List<string>());
        
        ClassicAssert.IsNotEmpty("Hello");
        ClassicAssert.IsNotEmpty(new int[] { 1, 2, 3 });
        ClassicAssert.IsNotEmpty(new List<string> { "item" });
    }
    #endregion

    #region InstanceOfExamples
    [Test]
    public void InstanceOf_Examples()
    {
        ClassicAssert.IsInstanceOf<string>("Hello");
        ClassicAssert.IsInstanceOf(typeof(string), "Hello");
        ClassicAssert.IsInstanceOf<object>("Hello");
        
        ClassicAssert.IsNotInstanceOf<int>("Hello");
        ClassicAssert.IsNotInstanceOf(typeof(int), "Hello");
    }
    #endregion

    #region AssignableFromExamples
    [Test]
    public void AssignableFrom_Examples()
    {
        // object can be assigned FROM string (string is a subtype of object)
        object obj = "Hello";
        ClassicAssert.IsAssignableFrom<string>(obj);
        ClassicAssert.IsAssignableFrom(typeof(string), obj);
        
        ClassicAssert.IsNotAssignableFrom<int>("Hello");
        ClassicAssert.IsNotAssignableFrom(typeof(int), "Hello");
    }
    #endregion
}

public class CollectionAssertExamples
{
    #region CollectionAssertBasicExamples
    [Test]
    public void CollectionAssert_Basic_Examples()
    {
        var list1 = new int[] { 1, 2, 3 };
        var list2 = new int[] { 1, 2, 3 };
        var list3 = new int[] { 3, 2, 1 };
        var list4 = new int[] { 1, 2, 4 };
        
        // Collections are equal (same order)
        CollectionAssert.AreEqual(list1, list2);
        
        // Collections are equivalent (same items, any order)
        CollectionAssert.AreEquivalent(list1, list3);
        
        // Collections are not equal
        CollectionAssert.AreNotEqual(list1, list4);
        
        // Collections are not equivalent
        CollectionAssert.AreNotEquivalent(list1, list4);
    }
    #endregion

    #region CollectionAssertContainsExamples
    [Test]
    public void CollectionAssert_Contains_Examples()
    {
        var list = new int[] { 1, 2, 3, 4, 5 };
        
        CollectionAssert.Contains(list, 3);
        CollectionAssert.DoesNotContain(list, 10);
    }
    #endregion

    #region CollectionAssertSubsetExamples
    [Test]
    public void CollectionAssert_Subset_Examples()
    {
        var superset = new int[] { 1, 2, 3, 4, 5 };
        var subset = new int[] { 2, 4 };
        var notSubset = new int[] { 1, 6 };
        
        CollectionAssert.IsSubsetOf(subset, superset);
        CollectionAssert.IsNotSubsetOf(notSubset, superset);
    }
    #endregion

    #region CollectionAssertEmptyExamples
    [Test]
    public void CollectionAssert_Empty_Examples()
    {
        var emptyList = new int[] { };
        var nonEmptyList = new int[] { 1, 2, 3 };
        
        CollectionAssert.IsEmpty(emptyList);
        CollectionAssert.IsNotEmpty(nonEmptyList);
    }
    #endregion

    #region CollectionAssertOrderedExamples
    [Test]
    public void CollectionAssert_Ordered_Examples()
    {
        var orderedList = new int[] { 1, 2, 3, 4, 5 };
        var reverseOrderedList = new int[] { 5, 4, 3, 2, 1 };
        
        CollectionAssert.IsOrdered(orderedList);
        CollectionAssert.IsOrdered(reverseOrderedList, Comparer<int>.Create((x, y) => y.CompareTo(x)));
    }
    #endregion


#pragma warning disable CS8625
    #region CollectionAssertItemTypeExamples
    [Test]
    public void CollectionAssert_ItemType_Examples()
    {
        var stringList = new string[] { "a", "b", "c" };
        var mixedList = new object[] { "string", 123, null };
        
        CollectionAssert.AllItemsAreInstancesOfType(stringList, typeof(string));
        CollectionAssert.AllItemsAreNotNull(stringList);
        CollectionAssert.AllItemsAreUnique(stringList);
    }
    #endregion
#pragma warning restore CS8625
}
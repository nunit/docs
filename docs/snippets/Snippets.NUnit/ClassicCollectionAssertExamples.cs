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

public class CollectionAssertExamples
{
    #region CollectionAssertBasicExamples
    [Test]
    public void CollectionAssert_Basic_Examples()
    {
        var list1 = new[] { 1, 2, 3 };
        var list2 = new[] { 1, 2, 3 };
        var list3 = new[] { 3, 2, 1 };
        var list4 = new[] { 1, 2, 4 };
        
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
        var list = new[] { 1, 2, 3, 4, 5 };
        
        CollectionAssert.Contains(list, 3);
        CollectionAssert.DoesNotContain(list, 10);
    }
    #endregion

    #region CollectionAssertSubsetExamples
    [Test]
    public void CollectionAssert_Subset_Examples()
    {
        var superset = new[] { 1, 2, 3, 4, 5 };
        var subset = new[] { 2, 4 };
        var notSubset = new[] { 1, 6 };
        
        CollectionAssert.IsSubsetOf(subset, superset);
        CollectionAssert.IsNotSubsetOf(notSubset, superset);
    }
    #endregion

    #region CollectionAssertEmptyExamples
    [Test]
    public void CollectionAssert_Empty_Examples()
    {
        var emptyList = new int[] { };
        var nonEmptyList = new[] { 1, 2, 3 };
        
        CollectionAssert.IsEmpty(emptyList);
        CollectionAssert.IsNotEmpty(nonEmptyList);
    }
    #endregion

    #region CollectionAssertOrderedExamples
    [Test]
    public void CollectionAssert_Ordered_Examples()
    {
        var orderedList = new[] { 1, 2, 3, 4, 5 };
        var reverseOrderedList = new[] { 5, 4, 3, 2, 1 };
        
        CollectionAssert.IsOrdered(orderedList);
        CollectionAssert.IsOrdered(reverseOrderedList, Comparer<int>.Create((x, y) => y.CompareTo(x)));
    }
    #endregion


#pragma warning disable CS8625
    #region CollectionAssertItemTypeExamples
    [Test]
    public void CollectionAssert_ItemType_Examples()
    {
        var stringList = new[] { "a", "b", "c" };
        var mixedList = new object[] { "string", 123, null };
        
        CollectionAssert.AllItemsAreInstancesOfType(stringList, typeof(string));
        CollectionAssert.AllItemsAreNotNull(stringList);
        CollectionAssert.AllItemsAreUnique(stringList);
    }
    #endregion
#pragma warning restore CS8625
}
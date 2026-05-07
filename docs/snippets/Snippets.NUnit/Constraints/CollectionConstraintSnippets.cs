using NUnit.Framework;

#pragma warning disable NUnit2045

namespace Snippets.NUnit.Constraints;

public class CollectionConstraintSnippets
{
    #region AllItemsConstraintExamples
    [Test]
    public void AllItemsConstraint_Examples()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        string[] names = { "Alice", "Bob", "Carol" };

        // All items must satisfy the constraint
        Assert.That(numbers, Is.All.GreaterThan(0));       // All positive
        Assert.That(numbers, Is.All.LessThan(10));         // All less than 10
        Assert.That(names, Is.All.Not.Null);               // No nulls
        Assert.That(names, Is.All.Not.Empty);              // No empty strings
        Assert.That(names, Is.All.InstanceOf<string>());   // All are strings

        // Has.All is equivalent to Is.All
        Assert.That(numbers, Has.All.GreaterThan(0));

        // Combining with property constraints
        Assert.That(names, Is.All.Length.GreaterThan(2));  // All names > 2 chars

        // Complex constraints
        Assert.That(numbers, Is.All.InRange(1, 10));
        Assert.That(names, Is.All.Matches<string>(n => n.Length <= 5));
    }
    #endregion

    #region SomeItemsConstraintExamples
    [Test]
    public void SomeItemsConstraint_Examples()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        string[] names = { "Alice", "Bob", "Carol" };

        // At least one item must satisfy the constraint
        Assert.That(numbers, Has.Some.GreaterThan(3));      // At least one > 3
        Assert.That(numbers, Has.Some.EqualTo(3));          // Contains 3
        Assert.That(names, Has.Some.Length.EqualTo(3));     // At least one 3-char name

        // Collection membership (all equivalent)
        Assert.That(numbers, Has.Member(3));
        Assert.That(numbers, Contains.Item(3));
        Assert.That(numbers, Does.Contain(3));
        Assert.That(numbers, Has.Some.EqualTo(3));

        // Custom comparison for membership
        Assert.That(names, Has.Some.EqualTo("alice").IgnoreCase);
        Assert.That(names, Has.Some.EqualTo("bob").Using(StringComparer.OrdinalIgnoreCase));
    }
    #endregion

    #region NoItemConstraintExamples
    [Test]
    public void NoItemConstraint_Examples()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        string[] names = { "Alice", "Bob", "Carol" };

        // No items should satisfy the constraint
        Assert.That(numbers, Has.None.LessThan(0));         // No negatives
        Assert.That(numbers, Has.None.GreaterThan(100));    // None > 100
        Assert.That(names, Has.None.Null);                  // No nulls
        Assert.That(names, Has.None.Empty);                 // No empty strings
        Assert.That(names, Has.None.EqualTo("Dave"));       // "Dave" not in list

        // Property-based constraints
        Assert.That(names, Has.None.Length.GreaterThan(10)); // No name > 10 chars

        // Multiple conditions
        Assert.That(numbers, Has.None.LessThanOrEqualTo(0));
    }
    #endregion

    #region UniqueItemsConstraintExamples
    [Test]
    public void UniqueItemsConstraint_Examples()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        string[] names = { "Alice", "Bob", "Carol" };

        // Basic uniqueness check
        Assert.That(numbers, Is.Unique);
        Assert.That(names, Is.Unique);

        // Fails: contains duplicates
        Assert.That(new[] { 1, 2, 2, 3 }, Is.Not.Unique);

        // Case-insensitive uniqueness
        Assert.That(new[] { "Alice", "ALICE" }, Is.Unique);               // Passes: different case
        Assert.That(new[] { "Alice", "ALICE" }, Is.Not.Unique.IgnoreCase); // Passes: same when ignoring case
    }
    #endregion

    #region CollectionOrderedConstraintExamples
    [Test]
    public void CollectionOrderedConstraint_Examples()
    {
        int[] ascending = { 1, 2, 3, 4, 5 };
        int[] descending = { 5, 4, 3, 2, 1 };
        string[] alphabetical = { "Alice", "Bob", "Carol" };

        // Simple ordering
        Assert.That(ascending, Is.Ordered);                  // Default is ascending
        Assert.That(ascending, Is.Ordered.Ascending);        // Explicit ascending
        Assert.That(descending, Is.Ordered.Descending);      // Descending order
        Assert.That(alphabetical, Is.Ordered);               // Alphabetical order

        // Property-based ordering
        string[] byLength = { "a", "bb", "ccc" };
        Assert.That(byLength, Is.Ordered.By("Length"));
        Assert.That(byLength.Reverse(), Is.Ordered.Descending.By("Length"));

        // Custom comparison
        var words = new[] { "apple", "Banana", "cherry" };
        Assert.That(words, Is.Ordered.Using((IComparer<string>)StringComparer.OrdinalIgnoreCase));
    }
    #endregion

    #region CollectionOrderedMultiplePropertiesExamples
    [Test]
    public void CollectionOrdered_MultipleProperties_Examples()
    {
        var people = new[]
        {
            new { Name = "Alice", Age = 25 },
            new { Name = "Bob", Age = 25 },
            new { Name = "Carol", Age = 30 }
        };

        // Order by Age ascending, then by Name ascending
        Assert.That(people, Is.Ordered.By("Age").Then.By("Name"));
    }
    #endregion

    #region CollectionSubsetConstraintExamples
    [Test]
    public void CollectionSubsetConstraint_Examples()
    {
        int[] superset = { 1, 2, 3, 4, 5 };

        Assert.That(new[] { 1, 3 }, Is.SubsetOf(superset));       // Passes
        Assert.That(new[] { 1, 2, 3, 4, 5 }, Is.SubsetOf(superset)); // Passes (equal sets are subsets)
        Assert.That(new int[] { }, Is.SubsetOf(superset));        // Passes (empty set is subset of any set)
        Assert.That(new[] { 1, 6 }, Is.Not.SubsetOf(superset));   // Passes (6 not in superset)

        // Case-insensitive string comparison
        string[] colors = { "Red", "Green", "Blue" };
        Assert.That(new[] { "red", "blue" }, Is.SubsetOf(colors).Using((IEqualityComparer<string>)StringComparer.OrdinalIgnoreCase));
    }
    #endregion

    #region CollectionSupersetConstraintExamples
    [Test]
    public void CollectionSupersetConstraint_Examples()
    {
        int[] actual = { 1, 2, 3, 4, 5 };

        Assert.That(actual, Is.SupersetOf(new[] { 1, 3 }));       // Passes
        Assert.That(actual, Is.SupersetOf(new[] { 1, 2, 3, 4, 5 })); // Passes (equal sets)
        Assert.That(actual, Is.SupersetOf(new int[] { }));        // Passes (superset of empty)
        Assert.That(actual, Is.Not.SupersetOf(new[] { 1, 6 }));   // Passes (missing 6)

        // Case-insensitive string comparison
        string[] colors = { "Red", "Green", "Blue", "Yellow" };
        Assert.That(colors, Is.SupersetOf(new[] { "red", "blue" }).Using((IEqualityComparer<string>)StringComparer.OrdinalIgnoreCase));
    }
    #endregion

    #region ExactCountConstraintExamples
    [Test]
    public void ExactCountConstraint_Examples()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        string[] names = { "Alice", "Bob", "Carol" };

        // Count total items
        Assert.That(numbers, Has.Exactly(5).Items);
        Assert.That(names, Has.Exactly(3).Items);

        // Count items matching a constraint
        Assert.That(numbers, Has.Exactly(2).GreaterThan(3));       // 4 and 5
        Assert.That(numbers, Has.Exactly(3).LessThanOrEqualTo(3)); // 1, 2, and 3
        Assert.That(names, Has.Exactly(1).Length.EqualTo(3));      // "Bob"

        // Combining multiple counts
        Assert.That(numbers, Has.Exactly(2).LessThan(3).And.Exactly(2).GreaterThan(3));

        // Zero items matching
        Assert.That(numbers, Has.Exactly(0).LessThan(0));          // No negatives
    }
    #endregion

    #region EmptyCollectionConstraintExamples
    [Test]
    public void EmptyCollectionConstraint_Examples()
    {
        // Empty collections
        Assert.That(new int[] { }, Is.Empty);
        Assert.That(new List<string>(), Is.Empty);
        Assert.That(Array.Empty<int>(), Is.Empty);
        Assert.That(Enumerable.Empty<string>(), Is.Empty);

        // Non-empty collections
        Assert.That(new[] { 1, 2, 3 }, Is.Not.Empty);
        Assert.That(new List<string> { "item" }, Is.Not.Empty);
    }
    #endregion

    #region CollectionEquivalentConstraintExamples
    [Test]
    public void CollectionEquivalentConstraint_Examples()
    {
        int[] expected = { 1, 2, 3 };
        int[] actual = { 3, 2, 1 };

        // Order doesn't matter
        Assert.That(actual, Is.EquivalentTo(expected));

        // Different collections with same elements
        Assert.That(new List<int> { 1, 2, 3 }, Is.EquivalentTo(new[] { 3, 1, 2 }));

        // Duplicates matter
        Assert.That(new[] { 1, 1, 2 }, Is.Not.EquivalentTo(new[] { 1, 2, 2 }));
        Assert.That(new[] { 1, 1, 2 }, Is.EquivalentTo(new[] { 2, 1, 1 }));

        // Case-insensitive for strings
        Assert.That(new[] { "A", "B" }, Is.EquivalentTo(new[] { "b", "a" }).IgnoreCase);
    }
    #endregion
}

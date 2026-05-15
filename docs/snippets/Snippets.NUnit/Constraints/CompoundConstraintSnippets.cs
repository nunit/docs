using NUnit.Framework;

#pragma warning disable NUnit2045

namespace Snippets.NUnit.Constraints;

public class CompoundConstraintSnippets
{
    #region AndConstraintExamples
    [Test]
    public void AndConstraint_Examples()
    {
        int value = 42;

        // Both conditions must be true
        Assert.That(value, Is.GreaterThan(0).And.LessThan(100));
        Assert.That(value, Is.Positive.And.LessThanOrEqualTo(50).Or.GreaterThanOrEqualTo(40));

        // String constraints
        Assert.That("Hello World", Does.StartWith("Hello").And.EndWith("World"));
        Assert.That("test@example.com", Does.Contain("@").And.EndWith(".com"));

        // Null checking pattern (check null first!)
        int? nullable = 42;
        Assert.That(nullable, Is.Not.Null.And.GreaterThan(0));

        // Collection constraints
        Assert.That(new[] { 1, 2, 3 }, Is.Not.Empty.And.All.Positive);
    }
    #endregion

    #region AndConstraintNullCheckExamples
    [Test]
    public void AndConstraint_NullCheck_Examples()
    {
        int? value = 42;

        // CORRECT: Check null first - fails gracefully with message for null
        Assert.That(value, Is.Not.Null.And.GreaterThan(9));
    }
    #endregion

    #region OrConstraintExamples
    [Test]
    public void OrConstraint_Examples()
    {
        int value = 42;

        // Either condition can be true
        Assert.That(value, Is.LessThan(10).Or.GreaterThan(40));
        Assert.That(value, Is.EqualTo(0).Or.Positive);

        // String constraints
        Assert.That("test", Does.StartWith("te").Or.EndWith("ing"));

        // Multiple alternatives
        Assert.That(value, Is.EqualTo(1).Or.EqualTo(42).Or.EqualTo(100));
    }
    #endregion

    #region OrConstraintNullPatternExamples
    [Test]
    public void OrConstraint_NullPattern_Examples()
    {
        int? nullable = null;

        // Null-or-value pattern (check null first!)
        Assert.That(nullable, Is.Null.Or.GreaterThan(0));  // Passes for null

        // Collection: empty or contains specific item
        var items = new List<int>();
        Assert.That(items, Is.Empty.Or.Contains(1));
    }
    #endregion

    #region NotConstraintExamples
    [Test]
    public void NotConstraint_Examples()
    {
        // Basic negation
        Assert.That(42, Is.Not.EqualTo(0));
        Assert.That("Hello", Is.Not.Null);
        Assert.That("Hello", Is.Not.Empty);

        // String negation
        Assert.That("Hello World", Does.Not.Contain("Goodbye"));
        Assert.That("test.txt", Does.Not.EndWith(".pdf"));

        // Collection negation
        Assert.That(new[] { 1, 2, 3 }, Has.No.Member(0));
        Assert.That(new[] { 1, 2, 3 }, Is.Not.Empty);
        Assert.That(new[] { 1, 2, 3 }, Has.None.Negative);

        // Type negation
        Assert.That("Hello", Is.Not.InstanceOf<int>());

        // Combined with And/Or
        object obj = 42;
        Assert.That(obj, Is.Not.Null.And.InstanceOf<int>());
        Assert.That("test", Is.Not.Null.And.Not.Empty);
    }
    #endregion
}

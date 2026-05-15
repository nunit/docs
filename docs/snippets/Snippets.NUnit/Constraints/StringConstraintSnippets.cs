using System.Globalization;
using NUnit.Framework;

#pragma warning disable NUnit2045

namespace Snippets.NUnit.Constraints;

public class StringConstraintSnippets
{
    #region StartsWithConstraintExamples
    [Test]
    public void StartsWithConstraint_Examples()
    {
        string phrase = "Make your tests fail before passing!";

        Assert.That(phrase, Does.StartWith("Make"));
        Assert.That(phrase, Does.StartWith("MAKE").IgnoreCase);
        Assert.That(phrase, Does.Not.StartWith("Break"));
    }
    #endregion

    #region StartsWithConstraintStringComparisonExamples
    [Test]
    public void StartsWithConstraint_StringComparison_Examples()
    {
        Assert.That("Hello World!", Does.StartWith("HELLO").Using(StringComparison.OrdinalIgnoreCase));
        Assert.That("Hello World!", Does.StartWith("Hello").Using(StringComparison.Ordinal));
    }
    #endregion

    #region EndsWithConstraintExamples
    [Test]
    public void EndsWithConstraint_Examples()
    {
        string phrase = "Make your tests fail before passing!";

        Assert.That(phrase, Does.EndWith("!"));
        Assert.That(phrase, Does.EndWith("passing!"));
        Assert.That(phrase, Does.EndWith("PASSING!").IgnoreCase);
        Assert.That(phrase, Does.Not.EndWith("failing"));
    }
    #endregion

    #region SubstringConstraintExamples
    [Test]
    public void SubstringConstraint_Examples()
    {
        string phrase = "Make your tests fail before passing!";

        Assert.That(phrase, Does.Contain("tests"));
        Assert.That(phrase, Does.Contain("TESTS").IgnoreCase);
        Assert.That(phrase, Does.Not.Contain("missing"));
    }
    #endregion

    #region SubstringConstraintStringComparisonExamples
    [Test]
    public void SubstringConstraint_StringComparison_Examples()
    {
        // IgnoreCase modifier
        Assert.That("Hello World!", Does.Contain("WORLD").IgnoreCase);
        Assert.That("Hello World!", Does.Contain("World"));
    }
    #endregion

    #region RegexConstraintExamples
    [Test]
    public void RegexConstraint_Examples()
    {
        string phrase = "Make your tests fail before passing!";

        Assert.That(phrase, Does.Match("Make.*tests.*pass"));
        Assert.That(phrase, Does.Match("make.*tests.*PASS").IgnoreCase);
        Assert.That(phrase, Does.Not.Match("your.*passing.*tests"));
    }
    #endregion

    #region RegexConstraintPatternExamples
    [Test]
    public void RegexConstraint_Pattern_Examples()
    {
        // Email validation (simplified)
        Assert.That("user@example.com", Does.Match(@"^[\w.-]+@[\w.-]+\.\w+$"));

        // Phone number format
        Assert.That("555-123-4567", Does.Match(@"^\d{3}-\d{3}-\d{4}$"));

        // Starts with digit
        Assert.That("42 is the answer", Does.Match(@"^\d"));

        // Contains only letters and spaces
        Assert.That("Hello World", Does.Match(@"^[a-zA-Z\s]+$"));

        // ISO date format
        Assert.That("2024-01-15", Does.Match(@"^\d{4}-\d{2}-\d{2}$"));
    }
    #endregion

    #region EmptyStringConstraintExamples
    [Test]
    public void EmptyStringConstraint_Examples()
    {
        Assert.That("", Is.Empty);
        Assert.That(string.Empty, Is.Empty);
        Assert.That("Hello", Is.Not.Empty);

        // Common pattern: check for null or empty
        string? result = "";
        Assert.That(result, Is.Null.Or.Empty);

        string name = "Alice";
        Assert.That(name, Is.Not.Null.And.Not.Empty);
    }
    #endregion

    #region WhiteSpaceConstraintExamples
    [Test]
    public void WhiteSpaceConstraint_Examples()
    {
        Assert.That("", Is.WhiteSpace);           // Empty string
        Assert.That(" ", Is.WhiteSpace);          // Space
        Assert.That("  \t\n", Is.WhiteSpace);     // Mixed whitespace
        Assert.That(null, Is.WhiteSpace);         // Null

        Assert.That("Hello", Is.Not.WhiteSpace);
        Assert.That(" Hello ", Is.Not.WhiteSpace);  // Has non-whitespace content
    }
    #endregion
}

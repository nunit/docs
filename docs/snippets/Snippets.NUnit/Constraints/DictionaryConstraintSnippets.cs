using NUnit.Framework;

#pragma warning disable NUnit2045

namespace Snippets.NUnit.Constraints;

public class DictionaryConstraintSnippets
{
    #region DictionaryContainsKeyConstraintExamples
    [Test]
    public void DictionaryContainsKeyConstraint_Examples()
    {
        var dictionary = new Dictionary<string, int>
        {
            ["Alice"] = 30,
            ["Bob"] = 25
        };

        // Basic key checks
        Assert.That(dictionary, Contains.Key("Alice"));
        Assert.That(dictionary, Does.ContainKey("Bob"));
        Assert.That(dictionary, Does.Not.ContainKey("Carol"));

        // Check key with corresponding value
        Assert.That(dictionary, Does.ContainKey("Alice").WithValue(30));
        Assert.That(dictionary, Does.ContainKey("Bob").WithValue(25));
    }
    #endregion

    #region DictionaryContainsKeyComparerExamples
    [Test]
    public void DictionaryContainsKey_Comparer_Examples()
    {
        // Case-sensitive dictionary (default)
        var caseSensitive = new Dictionary<string, string> { ["Hello"] = "World" };
        Assert.That(caseSensitive, Does.ContainKey("Hello"));
        Assert.That(caseSensitive, Does.Not.ContainKey("hello"));  // Different case

        // Case-insensitive dictionary
        var caseInsensitive = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            ["Hello"] = "World"
        };
        Assert.That(caseInsensitive, Does.ContainKey("Hello"));
        Assert.That(caseInsensitive, Does.ContainKey("hello"));    // Same due to comparer

        // Note: .IgnoreCase on WithValue applies to the VALUE, not the key
        Assert.That(caseInsensitive, Does.ContainKey("hello").WithValue("world").IgnoreCase);
    }
    #endregion

    #region DictionaryContainsValueConstraintExamples
    [Test]
    public void DictionaryContainsValueConstraint_Examples()
    {
        var scores = new Dictionary<string, int>
        {
            ["Alice"] = 100,
            ["Bob"] = 85,
            ["Carol"] = 100
        };

        // Basic value checks
        Assert.That(scores, Contains.Value(100));
        Assert.That(scores, Does.ContainValue(85));
        Assert.That(scores, Does.Not.ContainValue(50));

        // String values with case-insensitive comparison
        var names = new Dictionary<int, string>
        {
            [1] = "Alice",
            [2] = "Bob"
        };
        Assert.That(names, Does.ContainValue("alice").IgnoreCase);
    }
    #endregion

    #region DictionaryContainsKeyValuePairConstraintExamples
    [Test]
    public void DictionaryContainsKeyValuePairConstraint_Examples()
    {
        var translations = new Dictionary<string, string>
        {
            ["Hello"] = "World",
            ["Hola"] = "Mundo"
        };

        // Check for specific key-value pair
        Assert.That(translations, Does.ContainKey("Hello").WithValue("World"));
        Assert.That(translations, Does.ContainKey("Hola").WithValue("Mundo"));

        // Negative: key exists but value doesn't match
        Assert.That(translations, Does.Not.ContainKey("Hello").WithValue("Universe"));

        // Case-insensitive value comparison
        Assert.That(translations, Does.ContainKey("Hello").WithValue("WORLD").IgnoreCase);
    }
    #endregion
}

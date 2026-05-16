using System.Collections.Generic;
using NUnit.Framework;

#pragma warning disable NUnit2045

namespace Snippets.NUnit.Constraints;

public class ContainsHelperSnippets
{
    #region ContainsHelperStringExamples
    [Test]
    public void ContainsHelper_String_Examples()
    {
        string text = "Hello World";

        // Test for substring
        Assert.That(text, Contains.Substring("World"));
        Assert.That(text, Contains.Substring("WORLD").IgnoreCase);

        // Equivalent to Does.Contain for strings
        Assert.That(text, Does.Contain("World"));
    }
    #endregion

    #region ContainsHelperCollectionExamples
    [Test]
    public void ContainsHelper_Collection_Examples()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };

        // Test for item in collection
        Assert.That(numbers, Contains.Item(3));
        Assert.That(numbers, Does.Contain(3).And.Contain(5));

        // Equivalent forms
        Assert.That(numbers, Does.Contain(3));
        Assert.That(numbers, Has.Member(3));
    }
    #endregion

    #region ContainsHelperDictionaryExamples
    [Test]
    public void ContainsHelper_Dictionary_Examples()
    {
        var dict = new Dictionary<string, int>
        {
            ["Alice"] = 30,
            ["Bob"] = 25
        };

        // Test for key
        Assert.That(dict, Contains.Key("Alice"));

        // Test for value
        Assert.That(dict, Contains.Value(30));

        // Test for key-value pair
        Assert.That(dict, Contains.Key("Alice").WithValue(30));
    }
    #endregion

    #region ContainsHelperSmartRoutingExamples
    [Test]
    public void ContainsHelper_SmartRouting_Examples()
    {
        var dict = new Dictionary<string, int>
        {
            ["Alice"] = 30,
            ["Bob"] = 25
        };

        // String -> SubstringConstraint
        Assert.That("Hello World", Does.Contain("World"));

        // Collection -> SomeItemsConstraint
        Assert.That(new[] { 1, 2, 3 }, Does.Contain(2));

        // Dictionary key check
        Assert.That(dict, Does.ContainKey("Alice"));
        Assert.That(dict, Does.ContainValue(30));
    }
    #endregion
}

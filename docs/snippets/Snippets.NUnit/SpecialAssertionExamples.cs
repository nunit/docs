using NUnit.Framework;

#pragma warning disable CA1822

namespace Snippets.NUnit;

public class SpecialAssertionExamples
{
    #region AssertFailHelper
    public void AssertStringContains(string expected, string actual)
    {
        AssertStringContains(expected, actual, string.Empty);
    }

    public void AssertStringContains(string expected, string actual, string message)
    {
        if (actual.IndexOf(expected, StringComparison.Ordinal) < 0)
            Assert.Fail(message);
    }
    #endregion

    [Test]
    public void AssertFailHelperPassesWhenSubstringIsPresent()
    {
        AssertStringContains("fail", "Make your tests fail before passing!");
    }

    [Test]
    public void AssertFailHelperFailsWithMessageWhenSubstringIsMissing()
    {
        Assert.That(() => AssertStringContains("pass", "Nope", "Expected the word pass"),
            Throws.TypeOf<AssertionException>().With.Message.Contains("Expected the word pass"));
    }
}

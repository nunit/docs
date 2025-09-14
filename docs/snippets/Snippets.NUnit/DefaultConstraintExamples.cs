using NUnit.Framework;

namespace Snippets.NUnit;

public class DefaultConstraintExamples
{
    #region DefaultConstraintExample
    [Test]
    public void DefaultConstraintExample()
    {
        string defaultLength = string.Empty;
        var nonDefaultLength = "1";
        var defaultList = new List<int>(); 
        var nonDefaultList = new List<int> {1};
        var defaultDate = default(DateTime);
        var nonDefaultDate = DateTime.Now;

        using (Assert.EnterMultipleScope())
        {
            Assert.That(defaultLength.Length, Is.Zero);
            Assert.That(defaultLength.Length, Is.Default);
            Assert.That(defaultLength, Has.Length.Default);
            Assert.That(defaultLength, Has.Property("Length").Default);
            Assert.That(defaultList, Has.Count.Default);
            Assert.That(defaultDate, Is.Default);

            Assert.That(nonDefaultLength.Length, Is.Not.Zero);
            Assert.That(nonDefaultLength.Length, Is.Not.Default);
            Assert.That(nonDefaultLength, Has.Length.Not.Default);
            Assert.That(nonDefaultLength, Has.Property("Length").Not.Default);
            Assert.That(nonDefaultList, Has.Count.Not.Default);
            Assert.That(nonDefaultDate, Is.Not.Default);
        }
    }
    #endregion
}
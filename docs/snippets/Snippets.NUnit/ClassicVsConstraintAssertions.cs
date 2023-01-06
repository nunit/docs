namespace Snippets.NUnit;

public class ClassicVsConstraintAssertions
{
    [Test]
    public void TheTest()
    {
        #region ConstraintWithoutClassicEquivalent
        int[] array = { 1, 2, 3 };
        Assert.That(array, Has.Exactly(1).EqualTo(3));
        Assert.That(array, Has.Exactly(2).GreaterThan(1));
        Assert.That(array, Has.Exactly(3).LessThan(100));
        #endregion

        #region ClassicAndConstraintsAreEquivalent
        Assert.AreEqual(4, 2 + 2);
        Assert.That(2 + 2, Is.EqualTo(4));
        #endregion
    }
}
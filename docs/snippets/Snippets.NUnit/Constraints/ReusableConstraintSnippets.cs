using NUnit.Framework;
using NUnit.Framework.Constraints;

#pragma warning disable CA1822
#pragma warning disable NUnit2045

namespace Snippets.NUnit.Constraints;

public class ReusableConstraintSnippets
{
    #region ReusableConstraintProblem
    [Test, Explicit("Fails on purpose to show the problem with reusing an unresolved constraint")]
    public void ReusingAnUnresolvedConstraint()
    {
        Constraint myConstraint = Is.Not.Null;
        Assert.That("not a null", myConstraint); // Passes, of course
        Assert.That("not a null", myConstraint); // Fails! What is that about?
    }
    #endregion

    #region ReusableConstraintImplicit
    [Test]
    public void ReusableConstraintByAssignment()
    {
        ReusableConstraint myConstraint = Is.Not.Null;
        Assert.That("not a null", myConstraint); // Passes
        Assert.That("not a null", myConstraint); // Passes
    }
    #endregion

    #region ReusableConstraintExplicit
    [Test]
    public void ReusableConstraintByConstructor()
    {
        var myConstraint = new ReusableConstraint(Is.Not.Null);
        Assert.That("not a null", myConstraint); // Passes
        Assert.That("not a null", myConstraint); // Passes
    }
    #endregion

    [Test]
    public void ReusingAnUnresolvedConstraintFailsOnSecondUse()
    {
        Constraint myConstraint = Is.Not.Null;
        Assert.That("not a null", myConstraint);
        Assert.That(() => Assert.That("not a null", myConstraint), Throws.TypeOf<AssertionException>());
    }
}

using NUnit.Framework;

namespace Snippets.NUnit.Constraints;

public class PathConstraintSnippets
{
    #region SamePathConstraintExamples
    [Test]
    public void SamePathConstraint_Examples()
    {
        Assert.That("/folder1/./junk/../folder2", Is.SamePath("/folder1/folder2"));
        Assert.That("/folder1/./junk/../folder2/x", Is.Not.SamePath("/folder1/folder2"));

        Assert.That(@"C:\folder1\folder2", Is.SamePath(@"C:\Folder1\Folder2").IgnoreCase);
        Assert.That("/folder1/folder2", Is.Not.SamePath("/Folder1/Folder2").RespectCase);
    }
    #endregion

    #region SamePathOrUnderConstraintExamples
    [Test]
    public void SamePathOrUnderConstraint_Examples()
    {
        Assert.That("/folder1/./junk/../folder2", Is.SamePathOrUnder("/folder1/folder2"));
        Assert.That("/folder1/junk/../folder2/./folder3", Is.SamePathOrUnder("/folder1/folder2"));
        Assert.That("/folder1/junk/folder2/folder3", Is.Not.SamePathOrUnder("/folder1/folder2"));

        Assert.That(@"C:\folder1\folder2\folder3", Is.SamePathOrUnder(@"C:\Folder1\Folder2").IgnoreCase);
        Assert.That("/folder1/folder2/folder3", Is.Not.SamePathOrUnder("/Folder1/Folder2").RespectCase);
    }
    #endregion

    #region SubPathConstraintExamples
    [Test]
    public void SubPathConstraint_Examples()
    {
        Assert.That("/folder1/./junk/../folder2", Is.SubPathOf("/folder1/"));
        Assert.That("/folder1/junk/folder2", Is.Not.SubPathOf("/folder1/folder2"));

        Assert.That(@"C:\folder1\folder2\Folder3", Is.SubPathOf(@"C:\Folder1\Folder2").IgnoreCase);
        Assert.That("/folder1/folder2/folder3", Is.Not.SubPathOf("/Folder1/Folder2/Folder3").RespectCase);
    }
    #endregion
}

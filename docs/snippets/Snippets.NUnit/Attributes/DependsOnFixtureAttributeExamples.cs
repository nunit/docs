using NUnit.Framework;

namespace Snippets.NUnit.Attributes;

public class DependsOnFixtureAttributeExamples
{
    #region DependsOnFixture
    [TestFixture]
    public sealed class DatabaseFixture
    {
        [Test]
        public void CreateSchema()
        {
        }
    }

    [TestFixture]
    [DependsOnFixture(typeof(DatabaseFixture))]
    public sealed class ReportingFixture
    {
        [Test]
        public void GenerateReport()
        {
        }
    }

    [TestFixture]
    [DependsOnFixture(typeof(DatabaseFixture), AllowFailure = true)]
    public sealed class CleanupFixture
    {
        [Test]
        public void RemoveTemporaryFiles()
        {
        }
    }
    #endregion
}

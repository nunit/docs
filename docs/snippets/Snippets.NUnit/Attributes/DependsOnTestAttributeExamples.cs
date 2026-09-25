using NUnit.Framework;

namespace Snippets.NUnit.Attributes;

public class DependsOnTestAttributeExamples
{
    #region DependsOnTest
    [TestFixture]
    public sealed class DependencyExamples
    {
        [Test]
        public void CreateSharedData()
        {
        }

        [Test]
        [DependsOnTest(nameof(CreateSharedData))]
        public void ValidateSharedData()
        {
        }

        [Test]
        [DependsOnTest(nameof(CreateSharedData), AllowFailure = true)]
        public void CleanupSharedData()
        {
        }
    }
    #endregion
}

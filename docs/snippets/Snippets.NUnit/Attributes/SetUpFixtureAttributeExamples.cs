using NUnit.Framework;

namespace Snippets.NUnit.Attributes.SampleNamespace
{
    #region SetUpFixtureExample
    [SetUpFixture]
    public class MySetUpClass
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
        }
    }
    #endregion
}

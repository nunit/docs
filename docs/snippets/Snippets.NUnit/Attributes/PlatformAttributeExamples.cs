using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    public class PlatformAttributeExamples
    {
        #region PlatformAttributeExamples
        [TestFixture]
        [Platform("Win, Linux, MacOsX")]
        public class PortableTests
        {
            [Test]
            [Platform(Exclude = "Win98,WinME")]
            public void SomeTest()
            {
                Assert.Pass("Runs only on supported platforms.");
            }
        }
        #endregion
    }
}

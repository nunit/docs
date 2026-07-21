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
            [Platform(Excludes = ["Win98", "WinME"])]
            public void SomeTest()
            {
                Assert.Pass("Runs only on supported platforms.");
            }
        }

        [TestFixture]
        public class RuntimeSpecificTests
        {
            [Test]
            [Platform([PlatformNames.NETFramework])]
            public void SomeTest()
            {
                Assert.Pass("Runs only on .NET Framework");
            }
        }
        #endregion
    }
}

using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    #region NetPlatformFixture
    [TestFixture]
    [NetPlatform(Include = "windows")]
    public class WindowsOnlyTests
    {
        [Test]
        public void TestWindowsFeature()
        {
            // This test only runs on Windows
            Assert.Pass();
        }
    }
    #endregion

    [TestFixture]
    public class NetPlatformAttributeExamples
    {
        #region NetPlatformBasic
        [Test]
        [NetPlatform(Include = "windows")]
        public void RunOnWindowsOnly()
        {
            // This test only runs on Windows
            Assert.That(OperatingSystem.IsWindows(), Is.True);
        }
        #endregion

        #region NetPlatformExclude
        [Test]
        [NetPlatform(Exclude = "linux")]
        public void RunOnAllExceptLinux()
        {
            // This test runs on Windows, macOS, etc., but not Linux
            Assert.That(OperatingSystem.IsLinux(), Is.False);
        }
        #endregion

        #region NetPlatformVersion
        [Test]
        [NetPlatform(Include = "windows10.0")]
        public void RunOnWindows10OrLater()
        {
            // This test requires Windows 10 or later
            Assert.That(OperatingSystem.IsWindowsVersionAtLeast(10), Is.True);
        }
        #endregion

        #region NetPlatformMultiple
        [Test]
        [NetPlatform(Include = "windows,linux")]
        public void RunOnWindowsOrLinux()
        {
            // This test runs on Windows or Linux, but not macOS
            Assert.That(
                OperatingSystem.IsWindows() || OperatingSystem.IsLinux(),
                Is.True);
        }
        #endregion
    }
}

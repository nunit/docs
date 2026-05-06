using System.Threading;
using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    public class RequiresThreadAttributeExamples
    {
        #region RequiresThreadFixture
        [TestFixture]
        [RequiresThread]
        public class FixtureOnSeparateThread
        {
            [Test]
            public void TestRunsOnSeparateThread()
            {
                // All tests in this fixture run on a dedicated thread
                Assert.That(Thread.CurrentThread.IsThreadPoolThread, Is.False);
            }
        }
        #endregion

        #region RequiresThreadMethod
        [TestFixture]
        public class MixedThreadTests
        {
            [Test]
            [RequiresThread]
            public void TestOnSeparateThread()
            {
                // This test runs on a separate thread
                Assert.Pass();
            }

            [Test]
            [RequiresThread(ApartmentState.STA)]
            public void TestOnSTAThread()
            {
                // This test runs on a separate STA thread
                Assert.That(Thread.CurrentThread.GetApartmentState(), Is.EqualTo(ApartmentState.STA));
            }

            [Test]
            [RequiresThread(ApartmentState.MTA)]
            public void TestOnMTAThread()
            {
                // This test runs on a separate MTA thread
                Assert.That(Thread.CurrentThread.GetApartmentState(), Is.EqualTo(ApartmentState.MTA));
            }
        }
        #endregion
    }
}

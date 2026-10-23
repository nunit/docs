using System.Diagnostics;
using NUnit.Framework;
using NUnit.Framework.Diagnostics;

#pragma warning disable CA1822

namespace Snippets.NUnit.TraceOutput.ConsoleListener
{
    #region ConsoleTraceListenerSetUpFixture
    [SetUpFixture]
    public class SetupTrace
    {
        [OneTimeSetUp]
        public void StartTest()
        {
            Trace.Listeners.Add(new ConsoleTraceListener());
        }

        [OneTimeTearDown]
        public void EndTest()
        {
            Trace.Flush();
        }
    }
    #endregion

    public class VerboseTests
    {
        #region VerboseTest
        [Test]
        public void Test1()
        {
            Debug.WriteLine("This is Debug.WriteLine");
            Trace.WriteLine("This is Trace.WriteLine");
            Console.WriteLine("This is Console.Writeline");
            TestContext.WriteLine("This is TestContext.WriteLine");
            TestContext.Out.WriteLine("This is TestContext.Out.WriteLine");
            TestContext.Progress.WriteLine("This is TestContext.Progress.WriteLine");
            TestContext.Error.WriteLine("This is TestContext.Error.WriteLine");
            Assert.Pass();
        }
        #endregion
    }
}

namespace Snippets.NUnit.TraceOutput.ProgressListener
{
    #region ProgressTraceListenerSetUpFixture
    [SetUpFixture]
    public class SetupTrace
    {
        [OneTimeSetUp]
        public void StartTest()
        {
            if (!Trace.Listeners.OfType<ProgressTraceListener>().Any())
                Trace.Listeners.Add(new ProgressTraceListener());
        }
    }
    #endregion

    public class ProgressListenerTests
    {
        [Test]
        public void TraceOutputIsShownImmediately()
        {
            Trace.WriteLine("This is Trace.WriteLine, shown immediately by the ProgressTraceListener");
            Assert.That(Trace.Listeners.OfType<ProgressTraceListener>().Count(), Is.EqualTo(1));
        }
    }
}

using System.Collections.Concurrent;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal.Builders;
using MethodWrapper = NUnit.Framework.Internal.MethodWrapper;
using ParameterizedMethodSuite = NUnit.Framework.Internal.ParameterizedMethodSuite;
using PropertyNames = NUnit.Framework.Internal.PropertyNames;

#pragma warning disable CA1822

namespace Snippets.NUnit.ParallelGuide
{
    /// <summary>
    /// Stands in for a resource that must not be used from two threads at once,
    /// such as a Selenium web driver or a database connection.
    /// </summary>
    public sealed class Session : IDisposable
    {
        public int CallCount { get; private set; }

        public string Call(string input)
        {
            CallCount++;
            return input.ToUpperInvariant();
        }

        public void Dispose()
        {
        }
    }

    #region ParallelFixtureSelf
    // Runs alongside other fixtures; its two tests run one after the other.
    [Parallelizable]
    public class OrderCalculatorTests
    {
        [Test]
        public void Total_AddsLineItems()
        {
            Assert.That(2 + 3, Is.EqualTo(5));
        }

        [Test]
        public void Total_IsZeroForEmptyOrder()
        {
            Assert.That(0, Is.EqualTo(0));
        }
    }
    #endregion

    #region ParallelInstancePerTestCase
    [Parallelizable(ParallelScope.All)]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class SessionTests
    {
        private Session _session = null!;

        [SetUp]
        public void OpenSession()
        {
            // Each test gets its own fixture instance, so each test gets its own session.
            _session = new Session();
        }

        [TearDown]
        public void CloseSession()
        {
            _session.Dispose();
        }

        [Test]
        public void Call_ReturnsUpperCase()
        {
            Assert.That(_session.Call("abc"), Is.EqualTo("ABC"));
        }

        [Test]
        public void Call_CountsCalls()
        {
            _session.Call("x");
            _session.Call("y");

            // Would be unreliable if another test on another thread shared this session.
            Assert.That(_session.CallCount, Is.EqualTo(2));
        }
    }
    #endregion

    #region ParallelNonParallelizable
    public static class SharedCache
    {
        public static readonly ConcurrentDictionary<string, string> Entries = new();
    }

    // Uses a static resource, so it must not overlap with anything else that touches it.
    [NonParallelizable]
    public class SharedCacheTests
    {
        [SetUp]
        public void ClearCache()
        {
            SharedCache.Entries.Clear();
        }

        [Test]
        public void Cache_StartsEmpty()
        {
            Assert.That(SharedCache.Entries, Is.Empty);
        }

        [Test]
        public void Cache_StoresEntry()
        {
            SharedCache.Entries["key"] = "value";

            Assert.That(SharedCache.Entries, Has.Count.EqualTo(1));
        }
    }
    #endregion

    #region ParallelTestCases
    public class SlugTests
    {
        // The three cases of this test run in parallel with one another.
        [TestCase("Hello World", "hello-world")]
        [TestCase("  NUnit  ", "nunit")]
        [TestCase("A/B", "a-b")]
        [Parallelizable(ParallelScope.All)]
        public void ToSlug_NormalizesInput(string input, string expected)
        {
            var slug = input.Trim().ToLowerInvariant().Replace(' ', '-').Replace('/', '-');

            Assert.That(slug, Is.EqualTo(expected));
        }
    }
    #endregion

    #region ParallelThrottle
    public class RateLimitedServiceTests
    {
        // At most two cases call the service at the same time, whatever the worker count.
        private static readonly SemaphoreSlim Throttle = new(2);

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [Parallelizable(ParallelScope.All)]
        public async Task Service_HandlesRequest(int request)
        {
            await Throttle.WaitAsync();
            try
            {
                await Task.Delay(10);
                Assert.That(request, Is.Positive);
            }
            finally
            {
                Throttle.Release();
            }
        }
    }
    #endregion
}

#region ParallelGroupIsolated
namespace Snippets.NUnit.ParallelGuide.Reporting
{
    // Nothing outside this namespace runs while the fixtures in it run.
    [SetUpFixture]
    [NonParallelizable]
    public class ReportingSetUp
    {
        [OneTimeSetUp]
        public void StartReportServer()
        {
        }

        [OneTimeTearDown]
        public void StopReportServer()
        {
        }
    }

    // Within the group, these two fixtures run in parallel with each other.
    [Parallelizable]
    public class DailyReportTests
    {
        [Test]
        public void Report_HasHeader() => Assert.Pass();
    }

    [Parallelizable]
    public class MonthlyReportTests
    {
        [Test]
        public void Report_HasTotals() => Assert.Pass();
    }
}
#endregion

namespace Snippets.NUnit.ParallelGuide
{
    /// <summary>
    /// Not referenced from the docs. Checks the claims the guide makes about which scopes
    /// are valid on a test method, by building the tests the way NUnit does.
    /// </summary>
    public class ParallelScopeVerification
    {
        private static class Holder
        {
            // Not a test: no [Test] attribute, so NUnit never discovers it. The analyzer
            // still flags the invalid scope, which is the point being verified here.
#pragma warning disable NUnit1009
            [Parallelizable(ParallelScope.All)]
            public static void PlainMethodWithAll()
            {
            }
#pragma warning restore NUnit1009
        }

        [Test]
        public void AllOnPlainTestMethod_IsNotRunnable()
        {
            var method = new MethodWrapper(typeof(Holder), nameof(Holder.PlainMethodWithAll));

            var test = new NUnitTestCaseBuilder().BuildTestMethod(method, null, null);

            Assert.That(test.RunState, Is.EqualTo(RunState.NotRunnable));
            Assert.That(test.Properties.Get(PropertyNames.SkipReason),
                Is.EqualTo("May not specify ParallelScope.Children on a non-parameterized test method"));
        }

        [Test]
        public void AllOnParameterizedTestMethod_IsRunnable()
        {
            var method = new MethodWrapper(typeof(SlugTests), nameof(SlugTests.ToSlug_NormalizesInput));

            var suite = new DefaultTestCaseBuilder().BuildFrom(method, null);

            Assert.That(suite, Is.TypeOf<ParameterizedMethodSuite>());
            Assert.That(suite.RunState, Is.EqualTo(RunState.Runnable));
            Assert.That(suite.Tests, Has.Count.EqualTo(3));
        }
    }
}

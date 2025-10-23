using NUnit.Framework;
using NUnit.Framework.Internal.ExecutionHooks;

namespace Snippets.NUnit
{
    public class ExecutionHookExamples
    {
        #region TimingHookAttribute
        [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
        public sealed class TimeMeasurementHookAttribute : ExecutionHookAttribute
        {
            private readonly Dictionary<string, DateTime> _starts = new();

            public override void BeforeEverySetUpHook(HookData hookData)
            {
                _starts[hookData.Context.Test.FullName] = DateTime.UtcNow;
            }

            public override void AfterEverySetUpHook(HookData hookData)
            {
                var key = hookData.Context.Test.FullName;
                if (_starts.TryGetValue(key, out var start))
                {
                    var elapsed = DateTime.UtcNow - start;
                    TestContext.WriteLine($"[Timing] " +
                        $"{hookData.Context.Test.MethodName} " +
                        $"took {elapsed.TotalMilliseconds:F1} ms");
                }
            }
        }
        #endregion

        #region Usage
        [TestFixture]
        [TimeMeasurementHook]
        public class SampleTests
        {
            [SetUp]
            public void HeavySetUp() { /* ... */ }

            [Test]
            public void FastTest() { /* ... */ }
        }
        #endregion

        #region LoggingAllPhases
        [AttributeUsage(AttributeTargets.Method)]
        public sealed class LogAllHooksAttribute : ExecutionHookAttribute
        {
            private void Log(string phase, HookData data, bool withException = false)
            {
                var name = data.Context.Test.MethodName;
                var exInfo = withException && data.Exception != null ? 
                    $" (EX: {data.Exception.GetType().Name})" : string.Empty;
                TestContext.WriteLine($"[{phase}] {name}{exInfo}");
            }

            public override void BeforeEverySetUpHook(HookData d) 
                => Log("BeforeEverySetUp", d);

            public override void AfterEverySetUpHook(HookData d) 
                => Log("AfterEverySetUp", d, withException: true);

            public override void BeforeTestHook(HookData d) 
                => Log("BeforeTest", d);

            public override void AfterTestHook(HookData d) 
                => Log("AfterTest", d, withException: true);

            public override void BeforeEveryTearDownHook(HookData d) 
                => Log("BeforeEveryTearDown", d);

            public override void AfterEveryTearDownHook(HookData d) 
                => Log("AfterEveryTearDown", d, withException: true);
        }
        #endregion
    }
}
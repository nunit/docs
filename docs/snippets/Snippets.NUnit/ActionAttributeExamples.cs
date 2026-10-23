using NUnit.Framework;
using NUnit.Framework.Interfaces;

#pragma warning disable CA1822

namespace Snippets.NUnit.ActionAttributes
{
    #region ConsoleActionAttribute
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class |
                    AttributeTargets.Interface | AttributeTargets.Assembly,
                    AllowMultiple = true)]
    public class ConsoleActionAttribute : Attribute, ITestAction
    {
        private readonly string _message;

        public ConsoleActionAttribute(string message)
        {
            _message = message;
        }

        public void BeforeTest(ITest test)
        {
            WriteToConsole("Before", test);
        }

        public void AfterTest(ITest test)
        {
            WriteToConsole("After", test);
        }

        public ActionTargets Targets => ActionTargets.Test | ActionTargets.Suite;

        private void WriteToConsole(string eventMessage, ITest details)
        {
            Console.WriteLine("{0} {1}: {2}, from {3}.{4}.",
                eventMessage,
                details.IsSuite ? "Suite" : "Case",
                _message,
                details.TypeInfo is not null ? details.TypeInfo.Name : "{no fixture}",
                details.Method is not null ? details.Method.Name : "{no method}");
        }
    }
    #endregion

    namespace MethodExample1
    {
        #region MethodAttachedSimple
        [TestFixture]
        public class ActionAttributeSampleTests
        {
            [Test, ConsoleAction("Hello")]
            public void SimpleTest()
            {
                Console.WriteLine("Test ran.");
            }
        }
        #endregion
    }

    namespace MethodExample2
    {
        #region MethodAttachedTwice
        [TestFixture]
        public class ActionAttributeSampleTests
        {
            [Test]
            [ConsoleAction("Hello")]
            [ConsoleAction("Greetings")]
            public void SimpleTest()
            {
                Console.WriteLine("Test run.");
            }
        }
        #endregion
    }

    namespace MethodExample3
    {
        #region MethodAttachedTestCases
        [TestFixture]
        public class ActionAttributeSampleTests
        {
            [ConsoleAction("Hello")]
            [TestCase("02")]
            [TestCase("01")]
            public void SimpleTest(string number)
            {
                Console.WriteLine("Test run {0}.", number);
            }
        }
        #endregion
    }

    namespace TypeExample1
    {
        #region TypeAttached
        [TestFixture, ConsoleAction("Hello")]
        public class ActionAttributeSampleTests
        {
            [Test]
            public void SimpleTestOne()
            {
                Console.WriteLine("Test One.");
            }

            [Test]
            public void SimpleTestTwo()
            {
                Console.WriteLine("Test Two.");
            }
        }
        #endregion
    }

    namespace TypeExample2
    {
        #region InterfaceAttached
        [ConsoleAction("Hello")]
        public interface IHaveAnAction
        {
        }

        [TestFixture]
        public class ActionAttributeSampleTests : IHaveAnAction
        {
            [Test]
            public void SimpleTest()
            {
                Console.WriteLine("Test run.");
            }
        }
        #endregion
    }

    namespace TypeExample3
    {
        #region InterfaceAwareAction
        [AttributeUsage(AttributeTargets.Interface)]
        public class InterfaceAwareActionAttribute : TestActionAttribute
        {
            private readonly string _message;

            public InterfaceAwareActionAttribute(string message)
            {
                _message = message;
            }

            public override void BeforeTest(ITest details)
            {
                if (details.Fixture is IHaveAnAction obj)
                {
                    obj.Message = _message;
                }
            }

            public override ActionTargets Targets => ActionTargets.Test;
        }

        [InterfaceAwareAction("Hello")]
        public interface IHaveAnAction
        {
            string? Message { get; set; }
        }

        [TestFixture]
        public class ActionAttributeSampleTests : IHaveAnAction
        {
            [Test]
            public void SimpleTest()
            {
                Console.WriteLine("{0}, World!", Message);
                Assert.That(Message, Is.EqualTo("Hello"));
            }

            public string? Message { get; set; }
        }
        #endregion
    }

    namespace Verification
    {
        using System.Collections.Concurrent;

        // Not shown in the docs: records every call so the tests below can prove that
        // suite-level actions run before the first test case, as the documentation states.
        [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
        public class RecordingActionAttribute : Attribute, ITestAction
        {
            public static readonly ConcurrentQueue<string> Events = new();

            public void BeforeTest(ITest test) => Record("Before", test);

            public void AfterTest(ITest test) => Record("After", test);

            public ActionTargets Targets => ActionTargets.Test | ActionTargets.Suite;

            private static void Record(string eventMessage, ITest details) =>
                Events.Enqueue($"{eventMessage} {(details.IsSuite ? "Suite" : "Case")}: {details.Name}");
        }

        [TestFixture, RecordingAction]
        public class TypeAttachedActionRunsForTheSuite
        {
            [Test]
            public void SuiteBeforeTestRanBeforeThisTestCase()
            {
                Assert.That(RecordingActionAttribute.Events,
                    Does.Contain("Before Suite: " + nameof(TypeAttachedActionRunsForTheSuite)));
                Assert.That(RecordingActionAttribute.Events,
                    Does.Contain("Before Case: " + nameof(SuiteBeforeTestRanBeforeThisTestCase)));
            }
        }

        [TestFixture]
        public class MethodAttachedActionRunsForTheTestCaseSuite
        {
            [RecordingAction]
            [TestCase("02")]
            [TestCase("01")]
            public void SuiteBeforeTestRanBeforeTheTestCases(string number)
            {
                Assert.That(RecordingActionAttribute.Events,
                    Does.Contain("Before Suite: " + nameof(SuiteBeforeTestRanBeforeTheTestCases)));
                Assert.That(RecordingActionAttribute.Events,
                    Does.Contain($"Before Case: {nameof(SuiteBeforeTestRanBeforeTheTestCases)}(\"{number}\")"));
            }
        }
    }
}

using System;
using System.Text;
using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    public class TestCaseAttributeExamples
    {
        #region BasicTestCase
        [TestCase(12, 3, 4)]
        [TestCase(12, 2, 6)]
        [TestCase(12, 4, 3)]
        public void DivideTest(int n, int d, int q)
        {
            Assert.That(n / d, Is.EqualTo(q));
        }
        #endregion

        #region TestCaseWithExpectedResult
        [TestCase(12, 3, ExpectedResult = 4)]
        [TestCase(12, 2, ExpectedResult = 6)]
        [TestCase(12, 4, ExpectedResult = 3)]
        public int DivideTest(int n, int d)
        {
            return n / d;
        }
        #endregion

        #region TestCaseWithIgnore
        [TestCase(1, 1)]
        [TestCase(0, 0, Ignore = "Only ignore this")]
        [TestCase(1, 3)]
        public void AddTestWithIgnore(int a, int b)
        {
            var result = a + b;
            Assert.That(result, Is.GreaterThan(1));
        }
        #endregion

        #region TestCaseWithExplicit
        [TestCase(1, 1)]
        [TestCase(0, 0, Explicit = true, Reason = "This will fail so only run explicitly")]
        [TestCase(1, 3)]
        public void AddTestWithExplicit(int a, int b)
        {
            var result = a + b;
            Assert.That(result, Is.GreaterThan(1));
        }
        #endregion

        #region TestCaseWithCategory
        [TestCase(1, 1)]
        [TestCase(2, 0, Category = "Crazy")]
        [TestCase(1, 3)]
        public void AddTestWithCategory(int a, int b)
        {
            var result = a + b;
            Assert.That(result, Is.GreaterThan(1));
        }
        #endregion

        #region TestCaseWithDescriptionAuthorTestOf
        [TestFixture]
        public sealed class DescriptionAuthorTestOfExample
        {
            [TestCase(2,
                ExpectedResult = 4,
                Description = "Verify doubling for integer input",
                Author = "Snippet Author",
                TestOf = typeof(StringBuilder))] // System.Text (implicit usings)
            public int DoublesCorrectly(int n)
            {
                return n * 2;
            }
        }
        #endregion

        #region TestCaseWithPlatforms
        [TestFixture]
        public sealed class PlatformFilteringExample
        {
            /// <summary>Runs on all hosts; baseline case.</summary>
            [TestCase(1)]

            /// <summary>Usually still runs—excludes Xbox moniker only (see <c>Platform</c> attribute docs for names).</summary>
            [TestCase(2, ExcludePlatform = "XBox")]

            // IncludePlatform example (may skip on some hosts): [TestCase(3, IncludePlatform = "Net,Linux")]
            public void PlatformAwareCases(int id)
            {
                Assert.That(id, Is.InRange(1, 2));
            }
        }
        #endregion

        #region TestCaseWithTestName
        [TestFixture]
        public sealed class CustomNamesExample
        {
            [TestCase(10, ExpectedResult = 20, TestName = "Doubling_Positive_Value({a})")]
            [TestCase(-3, ExpectedResult = -6, TestName = "Doubling_Negative_Value({a})")]
            public int DoubleForDisplay(int input)
            {
                return input * 2;
            }
        }
        #endregion

        #region TestCaseWithIgnoreUntil
        [TestFixture]
        public sealed class IgnoreUntilExample
        {
            // Until requires IgnoreReason; expired dates revert to runnable (see Ignore attribute docs).

            [TestCase(99, IgnoreReason = "Stale doc sample ignore window", Until = "2001-01-01 12:00:00Z")]
            [TestCase(1)]
            public void IgnoreExpires(int value)
            {
                Assert.That(value, Is.Positive);
            }
        }
        #endregion

        #region TestCaseWithTypeArgs
        [TestFixture]
        public sealed class TypeArgsRuntimeExample
        {
            [TestCase(42, TypeArgs = new[] { typeof(int) })]
            [TestCase("sample", TypeArgs = new[] { typeof(string) })]
            public void GenericViaTypeArgs<T>(T payload)
            {
                Assert.That(payload, Is.Not.Null);
                Assert.That(typeof(T), Is.EqualTo(payload!.GetType()));
            }
        }
        #endregion
    }
}

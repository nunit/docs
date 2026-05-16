using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Snippets.NUnit.Attributes
{
    [TestFixture]
    public class NoTestsAttributeExamples
    {
        #region NoTestsSkipped
        [TestFixture]
        [NoTests(TestStatus.Skipped)]
        public class DynamicTestsFixture
        {
            // When no test cases are generated, the test will be marked as Skipped
            // instead of Failed (which is the default for Theory) or Passed
            [TestCaseSource(nameof(GetTestCases))]
            public void DynamicTest(int value)
            {
                Assert.That(value, Is.GreaterThan(0));
            }

            private static IEnumerable<int> GetTestCases()
            {
                // In real scenarios, this might query a database or external source
                // that could return empty results
                yield break; // No test cases
            }
        }
        #endregion

        #region NoTestsInconclusive
        [TestFixture]
        [NoTests(TestStatus.Inconclusive)]
        public class ConditionalTestsFixture
        {
            [TestCaseSource(nameof(GetConditionalCases))]
            public void ConditionalTest(string input)
            {
                Assert.That(input, Is.Not.Empty);
            }

            private static IEnumerable<string> GetConditionalCases()
            {
                // Returns empty when certain conditions aren't met
                if (Environment.GetEnvironmentVariable("RUN_CONDITIONAL_TESTS") == "true")
                {
                    yield return "test1";
                    yield return "test2";
                }
                // Otherwise yields nothing - test will be Inconclusive
            }
        }
        #endregion

        #region NoTestsOnMethod
        [TestFixture]
        public class MethodLevelNoTestsFixture
        {
            [NoTests(TestStatus.Skipped)]
            [TestCaseSource(nameof(EmptySource))]
            public void TestWithPossiblyEmptySource(int value)
            {
                Assert.That(value, Is.Positive);
            }

            private static IEnumerable<int> EmptySource()
            {
                yield break;
            }
        }
        #endregion

        #region NoTestsVerification
        [Test]
        public void VerifyNoTestsAttributeBehavior()
        {
            // This test verifies that NoTests attribute affects empty test sources
            // The actual behavior is seen when running the attributed fixtures above
            var attribute = new NoTestsAttribute(TestStatus.Skipped);

            // The attribute stores the status in properties
            Assert.That(attribute.Properties.Keys, Does.Contain("NoTests"));
        }
        #endregion
    }

    #region NoTestsDynamicData
    [TestFixture]
    [NoTests(TestStatus.Skipped)]
    public class DataDrivenTests
    {
        [TestCaseSource(typeof(ExternalDataSource))]
        public void ProcessData(int recordId)
        {
            Assert.That(recordId, Is.GreaterThan(0));
        }
    }

    public sealed class ExternalDataSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield break;
        }
    }
    #endregion

    [TestFixture]
    public class NoTestsConditionalExamples
    {
        #region NoTestsConditionalExecution
        [NoTests(TestStatus.Inconclusive)]
        [TestCaseSource(nameof(GetPlatformSpecificCases))]
        public void PlatformSpecificTest(string testCase)
        {
            Assert.That(testCase, Is.Not.Empty);
        }

        private static IEnumerable<string> GetPlatformSpecificCases()
        {
            yield break;
        }
        #endregion
    }

    #region NoTestsFeatureFlag
    [TestFixture]
    [NoTests(TestStatus.Skipped)]
    public class FeatureFlagTests
    {
        [TestCaseSource(nameof(GetEnabledFeatures))]
        public void TestFeature(string featureName)
        {
            Assert.That(featureName, Is.Not.Empty);
        }

        private static IEnumerable<string> GetEnabledFeatures()
        {
            yield break;
        }
    }
    #endregion
}

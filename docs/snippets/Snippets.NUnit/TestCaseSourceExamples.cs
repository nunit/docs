using System.Collections;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Legacy;

#pragma warning disable NUnit2046
#pragma warning disable IDE0044
#pragma warning disable CA2211
#pragma warning disable NUnit2005

namespace Snippets.NUnit;

public class TestCaseSourceExamples
{
    #region BasicTestCaseSource
    public class BasicTestCaseSourceFixture
    {
        [TestCaseSource(nameof(DivideCases))]
        public void DivideTest(int n, int d, int q)
        {
            ClassicAssert.AreEqual(q, n / d);
        }

        public static object[] DivideCases =
        [
            new object[] { 12, 3, 4 },
            new object[] { 12, 2, 6 },
            new object[] { 12, 4, 3 }
        ];
    }
    #endregion
    #region ParameterizedSource
    public class ParameterizedSourceExampleFixture
    {
        [TestCaseSource(nameof(TestStrings), new object[] { true })]
        public void LongNameWithEvenNumberOfCharacters(string name)
        {
            Assert.That(name.Length, Is.GreaterThan(5));

            bool hasEvenNumOfCharacters = (name.Length % 2) == 0;
            Assert.That(hasEvenNumOfCharacters, Is.True);
        }

        [TestCaseSource(nameof(TestStrings), new object[] { false })]
        public void ShortNameWithEvenNumberOfCharacters(string name)
        {
            Assert.That(name.Length, Is.LessThan(15));

            bool hasEvenNumOfCharacters = (name.Length % 2) == 0;
            Assert.That(hasEvenNumOfCharacters, Is.True);
        }

        static IEnumerable<string> TestStrings(bool generateLongTestCase)
        {
            if (generateLongTestCase)
            {
                yield return "ThisIsAVeryLongNameThisIsAVeryLongName";
                yield return "SomeName";
                yield return "YetAnotherName";
            }
            else
            {
                yield return "AA";
                yield return "BB";
                yield return "CC";
            }
        }
    }
    #endregion

    #region ClassMethodAsTestCaseSource
    public class TestFixtureThatUsesClassMethodAsTestCaseSource
    {
        [TestCaseSource(typeof(AnotherClassWithTestFixtures), nameof(AnotherClassWithTestFixtures.DivideCases))]
        public void DivideTest(int n, int d, int q)
        {
            ClassicAssert.AreEqual(q, n / d);
        }
    }

    public class AnotherClassWithTestFixtures
    {
        public static object[] DivideCases =
        {
            new object[] { 12, 3, 4 },
            new object[] { 12, 2, 6 },
            new object[] { 12, 4, 3 }
        };
    }
    #endregion

    #region ClassWithoutMethodAsTestCaseSource
    public class TestFixtureThatUsesClassAsTestCaseSource
    {
        [TestCaseSource(typeof(DivideCasesClass))]
        public void DivideTest(int n, int d, int q)
        {
            ClassicAssert.AreEqual(q, n / d);
        }
    }

    public class DivideCasesClass : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { 12, 3, 4 };
            yield return new object[] { 12, 2, 6 };
            yield return new object[] { 12, 4, 3 };
        }
    }
    #endregion

    #region SingleArgumentMatchingValueShorthand

    private static int[] _evenNumbers = { 2, 4, 6, 8 };

    [Test, TestCaseSource(nameof(_evenNumbers))]
    public void TestMethod(int num)
    {
        Assert.That(num % 2, Is.Zero);
    }
    #endregion

    #region TypedValuesWithExpectedAsAnonymousTuple
    public class TypedValuesWithExpectedAsAnonymousTuple
    {
        [TestCaseSource(nameof(TestCases))]
        public void TestOfPersonAge((Person P, bool Expected) td)
        {
            var res = td.P.IsOldEnoughToBuyAlcohol();
            Assert.That(res, Is.EqualTo(td.Expected));
        }

        private static IEnumerable<(Person, bool)> TestCases()
        {
            yield return (new Person { Name = "John", Age = 10 }, false);
            yield return (new Person { Name = "Jane", Age = 30 }, true);
        }
    }

    public class Person
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }

        public bool IsOldEnoughToBuyAlcohol()
        {
            return Age >= 18;
        }
    }
    #endregion

    #region TypedValuesWithExpectedInWrapperClass
    public class TypedValuesWithExpectedInWrapperClass
    {


        [TestCaseSource(nameof(TestCases))]
        public void TestOfPersonAge(TestDataWrapper<Person, bool> td)
        {
            var res = td.Value?.IsOldEnoughToBuyAlcohol();
            Assert.That(res, Is.EqualTo(td.Expected));
        }

        public static IEnumerable<TestDataWrapper<Person, bool>> TestCases()
        {
            yield return new TestDataWrapper<Person, bool> { Value = new Person { Name = "John", Age = 10 }, Expected = false };
            yield return new TestDataWrapper<Person, bool> { Value = new Person { Name = "Jane", Age = 30 }, Expected = true };
        }
    }

    public class TestDataWrapper<T, TExp>
    {
        public T? Value { get; set; }
        public TExp? Expected { get; set; }
    }
    #endregion

    #region TestCaseSourceWithCategory
    [TestFixture]
    public sealed class TestCaseSourceCategoryFixture
    {
        public static IEnumerable<int> YieldTaggedCases()
        {
            yield return 1;
            yield return 200;
        }

        [TestCaseSource(nameof(YieldTaggedCases), Category = "DocSample,Smoke")]
        public void EveryCaseFromSourceSharesCategoryTags(int magnitude)
        {
            Assert.That(magnitude, Is.Positive);
        }
    }
    #endregion

    #region OptionalParameters
    [TestFixture]
    public class OptionalParametersFixture
    {
        [TestCaseSource(nameof(OptionalParameterCases))]
        public void TestWithOptionalParameters(string first, string second = "default", int third = 42)
        {
            Assert.That(first, Is.Not.Null);
            Assert.That(second, Is.Not.Null);
            Assert.That(third, Is.GreaterThan(0));
        }

        private static IEnumerable<TestCaseData> OptionalParameterCases()
        {
            // Provide all three arguments
            yield return new TestCaseData("a", "b", 100);

            // Provide only two arguments - third uses default value of 42
            yield return new TestCaseData("a", "b");

            // Provide only one argument - second and third use defaults
            yield return new TestCaseData("a");
        }
    }
    #endregion

    #region CancellationTokenSupport
    [TestFixture]
    public class CancellationTokenFixture
    {
        [TestCaseSource(nameof(TestCases))]
        [CancelAfter(5000)]
        public void TestWithCancellationToken(int value, CancellationToken cancellationToken)
        {
            // NUnit automatically provides the CancellationToken as the last parameter
            // when [CancelAfter] is applied. The source only needs to provide the other arguments.
            Assert.That(cancellationToken, Is.Not.EqualTo(default(CancellationToken)));
            Assert.That(value, Is.Positive);
        }

        [TestCaseSource(nameof(TestCases))]
        [CancelAfter(5000)]
        public void TestWithOptionalCancellationToken(int value, CancellationToken cancellationToken = default)
        {
            // CancellationToken can also have a default value
            Assert.That(cancellationToken, Is.Not.EqualTo(default(CancellationToken)));
            Assert.That(value, Is.Positive);
        }

        private static IEnumerable<TestCaseData> TestCases()
        {
            // Note: Do NOT include CancellationToken in the test case data
            // NUnit injects it automatically when [CancelAfter] is present
            yield return new TestCaseData(1);
            yield return new TestCaseData(2);
        }
    }
    #endregion

    #region AsyncEnumerableSource
    [TestFixture]
    public class AsyncEnumerableSourceFixture
    {
        [TestCaseSource(nameof(AsyncTestCases))]
        public async Task TestWithAsyncEnumerableSource(int expected, int actual)
        {
            await Task.Delay(10); // Simulate async work
            Assert.That(actual, Is.EqualTo(expected));
        }

        // Source method returns IAsyncEnumerable (NUnit 4+)
        private static async IAsyncEnumerable<TestCaseData> AsyncTestCases()
        {
            await Task.Delay(10); // Simulate async data fetching
            yield return new TestCaseData(1, 1);

            await Task.Delay(10);
            yield return new TestCaseData(42, 42);
        }

        [TestCaseSource(nameof(TaskReturningSource))]
        public void TestWithTaskReturningSource(string value)
        {
            Assert.That(value, Is.Not.Empty);
        }

        // Source method returns Task<IEnumerable> (NUnit 3.14+)
        private static async Task<IEnumerable<TestCaseData>> TaskReturningSource()
        {
            await Task.Delay(10); // Simulate async data fetching
            return new[]
            {
                new TestCaseData("first"),
                new TestCaseData("second")
            };
        }
    }
    #endregion
}
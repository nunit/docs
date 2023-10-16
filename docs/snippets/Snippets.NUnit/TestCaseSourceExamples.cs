using System.Collections;
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
        {
            new object[] { 12, 3, 4 },
            new object[] { 12, 2, 6 },
            new object[] { 12, 4, 3 }
        };
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

        public static IEnumerable<(Person, bool)> TestCases()
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
}
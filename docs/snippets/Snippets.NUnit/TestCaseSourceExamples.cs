using System.Collections;
using NUnit.Framework;
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
            Assert.AreEqual(q, n / d);
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

            bool hasEvenNumOfCharacters =  (name.Length % 2) == 0;
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
            Assert.AreEqual(q, n / d);
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
            Assert.AreEqual(q, n / d);
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
    static int[] _evenNumbers = { 2, 4, 6, 8 };

    [Test, TestCaseSource(nameof(_evenNumbers))]
    public void TestMethod(int num)
    {
        Assert.That(num % 2, Is.Zero);
    }
    #endregion
}
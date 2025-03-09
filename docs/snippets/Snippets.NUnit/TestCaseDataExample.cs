using System.Collections;
using NUnit.Framework;

namespace Snippets.NUnit;

public class TestCaseDataExample
{

    #region TestCaseDataExample
    [TestFixture]
    public class MyTests
    {
        [TestCaseSource(typeof(MyDataClass), nameof(MyDataClass.TestCases))]
        public int DivideTest(int n, int d)
        {
            return n / d;
        }
    }

    public class MyDataClass
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(12, 3).Returns(4);
                yield return new TestCaseData(12, 2).Returns(6);
                yield return new TestCaseData(12, 4).Returns(3);
            }
        }
    }
    #endregion

    #region TestCaseDataTypeArgsExample
    [TestFixture]
    public class MyExplicitlyTypedTests
    {
        [TestCaseSource(nameof(ExplicitTypeArgsTestCases))]
        public void ExplicitTypeArgs<T>(T input)
        {
            Assert.That(typeof(T), Is.EqualTo(typeof(long)));
        }

        private static IEnumerable<TestCaseData> ExplicitTypeArgsTestCases()
        {
            yield return new TestCaseData(2) { TypeArgs = new[] { typeof(long) } };
            yield return new TestCaseData(2L) { TypeArgs = new[] { typeof(long) } };
        }
    }
    #endregion
}
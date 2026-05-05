using System;
using System.Collections;
using System.Collections.Generic;
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
            yield return new TestCaseData(2) { TypeArgs = [typeof(long)] };
            yield return new TestCaseData(2L) { TypeArgs = [typeof(long)] };
        }
    }
    #endregion

    #region GenericTestCaseDataExample
    [TestFixture]
    public class GenericTestCaseDataTests
    {
        [TestCaseSource(nameof(GenericTestCases))]
        public Type GenericMethodWithExplicitType<T>(T input)
        {
            return typeof(T);
        }

        private static IEnumerable<TestCaseData> GenericTestCases()
        {
            // Using TestCaseData<T> automatically sets TypeArgs to typeof(T)
            // This ensures the generic method uses 'long' even though 2 is an int
            yield return new TestCaseData<long>(2L)
            {
                ExpectedResult = typeof(long)
            };

            // Multiple type parameters with TestCaseData<T1, T2>
            yield return new TestCaseData<int>(42)
            {
                ExpectedResult = typeof(int)
            };
        }

        [TestCaseSource(nameof(TwoTypeParameterCases))]
        public void GenericMethodWithTwoTypes<T1, T2>(T1 first, T2 second)
        {
            Assert.That(first, Is.TypeOf<T1>());
            Assert.That(second, Is.TypeOf<T2>());
        }

        private static IEnumerable<TestCaseData> TwoTypeParameterCases()
        {
            // TestCaseData<T1, T2> sets TypeArgs = [typeof(T1), typeof(T2)]
            yield return new TestCaseData<string, int>("hello", 42);
            yield return new TestCaseData<double, bool>(3.14, true);
        }
    }
    #endregion

    #region IgnoreUntilExample
    [TestFixture]
    public class IgnoreUntilTests
    {
        [TestCaseSource(nameof(IgnoredTestCases))]
        public void TestWithTemporaryIgnore(int value)
        {
            Assert.That(value, Is.Positive);
        }

        private static IEnumerable<TestCaseData> IgnoredTestCases()
        {
            // This test case runs normally
            yield return new TestCaseData(1);

            // This test case is ignored indefinitely
            yield return new TestCaseData(2)
                .Ignore("Known bug - see issue #123");

            // This test case is ignored until the specified date
            // After the date passes, the test will run automatically
            yield return new TestCaseData(3)
                .Ignore("Waiting for API v2 release")
                .Until(new DateTimeOffset(2025, 6, 1, 0, 0, 0, TimeSpan.Zero));

            // This test was ignored in the past - it now runs because the date has passed
            yield return new TestCaseData(4)
                .Ignore("Was waiting for feature X")
                .Until(new DateTimeOffset(2020, 1, 1, 0, 0, 0, TimeSpan.Zero));
        }
    }
    #endregion

    #region SetArgDisplayNamesObjectExample
    [TestFixture]
    public class SetArgDisplayNamesObjectTests
    {
        [TestCaseSource(nameof(DisplayNameCases))]
        public void TestWithCustomDisplayNames(Person person, int expectedAge)
        {
            Assert.That(person.Age, Is.EqualTo(expectedAge));
        }

        private static IEnumerable<TestCaseData> DisplayNameCases()
        {
            var john = new Person { Name = "John", Age = 30 };
            var jane = new Person { Name = "Jane", Age = 25 };

            // SetArgDisplayNames with strings
            yield return new TestCaseData(john, 30)
                .SetArgDisplayNames("John Doe", "30");

            // SetArgDisplayNames with objects - they are automatically formatted
            // This is useful when you want the display name to match the object's ToString()
            yield return new TestCaseData(jane, 25)
                .SetArgDisplayNames(jane.Name, jane.Age);
        }

        public class Person
        {
            public string Name { get; set; } = "";
            public int Age { get; set; }
        }
    }
    #endregion
}
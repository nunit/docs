using NUnit.Framework;
using System.Collections;
namespace Snippets.NUnit.Attributes
{
    public class TestFixtureSourceAttributeExamples
    {
        internal static class StaticPropertyInOwnClass
        {
            #region StaticPropertyInOwnClass
            [TestFixtureSource(nameof(FixtureArgs))]
            public class MyTestClass
            {
                public MyTestClass(string word, int num) { /* ... */ }

                /* Tests */

                static object[] FixtureArgs = {
                    new object[] { "Question", 1 },
                    new object[] { "Answer", 42 }
                };
            }
            #endregion
        }

        internal static class StaticPropertyInAnotherClass {
        #region StaticPropertyInAnotherClass
        [TestFixtureSource(typeof(AnotherClass), nameof(AnotherClass.FixtureArgs))]
        public class MyTestClass
        {
            public MyTestClass(string word, int num) { /* ... */ }

            /* Tests */
        }

        public class AnotherClass
        {
            public static object[] FixtureArgs = {
                new object[] { "Question", 1 },
                new object[] { "Answer", 42 }
            };
        }
        #endregion
        }

        internal static class SourceFromEnumerable
        {
            #region SourceFromEnumerable
            [TestFixtureSource(typeof(FixtureArgs))]
            public class MyTestClass
            {
                public MyTestClass(string word, int num) { /* ... */ }

                /* ... */
            }

            class FixtureArgs : IEnumerable
            {
                public IEnumerator GetEnumerator()
                {
                    yield return new object[] { "Question", 1 };
                    yield return new object[] { "Answer", 42 };
                }
            }
            #endregion
        }
    }
}

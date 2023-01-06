using NUnit.Framework;
using System.Collections;
#pragma warning disable CS8625

namespace Snippets.NUnit.Attributes
{
    public class TestFixtureAttributeExamples
    {
        #region MultipleParameterizedTestFixtures
        [TestFixture("hello", "hello", "goodbye")]
        [TestFixture("zip", "zip")]
        [TestFixture(42, 42, 99)]
        public class ParameterizedTestFixture
        {
            private readonly string _eq1;
            private readonly string _eq2;
            private readonly string _neq;

            public ParameterizedTestFixture(string eq1, string eq2, string neq)
            {
                _eq1 = eq1;
                _eq2 = eq2;
                _neq = neq;
            }

            public ParameterizedTestFixture(string eq1, string eq2)
                : this(eq1, eq2, null) { }

            public ParameterizedTestFixture(int eq1, int eq2, int neq)
            {
                _eq1 = eq1.ToString();
                _eq2 = eq2.ToString();
                _neq = neq.ToString();
            }

            [Test]
            public void TestEquality()
            {
                Assert.AreEqual(_eq1, _eq2);
                if (_eq1 != null && _eq2 != null)
                    Assert.AreEqual(_eq1.GetHashCode(), _eq2.GetHashCode());
            }

            [Test]
            public void TestInequality()
            {
                Assert.AreNotEqual(_eq1, _neq);
                if (_eq1 != null && _neq != null)
                    Assert.AreNotEqual(_eq1.GetHashCode(), _neq.GetHashCode());
            }
        }
        #endregion

        #region GenericTestFixtures
        [TestFixture(typeof(ArrayList))]
        [TestFixture(typeof(List<int>))]
        public class IList_Tests<TList> where TList : IList, new()
        {
            private IList list;

            [SetUp]
            public void CreateList()
            {
                this.list = new TList();
            }

            [Test]
            public void CanAddToList()
            {
                list.Add(1); list.Add(2); list.Add(3);
                Assert.AreEqual(3, list.Count);
            }
        }
        #endregion

        #region GenericTestFixtureWithParameters
        [TestFixture(typeof(double), typeof(int), 100.0, 42)]
        [TestFixture(typeof(int), typeof(double), 42, 100.0)]
        public class SpecifyBothSetsOfArgs<T1, T2>
        {
            T1 t1;
            T2 t2;

            public SpecifyBothSetsOfArgs(T1 t1, T2 t2)
            {
                this.t1 = t1;
                this.t2 = t2;
            }

            [TestCase(5, 7)]
            public void TestMyArgTypes(T1 t1, T2 t2)
            {
                Assert.That(t1, Is.TypeOf<T1>());
                Assert.That(t2, Is.TypeOf<T2>());
            }
        }
        #endregion
    }
    public class AuthorAttributeExamples
    {
        #region AuthorAttributeExample
        [TestFixture]
        [Author("Jane Doe", "jane.doe@example.com")]
        [Author("Another Developer", "email@example.com")]
        public class MyTests
        {
            [Test]
            public void Test1() { /* ... */ }

            [Test]
            [Author("Joe Developer")]
            [Author("Yet Another Developer", "not.my.email@example.com")]
            public void Test2() { /* ... */ }
        }

        [TestFixture(Author = "Jane Doe")]
        public class MyOtherTests
        {
            [Test]
            public void Test1() { /* ... */ }

            [Test(Author = "Joe Developer")]
            public void Test2() { /* ... */ }
        }
        #endregion
    }
}

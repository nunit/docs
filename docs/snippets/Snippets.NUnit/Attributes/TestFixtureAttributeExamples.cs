using System.Collections;
using NUnit.Framework;
// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
#pragma warning disable NUnit2045
#pragma warning disable NUnit2041
#pragma warning disable NUnit1001

namespace Snippets.NUnit.Attributes;

#pragma warning disable CS8625
public class TestFixtureAttributeExamples
{
    #region MultipleParameterizedTestFixtures
    [TestFixture("hello", "hello", "goodbye")]
    [TestFixture("zip", "zip")]
    [TestFixture(42, 42, 99)]
    [TestFixture('a', 'a', 'b')]
    [TestFixture('A', 'A')]
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

        // Can use params arguments (but not yet optional arguments)
        public ParameterizedTestFixture(params char[] eqArguments)
        {
            _eq1 = eqArguments[0].ToString();
            _eq2 = eqArguments[1].ToString();
            if (eqArguments.Length > 2)
                _neq = eqArguments[2].ToString();
            else 
                _new = null;
        }
        
        [Test]
        public void TestEquality()
        {
            Assert.That(_eq2, Is.EqualTo(_eq1));
            Assert.That(_eq2.GetHashCode(), Is.EqualTo(_eq1.GetHashCode()));
        }

        [Test]
        public void TestInequality()
        {
            Assert.That(_neq, Is.Not.EqualTo(_eq1));
            if (_neq != null)
            {
                Assert.That(_neq.GetHashCode(), Is.Not.EqualTo(_eq1.GetHashCode()));
            }
        }
    }
    #endregion

    #region GenericTestFixtures
    [TestFixture(typeof(ArrayList))]
    [TestFixture(typeof(List<int>))]
    public class GenericListTests<TList>
        where TList : IList, new()
    {
        private IList _list = null!;

        [SetUp]
        public void CreateList()
        {
            _list = new TList();
        }

        [Test]
        public void CanAddToList()
        {
            _list.Add(1); _list.Add(2); _list.Add(3);
            Assert.That(_list, Has.Count.EqualTo(3));
        }
    }
    #endregion

    #region GenericTestFixtureWithParameters
    [TestFixture(typeof(double), typeof(int), 100.0, 42)]
    [TestFixture(typeof(int), typeof(double), 42, 100.0)]
    public class SpecifyBothSetsOfArgs<T1, T2>
        where T1 : notnull
        where T2 : notnull
    {
        private readonly T1 _t1;
        private readonly T2 _t2;

        public SpecifyBothSetsOfArgs(T1 t1, T2 t2)
        {
            _t1 = t1;
            _t2 = t2;
        }

        [TestCase(5, 7)]
        public void TestMyArgTypes(T1 t1, T2 t2)
        {
            Assert.That(t1, Is.TypeOf<T1>());
            Assert.That(t1, Is.LessThan(_t1));

            Assert.That(t2, Is.TypeOf<T2>());
            Assert.That(t2, Is.LessThan(_t2));
        }
    }
    #endregion

    #region SpecifyTypeArgsSeparately
    [TestFixture(100.0, 42, TypeArgs = new[] { typeof(double), typeof(int) })]
    [TestFixture(42, 100.0, TypeArgs = new[] { typeof(int), typeof(double) })]
    public class SpecifyTypeArgsSeparately<T1, T2>
        where T1 : notnull
        where T2 : notnull
    {
        private readonly T1 _t1;
        private readonly T2 _t2;

        public SpecifyTypeArgsSeparately(T1 t1, T2 t2)
        {
            _t1 = t1;
            _t2 = t2;
        }

        [TestCase(5, 7)]
        public void TestMyArgTypes(T1 t1, T2 t2)
        {
            Assert.That(t1, Is.TypeOf<T1>());
            Assert.That(t1, Is.LessThan(_t1));

            Assert.That(t2, Is.TypeOf<T2>());
            Assert.That(t2, Is.LessThan(_t2));
        }
    }
    #endregion

    #region DeducedTypesFromArguments
    [TestFixture(100.0, 42)]
    [TestFixture(42, 100.0)]
    public class DeduceTypeArgsFromArgs<T1, T2>
        where T1 : notnull
        where T2 : notnull
    {
        private readonly T1 _t1;
        private readonly T2 _t2;

        public DeduceTypeArgsFromArgs(T1 t1, T2 t2)
        {
            _t1 = t1;
            _t2 = t2;
        }

        [TestCase(5, 7)]
        public void TestMyArgTypes(T1 t1, T2 t2)
        {
            Assert.That(t1, Is.TypeOf<T1>());
            Assert.That(t1, Is.LessThan(_t1));

            Assert.That(t2, Is.TypeOf<T2>());
            Assert.That(t2, Is.LessThan(_t2));
        }
    }
    #endregion
}

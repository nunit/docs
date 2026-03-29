using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    [TestFixture]
    public class TestCaseGenericExamples
    {
        #region GenericTestCaseSingleType
        // Testing with a single generic type parameter
        // The compiler ensures the argument matches the type
        [TestCase<int>(42)]
        [TestCase<int>(0)]
        [TestCase<int>(-1)]
        public void TestDefaultComparison<T>(T value)
        {
            Assert.That(value, Is.Not.EqualTo(default(T)).Or.EqualTo(default(T)));
        }
        #endregion

        #region GenericTestCaseTwoTypes
        // Testing with two generic type parameters
        [TestCase<int, double>(42, 42.0)]
        [TestCase<string, int>("hello", 5)]
        public void TestPairTypes<T1, T2>(T1 first, T2 second)
        {
            Assert.That(first, Is.InstanceOf<T1>());
            Assert.That(second, Is.InstanceOf<T2>());
        }
        #endregion

        #region GenericTestCaseThreeTypes
        [TestCase<string, int, bool>("test", 4, true)]
        public void TestTriple<T1, T2, T3>(T1 text, T2 number, T3 flag)
        {
            Assert.Multiple(() =>
            {
                Assert.That(text, Is.InstanceOf<T1>());
                Assert.That(number, Is.InstanceOf<T2>());
                Assert.That(flag, Is.InstanceOf<T3>());
            });
        }
        #endregion

        #region GenericTestCaseMixedWithRegular
        // You can mix regular and generic TestCase attributes
        [TestCase(1, 2)]                        // Types inferred
        [TestCase<int, int>(3, 4)]              // Types explicit - same as above
        [TestCase<double, double>(1.5, 2.5)]    // Different types
        public void MixedTestCases<T1, T2>(T1 a, T2 b)
        {
            Assert.That(a, Is.InstanceOf<T1>());
            Assert.That(b, Is.InstanceOf<T2>());
        }
        #endregion

        #region GenericTestCaseWithExpectedResult
        // Using ExpectedResult with generic TestCase
        [TestCase<int>(5, ExpectedResult = 10)]
        [TestCase<int>(0, ExpectedResult = 0)]
        [TestCase<int>(-3, ExpectedResult = -6)]
        public int DoubleValue<T>(T value) where T : IConvertible
        {
            return Convert.ToInt32(value) * 2;
        }
        #endregion

        #region GenericTestCaseCompileTimeSafety
        // The key benefit: compile-time type checking
        // These would NOT compile:
        // [TestCase<int>("not a number")]  // Error: cannot convert string to int
        // [TestCase<int, int>(1)]          // Error: missing second argument

        [TestCase<int>(100)]
        [TestCase<int>(200)]
        public void CompileTimeSafeTest<T>(T value)
        {
            Assert.That(value, Is.InstanceOf<T>());
        }
        #endregion
    }
}

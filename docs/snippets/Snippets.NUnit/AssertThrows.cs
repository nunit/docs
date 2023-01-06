// ReSharper disable ConvertToLambdaExpression
// ReSharper disable MemberCanBeMadeStatic.Local
#pragma warning disable CA1822
#pragma warning disable CS8602
#pragma warning disable NUnit2045
#pragma warning disable CS8600
namespace Snippets.NUnit;

public class AssertThrows
{
    #region MyException
    public class MyException : Exception
    {
        public int MyParam { get; }

        public MyException(string message, int myParam) : base(message)
        {
            MyParam = myParam;
        }
    }
    #endregion
    #region AssertThrows
    [TestFixture]
    public class AssertThrowsTests
    {
        [Test]
        public void Tests()
        {
            // Using a method as a delegate
            Assert.Throws<ArgumentException>(MethodThatThrows);

            // Using an anonymous delegate
            Assert.Throws<ArgumentException>(
                delegate { throw new ArgumentException(); });

            // Using a Lambda expression
            Assert.Throws<ArgumentException>(
                () => throw new ArgumentException());
        }

        void MethodThatThrows()
        {
            throw new ArgumentException();
        }
    }
    #endregion

    #region UsingReturnValue
    [TestFixture]
    public class UsingReturnValue
    {
        [Test]
        public void TestException()
        {
            MyException ex = Assert.Throws<MyException>(
                () => throw new MyException("message", 42));

            Assert.That(ex.Message, Is.EqualTo("message"));
            Assert.That(ex.MyParam, Is.EqualTo(42));
        }
    }
    #endregion

    #region UsingConstraint
    [TestFixture]
    public class UsingConstraint
    {
        [Test]
        public void TestException()
        {
            Assert.Throws(Is.TypeOf<MyException>()
                    .And.Message.EqualTo("message")
                    .And.Property("MyParam").EqualTo(42),
                () => throw new MyException("message", 42));
        }
    }
    #endregion
}
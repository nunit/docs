using NUnit.Framework;
using static Snippets.NUnit.AssertThrows;
#pragma warning disable NUnit2045
#pragma warning disable CA1822

namespace Snippets.NUnit;

#pragma warning disable CS8602, CS8600
public class AssertThrowsAsync
{
    #region AssertThrowsAsync
    [TestFixture]
    public class AssertThrowsTests
    {
        [Test]
        public async Task Tests()
        {
            // Using a method as a delegate
            await Assert.ThrowsAsync<ArgumentException>(async () => await MethodThatThrows());
        }

        private async Task MethodThatThrows()
        {
            await Task.Delay(100);
            throw new ArgumentException();
        }
    }
    #endregion

    #region UsingReturnValue
    [TestFixture]
    public class UsingReturnValue
    {
        [Test]
        public async Task TestException()
        {
            MyException ex = await Assert.ThrowsAsync<MyException>(async () => await MethodThatThrows());

            Assert.That(ex.Message, Is.EqualTo("message"));
            Assert.That(ex.MyParam, Is.EqualTo(42));
        }

        private async Task MethodThatThrows()
        {
            await Task.Delay(100);
            throw new MyException("message", 42);
        }
    }
    #endregion
}
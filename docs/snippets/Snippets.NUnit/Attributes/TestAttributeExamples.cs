using System.Threading.Tasks;
using NUnit.Framework;

namespace Snippets.NUnit.Attributes;

public class TestAttributeExamples
{
    #region BasicTest
    [TestFixture]
    public sealed class BasicTests
    {
        [Test]
        public void Add()
        {
            Assert.That(2 + 2, Is.EqualTo(4));
        }
    }
    #endregion

    #region TestWithDescription
    [TestFixture]
    public sealed class DescriptionTests
    {
        [Test(Description = "My really cool test")]
        public void Add_WithDescriptionOnAttribute()
        {
            Assert.That(2 + 2, Is.EqualTo(4));
        }

        [Test]
        [Description("My really really cool test")]
        public void Add_WithDescriptionAttribute()
        {
            Assert.That(2 + 2, Is.EqualTo(4));
        }
    }
    #endregion

    #region AsyncTest
    [TestFixture]
    public sealed class AsyncTests
    {
        [Test]
        public async Task AddAsync()
        {
            await Task.Delay(1);
            Assert.That(2 + 2, Is.EqualTo(4));
        }
    }
    #endregion

    #region ExpectedResultTest
    [TestFixture]
    public sealed class ExpectedResultTests
    {
        [Test(ExpectedResult = 4)]
        public int TestAdd()
        {
            return 2 + 2;
        }

        [Test(ExpectedResult = 4)]
        public async Task<int> TestAddAsync()
        {
            await Task.Delay(1);
            return 2 + 2;
        }
    }
    #endregion
}

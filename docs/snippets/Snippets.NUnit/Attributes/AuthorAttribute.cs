using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{

    public class AuthorAttributeExample
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

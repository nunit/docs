using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    public class SingleThreadedAttributeExamples
    {
        #region SingleThreadedExample
        [TestFixture]
        [SingleThreaded]
        public class DatabaseTests
        {
            private DbConnection? _connection;

            [OneTimeSetUp]
            public void OneTimeSetUp()
            {
                // Connection created on this thread
                _connection = new DbConnection();
                _connection.Open();
            }

            [Test]
            public void Test1()
            {
                // Guaranteed to run on the same thread as OneTimeSetUp
                _connection!.Execute("SELECT 1");
            }

            [Test]
            public void Test2()
            {
                // Also runs on the same thread
                _connection!.Execute("SELECT 2");
            }

            [OneTimeTearDown]
            public void OneTimeTearDown()
            {
                // Runs on the same thread, safe to close connection
                _connection?.Close();
            }
        }

        // Simple stub classes for the example
        private class DbConnection
        {
            public void Open() { }
            public void Execute(string sql) { }
            public void Close() { }
        }
        #endregion
    }
}

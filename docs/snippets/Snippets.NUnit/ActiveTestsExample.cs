using System.Linq;
using NUnit.Framework;

namespace Snippets.NUnit.ActiveTestsExample;

#region ActiveTestsExample
[SetUpFixture]
public class DatabaseSetUp
{
    private bool _databaseStarted;

    [OneTimeSetUp]
    public void StartDatabaseIfNeeded()
    {
        // ActiveTests lists the test cases under this namespace that passed the filter
        var activeTests = TestContext.CurrentContext.ActiveTests ?? [];

        // Only do the expensive setup if at least one active test needs it
        if (activeTests.Any(test => test.Properties["Category"].Contains("Database")))
        {
            _databaseStarted = true; // Start the database here
        }
    }

    [OneTimeTearDown]
    public void StopDatabase()
    {
        if (_databaseStarted)
        {
            _databaseStarted = false; // Stop the database here
        }
    }
}

[TestFixture]
public class CustomerTests
{
    [Test, Category("Database")]
    public void CanSaveCustomer() => Assert.Pass();

    [Test]
    public void CanFormatCustomerName() => Assert.Pass();
}
#endregion

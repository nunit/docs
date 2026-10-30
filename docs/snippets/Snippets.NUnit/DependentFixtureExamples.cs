using NUnit.Framework;

// Fixture dependencies are resolved between fixtures in the same namespace,
// so these examples have their own namespace.
namespace Snippets.NUnit.DependentFixtures;

#region DependentFixtures
// State shared between fixtures. Fixture dependencies make the order safe.
public static class CustomerDatabase
{
    public static List<string> Customers { get; } = [];
}

public class SeedDatabaseTests
{
    [Test]
    public void AddCustomers()
    {
        CustomerDatabase.Customers.AddRange(["Alice", "Bob"]);
        Assert.That(CustomerDatabase.Customers, Has.Count.EqualTo(2));
    }
}

[DependsOnFixture(typeof(SeedDatabaseTests))]
public class CustomerReportTests
{
    // All tests in this fixture run after every test in SeedDatabaseTests.
    // If SeedDatabaseTests fails, this whole fixture is skipped.
    [Test]
    public void Report_ListsAllCustomers()
    {
        Assert.That(CustomerDatabase.Customers, Is.EquivalentTo(new[] { "Alice", "Bob" }));
    }

    [Test]
    public void Report_HasNoDuplicates()
    {
        Assert.That(CustomerDatabase.Customers, Is.Unique);
    }
}

[DependsOnFixture(typeof(CustomerReportTests), AllowFailure = true)]
public class CleanUpDatabaseTests
{
    // Runs after CustomerReportTests even if it failed, so the cleanup always happens.
    [Test]
    public void RemoveCustomers()
    {
        CustomerDatabase.Customers.Clear();
        Assert.That(CustomerDatabase.Customers, Is.Empty);
    }
}
#endregion

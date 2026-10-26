using NUnit.Framework;

#pragma warning disable CA1822

namespace Snippets.NUnit.LoadTimeExecutionTime
{
    public sealed class EventBus
    {
        public event Action<string>? Published;

        public void Publish(string message) => Published?.Invoke(message);
    }
}

namespace Snippets.NUnit.LoadTimeExecutionTime.FixedData
{
    #region DataIsFixedBeforeSetUp
    public class DiscountTests
    {
        private static int _discountPercent = 10;

        private static IEnumerable<int> Discounts()
        {
            // Load time: runs when NUnit loads the assembly, before any [SetUp] or [OneTimeSetUp].
            yield return _discountPercent;
        }

        [SetUp]
        public void ChangeDiscount()
        {
            // Execution time: too late. The test case and its argument were built at load time.
            _discountPercent = 50;
        }

        [TestCaseSource(nameof(Discounts))]
        public void Discount_IsTheValueFromLoadTime(int discount)
        {
            Assert.That(discount, Is.EqualTo(10));
        }
    }
    #endregion
}

namespace Snippets.NUnit.LoadTimeExecutionTime.Problem
{
    #region ListenerAttachedAtExecutionTimeToAnotherBus
    [SetUpFixture]
    public class TestEnvironment
    {
        public static EventBus? Bus { get; private set; }
        public static List<string> Received { get; } = new();

        [OneTimeSetUp]
        public void CreateBus()
        {
            // Execution time: create the shared bus and listen to it.
            Bus = new EventBus();
            Bus.Published += Received.Add;
        }
    }

    public class OrderTests
    {
        private static IEnumerable<EventBus> Buses()
        {
            // Load time: TestEnvironment.Bus is still null here, so the source
            // has to create a bus of its own. This is the object the test receives.
            yield return new EventBus();
        }

        [TestCaseSource(nameof(Buses))]
        public void Publish_IsNeverSeenByTheListener(EventBus bus)
        {
            bus.Publish("order placed");

            // The listener is attached to TestEnvironment.Bus, a different object.
            Assert.That(TestEnvironment.Received, Is.Empty);
        }
    }
    #endregion
}

namespace Snippets.NUnit.LoadTimeExecutionTime.Solution
{
    #region ListenerAndBusBothAtExecutionTime
    [SetUpFixture]
    public class TestEnvironment
    {
        public static EventBus Bus { get; private set; } = null!;
        public static List<string> Received { get; } = new();

        [OneTimeSetUp]
        public void CreateBus()
        {
            // Execution time: the bus and its listener are created together.
            Bus = new EventBus();
            Bus.Published += Received.Add;
        }
    }

    public class OrderTests
    {
        // Load time: the source supplies plain data only.
        private static readonly string[] Messages = { "order placed", "order shipped" };

        [TestCaseSource(nameof(Messages))]
        public void Publish_IsSeenByTheListener(string message)
        {
            // Execution time: resolve the live object here, not in the source.
            TestEnvironment.Bus.Publish(message);

            Assert.That(TestEnvironment.Received, Does.Contain(message));
        }
    }
    #endregion
}

namespace Snippets.NUnit.LoadTimeExecutionTime.LazyState
{
    public sealed class CatalogService
    {
        private readonly string[] _products = { "Apple", "Banana", "Cherry" };

        public IEnumerable<string> ProductNames() => _products;

        public bool IsKnown(string name) => _products.Contains(name);
    }

    #region LazySharedState
    public static class Services
    {
        // Created on first use, whether that happens in a data source at load time
        // or in a test at execution time. Within one load of the assembly, both see
        // the same instance.
        private static readonly Lazy<CatalogService> LazyCatalog = new(() => new CatalogService());

        public static CatalogService Catalog => LazyCatalog.Value;
    }

    public class CatalogTests
    {
        private static IEnumerable<string> ProductNames() => Services.Catalog.ProductNames();

        [TestCaseSource(nameof(ProductNames))]
        public void Product_IsKnownToTheCatalog(string name)
        {
            Assert.That(Services.Catalog.IsKnown(name), Is.True);
        }
    }
    #endregion
}

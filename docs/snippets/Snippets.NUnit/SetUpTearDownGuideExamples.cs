using NUnit.Framework;

#pragma warning disable CA1822

namespace Snippets.NUnit.SetUpTearDownGuide.PerTest
{
    #region PerTestSetUpTearDown
    public class ReportWriterTests
    {
        private string _folder = null!;

        [SetUp]
        public void CreateFolder()
        {
            // Runs before each test, so every test gets its own empty folder.
            _folder = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(_folder);
        }

        [TearDown]
        public void DeleteFolder()
        {
            // Runs after each test, also when the test failed.
            if (Directory.Exists(_folder))
                Directory.Delete(_folder, recursive: true);
        }

        [Test]
        public void Write_CreatesReportFile()
        {
            File.WriteAllText(Path.Combine(_folder, "report.txt"), "Hello");
            Assert.That(Directory.GetFiles(_folder), Has.Length.EqualTo(1));
        }

        [Test]
        public void Folder_StartsEmpty()
        {
            Assert.That(Directory.GetFiles(_folder), Is.Empty);
        }
    }
    #endregion
}

namespace Snippets.NUnit.SetUpTearDownGuide.PerFixture
{
    public sealed class ProductCatalog : IDisposable
    {
        public static ProductCatalog LoadFromDatabase() => new();
        public IReadOnlyList<string> Products { get; } = ["Apple", "Banana", "Cherry"];
        public void Dispose() { }
    }

    public class ShoppingCart
    {
        private readonly List<string> _items = [];
        public IReadOnlyList<string> Items => _items;
        public void Add(string product) => _items.Add(product);
    }

    #region PerFixtureOneTimeSetUp
    public class ShoppingCartTests
    {
        private ProductCatalog _catalog = null!;
        private ShoppingCart _cart = null!;

        [OneTimeSetUp]
        public void LoadCatalog()
        {
            // Expensive, and only read by the tests: create it once for all of them.
            _catalog = ProductCatalog.LoadFromDatabase();
        }

        [OneTimeTearDown]
        public void DisposeCatalog()
        {
            _catalog.Dispose();
        }

        [SetUp]
        public void CreateCart()
        {
            // Cheap, and the tests change it: create a fresh one for each test.
            _cart = new ShoppingCart();
        }

        [Test]
        public void Add_PutsProductInCart()
        {
            _cart.Add(_catalog.Products[0]);
            Assert.That(_cart.Items, Has.Count.EqualTo(1));
        }

        [Test]
        public void NewCart_IsEmpty()
        {
            Assert.That(_cart.Items, Is.Empty);
        }
    }
    #endregion
}

#region SetUpFixtureForNamespace
namespace Snippets.NUnit.SetUpTearDownGuide.Integration
{
    [SetUpFixture]
    public class IntegrationTestEnvironment
    {
        public static string ConnectionString { get; private set; } = "";

        [OneTimeSetUp]
        public void StartServices()
        {
            // Runs once, before any test in this namespace and its child namespaces.
            ConnectionString = "Server=localhost;Database=Tests";
        }

        [OneTimeTearDown]
        public void StopServices()
        {
            // Runs once, after all tests in this namespace have finished.
            ConnectionString = "";
        }
    }

    public class OrderRepositoryTests
    {
        [Test]
        public void ConnectionString_IsAvailable()
        {
            Assert.That(IntegrationTestEnvironment.ConnectionString, Does.Contain("Database=Tests"));
        }
    }
}
#endregion

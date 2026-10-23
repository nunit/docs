using NUnit.Framework;
using NUnit.Framework.Api;
using NUnit.Framework.Interfaces;

#pragma warning disable CA1822

namespace Snippets.NUnit.Attributes.SampleNamespace
{
    #region SetUpFixtureExample
    [SetUpFixture]
    public class MySetUpClass
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
        }
    }
    #endregion
}

namespace Snippets.NUnit.Attributes.SetUpFixtureInheritance.SharedPackage
{
    #region SetUpFixtureInheritanceBase
    // Lives in a shared test-support package. NUnit skips abstract classes,
    // so this class is not a setup fixture by itself.
    [SetUpFixture]
    public abstract class SharedEnvironmentSetUpFixture
    {
        public static bool IsStarted { get; private set; }

        [OneTimeSetUp]
        public void StartEnvironment()
        {
            IsStarted = true;
        }

        [OneTimeTearDown]
        public void StopEnvironment()
        {
            IsStarted = false;
        }
    }
    #endregion
}

namespace Snippets.NUnit.Attributes.SetUpFixtureInheritance.Consumer
{
    using Snippets.NUnit.Attributes.SetUpFixtureInheritance.SharedPackage;

    #region SetUpFixtureInheritanceDerived
    // Inherits [SetUpFixture] from the base class, so NUnit treats it as a setup
    // fixture for the namespace of *this* class: ...SetUpFixtureInheritance.Consumer,
    // not the namespace of the base class.
    public class ConsumerEnvironment : SharedEnvironmentSetUpFixture
    {
    }

    public class ConsumerTests
    {
        [Test]
        public void Environment_IsStartedByInheritedSetUpFixture()
        {
            Assert.That(SharedEnvironmentSetUpFixture.IsStarted, Is.True);
        }
    }
    #endregion
}

namespace Snippets.NUnit.Attributes.SetUpFixtureInheritance.Precedence
{
    using Snippets.NUnit.Attributes.SetUpFixtureInheritance.SharedPackage;

    #region SetUpFixtureInheritancePrecedence
    // [TestFixture] on the derived class wins over the inherited [SetUpFixture].
    // This is an ordinary test fixture: its tests are discovered and run, and the
    // base class's [OneTimeSetUp] runs once for this fixture, like any inherited
    // [OneTimeSetUp].
    [TestFixture]
    public class DerivedTestFixture : SharedEnvironmentSetUpFixture
    {
        [Test]
        public void ThisTestIsDiscovered()
        {
            Assert.That(IsStarted, Is.True);
        }
    }

    // No fixture attribute on the derived class, so the inherited [SetUpFixture]
    // wins. NUnit builds this class as a setup fixture for this namespace and
    // silently ignores its [Test] methods.
    public class DerivedWithTestsOnly : SharedEnvironmentSetUpFixture
    {
        [Test]
        public void ThisTestIsNotDiscovered()
        {
            Assert.Fail("NUnit never runs this test.");
        }
    }
    #endregion
}

namespace Snippets.NUnit.Attributes.SetUpFixtureInheritance
{
    // Verifies the rules documented on the SetUpFixture page by building the test
    // tree for this assembly the same way the NUnit framework does at discovery time.
    public class SetUpFixtureInheritanceVerification
    {
        private static ITest BuildTestTree()
        {
            var builder = new DefaultTestAssemblyBuilder();
            return builder.Build(typeof(SetUpFixtureInheritanceVerification).Assembly, new Dictionary<string, object>());
        }

        private static ITest? Find(ITest root, Type type)
        {
            if (root.TypeInfo?.Type == type)
                return root;

            foreach (var child in root.Tests)
            {
                var found = Find(child, type);
                if (found is not null)
                    return found;
            }

            return null;
        }

        [Test]
        public void AbstractBaseClass_IsNotASetUpFixtureByItself()
        {
            var tree = BuildTestTree();

            Assert.That(Find(tree, typeof(SharedPackage.SharedEnvironmentSetUpFixture)), Is.Null);
        }

        [Test]
        public void ConcreteDerivedClass_IsASetUpFixture_ForItsOwnNamespace()
        {
            var tree = BuildTestTree();

            var fixture = Find(tree, typeof(Consumer.ConsumerEnvironment));
            Assert.That(fixture, Is.Not.Null);
            Assert.That(fixture.TestType, Is.EqualTo("SetUpFixture"));
            Assert.That(fixture.Parent?.FullName, Is.EqualTo("Snippets.NUnit.Attributes.SetUpFixtureInheritance"));
            Assert.That(Find(fixture, typeof(Consumer.ConsumerTests)), Is.Not.Null);
        }

        [Test]
        public void DerivedClassWithTestFixtureAttribute_IsATestFixture()
        {
            var tree = BuildTestTree();

            var fixture = Find(tree, typeof(Precedence.DerivedTestFixture));
            Assert.That(fixture, Is.Not.Null);
            Assert.That(fixture.TestType, Is.EqualTo("TestFixture"));
            Assert.That(fixture.TestCaseCount, Is.EqualTo(1));
        }

        [Test]
        public void DerivedClassWithOnlyTestMethods_IsASetUpFixture_AndItsTestsAreNotDiscovered()
        {
            var tree = BuildTestTree();

            var fixture = Find(tree, typeof(Precedence.DerivedWithTestsOnly));
            Assert.That(fixture, Is.Not.Null);
            Assert.That(fixture.TestType, Is.EqualTo("SetUpFixture"));
            Assert.That(fixture.Tests.Select(t => t.Name), Does.Not.Contain(nameof(Precedence.DerivedWithTestsOnly.ThisTestIsNotDiscovered)));
        }
    }
}

namespace Snippets.NUnit.Attributes.SetUpFixtureSharing.SharedPackage
{
    #region SetUpFixtureSharingPackage
    // In the shared package: a plain class with no NUnit attributes.
    public static class SharedTestEnvironment
    {
        public static bool IsStarted { get; private set; }

        public static void Start()
        {
            // Start containers, seed the database, ...
            IsStarted = true;
        }

        public static void Stop()
        {
            IsStarted = false;
        }
    }
    #endregion
}

namespace Snippets.NUnit.Attributes.SetUpFixtureSharing.TestProject
{
    using Snippets.NUnit.Attributes.SetUpFixtureSharing.SharedPackage;

    #region SetUpFixtureSharingConsumer
    // In each test project that uses the package. Put it outside any namespace
    // to cover the whole project.
    [SetUpFixture]
    public class SharedTestEnvironmentSetUp
    {
        [OneTimeSetUp]
        public void Start()
        {
            SharedTestEnvironment.Start();
        }

        [OneTimeTearDown]
        public void Stop()
        {
            SharedTestEnvironment.Stop();
        }
    }

    public class OrderTests
    {
        [Test]
        public void Environment_IsStartedOnceForTheProject()
        {
            Assert.That(SharedTestEnvironment.IsStarted, Is.True);
        }
    }
    #endregion
}

namespace Snippets.NUnit.Attributes.SetUpFixtureSharing.LazyAlternative
{
    public sealed class TestServer
    {
        public static TestServer Start() => new();

        public string BaseAddress => "http://localhost:5000";
    }

    #region SetUpFixtureSharingLazy
    // In the shared package: start the resource the first time any test needs it.
    // Lazy<T> guarantees a single start per test run, but nothing stops the
    // resource at the end of the run.
    public abstract class SharedServerTestBase
    {
        private static readonly Lazy<TestServer> Server = new(TestServer.Start);

        protected static TestServer SharedServer => Server.Value;
    }

    // In a test project: no setup fixture needed.
    public class CustomerTests : SharedServerTestBase
    {
        [Test]
        public void Server_IsAvailable()
        {
            Assert.That(SharedServer.BaseAddress, Does.StartWith("http://"));
        }
    }
    #endregion
}

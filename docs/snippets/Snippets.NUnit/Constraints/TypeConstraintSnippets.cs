using NUnit.Framework;

#pragma warning disable NUnit2045

namespace Snippets.NUnit.Constraints;

public class TypeConstraintSnippets
{
    #region InstanceOfTypeConstraintExamples
    [Test]
    public void InstanceOfTypeConstraint_Examples()
    {
        // Basic type checking
        Assert.That("Hello", Is.InstanceOf(typeof(string)));
        Assert.That("Hello", Is.InstanceOf<string>());
        Assert.That(42, Is.InstanceOf<int>());

        // Inheritance: derived types pass
        Assert.That("Hello", Is.InstanceOf<object>());         // string derives from object
        Assert.That(new List<int>(), Is.InstanceOf<IEnumerable<int>>());

        // Interface checking
        Assert.That(new List<int>(), Is.InstanceOf<IList<int>>());
        Assert.That(new Dictionary<string, int>(), Is.InstanceOf<IDictionary<string, int>>());

        // Negative tests
        Assert.That("Hello", Is.Not.InstanceOf<int>());
        Assert.That((string?)null, Is.Not.InstanceOf<string>());        // null is not an instance of any type
    }
    #endregion

    #region ExactTypeConstraintExamples
    [Test]
    public void ExactTypeConstraint_Examples()
    {
        // Exact type match
        Assert.That("Hello", Is.TypeOf(typeof(string)));
        Assert.That("Hello", Is.TypeOf<string>());
        Assert.That(42, Is.TypeOf<int>());

        // Derived types fail - exact match required
        Assert.That("Hello", Is.Not.TypeOf<object>());         // string is not exactly object
        Assert.That(new List<int>(), Is.TypeOf<List<int>>());
        Assert.That(new List<int>(), Is.Not.TypeOf<IList<int>>()); // List<int> is not exactly IList<int>

        // Common use: distinguish between value types
        Assert.That(42, Is.TypeOf<int>());
        Assert.That(42L, Is.TypeOf<long>());
        Assert.That(42L, Is.Not.TypeOf<int>());
    }
    #endregion

    #region AssignableFromConstraintExamples
    [Test]
    public void AssignableFromConstraint_Examples()
    {
        // A string variable can be assigned from string
        Assert.That("Hello", Is.AssignableFrom(typeof(string)));
        Assert.That("Hello", Is.AssignableFrom<string>());

        // An object variable can be assigned from string (string derives from object)
        Assert.That(new object(), Is.AssignableFrom<string>());

        // An IEnumerable variable can be assigned from List<int>
        IEnumerable<int> items = new List<int>();
        Assert.That(items, Is.AssignableFrom<List<int>>());

        // Negative: an int variable cannot be assigned from string
        Assert.That(5, Is.Not.AssignableFrom(typeof(string)));
    }
    #endregion

    #region AssignableToConstraintExamples
    [Test]
    public void AssignableToConstraint_Examples()
    {
        // A string can be assigned to object (string derives from object)
        Assert.That("Hello", Is.AssignableTo(typeof(object)));
        Assert.That("Hello", Is.AssignableTo<object>());

        // A string can be assigned to IEnumerable<char>
        Assert.That("Hello", Is.AssignableTo<IEnumerable<char>>());

        // A List<int> can be assigned to IList<int>
        Assert.That(new List<int>(), Is.AssignableTo<IList<int>>());
        Assert.That(new List<int>(), Is.AssignableTo<IEnumerable<int>>());

        // Negative: an int cannot be assigned to string
        Assert.That(5, Is.Not.AssignableTo(typeof(string)));
    }
    #endregion

    #region AttributeConstraintExamples
    [TestFixture(Description = "Integration tests")]
    [Category("Database")]
    public class AttributeConstraintExamplesFixture
    {
        [Test]
        public void AttributeConstraint_Examples()
        {
            // Test that a type has an attribute with specific properties
            Assert.That(typeof(AttributeConstraintExamplesFixture), Has.Attribute<TestFixtureAttribute>()
                .Property("Description").EqualTo("Integration tests"));

            Assert.That(typeof(AttributeConstraintExamplesFixture), Has.Attribute(typeof(CategoryAttribute))
                .Property("Name").EqualTo("Database"));
        }
    }
    #endregion

    #region AttributeExistsConstraintExamples
    [Serializable]
    public class SerializableClass { }

    [Test]
    public void AttributeExistsConstraint_Examples()
    {
        // Test that a type has an attribute
        Assert.That(typeof(SerializableClass), Has.Attribute<SerializableAttribute>());

        // Negative test
        Assert.That(typeof(TypeConstraintSnippets), Has.No.Attribute<SerializableAttribute>());
    }
    #endregion
}

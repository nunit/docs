using System;
using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    public class PropertyAttributeExamples
    {
        #region BasicProperty
        [TestFixture]
        [Property("Location", 723)]
        public class MathTests
        {
            [Test]
            [Property("Severity", "Critical")]
            public void AdditionTest()
            {
                Assert.That(2 + 2, Is.EqualTo(4));
            }

            [Test]
            [Property("Severity", "Normal")]
            [Property("Author", "John Doe")]
            public void SubtractionTest()
            {
                // Multiple properties can be applied to a single test
                Assert.That(5 - 3, Is.EqualTo(2));
            }
        }
        #endregion

        #region PropertyTypes
        [TestFixture]
        public class PropertyTypesTests
        {
            [Test]
            [Property("StringProp", "value")]
            [Property("IntProp", 42)]
            [Property("DoubleProp", 3.14)]
            public void TestWithDifferentPropertyTypes()
            {
                // Properties can be string, int, or double
                Assert.Pass();
            }
        }
        #endregion

        #region AccessingProperties
        [TestFixture]
        public class AccessingPropertiesTests
        {
            [Test]
            [Property("Priority", "High")]
            public void TestAccessingProperty()
            {
                // Access properties via TestContext
                var priority = TestContext.CurrentContext.Test.Properties.Get("Priority");
                Assert.That(priority, Is.EqualTo("High"));
            }
        }
        #endregion

        #region CustomPropertyAttribute
        // Define a custom severity level enum
        public enum SeverityLevel
        {
            Critical,
            Major,
            Normal,
            Minor
        }

        // Create a custom property attribute
        [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
        public class SeverityAttribute : PropertyAttribute
        {
            public SeverityAttribute(SeverityLevel level)
                : base(level.ToString())
            {
            }
        }

        [TestFixture]
        public class CustomPropertyTests
        {
            [Test]
            [Severity(SeverityLevel.Critical)]
            public void CriticalTest()
            {
                // The property name is "Severity" (derived from attribute name)
                var severity = TestContext.CurrentContext.Test.Properties.Get("Severity");
                Assert.That(severity, Is.EqualTo("Critical"));
            }

            [Test]
            [Severity(SeverityLevel.Minor)]
            public void MinorTest()
            {
                var severity = TestContext.CurrentContext.Test.Properties.Get("Severity");
                Assert.That(severity, Is.EqualTo("Minor"));
            }
        }
        #endregion
    }
}

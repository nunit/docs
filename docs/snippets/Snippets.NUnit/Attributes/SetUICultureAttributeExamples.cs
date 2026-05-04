using System.Globalization;
using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    public class SetUICultureAttributeExamples
    {
        #region SetUICultureOnFixture
        [TestFixture]
        [SetUICulture("fr-FR")]
        public class FrenchUITests
        {
            [Test]
            public void TestResourceLoading()
            {
                // UI Culture affects resource manager lookups
                // e.g., ResourceManager will look for French resources
                Assert.That(CultureInfo.CurrentUICulture.Name, Is.EqualTo("fr-FR"));
            }

            [Test]
            public void CurrentCultureUnchanged()
            {
                // SetUICulture does NOT affect CurrentCulture
                // Formatting operations use CurrentCulture, not CurrentUICulture
                Assert.That(CultureInfo.CurrentUICulture.Name, Is.EqualTo("fr-FR"));
                Assert.That(CultureInfo.CurrentCulture.Name, Is.Not.EqualTo("fr-FR").Or.EqualTo("fr-FR"));
            }
        }
        #endregion

        #region SetUICultureOnMethod
        [TestFixture]
        public class MixedUITests
        {
            [Test]
            [SetUICulture("de-DE")]
            public void TestWithGermanUI()
            {
                Assert.That(CultureInfo.CurrentUICulture.Name, Is.EqualTo("de-DE"));
            }

            [Test]
            [SetUICulture("es-ES")]
            public void TestWithSpanishUI()
            {
                Assert.That(CultureInfo.CurrentUICulture.Name, Is.EqualTo("es-ES"));
            }
        }
        #endregion

        #region BothCultures
        [TestFixture]
        public class LocalizationTests
        {
            [Test]
            [SetCulture("en-US")]
            [SetUICulture("fr-FR")]
            public void TestWithDifferentCultures()
            {
                // CurrentCulture: affects formatting (numbers, dates, currency)
                Assert.That(CultureInfo.CurrentCulture.Name, Is.EqualTo("en-US"));

                // CurrentUICulture: affects resource loading (UI strings, messages)
                Assert.That(CultureInfo.CurrentUICulture.Name, Is.EqualTo("fr-FR"));

                // Example: Format a number using CurrentCulture (en-US)
                double price = 1234.56;
                string formatted = price.ToString("C"); // Uses en-US currency format
                Assert.That(formatted, Does.Contain("$"));
            }
        }
        #endregion
    }
}

using System;
using System.Globalization;
using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    public class SetCultureAttributeExamples
    {
        #region SetCultureOnFixture
        [TestFixture]
        [SetCulture("fr-FR")]
        public class FrenchCultureTests
        {
            [Test]
            public void TestDateFormatting()
            {
                // This test runs with French culture
                var date = new DateTime(2024, 12, 25);
                string formatted = date.ToString("d");

                // French date format: dd/MM/yyyy
                Assert.That(CultureInfo.CurrentCulture.Name, Is.EqualTo("fr-FR"));
            }

            [Test]
            public void TestNumberFormatting()
            {
                // French uses comma as decimal separator
                double value = 1234.56;
                string formatted = value.ToString("N2");

                Assert.That(formatted, Does.Contain(","));
            }
        }
        #endregion

        #region SetCultureOnMethod
        [TestFixture]
        public class MixedCultureTests
        {
            [Test]
            [SetCulture("de-DE")]
            public void TestWithGermanCulture()
            {
                // Only this test runs with German culture
                Assert.That(CultureInfo.CurrentCulture.Name, Is.EqualTo("de-DE"));
            }

            [Test]
            [SetCulture("ja-JP")]
            public void TestWithJapaneseCulture()
            {
                // Only this test runs with Japanese culture
                Assert.That(CultureInfo.CurrentCulture.Name, Is.EqualTo("ja-JP"));
            }

            [Test]
            public void TestWithDefaultCulture()
            {
                // This test runs with the system's default culture
                Assert.That(CultureInfo.CurrentCulture, Is.Not.Null);
            }
        }
        #endregion

        #region SetCultureWithSetUICulture
        [TestFixture]
        public class CombinedCultureTests
        {
            [Test]
            [SetCulture("fr-FR")]
            [SetUICulture("de-DE")]
            public void TestWithDifferentCultures()
            {
                // Culture affects formatting (numbers, dates)
                Assert.That(CultureInfo.CurrentCulture.Name, Is.EqualTo("fr-FR"));

                // UICulture affects resource loading (UI strings)
                Assert.That(CultureInfo.CurrentUICulture.Name, Is.EqualTo("de-DE"));
            }
        }
        #endregion
    }
}

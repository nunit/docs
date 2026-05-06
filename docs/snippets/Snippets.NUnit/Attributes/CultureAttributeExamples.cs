using System.Globalization;
using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    public class CultureAttributeExamples
    {
        #region CultureInclude
        [TestFixture]
        public class FrenchOnlyTests
        {
            [Test]
            [Culture("fr-FR")]
            public void TestForFrenchCulture()
            {
                // This test only runs when current culture is fr-FR
                Assert.That(CultureInfo.CurrentCulture.Name, Is.EqualTo("fr-FR"));
            }

            [Test]
            [Culture("fr-FR,fr-CA")]
            public void TestForFrenchCultures()
            {
                // This test runs when current culture is fr-FR or fr-CA
                Assert.That(CultureInfo.CurrentCulture.TwoLetterISOLanguageName, Is.EqualTo("fr"));
            }

            [Test]
            [Culture("fr")]
            public void TestForAnyFrenchCulture()
            {
                // Using neutral culture matches any French variant (fr-FR, fr-CA, etc.)
                Assert.That(CultureInfo.CurrentCulture.TwoLetterISOLanguageName, Is.EqualTo("fr"));
            }
        }
        #endregion

        #region CultureExclude
        [TestFixture]
        public class ExcludeCultureTests
        {
            [Test]
            [Culture(Exclude = "en")]
            public void TestExcludingEnglish()
            {
                // This test runs on any culture EXCEPT English variants
                Assert.That(CultureInfo.CurrentCulture.TwoLetterISOLanguageName, Is.Not.EqualTo("en"));
            }

            [Test]
            [Culture(Exclude = "en,de")]
            public void TestExcludingEnglishAndGerman()
            {
                // This test is skipped when culture is English or German
                var lang = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
                Assert.That(lang, Is.Not.EqualTo("en").And.Not.EqualTo("de"));
            }
        }
        #endregion

        #region CultureOnFixture
        [TestFixture]
        [Culture("en-US,en-GB")]
        public class EnglishCultureTests
        {
            [Test]
            public void Test1()
            {
                // All tests in this fixture only run on en-US or en-GB
                Assert.That(CultureInfo.CurrentCulture.Name,
                    Is.EqualTo("en-US").Or.EqualTo("en-GB"));
            }

            [Test]
            public void Test2()
            {
                Assert.That(CultureInfo.CurrentCulture.TwoLetterISOLanguageName, Is.EqualTo("en"));
            }
        }
        #endregion

        #region CultureWithReason
        [TestFixture]
        public class CultureWithReasonTests
        {
            [Test]
            [Culture(Include = "ja-JP", Reason = "This test uses Japanese-specific date formatting")]
            public void TestJapaneseDateFormat()
            {
                // The reason is shown when the test is skipped
                Assert.That(CultureInfo.CurrentCulture.Name, Is.EqualTo("ja-JP"));
            }
        }
        #endregion
    }
}

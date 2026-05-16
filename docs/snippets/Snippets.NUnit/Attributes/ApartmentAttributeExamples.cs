using System.Threading;
using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    public class ApartmentAttributeExamples
    {
        #region ApartmentFixture
        [TestFixture]
        [Apartment(ApartmentState.STA)]
        public class WinFormsTests
        {
            [Test]
            public void TestRunsInSTA()
            {
                // All tests in this fixture run in the STA
                Assert.That(Thread.CurrentThread.GetApartmentState(), Is.EqualTo(ApartmentState.STA));
            }
        }
        #endregion

        #region ApartmentMethod
        [TestFixture]
        public class MixedApartmentTests
        {
            [Test]
            [Apartment(ApartmentState.STA)]
            public void TestRequiringSTA()
            {
                Assert.That(Thread.CurrentThread.GetApartmentState(), Is.EqualTo(ApartmentState.STA));
            }

            [Test]
            [Apartment(ApartmentState.MTA)]
            public void TestRequiringMTA()
            {
                Assert.That(Thread.CurrentThread.GetApartmentState(), Is.EqualTo(ApartmentState.MTA));
            }
        }
        #endregion
    }
}

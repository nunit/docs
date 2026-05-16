using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    public class DescriptionAttributeExamples
    {
        #region DescriptionFixture
        [TestFixture]
        [Description("Tests for the shopping cart functionality")]
        public class ShoppingCartTests
        {
            [Test]
            public void AddItem_EmptyCart_ItemAdded()
            {
                Assert.Pass();
            }
        }
        #endregion

        #region DescriptionMethod
        [TestFixture]
        public class PaymentTests
        {
            [Test]
            [Description("Verifies that valid credit card payments are processed successfully")]
            public void ProcessPayment_ValidCard_ReturnsSuccess()
            {
                Assert.Pass();
            }

            [Test]
            [Description("Ensures expired cards are rejected with appropriate error")]
            public void ProcessPayment_ExpiredCard_ReturnsError()
            {
                Assert.Pass();
            }
        }
        #endregion

        #region DescriptionNamedParameter
        [TestFixture(Description = "Integration tests for the user registration flow")]
        public class UserRegistrationTests
        {
            [Test(Description = "Tests complete registration with all required fields")]
            public void Register_AllFieldsValid_CreatesUser()
            {
                Assert.Pass();
            }
        }
        #endregion
    }
}

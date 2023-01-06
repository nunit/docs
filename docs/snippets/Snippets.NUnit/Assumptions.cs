// ReSharper disable ConvertToLambdaExpression
namespace Snippets.NUnit
{
    public class Assumptions
    {
        #region TestThatUsesAssume
        [Test]
        public void Number_Divided_By_Itself_Is1()
        {
            var numberToCheck = 5;
            var divisor = GetMatchingDivisor(numberToCheck);

            Assume.That(divisor, Is.Not.EqualTo(0), () => "divisor must not zero in order for this test to be valid");

            var result = numberToCheck / divisor;
            Assert.That(result, Is.EqualTo(1));
        }

        /// <summary>
        /// Returns same number that's passed in
        /// </summary>
        private int GetMatchingDivisor(int inputNumber)
        {
            // If this ever returned 0, we'd be in trouble
            return inputNumber;
        }
        #endregion
    }
}

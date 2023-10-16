using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    public class ConstraintExamples
    {
        #region AllItemsIsExample
        [Test]
        public void CanUseIsToTalkAboutAllItems()
        {
            int[] arrayOfIntegers = new int[] { 1, 2, 3 };
            string[] arrayOfStrings = new string[] { "a", "b", "c" };

            Assert.That(arrayOfIntegers, Is.All.Not.Null);
            Assert.That(arrayOfIntegers, Is.All.GreaterThan(0));

            Assert.That(arrayOfStrings, Is.All.InstanceOf<string>());
        }
        #endregion

        #region AllItemsHasExample
        [Test]
        public void CanUseHasToTalkAboutAllItems()
        {
            int[] arrayOfIntegers = new int[] { 1, 2, 3 };

            Assert.That(arrayOfIntegers, Has.All.GreaterThan(0));
        }
        #endregion
    }

}

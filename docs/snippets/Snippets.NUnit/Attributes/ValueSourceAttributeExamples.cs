using System.Collections.Generic;
using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    public class ValueSourceAttributeExamples
    {
        private static readonly int[] Numbers = { 1, 2, 3 };

        #region ValueSourceBasic
        [Test]
        public void TestUsingValueSource([ValueSource(nameof(Numbers))] int value)
        {
            Assert.That(value, Is.GreaterThan(0));
        }
        #endregion

        public static IEnumerable<string> Names()
        {
            yield return "Alice";
            yield return "Bob";
        }
    }
}

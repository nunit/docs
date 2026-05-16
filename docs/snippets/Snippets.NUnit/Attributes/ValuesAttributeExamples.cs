using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    public class ValuesAttributeExamples
    {
        #region ValuesAttributeExample
        [Test]
        public void ValuesAttribute_BasicExample([Values(1, 2, 3)] int x, [Values("A", "B")] string s)
        {
            Assert.That(x, Is.GreaterThan(0));
            Assert.That(s, Is.Not.Null);
        }
        #endregion

        #region ValuesAttributeEnumExample
        public enum MyEnumType
        {
            Value1,
            Value2,
            Value3
        }

        [Test]
        public void ValuesAttribute_EnumExample([Values] MyEnumType myEnumArgument)
        {
            Assert.That(myEnumArgument, Is.TypeOf<MyEnumType>());
        }
        #endregion

        #region ValuesAttributeBoolExample
        [Test]
        public void ValuesAttribute_BoolExample([Values] bool value)
        {
            Assert.That(value, Is.EqualTo(true).Or.EqualTo(false));
        }
        #endregion
    }
}

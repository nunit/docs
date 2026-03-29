using NUnit.Framework;

// This attribute is applied at the assembly level
// Uncomment the line below to enable assembly directory resolution
// [assembly: TestAssemblyDirectoryResolve]

namespace Snippets.NUnit.Attributes
{
    [TestFixture]
    public class TestAssemblyDirectoryResolveAttributeExamples
    {
        #region VerifyAttributeExists
        [Test]
        public void VerifyTestAssemblyDirectoryResolveAttributeExists()
        {
            // Verify the attribute type exists and can be instantiated
            var attribute = new TestAssemblyDirectoryResolveAttribute();

            Assert.That(attribute, Is.Not.Null);
            Assert.That(attribute, Is.InstanceOf<NUnitAttribute>());
        }
        #endregion

        #region CheckAssemblyForAttribute
        [Test]
        public void CheckIfAssemblyHasAttribute()
        {
            // Check if the current assembly has the attribute applied
            var assembly = typeof(TestAssemblyDirectoryResolveAttributeExamples).Assembly;
            var attributes = assembly.GetCustomAttributes(
                typeof(TestAssemblyDirectoryResolveAttribute),
                inherit: false);

            // This will be empty unless the attribute is applied to the assembly
            Assert.That(attributes, Is.Empty);
        }
        #endregion
    }
}

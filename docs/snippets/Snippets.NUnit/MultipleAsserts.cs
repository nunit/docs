using NUnit.Framework;
using NUnit.Framework.Legacy;

#pragma warning disable NUnit2005
namespace Snippets.NUnit;

public class MultipleAsserts
{
    #region MultipleAssertsProdCode
    public class CalculationResult
    {
        public double RealPart { get; set; }
        public double ImaginaryPart { get; set; }

    }
    public class SomeCalculator
    {
        public CalculationResult DoCalculation()
        {
            return new CalculationResult
            {
                // Hard-coded for demo
                RealPart = 5.2,
                ImaginaryPart = 3.9
            };
        }
    }
    #endregion

    #region MultipleAssertsTests
    [Test]
    public void MultipleAssertsDemo()
    {
        var situationUnderTest = new SomeCalculator();
        var result = situationUnderTest.DoCalculation();

        Assert.Multiple(() =>
        {
            Assert.That(result.RealPart, Is.EqualTo(5.2));
            Assert.That(result.ImaginaryPart, Is.EqualTo(3.9));
        });

        // Can also work with the classic assertion syntax
        Assert.Multiple(() =>
        {
            ClassicAssert.AreEqual(5.2, result.RealPart, "Real Part");
            ClassicAssert.AreEqual(3.9, result.ImaginaryPart, "Imaginary Part");
        });
    }
    #endregion

    #region MultipleAssertsScopes
    [Test]
    public void MultipleAssertsScopeDemo()
    {
        var situationUnderTest = new SomeCalculator();
        var result = situationUnderTest.DoCalculation();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.RealPart, Is.EqualTo(5.2));
            Assert.That(result.ImaginaryPart, Is.EqualTo(3.9));
        }

        // Can also work with the classic assertion syntax
        using (Assert.EnterMultipleScope())
        {
            ClassicAssert.AreEqual(5.2, result.RealPart, "Real Part");
            ClassicAssert.AreEqual(3.9, result.ImaginaryPart, "Imaginary Part");
        }
    }
    #endregion
}
namespace Snippets.NUnit;

public class MultipleAsserts
{
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
    }
}
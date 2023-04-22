namespace Converter.Tests;

public class TemperatureConverterTests
{
    #region ConvertCToF_Zero_Returns32
    [Test]
    public void ConvertCToF_Zero_Returns32()
    {
        // Arrange
        var sut = new TemperatureConverter();

        // Act
        var result = sut.ConvertCToF(0);

        // Assert
        Assert.That(result, Is.EqualTo(32));
    }
    #endregion
    #region ConvertCToF_100_Returns212
    [Test]
    public void ConvertCToF_100_Returns212()
    {
        // Arrange
        var sut = new TemperatureConverter();

        // Act
        var result = sut.ConvertCToF(100);

        // Assert
        Assert.That(result, Is.EqualTo(212));
    }
    #endregion
    #region RemainingExamples
    [Test]
    public void ConvertCToF_37_Returns98point6()
    {
        // Arrange
        var sut = new TemperatureConverter();

        // Act
        var result = sut.ConvertCToF(37);

        // Assert
        Assert.That(result, Is.EqualTo(98.6));
    }

    [Test]
    public void ConvertCToF_Negative40_ReturnsNegative40()
    {
        // Arrange
        var sut = new TemperatureConverter();

        // Act
        var result = sut.ConvertCToF(-40);

        // Assert
        Assert.That(result, Is.EqualTo(-40));
    }

    #endregion
}

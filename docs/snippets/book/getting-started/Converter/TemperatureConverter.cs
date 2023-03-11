namespace Converter;

public class TemperatureConverter
{
    public decimal ConvertCToF(decimal celsius)
    {
        return celsius * 9 / 5 + 32;
    }
}
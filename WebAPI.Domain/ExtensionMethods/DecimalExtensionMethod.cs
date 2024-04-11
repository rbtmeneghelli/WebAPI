namespace WebAPI.Domain.ExtensionMethods;

public static class DecimalExtensionMethods
{
    public static decimal SumDecimalValues(decimal firstValue, decimal secondValue)
    {
        return decimal.Add(firstValue, secondValue);
    }

    public static decimal SubtractDecimalValues(decimal firstValue, decimal secondValue)
    {
        return decimal.Subtract(firstValue, secondValue);
    }

    public static decimal MultiplyDecimalValues(decimal firstValue, decimal secondValue)
    {
        return decimal.Multiply(firstValue, secondValue);
    }

    public static decimal ModDivisionDecimalValues(decimal firstValue, decimal secondValue)
    {
        return decimal.Remainder(firstValue, secondValue);
    }

    public static decimal RoundDecimalValues(decimal firstValue)
    {
        return decimal.Round(firstValue, 2);
    }

    public static decimal DivideDecimalValues(decimal firstValue, decimal secondValue)
    {
        return decimal.Divide(firstValue, secondValue);
    }

    public static decimal GetMaxValue(decimal firstValue, decimal secondValue)
    {
        return decimal.Max(firstValue, secondValue);
    }

    public static decimal GetMinValue(decimal firstValue, decimal secondValue)
    {
        return decimal.Min(firstValue, secondValue);
    }
}

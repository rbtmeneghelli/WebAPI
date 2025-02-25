﻿using Newtonsoft.Json.Linq;

namespace WebAPI.Domain.ExtensionMethods;

public static class DecimalExtensionMethods
{
    public static decimal Sum(this decimal input, decimal value) => decimal.Add(input, value);
    public static decimal Subtract(this decimal input, decimal value) => decimal.Subtract(input, value);
    public static decimal Multiply(this decimal input, decimal value) => decimal.Multiply(input, value);
    public static decimal ModDivision(this decimal input, decimal value) => decimal.Remainder(input, value);
    public static decimal Round(this decimal input, int decimals = 2) => decimal.Round(input, decimals);
    public static decimal Divide(this decimal input, decimal value) => decimal.Divide(input, value);

    public static decimal GetMaxValue(decimal firstValue, decimal secondValue)
    {
        return decimal.Max(firstValue, secondValue);
    }

    public static decimal GetMinValue(decimal firstValue, decimal secondValue)
    {
        return decimal.Min(firstValue, secondValue);
    }
}

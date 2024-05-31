using WebAPI.Domain.Models;
using System.Text.RegularExpressions;

namespace WebAPI.Domain;

public static class GuardClauses
{
    public static bool ObjectIsNull(object argumentValue) => argumentValue is null;

    public static bool ObjectIsNotNull(object argumentValue) => argumentValue is not null;

    public static bool IsNullOrWhiteSpace(string argumentValue) => string.IsNullOrWhiteSpace(argumentValue);

    public static void IsNotZero(int argumentValue, string argumentName)
    {
        if (argumentValue == 0)
            throw new ArgumentException($"Argumento '{argumentName}' não pode ser zero");
    }

    public static void IsNotSmallerThan(int maxValue, int argumentValue, string argumentName)
    {
        if (argumentValue >= maxValue)
            throw new ArgumentException($"Argumento '{argumentName}' não pode exceder '{maxValue}'");
    }

    public static void IsNotBiggerThan(int minValue, int argumentValue, string argumentName)
    {
        if (argumentValue <= minValue)
            throw new ArgumentException($"Argumento '{argumentName}' não pode ser menor que '{minValue}'");
    }

    public static bool IsBinaryString(string binaryContent) => Regex.IsMatch(binaryContent, "^[01]+$");

    public static bool HaveDataOnList<T>(List<T> list)
    {
        return ObjectIsNotNull(list) ? list.Count > 0 : false;
    }

    public static bool HaveDataOnList<T>(IEnumerable<T> list)
    {
        return ObjectIsNotNull(list) ? list.Count() > 0 : false;
    }

    public static bool IsNumberOnInterval(int minInterval, int number, int maxInterval) => number >= minInterval && number <= maxInterval;

    public static bool ValidatePropertyObject(DropDownList dropDownList) => dropDownList is { Id : > 0, Id: <= 100 };

    public static bool IsEqualString(string value, string word) => value.Equals(word, StringComparison.OrdinalIgnoreCase);

    public static bool IntervalMaxLengthIsOk(string argumentValue, int minLength, int maxLength) => argumentValue.Length < minLength || argumentValue.Length > maxLength;

    public static bool HasAnyDigit(string argumentValue) => argumentValue.Any(p => char.IsDigit(p));

    public static bool HasAnyUpperChar(string argumentValue) => argumentValue.Any(p => char.IsUpper(p));

    public static bool HasAnyLowerChar(string argumentValue) => argumentValue.Any(p => char.IsLower(p));

    public static bool HasAnySymbolChar(string argumentValue) => argumentValue.Any(p => char.IsSymbol(p));
}
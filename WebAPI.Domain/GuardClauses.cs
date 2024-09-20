using WebAPI.Domain.Models;
using System.Text.RegularExpressions;

namespace WebAPI.Domain;

public static class GuardClauses
{
    public static bool ObjectIsNull(object argumentValue) => argumentValue is null;

    public static bool ObjectIsNotNull(object argumentValue) => argumentValue is not null;

    public static bool IsNullOrWhiteSpace(string argumentValue) => string.IsNullOrWhiteSpace(argumentValue);

    public static bool IsBiggerThanZero(int argumentValue, string argumentName) => argumentValue > 0;

    public static bool IsValueBiggerThanMax( int argumentValue, int maxValue) => argumentValue >= maxValue;

    public static bool IsValueBiggerThanMin(int argumentValue, int minValue) => argumentValue <= minValue;

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
using Newtonsoft.Json;
using System.Globalization;
using System.Text;

namespace WebAPI.Domain.ExtensionMethods;

public static class StringExtensionMethod
{
    public static string ApplyTrim(this string text) => GuardClauses.IsNullOrWhiteSpace(text) == false ? text.Trim() : text;

    public static string ApplySubString(this string text, int startIndex, int length) => GuardClauses.IsNullOrWhiteSpace(text) == false ? text.Substring(startIndex, length) : text;

    public static string ApplyReplace(this string text, string oldChar, string newChar) => GuardClauses.IsNullOrWhiteSpace(text) == false ? text.Replace(oldChar, newChar) : text;

    public static string SerializeObject(this object data) => JsonConvert.SerializeObject(data.SerializeObject(), Formatting.Indented);
    
    public static TSource DeserializeObject<TSource>(this string data) => JsonConvert.DeserializeObject<TSource>(data);
    
    public static StringBuilder BuildString(List<string> listStrings, bool hasWordBreak)
    {
        StringBuilder sb = new StringBuilder();

        foreach (var itemString in listStrings)
        {
            if (hasWordBreak)
                sb.AppendLine(itemString);
            else
                sb.Append(itemString).Append('\n');
        }

        return sb;
    }

    public static int GetFirstIndexPositionFromWord(string value, string valueToFind, int indexStart = 0)
    {
        if (value.IndexOf(valueToFind) != -1 && indexStart == 0)
            return value.IndexOf(valueToFind);

        else if (value.IndexOf(valueToFind) != -1 && indexStart > 0)
            return value.IndexOf(valueToFind, indexStart);

        return -1;
    }

    public static int GetLastIndexPositionFromWord(string value, string valueToFind, int indexStart = 0)
    {
        if (value.LastIndexOf(valueToFind) != -1 && indexStart == 0)
            return value.LastIndexOf(valueToFind);

        else if (value.LastIndexOf(valueToFind) != -1 && indexStart > 0)
            return value.LastIndexOf(valueToFind, indexStart);

        return -1;
    }

    public static string TransformListOrArrayInString(List<string> list)
    {
        if (list is not null)
            return string.Join(",", list);

        return string.Empty;
    }

    public static string TurnFirstWordFromLetterToUpperCase(this string text, string language = "pt-BR")
    {
        var textResult = CultureInfo.GetCultureInfo(language).TextInfo;
        return textResult.ToTitleCase(text);
    }

    public static string ApplyRemoveAccent(this string text)
    {
        return new string(text
            .Normalize(NormalizationForm.FormD)
            .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
            .ToArray());
    }

    #region Literal string bruta

    public static string setLiteralStringSimple() => """ Este e o seu "Token": "XXXXXXXXXXXXXXX" """;

    public static string setLiteralString(this string textQuotationMarks) => $""" Este e o seu "Token": {textQuotationMarks}""";

    #endregion
}

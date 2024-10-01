using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace WebAPI.Domain.ExtensionMethods;

public static class StringExtensionMethod
{
    public static string ApplyTrim(this string text) => GuardClauses.IsNullOrWhiteSpace(text) == false ? text.Trim() : text;

    public static string ApplySubString(this string text, int startIndex, int length) => GuardClauses.IsNullOrWhiteSpace(text) == false ? text.Substring(startIndex, length) : text;

    public static string ApplyReplace(this string text, string oldChar, string newChar) => GuardClauses.IsNullOrWhiteSpace(text) == false ? text.Replace(oldChar, newChar) : text;

    public static string SerializeObject(this object data) => JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
    
    public static TSource DeserializeObject<TSource>(this string data) => JsonSerializer.Deserialize<TSource>(data);
    
    public static StringBuilder BuildString(IEnumerable<string> listStrings, bool hasWordBreak)
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

    public static string TransformListOrArrayInString(IEnumerable<string> list)
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

    public static string GetEmptyString()
    {
        return string.Empty;
    }

    public static string FormatCpfOrCnpj(this string text)
    {
        if(string.IsNullOrEmpty(text))
            return GetEmptyString();

        if (text.Length == 11)
            return text.Insert(3, ".").Insert(7, ".").Insert(11, "-");
        else if (text.Length == 14)
            return text.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
        else
            return text;
    }

    public static string RemoveFormatCpfCnpj(this string text)
    {
        string[] arrSpecialChar = [".", "-", "/"];
        for(int i = 0; i < arrSpecialChar.Length -1; i++)
        {
            text = text.ApplyReplace(arrSpecialChar[i],GetEmptyString());
        }
        return text;
    }

    public static string TransformBoolToString(this bool varBoolean) => varBoolean ? "1" : "0";

    public static bool TransformStringToBool(this string varString) => bool.Parse(varString);

    public static string GetOnlyNumbers(this string text)
    {
        if (GuardClauses.IsNullOrWhiteSpace(text))
            return GetEmptyString();

        var numbers = text.Where(char.IsDigit).ToArray();
        if (GuardClauses.ObjectIsNull(numbers) || numbers.Length == 0)
            return GetEmptyString();

        return new string(numbers);
    }
    public static string TransformStringToDate(this string value)
    {
        return DateTime.TryParse(value, out var date) ? date.ToString("yyyy-MM-dd") : value;
    }
    public static string RemoveSpecialCharacters(this string text)
    {
        string[] specialCharacters = { "=", ":", "%", "/" };
        string result = string.Empty;
        string partText = string.Empty;
        if (GuardClauses.IsNullOrWhiteSpace(text) == false)
        {
            for (int i = 0; i < text.Length; i++)
            {
                partText = text.ApplySubString(i, 1);
                if (!specialCharacters.Contains(partText))
                    result += partText;
            }
            return result;
        }
        return text;
    }
    public static string StripHTML(this string input)
    {
        return Regex.Replace(input, "<.*?>", String.Empty);
    }
    public static string RemoveQuotationMarks(this string value)
    {
        if (GuardClauses.IsNullOrWhiteSpace(value) == false && value.EndsWith("\'") || value.EndsWith("\""))
            return value.ApplyReplace("\'", "").ApplyReplace("\"", "").ApplyTrim();
        return value;
    }
    public static string FormatCnpj(this string texto)
    {
        return Convert.ToUInt64(texto).ToString(@"00\.000\.000\/0000\-00");
    }
    public static string FormatCpf(this string texto)
    {
        return Convert.ToUInt64(texto).ToString(@"000\.000\.000\-00");
    }
    public static string FormatStringBase64ToString(this string text)
    {
        return Encoding.UTF8.GetString(Convert.FromBase64String(text));
    }

    #region Metodo para pegar o base64 do front (btoa ou atob) e faz o processo de conversão

    public static string EncodingString(this string toEncode)
    {
        byte[] bytes = Encoding.GetEncoding("UTF-8").GetBytes(toEncode);
        return Convert.ToBase64String(bytes);
    }

    public static string DecodingString(this string toDecode)
    {
        byte[] bytes = Convert.FromBase64String(toDecode);
        return ASCIIEncoding.ASCII.GetString(bytes);
    }

    #endregion
}

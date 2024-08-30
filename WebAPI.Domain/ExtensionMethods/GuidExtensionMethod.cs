namespace WebAPI.Domain.ExtensionMethods;

/// <summary>
/// Formatos do GUID
/// D: 32 dígitos, mas com os hífens. Esse é o padrão;
/// N: 32 dígitos, sem outros símbolos; (Ideal para usar em nome de arquivos)
/// B: Usa os hífens e a string é envolta entre chaves
/// P: semelhante a B, mas com parênteses em vez de chaves
/// X:  Usa a representação hexadecimal do guid.
/// </summary>
public static class GuidExtensionMethod
{
    public static string GetGuidDigits(string typeGuid) => Guid.NewGuid().ToString(typeGuid);
    public static Guid GetGuidDigitsByString(this string text) => Guid.Parse(text);
}

namespace TestsWebAPI.Models;

public static class Constants
{
    public const string TOKEN_INVALID = "O token de autenticação está invalido. por favor renove o token para prosseguir seus testes.";
    public const string TOKEN_NOT_EXIST = "O token de autenticação não existe. por favor cria-lo.";
    public const string URL_AUTHENTICATE_FAIL = "Ocorreu um erro na autenticação para gravação do token";
    public const string URL_FAIL_GET_DATA = "Falha ao obter dados do endpoint solicitado via GET";

    /// <summary>
    /// Primeiro irei Obter a data e hora atual em GMT,
    /// Definir o fuso horário de São Paulo,
    /// Converte a data e hora atual para o fuso horário de São Paulo
    /// </summary>
    /// <returns></returns>
    public static DateTime GetDateTimeNowFromBrazil()
    {
        TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
        DateTime dateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tz);
        return dateTime;
    }
}

public static class ConstantsURL
{
    public const string API_URL = "http://localhost:7071/api/";
    public const string URL_AUTHENTICATE = "authenticate";
    public const string URL_GET_PROPOSALTYPE = "proposaltype/get";
}
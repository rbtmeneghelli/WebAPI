namespace WebAPI.Domain.Constants;

public static class FixConstantsUrl
{
    public const string URL_TO_GET_FIREBASE = "https://fcm.googleapis.com/fcm/send";
    public const string URL_TO_GET_FIREBASE_V2 = "https://fcm.googleapis.com/v1/projects/webapi-ce363/messages:send";
    public const string URL_TO_GET_ZIPPOSTALCODE = "http://viacep.com.br/ws/{0}/json";
    public const string URL_TO_GET_ZIPPOSTALCODE_II = "https://brasilapi.com.br/api/cep/v1/{0}";
    public const string URL_TO_GET_ZIPPOSTALCODE_III = "https://api.brasilaberto.com/v1/zipcode/{0}";
    public const string URL_TO_GET_ZIPPOSTALCODE_IV = "https://opencep.com/v1/12240020";
    public const string URL_TO_GET_STATES = "https://servicodados.ibge.gov.br/api/v1/localidades/estados";
    public const string URL_TO_GET_CITIES = "https://servicodados.ibge.gov.br/api/v1/localidades/estados/{0}/municipios";
    public const string URL_TO_HANGFIRE = "https://{url}:9000/hangfire/servers";
    public const string URL_TO_RABBITMQ = "https://{url}:15672";
    public const string URL_TO_KISSLOG = "https://kisslog.net/Dashboard/{KissLog.ApplicationId}/defaultapi";
    public const string URL_TO_GET_BANKS = "https://brasilapi.com.br/api/banks/v1";
    public const string URL_TO_GET_CITIES_II = "https://brasilapi.com.br/api/ibge/municipios/v1/{0}?providers=dados-abertos-br,gov,wikipedia";
    public const string URL_TO_GET_HOLIDAYS = "https://brasilapi.com.br/api/feriados/v1/{0}";
    public const string URL_TO_GET_FIPE = "https://brasilapi.com.br/api/fipe/marcas/v1/{0}";
    public const string URL_TO_GET_CNPJ = "https://brasilapi.com.br/api/cnpj/v1/{0}";
}

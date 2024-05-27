using System.Net;
using Microsoft.Extensions.Configuration;
using WebAPI.Domain.ExtensionMethods;

namespace WebAPI.Domain;

public static class FixConstants
{
    public const int SALT_SIZE = 16;
    public const int HASH_SIZE = 20;
    public const string DEFAULT_PASSWORD = "123mudar";

    public const string SERVER_API_KEY = "AIzaSyD2i3-nX8RkclUxWPFwirDHKN_D0x2h4Pc"; // Get this from your Firebase Developer Console Login  
    public const string SENDER_ID = "AAAANLjaZwE:APA91bFAfv1CviU_8WyiL971mnqBXi2m6qJax9VwWvmUOnMepnShnGeZmw_sBYAAe3YH5CW370xJm-LZrWCMNt5CMK_Hn8fhigbtc5OaJd0_rqubiHK4hEI4CFh179hfTmwMoHOk9QkW"; // Get this from your Firebase Developer Console Login  

    public const string URL_TO_GET_FIREBASE = "https://fcm.googleapis.com/v1/projects/webapi-ce363/messages:send";
    public const string URL_TO_GET_CEP = "http://viacep.com.br/ws/{0}/json"; //Param >> Cep
    public const string URL_TO_GET_STATES = "https://servicodados.ibge.gov.br/api/v1/localidades/estados";
    public const string URL_TO_GET_CITIES = "https://servicodados.ibge.gov.br/api/v1/localidades/estados/{0}/municipios";
    public const string URL_TO_HANGFIRE = "https://{url}:9000/hangfire/servers";
    public const string URL_TO_RABBITMQ = "https://{url}:15672";
    public const string URL_TO_KISSLOG = "https://kisslog.net/Dashboard/{KissLog.ApplicationId}/defaultapi";
    public const string URL_TO_GET_BANKS = "https://brasilapi.com.br/api/banks/v1";
    public const string URL_TO_GET_CITIES_II = "https://brasilapi.com.br/api/ibge/municipios/v1/{0}?providers=dados-abertos-br,gov,wikipedia"; // Param >> SiglaUF
    public const string URL_TO_GET_HOLIDAYS = "https://brasilapi.com.br/api/feriados/v1/{0}"; //Param >> Ano
    public const string URL_TO_GET_FIPE = "https://brasilapi.com.br/api/fipe/marcas/v1/{0}"; // Param >> tipoVeiculo

    public const string SAVE_LOG = @"insert into Logs(Class,Method,Message_Error,Update_time,Object) values('{0}','{1}','{2}','{3}','{4}')";

    public const string EXCEPTION_REQUEST_API = "Erro ao efetuar request da Api externa: ";
    public const string EXCEPTION_EXCEL = "Erro ao gerar o excel solicitado";

    public const string ERROR_IN_ADD = "Ocorreu um erro ao adicionar um novo registro. Entre em contato com o Administrador";
    public const string ERROR_IN_UPDATE = "Ocorreu um erro ao atualizar um registro. Entre em contato com o Administrador";
    public const string ERROR_IN_DELETELOGIC = "Ocorreu um erro ao deletar o registro de forma logica. Entre em contato com o Administrador";
    public const string ERROR_IN_DELETEPHYSICAL = "Ocorreu um erro ao deletar o registro de forma fisica. Entre em contato com o Administrador";
    public const string ERROR_IN_RESEARCH = "Ocorreu um erro ao pesquisar um registro. Entre em contato com o Administrador";
    public const string ERROR_IN_GETALL = "Ocorreu um erro para pesquisar todos os registros. Entre em contato com o Administrador";
    public const string ERROR_IN_GETID = "Ocorreu um erro para pesquisar o registro do ID solicitado. Entre em contato com o Administrador";
    public const string ERROR_IN_GETDDL = "Ocorreu um erro para retornar os dados de dropdownlist. Entre em contato com o Administrador";
    public const string ERROR_IN_LOGIN = "As autenticações fornecidas são invalidas. tente novamente!";
    public const string ERROR_IN_CHANGEPASSWORD = "Ocorreu um erro ao efetuar a troca de senha. Entre em contato com o Administrador";
    public const string ERROR_IN_RESETPASSWORD = "Não foi encontrado um usuário cadastrado no sistema com o email informado. Entre em contato com o Administrador";
    public const string ERROR_IN_ACTIVERECORD = "Ocorreu um erro ao efetuar a reativação do registro. Entre em contato com o Administrador";
    public const string ERROR_IN_BACKUP = "Ocorreu um erro para efetuar a execução do backup. Entre em contato com o Administrador";
    public const string ERROR_IN_PROCEDURE = "Ocorreu um erro para efetuar a execução da procedure {0}. Entre em contato com o Administrador";
    public const string ERROR_IN_ADDCITY = "Ocorreu um erro para adicionar as cidades na base de dados. Entre em contato com o Administrador";
    public const string ERROR_IN_REFRESHTOKEN = "Token Invalido";
    public const string ERROR_IN_REFRESHCEP = "Ocorreu um erro para atualizar/adicionar ceps. Entre em contato com o Administrador";
    public const string ERROR_IN_UPDATESTATUS = "Ocorreu um erro ao atualizar o status de um registro. Entre em contato com o Administrador";
    public const string ERROR_IN_REFRESHREGION = "Ocorreu um erro para atualizar/adicionar regiões. Entre em contato com o Administrador";
    public const string ERROR_IN_REFRESHSTATE = "Ocorreu um erro para atualizar/adicionar estados. Entre em contato com o Administrador";

    public const string SUCCESS_IN_LOGIN = "A autenticação foi efetuada com sucesso";
    public const string SUCCESS_IN_ADD = "O registro foi adicionado com sucesso";
    public const string SUCCESS_IN_UPDATE = "O registro foi atualizado com sucesso";
    public const string SUCCESS_IN_DELETELOGIC = "O registro foi excluído de forma logica com sucesso";
    public const string SUCCESS_IN_DELETEPHYSICAL = "O registro foi excluído de forma fisica com sucesso";
    public const string SUCCESS_IN_NOTFOUND = "O registro solicitado não foi encontrado";
    public const string SUCCESS_IN_CHANGEPASSWORD = "A troca de senha foi efetuada com sucesso";
    public const string SUCCESS_IN_RESETPASSWORD = "O reset de senha foi efetuado com sucesso";
    public const string SUCCESS_IN_ACTIVERECORD = "A reativação do registro foi efetuada com sucesso";
    public const string SUCCESS_IN_RESEARCH = "O registro foi localizado com sucesso";
    public const string SUCCESS_IN_PROCEDURE = "A procedure {0} foi executada com sucesso";
    public const string SUCCESS_IN_BACKUP = "O backup foi executado com sucesso";
    public const string SUCCESS_IN_ADDCITY = "As cidades foram adicionadas com sucesso";
    public const string SUCCESS_IN_GETALL = "Os registros solicitados foram retornados com sucesso";
    public const string SUCCESS_IN_GETALLPAGINATE = "Os registros solicitados foram retornados em paginação com sucesso";
    public const string SUCCESS_IN_GETID = "O registro solicitado foi retornado com sucesso";
    public const string SUCCESS_IN_DDL = "Os dados de dropdownlist foram retornados com sucesso";

    public const string NO_AUTHORIZATION = "Caro usuário você não tem permissão para efetuar tal ação. Entre em contato com o Administrador";

    public const string DEV_FIRSTNAME = "Roberto";
    public const string DEV_SECONDNAME = "Meneghelli";
    public const string CONSTANTE_COM_INTERPOLACAO = $"{DEV_FIRSTNAME}-{DEV_SECONDNAME}";

    public const string STATUS_ACTIVE = "Ativo";
    public const string STATUS_INACTIVE = "Inativo";

    public const string QUOTE = "\"";

    public const int INTERNAL_ERROR_CODE = (int)HttpStatusCode.InternalServerError;
    public const int UNAUTHORIZED_ERROR_CODE = (int)HttpStatusCode.Unauthorized;
    public const int FORBIDDEN_ERROR_CODE = (int)HttpStatusCode.Forbidden;

    public const string MESSAGE_ERROR_APP_EX = "Atenção! Ocorreu um erro ao processar os dados. Tente novamente!";
    public const string MESSAGE_ERROR_UNAUTH_EX = "Atenção! Usuário não possui privilegios de permissão para prosseguir com a requisição solicitada!";
    public const string MESSAGE_ERROR_FORB_EX = "Sua sessão expirou, faça login novamente!";

    public const string OFFICE_STREAM = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    public const string PDF_STREAM = "application/pdf";

    public static TSource GetEnvironmentVariableToObject<TSource>(IConfiguration configuration, string varName)
    {
        var data = Environment.GetEnvironmentVariable(configuration[varName]) ?? string.Empty;
        return !string.IsNullOrWhiteSpace(data) ? data.DeserializeObject<TSource>() : default;
    }

    public static string[] GetEnvironmentVariableToStringArray<TSource>(IConfiguration configuration, string varName)
    {
        var data = Environment.GetEnvironmentVariable(configuration[varName]) ?? string.Empty;
        return !string.IsNullOrWhiteSpace(data) ? data.Split(',') : default;
    }
}
namespace WebAPI.Domain.Constants;

public static class FixConstants
{
    public const int SALT_SIZE = 16;
    public const int HASH_SIZE = 20;
    public const string DEFAULT_PASSWORD = "123mudar";

    public const string SERVER_API_KEY = "AIzaSyD2i3-nX8RkclUxWPFwirDHKN_D0x2h4Pc";  
    public const string SENDER_ID = "AAAANLjaZwE:APA91bFAfv1CviU_8WyiL971mnqBXi2m6qJax9VwWvmUOnMepnShnGeZmw_sBYAAe3YH5CW370xJm-LZrWCMNt5CMK_Hn8fhigbtc5OaJd0_rqubiHK4hEI4CFh179hfTmwMoHOk9QkW"; // Get this from your Firebase Developer Console Login  

    public const string SAVE_LOG = @"insert into ControlPanel_Logs(Class,Method,Error,UpdateDate,Object) values('{0}','{1}','{2}','{3}','{4}')";

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
    public const string ERROR_TOKEN_INVALID = "O token informado é invalido.";
    public const string ERROR_INTERNAL = "Ocorreu um erro interno no processamento dos dados pela API. Entre em contato com o Administrador";

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

    public const string QUOTE = "\"";

    public const string MESSAGE_ERROR_APP_EX = "Atenção! Ocorreu um erro ao processar os dados. Tente novamente!";
    public const string MESSAGE_ERROR_UNAUTH_EX = "Atenção! Usuário não possui privilegios de permissão para prosseguir com a requisição solicitada!";
    public const string MESSAGE_ERROR_FORB_EX = "Sua sessão expirou, faça login novamente!";

    public const string ID = "O Id não pode ser negativo";

    public const string CACHE_KEY_ID = "{0}_Id";
    public const string CACHE_KEY_ALL = "{0}_All";
}
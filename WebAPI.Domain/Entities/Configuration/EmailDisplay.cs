using WebAPI.Domain.Generic;
using MimeKit;
using WebAPI.Domain.ExtensionMethods;

namespace WebAPI.Domain.Entities.Configuration;

public class EmailDisplay : GenericEntity
{
    public string Title { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public MessagePriority Priority { get; set; }
    public bool HasAttachment { get; set; }
    public virtual EmailTemplate EmailTemplates { get; set; }
    public long EmailTemplateId { get; set; }

    public static string GetTitleDefault()
    {
        return "Padrão";
    }

    public static string GetTitleWelcome()
    {
        return "Boas vindas";
    }

    public static string GetTitleForgetPsw()
    {
        return "Esqueci a senha";
    }

    public static string GetTitleTradePsw()
    {
        return "Troca de senha";
    }
    public static string GetTitleConfirmPsw()
    {
        return "Confirmação de senha";
    }

    public static string GetTitleReport()
    {
        return "Relatório";
    }

    public static string GetSubjectDefault()
    {
        return "Bem vindo ao sistema {0}";
    }

    public static string GetSubjectWelcome()
    {
        return "Bem vindo ao sistema {0}";
    }

    public static string GetSubjectForgetPsw()
    {
        return "{0} - Esqueci a senha";
    }

    public static string GetSubjectTradePsw()
    {
        return "{0} - Solicitação de troca de senha";
    }
    public static string GetSubjectConfirmPsw()
    {
        return "{0} - Confirmação de senha";
    }

    public static string GetSubjectReport()
    {
        return "{0} - Relatório";
    }

    public static string GetBodyTextResetPsw()
    {
        return $"Caro Administrador, <br> Sua senha de administrador foi resetada com sucesso. <br> Segue a sua nova senha: {FixConstants.DEFAULT_PASSWORD} ";
    }

    public static string GetBodyTextWelcome()
    {
        return "Olá, {0}" + "<br>" +
        "Seja bem vindo ao <b>{1}</b>" + "<br> " +
        "Utilize a senha <b>1234</b> para acessar o sistema e usufrua de todas as ferramentas disponíveis." + "<br>";
    }

    public static string GetBodyTextForgetPsw()
    {
        return "<center>Olá, {0}</center>" +
        "<center>Conforme sua solicitação enviamos este email para que você possa concluir sua solicitação de esqueci a senha. Clique no botão abaixo.</center>" + "<br> ";
    }

    public static string GetBodyTextTradePsw()
    {
        return "<center>Olá, {0}</center>" +
            "<center>Conforme sua solicitação enviamos este email para que você possa concluir sua solicitação de troca de senha. Clique no botão abaixo.</center>" + "<br> ";
    }

    public static string GetBodyTextConfirmPsw()
    {
        return "<center>Olá, {0}</center>" +
        $"<center>Quero reporta-lo que a sua confirmação de senha foi realizada com sucesso no periodo das {DateOnlyExtensionMethods.GetShortDate()} - {DateOnlyExtensionMethods.GetShortTime()}</center>" + "<br> ";
    }
}

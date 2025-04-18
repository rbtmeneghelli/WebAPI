using FastPackForShare.Constants;
using FastPackForShare.Default;
using FastPackForShare.Extensions;
using MimeKit;
using WebAPI.Domain.Constants;

namespace WebAPI.Domain.Entities.Configuration;

public class EmailDisplay : BaseEntityModel
{
    public string Title { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public MessagePriority MessagePriority { get; set; }
    public bool HasAttachment { get; set; }
    public virtual EmailTemplate EmailTemplates { get; set; }
    public long EmailTemplateId { get; set; }

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

    protected override void CreateEntityIsValid()
    {
        BaseDomainException.When(GuardClauseExtension.IsNullOrWhiteSpace(Title), ConstantValidation.REQUIRED);
    }

    protected override void UpdateEntityIsValid()
    {
        BaseDomainException.When(GuardClauseExtension.IsNullOrWhiteSpace(Title), ConstantValidation.REQUIRED);
    }
}

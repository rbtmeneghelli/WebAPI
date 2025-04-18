using FastPackForShare.Extensions;
using WebAPI.Domain.Enums;
using WebAPI.Domain.Interfaces.Factory;

namespace WebAPI.Domain.Models.Factory.Email;

public sealed class EmailChangePassword : IEmailConfigFactory
{
    public int GetDisplayIdToSend()
    {
        return (int)EnumEmail.ChangePassword;
    }

    public (string Subject, string TemplateId) GetSendGridIdToSend()
    {
        return (EnumEmail.ChangePassword.GetDisplayShortName(), "d-0000b111d222222222222c333333333333");
    }

    public string GetBodyText()
    {
        return "<center>Olá, {0}</center>" +
            "<center>Conforme sua solicitação enviamos este email para que você possa concluir sua solicitação de troca de senha. Clique no botão abaixo.</center>" + "<br> ";
    }
}

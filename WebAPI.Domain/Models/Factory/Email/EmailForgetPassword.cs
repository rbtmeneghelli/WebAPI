using FastPackForShare.Extensions;
using WebAPI.Domain.Enums;
using WebAPI.Domain.Interfaces.Factory;

namespace WebAPI.Domain.Models.Factory.Email;

public sealed class EmailForgetPassword : IEmailConfigFactory
{
    public int GetDisplayIdToSend()
    {
        return (int)EnumEmail.ForgetPassword;
    }

    public (string Subject, string TemplateId) GetSendGridIdToSend()
    {
        return (EnumEmail.ForgetPassword.GetDisplayShortName(), "d-0000b111d222222222222c333333333333");
    }

    public string GetBodyText()
    {
        return "<center>Olá, {0}</center>" +
        "<center>Conforme sua solicitação enviamos este email para que você possa concluir sua solicitação de esqueci a senha. Clique no botão abaixo.</center>" + "<br> ";
    }
}


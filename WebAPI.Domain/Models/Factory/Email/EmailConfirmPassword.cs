using FastPackForShare.Extensions;
using WebAPI.Domain.Enums;
using WebAPI.Domain.Interfaces.Factory;

namespace WebAPI.Domain.Models.Factory.Email;

public sealed class EmailConfirmPassword : IEmailConfigFactory
{
    public EmailConfirmPassword()
    {
    }

    public int GetDisplayIdToSend()
    {
        return (int)EnumEmail.ConfirmPassword;
    }

    public (string Subject, string TemplateId) GetSendGridIdToSend()
    {
        return (EnumEmail.ConfirmPassword.GetDisplayShortName(), "d-0000b111d222222222222c333333333333");
    }

    public string GetBodyText()
    {
        return "<center>Olá, {0}</center>" +
        $"<center>Quero reporta-lo que a sua confirmação de senha foi realizada com sucesso no periodo das {DateOnlyExtension.GetShortDate()} - {DateOnlyExtension.GetShortTime()}</center>" + "<br> ";
    }
}

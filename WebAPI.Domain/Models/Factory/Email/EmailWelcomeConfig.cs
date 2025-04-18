using FastPackForShare.Extensions;
using WebAPI.Domain.Enums;
using WebAPI.Domain.Interfaces.Factory;

namespace WebAPI.Domain.Models.Factory.Email;

public sealed class EmailWelcomeConfig : IEmailConfigFactory
{
    public EmailWelcomeConfig()
    {
    }

    public int GetDisplayIdToSend()
    {
        return (int)EnumEmail.Welcome;
    }

    public (string Subject, string TemplateId) GetSendGridIdToSend()
    {
        return (EnumEmail.Welcome.GetDisplayShortName(), "d-0000b111d222222222222c333333333333");
    }

    public string GetBodyText()
    {
        return "Olá, {0}" + "<br>" +
        "Seja bem vindo ao <b>{1}</b>" + "<br> " +
        "Utilize a senha <b>1234</b> para acessar o sistema e usufrua de todas as ferramentas disponíveis." + "<br>";
    }
}

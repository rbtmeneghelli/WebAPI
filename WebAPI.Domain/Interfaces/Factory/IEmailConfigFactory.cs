namespace WebAPI.Domain.Interfaces.Factory;

public interface IEmailConfigFactory
{
    int GetDisplayIdToSend();
    (string Subject, string TemplateId) GetSendGridIdToSend();
    string GetBodyText();
}

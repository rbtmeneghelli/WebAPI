namespace WebAPI.Application.FactoryInterfaces;

public interface IEmailConfigFactory
{
    int GetDisplayIdToSend();
    (string Subject, string TemplateId) GetSendGridIdToSend();
}

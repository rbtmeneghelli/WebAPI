using MimeKit;
using System.Net.Mail;
using WebAPI.Domain.Entities.Configuration;

namespace WebAPI.Domain.Models;

/// <summary>
/// E um tipo de objeto imutavel, ou seja, não pode ser modificado nem com a palavra chave with
/// Esse tipo de objeto funciona de forma perfomartica do que um readonly comum 
/// </summary>
public readonly record struct EmailConfig
{
    private const string EMAIL_TO = "dev@test.com.br";

    public MailAddress EmailFrom { get; init; }
    public string EmailTo { get; init; }
    public string Title { get; init; }
    public string Subject { get; init; }
    public string Body { get; init; }
    public string Template { get; init; }
    public MessagePriority Priority { get; init; }
    public bool HasAttachment { get; init; }
    public string UserName { get; init; }

    public EmailConfig()
    {
        
    }

    public EmailConfig(EmailDisplay emailDisplay, string userName)
    {
        Title = emailDisplay.Title;
        Subject = emailDisplay.Subject;
        Body = emailDisplay.Body;
        EmailTo = EMAIL_TO;
        Priority = emailDisplay.MessagePriority;
        UserName = userName;
        HasAttachment = emailDisplay.HasAttachment;
        Template = emailDisplay.EmailTemplates.Description;
    }
}

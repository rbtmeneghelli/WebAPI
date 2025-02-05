using MimeKit;
using System.Net.Mail;
using WebAPI.Domain.Entities.Configuration;

namespace WebAPI.Domain.Models;

public class EmailConfig
{
    private const string EMAIL_TO = "dev@test.com.br";

    public MailAddress EmailFrom { get; set; }
    public string EmailTo { get; set; }
    public string Title { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public string Template { get; set; }
    public MessagePriority Priority { get; set; }
    public bool HasAttachment { get; set; }
    public string UserName { get; set; }

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

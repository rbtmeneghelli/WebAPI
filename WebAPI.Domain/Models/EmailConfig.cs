using WebAPI.Domain.Entities;
using MimeKit;
using System.Net.Mail;

namespace WebAPI.Domain.Models;

public class EmailConfig
{
    private const string EMAIL_TO = "roberto.mng.89@gmail.com";

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
        Priority = emailDisplay.Priority;
        UserName = userName;
        HasAttachment = emailDisplay.HasAttachment;
        Template = emailDisplay.EmailTemplate.Description;
    }
}

using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using WebAPI.Application.Generic;
using WebAPI.Application.FactoryInterfaces;
using WebAPI.Domain.Entities.Configuration;

namespace WebAPI.Application.Services;

public class EmailService : GenericService, IEmailService
{
    private readonly IGenericRepository<EmailSettings> _iEmailTypeRepository;
    private readonly IGenericRepository<EmailDisplay> _iEmailDisplayRepository;
    private readonly IEmailFactory _iEmailFactory;
    private EnvironmentVariables _environmentVariables;
    private EmailSettings _emailSettings;

    public EmailService(
        EnvironmentVariables environmentVariables,
        INotificationMessageService notificationMessageService,
        IGenericRepository<EmailSettings> iEmailTypeRepository,
        IGenericRepository<EmailDisplay> iEmailDisplayRepository,
        IEmailFactory iEmailFactory
        ) : base(notificationMessageService)
    {
        _environmentVariables = environmentVariables;
        _iEmailTypeRepository = iEmailTypeRepository;
        _iEmailDisplayRepository = iEmailDisplayRepository;
        _iEmailFactory = iEmailFactory;
    }

    private MimeEntity BuildMessage(EmailConfig emailConfig, string appPath)
    {
        if (emailConfig.HasAttachment)
        {
            var builder = new BodyBuilder();
            builder.HtmlBody = emailConfig.Body;
            builder.Attachments.Add(Path.Combine(appPath, "Arquivos", "arquivo.pdf"));
            return builder.ToMessageBody();
        }
        else
        {
            return new TextPart(TextFormat.Html)
            {
                Text = emailConfig.Body
            };
        }
    }

    private async Task SendEmailAsync(EmailConfig emailConfig, string appPath)
    {
        _emailSettings = _iEmailTypeRepository.GetAll().Where(x => x.IsActive && x.Environment.Equals(_environmentVariables.Environment)).FirstOrDefault();
        var email = new MimeMessage();
        email.Sender = MailboxAddress.Parse(emailConfig.EmailFrom.Address);
        emailConfig.EmailTo.Split(';').ToList().ForEach(p => email.To.Add(MailboxAddress.Parse(p.Trim())));
        email.Subject = emailConfig.Subject;
        email.Priority = emailConfig.Priority;
        email.Body = BuildMessage(emailConfig, appPath);
        await ExecuteMailWithMailKitAsync(emailConfig, email);
    }

    private async Task ExecuteMailWithMailKitAsync(EmailConfig emailConfig, MimeMessage email)
    {
        using (var client = new MailKit.Net.Smtp.SmtpClient())
        {
            try
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect(_emailSettings.SmtpConfig, _emailSettings.PrimaryPort, SecureSocketOptions.Auto);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailSettings.Email, _emailSettings.Password);
                await client.SendAsync(email);
                await client.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                Notify(ex.Message);
            }
            finally
            {
                await client.DisconnectAsync(true);
                client.Dispose();
            }
        }
    }

    public async Task CustomSendEmailAsync(EnumEmail enumEmail, string userName, string appPath = "")
    {
        IEmailConfigFactory iEmailFactoryConfig = _iEmailFactory.SendEmailByEnumEmail(enumEmail);
        var emailDisplay = _iEmailDisplayRepository
                           .GetAll()
                           .Include(x => x.EmailTemplates)
                           .Where(x => x.IsActive && x.Id == iEmailFactoryConfig.GetDisplayIdToSend())
                           .FirstOrDefault();

        if (GuardClauses.ObjectIsNotNull(emailDisplay))
        {
            EmailConfig emailConfig = new(emailDisplay, userName);
            await SendEmailAsync(emailConfig, appPath);
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}

using WebAPI.Domain.Entities.Generic;

namespace WebAPI.Domain.Entities.Configuration;

public class EmailSettings : GenericEntity
{
    public string Host { get; set; }
    public string SmtpConfig { get; set; }
    public int PrimaryPort { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool EnableSsl { get; set; }

    public virtual EnvironmentTypeSettings EnvironmentTypeSettings { get; set; }
    public virtual long? IdEnvironmentType { get; set; }
    public virtual IEnumerable<EmailTemplate> EmailTemplates { get; set; }
}

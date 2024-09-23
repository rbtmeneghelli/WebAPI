using System.ComponentModel;
using WebAPI.Domain.Entities.Generic;

namespace WebAPI.Domain.Entities.Configuration;

public class EnvironmentTypeSettings : GenericEntity
{
    [DisplayName("Nome do ambiente")]
    public string Description { get; set; }

    [DisplayName("Sigla do ambiente")]
    public string Initials { get; set; }

    public virtual IEnumerable<EmailSettings> EmailSettings { get; set; }
    public virtual ExpirationPasswordSettings ExpirationPasswordSettings { get; set; }
    public virtual RequiredPasswordSettings RequiredPasswordSettings { get; set; }
    public virtual AuthenticationSettings AuthenticationSettings { get; set; }
    public virtual LayoutSettings LayoutSettings { get; set; }
    public virtual LogSettings LogSettings { get; set; }
}

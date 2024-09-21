using System.ComponentModel;
using WebAPI.Domain.Entities.Generic;
using WebAPI.Domain.Enums;

namespace WebAPI.Domain.Entities.Configuration;

public class ExpirationPasswordSettings : GenericEntity
{
    [DisplayName("Quantidade de dias para expiração")]
    public int QtyDaysPasswordExpire { get; set; }

    [DisplayName("Notificação de expiração dias antes")]
    public int NotifyExpirationDays { get; set; }

    public virtual EnvironmentTypeSettings EnvironmentTypeSettings { get; set; }
    public virtual long? IdEnvironmentType { get; set; }
}

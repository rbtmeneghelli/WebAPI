using FastPackForShare.Default;

namespace WebAPI.Domain.Entities.Configuration;

public class ExpirationPasswordSettings : BaseEntityModel
{
    [DisplayName("Quantidade de dias para expiração")]
    public int QtyDaysPasswordExpire { get; set; }

    [DisplayName("Notificação de expiração dias antes")]
    public int NotifyExpirationDays { get; set; }

    public virtual EnvironmentTypeSettings EnvironmentTypeSettings { get; set; }
    public virtual long? IdEnvironmentType { get; set; }

    protected override void CreateEntityIsValid()
    {
        throw new NotImplementedException();
    }

    protected override void UpdateEntityIsValid()
    {
        throw new NotImplementedException();
    }
}

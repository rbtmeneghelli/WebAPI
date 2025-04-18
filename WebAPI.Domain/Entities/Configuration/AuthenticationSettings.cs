using System.ComponentModel;
using FastPackForShare.Default;

namespace WebAPI.Domain.Entities.Configuration;

public class AuthenticationSettings : BaseEntityModel
{
    [DisplayName("Número de tentativas antes do bloqueio do usuário")]
    public int NumberOfTryToBlockUser { get; set; }

    [DisplayName("Duração do bloqueio em minutos")]
    public int BlockUserTime { get; set; }

    [DisplayName("Aplicar validação de dois fatores")]
    public bool ApplyTwoFactoryValidation { get; set; }

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

using System.ComponentModel;
using WebAPI.Domain.Entities.Generic;

namespace WebAPI.Domain.Entities.Configuration;

public class AuthenticationSettings :GenericEntity
{
    [DisplayName("Número de tentativas antes do bloqueio do usuário")]
    public int NumberOfTryToBlockUser { get; set; }

    [DisplayName("Duração do bloqueio em minutos")]
    public int BlockUserTime { get; set; }

    [DisplayName("Aplicar validação de dois fatores")]
    public bool ApplyTwoFactoryValidation { get; set; }

    public virtual EnvironmentTypeSettings EnvironmentTypeSettings { get; set; }
    public virtual long? IdEnvironmentType { get; set; }
}

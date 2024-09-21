using System.ComponentModel;
using WebAPI.Domain.Entities.Generic;
using WebAPI.Domain.Enums;

namespace WebAPI.Domain.Entities.Configuration;

public class RequiredPasswordSettings : GenericEntity
{
    [DisplayName("Mínimo de caracteres")]
    public int MinimalOfChars { get; set; }

    [DisplayName("Deve conter letras maiúsculas")]
    public bool MustHaveUpperCaseLetter { get; set; }

    [DisplayName("Deve conter números")]
    public bool MustHaveNumbers { get; set; }

    [DisplayName("Deve conter caracteres especiais ")]
    public bool MustHaveSpecialChars { get; set; }

    public virtual EnvironmentTypeSettings EnvironmentTypeSettings { get; set; }
    public virtual long? IdEnvironmentType { get; set; }
}

using System.ComponentModel;
using FastPackForShare.Default;

namespace WebAPI.Domain.Entities.Configuration;

public class RequiredPasswordSettings : BaseEntityModel
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

    protected override void CreateEntityIsValid()
    {
        throw new NotImplementedException();
    }

    protected override void UpdateEntityIsValid()
    {
        throw new NotImplementedException();
    }
}

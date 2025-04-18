using System.ComponentModel;
using FastPackForShare.Default;

namespace WebAPI.Domain.Entities.Configuration;

public class LogSettings : BaseEntityModel
{
    [DisplayName("Salvar log ao logar no sistema")]
    public bool SaveLogTurnOnSystem { get; set; }

    [DisplayName("Salvar log ao deslogar no sistema")]
    public bool SaveLogTurnOffSystem { get; set; }

    [DisplayName("Salvar log ao criar registro no sistema")]
    public bool SaveLogCreateData { get; set; }

    [DisplayName("Salvar log ao pesquisar registro no sistema")]
    public bool SaveLogResearchData { get; set; }

    [DisplayName("Salvar log ao atualizar registro no sistema")]
    public bool SaveLogUpdateData { get; set; }

    [DisplayName("Salvar log ao excluir registro no sistema")]
    public bool SaveLogDeleteData { get; set; }

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

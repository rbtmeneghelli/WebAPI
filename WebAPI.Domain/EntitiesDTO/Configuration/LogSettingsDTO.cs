using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Domain.EntitiesDTO.Configuration;

public record LogSettingsExcelDTO
{
    [DisplayName("EnvironmentDescription")]
    public string EnvironmentDescription { get; set; }

    [DisplayName("SaveLogTurnOnSystemDescription")]
    public string SaveLogTurnOnSystemDescription { get; set; }

    [DisplayName("SaveLogTurnOffSystemDescription")]
    public string SaveLogTurnOffSystemDescription { get; set; }

    [DisplayName("SaveLogCreateData")]
    public string SaveLogCreateDataDescription { get; set; }

    [DisplayName("SaveLogResearchData")]
    public string SaveLogResearchDataDescription { get; set; }

    [DisplayName("SaveLogUpdateData")]
    public string SaveLogUpdateDataDescription { get; set; }

    [DisplayName("SaveLogDeleteData")]
    public string SaveLogDeleteDataDescription { get; set; }

    [DisplayName("StatusDescription")]
    public string StatusDescriptionDescription { get; set; }
}

public record LogSettingsResponseDTO
{
    [Display(Name = "Id", Description = "Id do registro")]
    public long Id { get; set; }

    [Display(Name = "EnvironmentDescription", Description = "Descrição do ambiente")]
    public string EnvironmentDescription { get; set; }

    [Display(Name = "SaveLogTurnOnSystem", Description = "Salvar log ao logar no sistema")]
    public bool SaveLogTurnOnSystem { get; set; }

    [Display(Name = "SaveLogTurnOffSystem", Description = "Salvar log ao deslogar no sistema")]
    public bool SaveLogTurnOffSystem { get; set; }

    [Display(Name = "SaveLogCreateData", Description = "Salvar log ao criar registro no sistema")]
    public bool SaveLogCreateData { get; set; }

    [Display(Name = "SaveLogResearchData", Description = "Salvar log ao pesquisar registro no sistema")]
    public bool SaveLogResearchData { get; set; }

    [Display(Name = "SaveLogUpdateData", Description = "Salvar log ao atualizar registro no sistema")]
    public bool SaveLogUpdateData { get; set; }

    [Display(Name = "SaveLogDeleteData", Description = "Salvar log ao excluir registro no sistema")]
    public bool SaveLogDeleteData { get; set; }

    [Display(Name = "Status", Description = "Status do ambiente")]
    public string StatusDescription { get; set; }
}

public record LogSettingsCreateRequestDTO
{
    [Required]
    [Display(Name = "Id", Description = "Id do registro")]
    public long? Id { get; set; }

    [Required]
    [Display(Name = "SaveLogTurnOnSystem", Description = "Salvar log ao logar no sistema")]
    public bool SaveLogTurnOnSystem { get; set; }

    [Required]
    [Display(Name = "SaveLogTurnOffSystem", Description = "Salvar log ao deslogar no sistema")]
    public bool SaveLogTurnOffSystem { get; set; }

    [Required]
    [Display(Name = "SaveLogCreateData", Description = "Salvar log ao criar registro no sistema")]
    public bool SaveLogCreateData { get; set; }

    [Required]
    [Display(Name = "SaveLogResearchData", Description = "Salvar log ao pesquisar registro no sistema")]
    public bool SaveLogResearchData { get; set; }

    [Required]
    [Display(Name = "SaveLogUpdateData", Description = "Salvar log ao atualizar registro no sistema")]
    public bool SaveLogUpdateData { get; set; }

    [Required]
    [Display(Name = "SaveLogDeleteData", Description = "Salvar log ao excluir registro no sistema")]
    public bool SaveLogDeleteData { get; set; }

    [Required]
    [Display(Name = "IdEnvironment", Description = "Id do ambiente")]
    public long? IdEnvironment { get; set; }
}

public record LogSettingsUpdateRequestDTO
{
    [Required]
    [Display(Name = "Id", Description = "Id do registro")]
    public long? Id { get; set; }

    [Required]
    [Display(Name = "SaveLogTurnOnSystem", Description = "Salvar log ao logar no sistema")]
    public bool SaveLogTurnOnSystem { get; set; }

    [Required]
    [Display(Name = "SaveLogTurnOffSystem", Description = "Salvar log ao deslogar no sistema")]
    public bool SaveLogTurnOffSystem { get; set; }

    [Required]
    [Display(Name = "SaveLogCreateData", Description = "Salvar log ao criar registro no sistema")]
    public bool SaveLogCreateData { get; set; }

    [Required]
    [Display(Name = "SaveLogResearchData", Description = "Salvar log ao pesquisar registro no sistema")]
    public bool SaveLogResearchData { get; set; }

    [Required]
    [Display(Name = "SaveLogUpdateData", Description = "Salvar log ao atualizar registro no sistema")]
    public bool SaveLogUpdateData { get; set; }

    [Required]
    [Display(Name = "SaveLogDeleteData", Description = "Salvar log ao excluir registro no sistema")]
    public bool SaveLogDeleteData { get; set; }

    [Required]
    [Display(Name = "IdEnvironment", Description = "Id do ambiente")]
    public long? IdEnvironment { get; set; }
}

public record LogSettingsReactiveRequestDTO
{
    [Required]
    [Display(Name = "Id", Description = "Id do registro")]
    public long? Id { get; set; }
}

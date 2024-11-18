using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPI.Domain.DTO.Configuration;

public record EnvironmentTypeSettingsExcelDTO
{
    [DisplayName("EnvironmentDescription")]
    public string EnvironmentDescription { get; set; }

    [DisplayName("EnvironmentInitial")]
    public string EnvironmentInitial { get; set; }

    [DisplayName("StatusDescription")]
    public string StatusDescription { get; set; }
}

public record EnvironmentTypeSettingsResponseDTO
{
    [Display(Name = "Id", Description = "Id do registro")]
    public long Id { get; set; }

    [Display(Name = "EnvironmentDescription", Description = "Descrição do ambiente")]
    public string EnvironmentDescription { get; set; }

    [Display(Name = "EnvironmentInitial", Description = "Iniciais do ambiente")]
    public string EnvironmentInitial { get; set; }

    [Display(Name = "Status", Description = "Status do registro")]
    public string StatusDescription { get; set; }
}

public record EnvironmentTypeSettingsCreateRequestDTO
{
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    [Display(Name = "Id", Description = "Id do registro")]
    public long? Id { get; set; }

    [Required]
    [Display(Name = "EnvironmentDescription", Description = "Descrição do ambiente")]
    public string EnvironmentDescription { get; set; }

    [Required]
    [Display(Name = "EnvironmentInitial", Description = "Iniciais do ambiente")]
    public string EnvironmentInitial { get; set; }
}

public record EnvironmentTypeSettingsUpdateRequestDTO
{
    [Required]
    [Display(Name = "Id", Description = "Id do registro")]
    public long? Id { get; set; }

    [Required]
    [Display(Name = "EnvironmentDescription", Description = "Descrição do ambiente")]
    public string EnvironmentDescription { get; set; }

    [Required]
    [Display(Name = "EnvironmentInitial", Description = "Iniciais do ambiente")]
    public string EnvironmentInitial { get; set; }
}

public record EnvironmentTypeSettingsReactiveRequestDTO
{
    [Required]
    [Display(Name = "Id", Description = "Id do registro")]
    public long? Id { get; set; }
}

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPI.Domain.DTO.Configuration;

public record UploadSettingsResponseDTO
{
    [Display(Name = "Id", Description = "Id do registro")]
    public long Id { get; set; }

    [Display(Name = "EnvironmentDescription", Description = "Descrição do ambiente")]
    public string EnvironmentDescription { get; set; }

    [Display(Name = "LogoWeb", Description = "Logo da aplicação Web")]
    public byte[] LogoWeb { get; set; }

    [Display(Name = "LogoWebDescription", Description = "Nome do Logo da aplicação Web")]
    public string LogoWebDescription { get; set; }

    [Display(Name = "BannerWeb", Description = "Banner da aplicação Web")]
    public byte[] BannerWeb { get; set; }

    [Display(Name = "BannerWebDescription", Description = "Nome do Banner da aplicação Web")]
    public string BannerWebDescription { get; set; }

    [Display(Name = "LogoMobile", Description = "Logo da aplicação Mobile")]
    public byte[] LogoMobile { get; set; }

    [Display(Name = "BannerWebDescription", Description = "Nome do Logo da aplicação Mobile")]
    public string LogoMobileDescription { get; set; }

    [Display(Name = "BannerMobile", Description = "Banner da aplicação Mobile")]
    public byte[] BannerMobile { get; set; }

    [Display(Name = "BannerMobileDescription", Description = "Nome do Banner da aplicação Mobile")]
    public string BannerMobileDescription { get; set; }

    [Display(Name = "Status", Description = "Status do registro")]
    public string StatusDescription { get; set; }
}

public record UploadSettingsCreateRequestDTO
{
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    [Display(Name = "Id", Description = "Id do registro")]
    public long? Id { get; set; }

    [Display(Name = "LogoWeb", Description = "Logo da aplicação Web")]
    public IFormFile LogoWeb { get; set; }

    [Display(Name = "BannerWeb", Description = "Banner da aplicação Web")]
    public IFormFile BannerWeb { get; set; }

    [Display(Name = "LogoMobile", Description = "Logo da aplicação Mobile")]
    public IFormFile LogoMobile { get; set; }

    [Display(Name = "BannerMobile", Description = "Banner da aplicação Mobile")]
    public IFormFile BannerMobile { get; set; }

    [Required]
    [Display(Name = "IdEnvironment", Description = "Id do ambiente")]
    public long? IdEnvironment { get; set; }
}

public record UploadSettingsUpdateRequestDTO
{
    [Required]
    [Display(Name = "Id", Description = "Id do registro")]
    public long? Id { get; set; }

    [Display(Name = "LogoWeb", Description = "Logo da aplicação Web")]
    public IFormFile LogoWeb { get; set; }

    [Display(Name = "BannerWeb", Description = "Banner da aplicação Web")]
    public IFormFile BannerWeb { get; set; }

    [Display(Name = "LogoMobile", Description = "Logo da aplicação Mobile")]
    public IFormFile LogoMobile { get; set; }

    [Display(Name = "BannerMobile", Description = "Banner da aplicação Mobile")]
    public IFormFile BannerMobile { get; set; }

    [Required]
    [Display(Name = "IdEnvironment", Description = "Id do ambiente")]
    public long? IdEnvironment { get; set; }
}

public record UploadSettingsReactiveRequestDTO
{
    [Required]
    [Display(Name = "Id", Description = "Id do registro")]
    public long? Id { get; set; }
}

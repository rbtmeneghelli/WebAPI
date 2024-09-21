using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using WebAPI.Domain.EntitiesDTO.Generic;

namespace WebAPI.Domain.EntitiesDTO.Configuration;

public record LayoutSettingsDTO : GenericDTO
{
    [Required]
    [Display(Name = "LogoWeb", Description = "Logo da aplicação Web")]
    public IFormFile LogoWeb { get; set; }

    [Required]
    [Display(Name = "BannerWeb", Description = "Banner da aplicação Web")]
    public IFormFile BannerWeb { get; set; }

    [Required]
    [Display(Name = "LogoMobile", Description = "Logo da aplicação Mobile")]
    public IFormFile LogoMobile { get; set; }

    [Required]
    [Display(Name = "BannerMobile", Description = "Banner da aplicação Mobile")]
    public IFormFile BannerMobile { get; set; }
}

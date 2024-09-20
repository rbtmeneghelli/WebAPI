using System.ComponentModel;
using WebAPI.Domain.Enums;
using WebAPI.Domain.Generic;

namespace WebAPI.Domain.Entities.Configuration;

public class LayoutSettings : GenericEntity
{
    [DisplayName("LogoWeb")]
    public string LogoWeb { get; set; }

    [DisplayName("BannerWeb")]
    public string BannerWeb { get; set; }

    [DisplayName("LogoMobile")]
    public string LogoMobile { get; set; }

    [DisplayName("BannerMobile")]
    public string BannerMobile { get; set; }

    public virtual EnvironmentTypeSettings EnvironmentTypeSettings { get; set; }
    public virtual long? IdEnvironmentType { get; set; }
}

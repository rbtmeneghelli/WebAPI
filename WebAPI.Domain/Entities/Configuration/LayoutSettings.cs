using WebAPI.Domain.Generic;

namespace WebAPI.Domain.Entities.Configuration;

public class LayoutSettings : GenericEntity
{
    public string LogoWeb { get; set; }
    public string BannerWeb { get; set; }
    public string LogoMobile { get; set; }
    public string BannerMobile { get; set; }
}

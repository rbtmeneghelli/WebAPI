using System.ComponentModel.DataAnnotations;

namespace WebAPI.Domain.Enums;

public enum EnumTypeGraphic : byte
{
    [Display(Name = "Gráfico do tipo chart js")]
    CHARTJS = 0,

    [Display(Name = "Gráfico do tipo google chart")]
    GOOGLECHART = 1,

    [Display(Name = "Gráfico do tipo d3")]
    D3 = 2,

    [Display(Name = "Gráfico do tipo echarts")]
    ECHARTS = 3,  
}

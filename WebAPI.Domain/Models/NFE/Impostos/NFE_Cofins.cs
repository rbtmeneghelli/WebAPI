using Newtonsoft.Json;

namespace WebAPI.Domain.Models.NFE.Impostos;

public sealed record NFE_COFINS
{
    [JsonProperty("tipo")]
    public string Cofins_Tipo { get; set; }
    [JsonProperty("CST")]
    public string Cofins_Cst { get; set; }
    [JsonProperty("vBC")]
    public string Cofins_Vbc { get; set; }
    [JsonProperty("pCOFINS")]
    public string Cofins_Pcofins { get; set; }
    [JsonProperty("vCOFINS")]
    public string Cofins_Vcofins { get; set; }
}

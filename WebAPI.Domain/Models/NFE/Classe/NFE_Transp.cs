using Newtonsoft.Json;
using WebAPI.Domain.Models.NFE.Transporte;

namespace WebAPI.Domain.Models.NFE.Classe;

public sealed record NFE_Transp
{
    [JsonProperty("modFrete")]
    public string ModFrete { get; set; }
    [JsonProperty("transporta")]
    public NFE_Transporta Transporta { get; set; }
    [JsonProperty("veicTransp")]
    public NFE_VeicTransp VeicTransp { get; set; }
    [JsonProperty("reboque")]
    public NFE_Reboque Reboque { get; set; }
    [JsonProperty("vol")]
    public NFE_Vol Vol { get; set; }
}

using Newtonsoft.Json;

namespace WebAPI.Domain.Models.NFE.Total;

public sealed record NFE_IcmsTot
{
    [JsonProperty("vBC")]
    public string Vbc { get; set; }
    [JsonProperty("vICMS")]
    public string Vicms { get; set; }
    [JsonProperty("vBCST")]
    public string Vbcst { get; set; }
    [JsonProperty("vST")]
    public string Vst { get; set; }
    [JsonProperty("vProd")]
    public string Vprod { get; set; }
    [JsonProperty("vFrete")]
    public string Vfrete { get; set; }
    [JsonProperty("vSeg")]
    public string Vseg { get; set; }
    [JsonProperty("vDesc")]
    public string Vdesc { get; set; }
    [JsonProperty("vII")]
    public string Vii { get; set; }
    [JsonProperty("vIPI")]
    public string Vipi { get; set; }
    [JsonProperty("vPIS")]
    public string Vpis { get; set; }
    [JsonProperty("vCOFINS")]
    public string Vcofins { get; set; }
    [JsonProperty("vOutro")]
    public string Voutro { get; set; }
    [JsonProperty("vNF")]
    public string Vnf { get; set; }
}

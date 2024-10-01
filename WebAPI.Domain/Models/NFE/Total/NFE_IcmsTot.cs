using System.Text.Json.Serialization;

namespace WebAPI.Domain.Models.NFE.Total;

public sealed record NFE_IcmsTot
{
    [JsonPropertyName("vBC")]
    public string Vbc { get; set; }
    [JsonPropertyName("vICMS")]
    public string Vicms { get; set; }
    [JsonPropertyName("vBCST")]
    public string Vbcst { get; set; }
    [JsonPropertyName("vST")]
    public string Vst { get; set; }
    [JsonPropertyName("vProd")]
    public string Vprod { get; set; }
    [JsonPropertyName("vFrete")]
    public string Vfrete { get; set; }
    [JsonPropertyName("vSeg")]
    public string Vseg { get; set; }
    [JsonPropertyName("vDesc")]
    public string Vdesc { get; set; }
    [JsonPropertyName("vII")]
    public string Vii { get; set; }
    [JsonPropertyName("vIPI")]
    public string Vipi { get; set; }
    [JsonPropertyName("vPIS")]
    public string Vpis { get; set; }
    [JsonPropertyName("vCOFINS")]
    public string Vcofins { get; set; }
    [JsonPropertyName("vOutro")]
    public string Voutro { get; set; }
    [JsonPropertyName("vNF")]
    public string Vnf { get; set; }
}

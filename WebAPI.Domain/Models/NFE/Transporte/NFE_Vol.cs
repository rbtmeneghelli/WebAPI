using System.Text.Json.Serialization;

namespace WebAPI.Domain.Models.NFE.Transporte;

public class NFE_Vol
{
    [JsonPropertyName("qVol")]
    public string Qvol { get; set; }
    [JsonPropertyName("esp")]
    public string Esp { get; set; }
    [JsonPropertyName("marca")]
    public string Marca { get; set; }
    [JsonPropertyName("nVol")]
    public string Nvol { get; set; }
    [JsonPropertyName("pesoL")]
    public string PesoL { get; set; }
    [JsonPropertyName("pesoB")]
    public string PesoB { get; set; }
    [JsonPropertyName("lacre")]
    public NFE_Lacre Lacre { get; set; }
}

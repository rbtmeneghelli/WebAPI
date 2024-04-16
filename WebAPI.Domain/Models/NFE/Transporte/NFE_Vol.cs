using Newtonsoft.Json;

namespace WebAPI.Domain.Models.NFE.Transporte;

public class NFE_Vol
{
    [JsonProperty("qVol")]
    public string Qvol { get; set; }
    [JsonProperty("esp")]
    public string Esp { get; set; }
    [JsonProperty("marca")]
    public string Marca { get; set; }
    [JsonProperty("nVol")]
    public string Nvol { get; set; }
    [JsonProperty("pesoL")]
    public string PesoL { get; set; }
    [JsonProperty("pesoB")]
    public string PesoB { get; set; }
    [JsonProperty("lacre")]
    public Lacre Lacre { get; set; }
}

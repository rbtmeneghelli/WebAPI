using Newtonsoft.Json;
using WebAPI.Domain.Models.NFE.Total;

namespace WebAPI.Domain.Models.NFE.Classe;

public sealed record NFE_TribTotal
{
    [JsonProperty("totalICMS")]
    public NFE_IcmsTot TotalICMS { get; set; }
}

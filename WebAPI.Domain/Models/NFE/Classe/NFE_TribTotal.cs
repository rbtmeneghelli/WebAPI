using System.Text.Json.Serialization;
using WebAPI.Domain.Models.NFE.Total;

namespace WebAPI.Domain.Models.NFE.Classe;

public sealed record NFE_TribTotal
{
    [JsonPropertyName("totalICMS")]
    public NFE_IcmsTot TotalICMS { get; set; }
}

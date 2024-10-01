using System.Text.Json.Serialization;

namespace WebAPI.Domain.Models.NFE.Outros;

public sealed record NFE_InfAdic
{
    [JsonPropertyName("InfAdFisco")]
    public string InfAdicional { get; set; }
}

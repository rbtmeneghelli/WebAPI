using Newtonsoft.Json;

namespace WebAPI.Domain.Models.NFE.Outros;

public sealed record NFE_InfAdic
{
    [JsonProperty("InfAdFisco")]
    public string InfAdicional { get; set; }
}

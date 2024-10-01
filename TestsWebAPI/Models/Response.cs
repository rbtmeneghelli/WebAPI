using System.Text.Json.Serialization;

namespace TestsWebAPI.Models;

public class ResponseForToken
{
    [JsonPropertyName("sucess")]
    public bool Success { get; set; }
    [JsonPropertyName("data")]
    public ResponseFromToken Data { get; set; }
}

public class ResponseFromToken
{
    [JsonPropertyName("vinculoCorretora")]
    public bool VinculoCorretora { get; set; }
    [JsonPropertyName("token")]
    public string Token { get; set; }
    [JsonPropertyName("expiredays")]
    public int Expiredays { get; set; }
}

namespace TestsWebAPI.Models;

public class ResponseForToken
{
    [JsonProperty("sucess")]
    public bool Success { get; set; }
    [JsonProperty("data")]
    public ResponseFromToken Data { get; set; }
}

public class ResponseFromToken
{
    [JsonProperty("vinculoCorretora")]
    public bool VinculoCorretora { get; set; }
    [JsonProperty("token")]
    public string Token { get; set; }
    [JsonProperty("expiredays")]
    public int Expiredays { get; set; }
}

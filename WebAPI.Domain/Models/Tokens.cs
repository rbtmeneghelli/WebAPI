namespace WebAPI.Domain.Models;

public record Tokens
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}

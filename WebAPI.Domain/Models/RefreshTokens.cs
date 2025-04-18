namespace WebAPI.Domain.Models;

public record RefreshTokens
{
    public string Username { get; set; }
    public string RefreshToken { get; set; }

    public RefreshTokens(string userName, string refreshToken)
    {
        Username = userName;
        RefreshToken = refreshToken;
    }
}

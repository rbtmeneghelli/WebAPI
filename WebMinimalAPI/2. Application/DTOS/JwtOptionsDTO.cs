namespace WebMinimalAPI._2._Application.DTOS;

public sealed record JwtOptions
{
    public string Issuer { get; set; }
    public string Audience { get; set; } 
    public string PrivateKey { get; set; }
    public int ExpireSeconds { get; set; }
};

namespace WebMinimalAPI._2._Application.Interfaces;

public interface ITokenService
{
    Task<string> CreateAccessToken(string userName);
}

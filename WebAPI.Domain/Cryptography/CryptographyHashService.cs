using System.Security.Cryptography;
using System.Text;

namespace WebAPI.Domain.Cryptography;

public sealed class CryptographyHashService
{
    private HashAlgorithm _algoritm;

    public CryptographyHashService(HashAlgorithm algoritm)
    {
        _algoritm = algoritm;
    }

    public string EncryptPassword(string password)
    {
        var encodedValue = Encoding.UTF8.GetBytes(password);
        var encryptedPassword = _algoritm.ComputeHash(encodedValue);

        var sb = new StringBuilder();
        foreach (var character in encryptedPassword)
            sb.Append(character.ToString("X2"));

        return sb.ToString();
    }

    public bool CheckPassword(string passwordInputed, string passwordInDb)
    {
        if (GuardClauses.IsNullOrWhiteSpace(passwordInDb))
            throw new NullReferenceException("Cadastre uma senha.");

        var encryptedPassword = _algoritm.ComputeHash(Encoding.UTF8.GetBytes(passwordInputed));

        var sb = new StringBuilder();
        foreach (var character in encryptedPassword)
        {
            sb.Append(character.ToString("X2"));
        }

        return sb.ToString() == passwordInDb;
    }
}

using WebAPI.Domain.ExtensionMethods;
using System.Security.Cryptography;

namespace WebAPI.Domain.Cryptography;

public sealed class CryptographyService
{
    public string Hash(string password, int iterations)
    {
        byte[] salt;
        #pragma warning disable SYSLIB0023 // Type or member is obsolete
        new RNGCryptoServiceProvider().GetBytes(salt = new byte[Constants.SALT_SIZE]);
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
        var hash = pbkdf2.GetBytes(Constants.HASH_SIZE);
        var hashBytes = new byte[Constants.SALT_SIZE + Constants.HASH_SIZE];
        Array.Copy(salt, 0, hashBytes, 0, Constants.SALT_SIZE);
        Array.Copy(hash, 0, hashBytes, Constants.SALT_SIZE, Constants.HASH_SIZE);
        var base64Hash = Convert.ToBase64String(hashBytes);
        return $"$FXR$V1${iterations}${base64Hash}";
        return null;
    }

    public string Hash(string password)
    {
        return Hash(password, 10000);
    }

    public bool IsHashSupported(string hashString)
    {
        return hashString.Contains("$FXR$V1$");
    }

    public bool Verify(string password, string hashedPassword)
    {
        if (!IsHashSupported(hashedPassword))
        {
            throw new NotSupportedException("The hashtype is not supported");
        }

        var splittedHashString = hashedPassword.ApplyReplace("$FXR$V1$", "").Split('$');
        var iterations = int.Parse(splittedHashString[0]);
        var base64Hash = splittedHashString[1];
        var hashBytes = Convert.FromBase64String(base64Hash);
        var salt = new byte[Constants.SALT_SIZE];
        Array.Copy(hashBytes, 0, salt, 0, Constants.SALT_SIZE);
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
        byte[] hash = pbkdf2.GetBytes(Constants.HASH_SIZE);
        for (var i = 0; i < Constants.HASH_SIZE; i++)
        {
            if (hashBytes[i + Constants.SALT_SIZE] != hash[i])
            {
                return false;
            }
        }
        return true;
    }
}

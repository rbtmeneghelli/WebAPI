using WebAPI.Domain.ExtensionMethods;
using System.Security.Cryptography;
using WebAPI.Domain.Constants;

namespace WebAPI.Domain.Cryptography;

public sealed class CryptographyService
{
    public string Hash(string password, int iterations)
    {
        byte[] salt;
        #pragma warning disable SYSLIB0023 // Type or member is obsolete
        new RNGCryptoServiceProvider().GetBytes(salt = new byte[FixConstants.SALT_SIZE]);
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
        var hash = pbkdf2.GetBytes(FixConstants.HASH_SIZE);
        var hashBytes = new byte[FixConstants.SALT_SIZE + FixConstants.HASH_SIZE];
        Array.Copy(salt, 0, hashBytes, 0, FixConstants.SALT_SIZE);
        Array.Copy(hash, 0, hashBytes, FixConstants.SALT_SIZE, FixConstants.HASH_SIZE);
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
        var salt = new byte[FixConstants.SALT_SIZE];
        Array.Copy(hashBytes, 0, salt, 0, FixConstants.SALT_SIZE);
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
        byte[] hash = pbkdf2.GetBytes(FixConstants.HASH_SIZE);
        for (var i = 0; i < FixConstants.HASH_SIZE; i++)
        {
            if (hashBytes[i + FixConstants.SALT_SIZE] != hash[i])
            {
                return false;
            }
        }
        return true;
    }
}

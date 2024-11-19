using System.Security.Cryptography;
using System.Text;

namespace WebAPI.Domain.Cryptography;

public static class CryptographyTokenService
{
    public static string EncryptToken(string token, string key)
    {
        var keyBytes = Encoding.UTF8.GetBytes(key);
        using (var aes = Aes.Create())
        {
            aes.Key = keyBytes;
            aes.GenerateIV();
            var iv = aes.IV;
            using (var encryptor = aes.CreateEncryptor())
            {
                var tokenBytes = Encoding.UTF8.GetBytes(token);
                var tokenCrypt = encryptor.TransformFinalBlock(tokenBytes, 0, tokenBytes.Length);

                var result = new byte[iv.Length + tokenCrypt.Length];
                Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                Buffer.BlockCopy(tokenCrypt, 0, result, iv.Length, tokenCrypt.Length);

                return Convert.ToBase64String(result);
            }
        }
    }

    public static string DecryptToken(string tokenCrypt, string key)
    {
        var keyBytes = Encoding.UTF8.GetBytes(key);
        var fullCipher = Convert.FromBase64String(tokenCrypt);

        using (var aes = Aes.Create())
        {
            aes.Key = keyBytes;
            var iv = new byte[aes.BlockSize / 8];
            var cipher = new byte[fullCipher.Length - iv.Length];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, cipher.Length);
            aes.IV = iv;

            using (var decryptor = aes.CreateDecryptor())
            {
                var decryptedBytes = decryptor.TransformFinalBlock(cipher, 0, cipher.Length);
                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }
    }
}

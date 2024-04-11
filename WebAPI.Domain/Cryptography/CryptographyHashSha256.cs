using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Domain.Cryptography
{
    /// <summary>
    /// Esse exemplo é para registrar uma nova senha com criptografia
    /// Referencia >> https://macoratti.net/22/10/net_secsenha1.htm
    /// var novoUsuario = //Registro do banco de dados...
    /// novoUsuario.PasswordSalt = SenhaHash.GenerateSalt()
    /// novoUsuario.PasswordHash = SenhaHash.ComputeHash("SenhaDigitadaPeloUsuario", usuario.PasswordSalt, "numsey", 3);
    /// gravar a variavel novoUsuario no banco de dados
    /// </summary>
    /// 
    /// <summary>
    /// Esse exemplo é para resgatar o usuario do banco e verificar se a senha digitada confere com a armazenada
    /// Referencia >> https://macoratti.net/22/10/net_secsenha1.htm
    /// var usuarioDB = //Registro do banco de dados...
    /// var passwordHash = SenhaHash.ComputeHash("SenhaDigitadaPeloUsuario", usuarioDB.SenhaSalt, "numsey", 3);
    /// if (usuario.SenhaHash != passwordHash)
    /// throw new Exception("Nome e senha não conferem.");
    /// </summary>
    public class CryptographyHashSha256
    {
        public static string ComputeHash(string senha, string salt, string pepper, int iteration)
        {
            if (iteration <= 0) return senha;
            using var sha256 = SHA256.Create();
            var passwordSaltPepper = $"{senha}{salt}{pepper}";
            var byteValue = Encoding.UTF8.GetBytes(passwordSaltPepper);
            var byteHash = sha256.ComputeHash(byteValue);
            var hash = Convert.ToBase64String(byteHash);
            return ComputeHash(hash, salt, pepper, iteration - 1);
        }

        public static string GenerateSalt()
        {
            using var rng = RandomNumberGenerator.Create();
            var byteSalt = new byte[16];
            rng.GetBytes(byteSalt);
            var salt = Convert.ToBase64String(byteSalt);
            return salt;
        }
    }
}

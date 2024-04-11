using WebAPI.Domain.ExtensionMethods;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;

namespace WebAPI.Application.Services;

public class GeneralService : GenericService, IGeneralService
{
    private List<RefreshTokens> _refreshTokens = new List<RefreshTokens>();
    TokenConfiguration _tokenConfiguration { get; }

    private readonly IHttpClientFactory _httpClientFactory;

    public GeneralService(TokenConfiguration tokenConfiguration, INotificationMessageService notificationMessageService, IHttpClientFactory httpClientFactory) : base(notificationMessageService)
    {
        _tokenConfiguration = tokenConfiguration;
        _httpClientFactory = httpClientFactory;
    }

    private SqlConnection GetSqlConnection()
    {
        return null;
        //return new SqlConnection(_configuration["ConnectionString:DefaultConnection"]);
    }

    public string CreateJwtToken(Credentials credentials)
    {
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_tokenConfiguration.Key);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _tokenConfiguration.Issuer,
            Audience = _tokenConfiguration.Audience,
            Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("Id",credentials.Id.ToString()),
                    new Claim(ClaimTypes.Name, credentials.Login.ToString()),
                    new Claim(ClaimTypes.Role, string.Join(",",credentials.Roles)) // são as permissões do usuario, onde podemos restringir os endpoints a partir da tag >>  No Authorize(Roles = "ROLE_AUDIT") por exemplo
            }),
            Expires = DateTime.UtcNow.AddSeconds(_tokenConfiguration.Seconds),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public async Task<RequestData> RequestDataToExternalAPIAsync(string url)
    {
        RequestData requestDataDto = new RequestData();

        try
        {
            var client = _httpClientFactory.CreateClient("Signed");
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromMinutes(1);
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                requestDataDto.Data = await response.Content.ReadAsStringAsync();
                requestDataDto.IsSuccess = true;
                return requestDataDto;
            }
        }
        catch
        {
            requestDataDto.Data = $"{Constants.EXCEPTION_REQUEST_API} {url}";
            requestDataDto.IsSuccess = false;
        }
        return requestDataDto;
    }

    public async Task<RequestData> RequestLoginAsync(string url, string key = "")
    {
        RequestData requestDataDto = new RequestData();
        try
        {
            var client = _httpClientFactory.CreateClient("Signed");
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromMinutes(1);
            var stringContent = new StringContent(key, Encoding.UTF8, "application/xml");
            HttpResponseMessage response = await client.PostAsync(url, stringContent);
            if (response.IsSuccessStatusCode)
            {
                requestDataDto.Data = await response.Content.ReadAsStringAsync();
                requestDataDto.IsSuccess = true;
            }
            else
            {
                requestDataDto.Data = $"{Constants.EXCEPTION_REQUEST_API} {url}";
                requestDataDto.IsSuccess = false;
            }
            return requestDataDto;
        }
        catch
        {
            requestDataDto.Data = $"{Constants.EXCEPTION_REQUEST_API} {url}";
            requestDataDto.IsSuccess = false;
        }
        return requestDataDto;
    }

    public async Task<bool> RunSqlProcedureAsync(string procName, string paramName, string paramValue)
    {
        SqlConnection sqlConnObj = GetSqlConnection();
        try
        {
            SqlCommand sqlCmd = new SqlCommand(procName, sqlConnObj);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue(paramName, paramValue);
            sqlConnObj.Open();
            await sqlCmd.ExecuteNonQueryAsync();
        }
        catch
        {
            Notify(string.Format(Constants.ERROR_IN_PROCEDURE, procName));
            return false;
        }
        finally
        {
            sqlConnObj.Close();
        }

        return true;
    }

    public async Task<bool> RunSqlBackupAsync(string directory)
    {
        string dir = GuardClauses.IsNullOrWhiteSpace(directory) ? Directory.GetCurrentDirectory() : directory;
        SqlConnection sqlConnObj = GetSqlConnection();
        try
        {
            string nomeArquivo = $"DefaultAPI_{Constants.GetDateTimeNowFromBrazil().ToString("ddMMyyyy")}.bak";
            if (File.Exists(Path.Combine(dir, nomeArquivo)))
            {
                File.Delete(Path.Combine(dir, nomeArquivo));
            }
            string query = $"Backup database {sqlConnObj.Database} to disk='{dir}\\{nomeArquivo}'";
            SqlCommand sqlCmd = new SqlCommand(query, sqlConnObj);
            sqlConnObj.Open();
            await sqlCmd.ExecuteNonQueryAsync();
        }
        catch
        {
            Notify(Constants.ERROR_IN_BACKUP);
            return false;
        }
        finally
        {
            sqlConnObj.Close();
        }

        return true;
    }

    public async Task<MemoryStream> Export2ZipAsync(string directory, int typeFile = 2)
    {
        GeneralExtensionMethod extensionMethods = GeneralExtensionMethod.GetLoadExtensionMethods();
        List<string> archives = new List<string>();
        int count = 0;
        foreach (string arquivo in Directory.GetFiles(directory, $"*.{extensionMethods.GetMemoryStreamExtension(typeFile)}"))
        {
            archives.Add(arquivo);
        }

        using (MemoryStream ms = new MemoryStream())
        {
            using (var archive = new ZipArchive(ms, ZipArchiveMode.Create, true))
            {
                foreach (string arquivo in archives)
                {
                    ZipArchiveEntry zipArchiveEntry = archive.CreateEntry($"file{count}.pdf", CompressionLevel.Fastest);
                    using (var zipStream = zipArchiveEntry.Open()) zipStream.Write(System.IO.File.ReadAllBytes(arquivo), 0, System.IO.File.ReadAllBytes(arquivo).Length);
                    count++;
                }
            }
            await Task.CompletedTask;
            return ms;
        }
    }

    public async Task<bool> SendPushNotificationAsync(PushNotification notification, string tokenUser)
    {
        // Reference: http://codepickup.in/csharp/fcm-push-notification-in-csharp/
        // Se nao gerar a chave web api, so ir na autentication

        var postData = new
        {
            to = tokenUser,
            notification,
            // data = Algum dado em especial
        }.SerializeObject();

        Byte[] byteArray = Encoding.UTF8.GetBytes(postData.ToString());

        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Constants.URL_TO_GET_FIREBASE);
            request.Method = "post";
            request.KeepAlive = false;
            request.ContentType = "application/json";
            request.Headers.Add($"Authorization: key={Constants.SERVER_API_KEY}");
            request.Headers.Add($"Sender: id={Constants.SENDER_ID}");
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            HttpStatusCode responseCode = ((HttpWebResponse)response).StatusCode;

            if (!responseCode.Equals(HttpStatusCode.OK))
                return false;

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseLine = reader.ReadToEnd();
            reader.Close();

            await Task.CompletedTask;
            return true;

        }
        catch (Exception ex)
        {
            Notify(ex.Message);
            return false;
        }
    }

    public string GenerateToken(IEnumerable<Claim> claims)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_tokenConfiguration.Key);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var key = Encoding.ASCII.GetBytes(_tokenConfiguration.Key);

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateLifetime = false
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
        if (!(securityToken is JwtSecurityToken jwtSecurityToken))
            throw new SecurityTokenException(Constants.ERROR_IN_REFRESHTOKEN);
        else if (!jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException(Constants.ERROR_IN_REFRESHTOKEN);

        return principal;
    }

    public void SaveRefreshToken(string username, string refreshToken)
    {
        _refreshTokens.Add(new RefreshTokens(username, refreshToken));
    }

    public string GetRefreshToken(string username)
    {
        return _refreshTokens.FirstOrDefault(x => x.Username == username).RefreshToken;
    }

    public void DeleteRefreshToken(string username, string refreshToken)
    {
        var item = _refreshTokens.FirstOrDefault(x => x.Username == username && x.RefreshToken == refreshToken);
        _refreshTokens.Remove(item);
    }

    public string ExtractObjectInformationsByReflection(object obj)
    {
        //obtem o tipo do objeto
        //esse tipo não tem relação com a instância de obj
        var tipo = obj.GetType();

        StringBuilder builder = new StringBuilder();
        //obtem o nome do tipo
        builder.AppendLine("Log do " + tipo.Name);
        builder.AppendLine("Data: " + Constants.GetDateTimeNowFromBrazil());

        //Vamos obter agora todas as propriedades do tipo
        //Usamos o método GetProperties para obter
        //o nome das propriedades do tipo
        foreach (var prop in tipo.GetProperties())
        {
            //usa a propriedade Name para obter o nome da propriedade
            //e o método GetValue() para obter o valor da instância desse tipo
            builder.AppendLine(prop.Name + ": " + prop.GetValue(obj));
        }

        return builder.ToString();
    }

    public bool TokenIsValid(string jwtToken)
    {
        var handler = new JwtSecurityTokenHandler();
        var validations = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero,
            ValidIssuer = _tokenConfiguration.Issuer,
            ValidAudience = _tokenConfiguration.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtToken))
        };

        var identity = handler.ValidateToken(jwtToken, validations, out var tokenSecure).Identity as ClaimsIdentity;

        return identity != null ? true : false;
    }
}

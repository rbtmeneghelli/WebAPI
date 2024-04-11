namespace TestsWebAPI.Models;

public class Login
{
    [StringLength(256, MinimumLength = 0, ErrorMessage = "O login deve ter no maximo 256 caracteres!")]
    public string User { get; set; }

    [StringLength(256, MinimumLength = 0, ErrorMessage = "A senha deve ter maximo 256 caracteres!")]
    public string Password { get; set; }

    public Login()
    {
      
    }

    public Login(string user, string password)
    {
        User = user;
        Password = password;
    }
}

namespace WebAPI.Domain.Models;

public record LoginUser
{   
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Login { get; set; }

    [Required(ErrorMessage = "O campo Password é obrigatório")]
    [StringLength(100, ErrorMessage = "O campo Password precisa ter entre {2} e {1} caracteres", MinimumLength = 4)]
    public string Password { get; set; }
}

public record ConfirmLoginUser
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string CodeTwoFactory { get; set; }
}

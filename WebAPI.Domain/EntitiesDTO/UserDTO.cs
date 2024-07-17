using WebAPI.Domain.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Domain.EntitiesDTO;

public record UserResponseDTO : GenericDTO
{
    [DisplayName("Login")]
    public string Login { get; set; }

    public string Password { get; set; }

    public string LastPassword { get; set; }

    [DisplayName("Autenticado")]
    public bool IsAuthenticated { get; set; }

    [DisplayName("Funcionario")]
    public string Employee { get; set; }

    [DisplayName("Perfil")]
    public string Profile { get; set; }

    [DisplayName("Status")]
    public string Status { get; set; }

    public override string ToString() => $"Login: {Login}";
}

public record UserRequestDTO : GenericDTO
{
    [Required(ErrorMessage = "O campo Login é obrigatório")]
    public string Login { get; set; }

    [MinLength(8, ErrorMessage = "A senha tem que ter no minímo {0} caracteres"), MaxLength(16, ErrorMessage = "A senha tem que ter no máximo {0} caracteres")]
    public string Password { get; set; }

    [MinLength(8, ErrorMessage = "A senha tem que ter no minímo {0} caracteres"), MaxLength(16, ErrorMessage = "A senha tem que ter no máximo {0} caracteres")]
    public string LastPassword { get; set; }
    
    public bool IsAuthenticated { get; set; }

    public override string ToString() => $"Login: {Login}";
}

public record UserExcelDTO
{
    [DisplayName("Login")]
    public string Login { get; set; }

    [DisplayName("Autenticado")]
    public bool IsAuthenticated { get; set; }

    [DisplayName("Funcionario")]
    public string Employee { get; set; }

    [DisplayName("Status")]
    public string Status { get; set; }
}

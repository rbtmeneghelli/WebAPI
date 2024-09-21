using System.ComponentModel.DataAnnotations;

namespace WebAPI.Domain.Models.Generic;

/// <summary>
/// Required - Obriga a entrada de um campo especificado
/// ErrorMessage - Define a mensagem de erro
/// AllowEmptyStrings - Define se são permitidos valores em branco
/// EmailAddress - Validador de email
/// Display - Define o texto que será visível para uma propriedade quando usada em um campo de formulário
/// StringLength - Determina a quantidade máxima de caracteres que poderá ser informada
/// MinimumLength - O parâmetro MinimumLength define a quantidade mínima de caracteres permitida
/// DataType - Associa um tipo adicional a uma propriedade
/// Range - Define um intervalo para uma propriedade onde a validação será aplicada
/// MinLength - Determina um tamanho mínimo que deve ser informado;
/// MaxLength - Determina um tamanho máximo que não deve ser ultrapassado;
/// Base64String() - A partir do NET 8 é possivel receber dados em formato Base64 direto no campo, sem a existencia de um objeto
/// AllowedValues(X,X,X) - A partir do NET 8 é possivel listar valores permitidos a serem inputados
/// DeniedValues(X,X,X) - A partir do NET 8 é possivel listar valores não permitidos a serem inputados
/// Length(X,X) - A partir do NET 8 é possivel definir um tamanho minimo e maximo de caracteres por essa Data Annotation
/// </summary>
public abstract class GenericAnnotation
{
    public GenericAnnotation() { }

    [Display(Name = "{0}")]
    [Required(ErrorMessage = "O {0} é obrigatório")]
    [StringLength(80, ErrorMessage = "{0} deve ter no minimo {2} e no maximo {1} caracteres preenchidos", MinimumLength = 5)]
    public string FirstName { get; set; }

    [Display(Name = "{0}")]
    [Required(ErrorMessage = "O {0} é obrigatório", AllowEmptyStrings = false)]
    public string LastName { get; set; }

    [Display(Name = "{0}")]
    [Required(ErrorMessage = "O {0} é obrigatório")]
    [MinLength(5, ErrorMessage = "{0} inválido, informe no mínimo {1} caracteres")]
    [MaxLength(40, ErrorMessage = "{0} excedeu o tamanho de {1} permitido")]
    public string NickName { get; set; }

    [Display(Name = "{0}")]
    [Required(ErrorMessage = "O {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "Informe um {0} válido...")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [StringLength(10, MinimumLength = 4)]
    [Display(Name = "Password", Description = "Senha do usuário")]
    public string Password { get; set; }

    [Required]
    [Display(Name = "Age", Description = "Idade do usuário")]
    [Range(18, 65, ErrorMessage = "O campo {0} deve ser preenchido com idade de {1} até {2}")]
    public int Age { get; set; }

    [Display(Name = "HoraCriacao")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Date, ErrorMessage = "Uma data de criação deve ser informada!")]
    public DateTime? CreateDate { get; set; }

    [Display(Name = "HoraAtualizacao")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Date, ErrorMessage = "Uma data de atualização deve ser informada!")]
    public DateTime? UpdateDate { get; set; }

    #region Novas funcionalidades a partir do NET 8

    [Base64String()]
    public string StringBase64 { get; set; }

    [Required]
    [AllowedValues("CO", "N", "NE", "S", "SE", ErrorMessage = "Regiao invalida")]
    public string CodigoRegiao { get; set; }

    [Required]
    [DeniedValues("CO", "N", "NE", ErrorMessage = "Regiao invalida")]
    public string CodigoRegiao2 { get; set; }

    [Required]
    [Length(5, 80)]
    public string Name { get; set; }

    #endregion

}

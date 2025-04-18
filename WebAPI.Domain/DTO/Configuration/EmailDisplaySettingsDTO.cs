using FastPackForShare.Bases;
using MimeKit;

namespace WebAPI.Domain.DTO.Configuration;

public record EmailDisplaySettingsExcelDTO : BaseReportModel
{
    [DisplayName("Title")]
    public string Title { get; set; }

    [DisplayName("Subject")]
    public string Subject { get; set; }

    [DisplayName("Body")]
    public string Body { get; set; }

    [DisplayName("MessagePriority")]
    public MessagePriority MessagePriority { get; set; }

    [DisplayName("HasAttachment")]
    public bool HasAttachment { get; set; }

    [DisplayName("TemplateDescription")]
    public string TemplateDescription { get; set; }

    [DisplayName("StatusDescription")]
    public string StatusDescription { get; set; }
}

public record EmailDisplaySettingsResponseDTO : GenericDTOModel
{
    [Display(Name = "Id", Description = "Id do registro")]
    public long Id { get; set; }

    [Display(Name = "Title", Description = "Titulo do email")]
    public string Title { get; set; }

    [Display(Name = "Subject", Description = "Assunto do email")]
    public string Subject { get; set; }

    [Display(Name = "Body", Description = "Corpo do email")]
    public string Body { get; set; }

    [Display(Name = "MessagePriority", Description = "Grau de prioridade do envio do email")]
    public MessagePriority MessagePriority { get; set; }

    [Display(Name = "HasAttachment", Description = "Tem arquivo em anexo")]
    public bool HasAttachment { get; set; }

    [Display(Name = "TemplateDescription", Description = "Descrição do template")]
    public string TemplateDescription { get; set; }

    [Display(Name = "Status", Description = "Status do registro")]
    public string StatusDescription { get; set; }
}

public record EmailDisplaySettingsCreateRequestDTO : GenericDTOModel
{
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    [Display(Name = "Id", Description = "Id do registro")]
    public long? Id { get; set; }

    [Required]
    [Display(Name = "Host", Description = "Host do Email")]
    [Length(1, 255, ErrorMessage = "{0} deve ter no minimo {2} e no maximo {1} caracteres preenchidos")]
    public string Title { get; set; }

    [Required]
    [Display(Name = "SmtpConfig", Description = "Endereço de SMTP do HOST")]
    [Length(1, 255, ErrorMessage = "{0} deve ter no minimo {2} e no maximo {1} caracteres preenchidos")]
    public string Subject { get; set; }

    [Required]
    [Display(Name = "PrimaryPort", Description = "Porta principal de acesso")]
    [Length(1, 8000, ErrorMessage = "{0} deve ter no minimo {2} e no maximo {1} caracteres preenchidos")]
    public string Body { get; set; }

    [Required]
    [Display(Name = "MessagePriority", Description = "Grau de prioridade do envio do email")]
    public MessagePriority MessagePriority { get; set; }

    [Required]
    [Display(Name = "HasAttachment", Description = "Tem arquivo em anexo")]
    public bool HasAttachment { get; set; }

    [Required]
    [Display(Name = "IdEmailTemplate", Description = "Id do template de email")]
    public long IdEmailTemplate { get; set; }
}

public record EmailDisplaySettingsUpdateRequestDTO : GenericDTOModel
{
    [Required]
    [Display(Name = "Id", Description = "Id do registro")]
    public long? Id { get; set; }

    [Required]
    [Display(Name = "Host", Description = "Host do Email")]
    [Length(1, 255, ErrorMessage = "{0} deve ter no minimo {2} e no maximo {1} caracteres preenchidos")]
    public string Title { get; set; }

    [Required]
    [Display(Name = "SmtpConfig", Description = "Endereço de SMTP do HOST")]
    [Length(1, 255, ErrorMessage = "{0} deve ter no minimo {2} e no maximo {1} caracteres preenchidos")]
    public string Subject { get; set; }

    [Required]
    [Display(Name = "PrimaryPort", Description = "Porta principal de acesso")]
    [Length(1, 8000, ErrorMessage = "{0} deve ter no minimo {2} e no maximo {1} caracteres preenchidos")]
    public string Body { get; set; }

    [Required]
    [Display(Name = "MessagePriority", Description = "Grau de prioridade do envio do email")]
    public MessagePriority MessagePriority { get; set; }

    [Required]
    [Display(Name = "HasAttachment", Description = "Tem arquivo em anexo")]
    public bool HasAttachment { get; set; }

    [Required]
    [Display(Name = "IdEmailTemplate", Description = "Id do template de email")]
    public long IdEmailTemplate { get; set; }
}

public record EmailDisplaySettingsReactiveRequestDTO : GenericDTOModel
{
    [Required]
    [Display(Name = "Id", Description = "Id do registro")]
    public long? Id { get; set; }
}


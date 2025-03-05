using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebAPI.Domain.DTO.Generic;

namespace WebAPI.Domain.DTO.ControlPanel;

public record EmployeeResponseDTO : GenericDTO
{
    [DisplayName("Name")]
    public string Name { get; set; }
    [DisplayName("Email")]
    public string Email { get; set; }
    [DisplayName("TelPhone")]
    public string TelPhone { get; set; }
    [DisplayName("CelPhone")]
    public string CelPhone { get; set; }
    [DisplayName("Salary")]
    public decimal Salary {get; set; }
    [DisplayName("SalaryAnual")]
    public decimal SalaryAnual {get; set; }
    [DisplayName("BirthDate")]
    public DateTime BirthDate {get; set; }
    [DisplayName("Age")]
    public int Age {get; set; }

    public override string ToString() => $"Name: {Name}";
}

public record EmployeeRequestDTO : GenericDTO
{
    [Required(ErrorMessage = "O campo Name é obrigatório")]
    public string Name { get; set; }
    [Required(ErrorMessage = "O campo Email é obrigatório")]
    public string Email { get; set; }
    [Required(ErrorMessage = "O campo TelPhone é obrigatório")]
    public string TelPhone { get; set; }
    [Required(ErrorMessage = "O campo CelPhone é obrigatório")]
    public string CelPhone { get; set; }
    [DisplayName("Salary")]
    public decimal Salary {get; set; }
    [DisplayName("BirthDate")]
    public DateTime BirthDate {get; set; }
    public long IdProfile { get; set; }
    public long IdUser { get; set; }

    public override string ToString() => $"Name: {Name}";
}

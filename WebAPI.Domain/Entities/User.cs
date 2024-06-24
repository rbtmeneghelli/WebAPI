using WebAPI.Domain.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Domain.Entities;

//Exemplo de DataAnnotation de aplicação de FluentAPI, sem necessidade de especificar no onModelCreating
//[EntityTypeConfiguration(typeof(UserMapping))]
public class User : GenericEntity
{
    public string Login { get; set; }
    [JsonIgnore]

    public string Password { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]

    public string LastPassword { get; set; }
    public bool IsAuthenticated { get; set; }
    public long IdProfile { get; set; }
    public Profile Profile { get; set; }

    [NotMapped]
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]

    public string NewPassword { get; set; }

    public bool HasTwoFactoryValidation { get; set; }

    public override string ToString() => $"Login: {Login}";
}

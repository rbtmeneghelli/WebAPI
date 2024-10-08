﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using WebAPI.Domain.Entities.Generic;

namespace WebAPI.Domain.Entities.ControlPanel;

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
    public virtual Employee Employee { get; set; }
    [NotMapped]
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public string NewPassword { get; set; }
    public bool HasTwoFactoryValidation { get; set; }
    public override string ToString() => $"Login: {Login}";
}

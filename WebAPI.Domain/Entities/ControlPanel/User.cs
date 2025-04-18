using System.ComponentModel.DataAnnotations.Schema;
using FastPackForShare.Default;

namespace WebAPI.Domain.Entities.ControlPanel;

public class User : BaseEntityModel
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

    protected override void CreateEntityIsValid()
    {
        throw new NotImplementedException();
    }

    protected override void UpdateEntityIsValid()
    {
        throw new NotImplementedException();
    }
}

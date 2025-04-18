using FastPackForShare.Default;

namespace WebAPI.Domain.Entities.ControlPanel;

public class Employee : BaseEntityModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string TelPhone { get; set; }
    public string CelPhone { get; set; }
    public decimal Salary {get; set; }
    public DateTime BirthDate {get; set; }
    public long IdProfile { get; set; }
    public virtual Profile Profile { get; set; }
    public long IdUser { get; set; }
    public virtual User User { get; set; }

    protected override void CreateEntityIsValid()
    {
        throw new NotImplementedException();
    }

    protected override void UpdateEntityIsValid()
    {
        throw new NotImplementedException();
    }
}

namespace WebAPI.Domain.Entities.Others;

public class Notification
{
    public long? Id { get; set; }
    public string Description { get; set; }
    public DateTime? CreatedDate { get; set; }
    public bool Status { get; set; }

    public Notification()
    {

    }

    public Notification(long? id, string description, DateTime createdDate, bool status)
    {
        Id = id;
        Description = description;
        CreatedDate = createdDate;
        Status = status;
    }

    // Expression Body Constructor
    public Notification(string description, DateTime createdTime, bool isActive)
    => (Description, CreatedDate, Status) = (description, createdTime, isActive);
}

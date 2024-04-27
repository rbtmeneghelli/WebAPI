namespace WebAPI.Domain.Generic;

public abstract class GenericEntity
{
    private long? _id;

    public long? Id
    {
        get
        {
            return _id;
        }
        set
        {
            _id = value.HasValue ? (value > 0 ? value : null) : null; 
        }
    }

    public DateTime? CreatedTime { get; set; }

    public DateTime? UpdateTime { get; set; }

    public bool IsActive { get; set; }

    public string GetStatus() => IsActive ? FixConstants.STATUS_ACTIVE : FixConstants.STATUS_INACTIVE;
}

using WebAPI.Domain.ExtensionMethods;

namespace WebAPI.Domain.Generic;

public abstract class GenericEntity
{
    private long? _id;
    private DateTime? _createdTime;
 
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

    public DateTime? CreatedTime
    {
        get
        {
            return _createdTime;
        }
        set
        {
            _createdTime = _id.HasValue ? value : DateOnlyExtensionMethods.GetDateTimeNowFromBrazil();
        }
    }

    public DateTime? UpdateTime { get; set; }

    public bool IsActive { get; set; }

    public string GetIsActiveDescription() => IsActive ? FixConstants.STATUS_ACTIVE : FixConstants.STATUS_INACTIVE;
    public DateTime GetNewUpDateTime() => DateOnlyExtensionMethods.GetDateTimeNowFromBrazil();
}

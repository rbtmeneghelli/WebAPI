using WebAPI.Domain.Constants;
using WebAPI.Domain.ExtensionMethods;

namespace WebAPI.Domain.Entities.Generic;

public abstract class GenericEntity
{
    private long? _id;
    private DateTime? _createDate;

    public long? Id
    {
        get
        {
            return _id;
        }
        set
        {
            _id = value.HasValue ? value > 0 ? value : null : null;
        }
    }

    public DateTime? CreateDate
    {
        get
        {
            return _createDate;
        }
        set
        {
            _createDate = _id.HasValue ? value : DateOnlyExtensionMethods.GetDateTimeNowFromBrazil();
        }
    }

    public DateTime? UpdateDate { get; set; }

    public bool Status { get; set; }

    public string GetStatusDescription() => Status ? FixConstants.STATUS_ACTIVE : FixConstants.STATUS_INACTIVE;
    public DateTime GetNewUpdateDate() => DateOnlyExtensionMethods.GetDateTimeNowFromBrazil();
}

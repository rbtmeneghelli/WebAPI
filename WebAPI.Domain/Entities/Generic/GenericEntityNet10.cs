using WebAPI.Domain.Constants;
using WebAPI.Domain.ExtensionMethods;

namespace WebAPI.Domain.Entities.Generic;

/// <summary>
/// A partir do NET 10 com C# 14 não será necessario criar uma propriedade privada, esse processo será substituido pela palavra chave field.
/// </summary>
public abstract class GenericEntityNet10
{
    //public long? Id
    //{
    //    get
    //    {
    //        return field;
    //    }
    //    set
    //    {
    //        field = value.HasValue ? value > 0 ? value : null : null;
    //    }
    //}

    //public DateTime? CreateDate
    //{
    //    get
    //    {
    //        return field;
    //    }
    //    set
    //    {
    //        field = _id.HasValue ? value : DateOnlyExtensionMethods.GetDateTimeNowFromBrazil();
    //    }
    //}

    public DateTime? UpdateDate { get; set; }

    public bool Status { get; set; }

    public string GetStatusDescription() => Status ? FixConstants.STATUS_ACTIVE : FixConstants.STATUS_INACTIVE;
    public DateTime GetNewUpdateDate() => DateOnlyExtensionMethods.GetDateTimeNowFromBrazil();
}

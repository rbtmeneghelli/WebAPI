using WebAPI.Domain.Entities.Generic;

namespace WebAPI.Domain.Entities.Others;

public class City : GenericEntity
{
    public string Name { get; set; }

    public long? IBGE { get; set; }

    public long StateId { get; set; }

    public virtual States States { get; set; }

    public static int GetDFCodeFromIBGE() => 5300108;
    public static string GetDFNameFromIBGE() => "DISTRITO FEDERAL";
    public static string GetDFNickNameFromIBGE() => "DF";
}

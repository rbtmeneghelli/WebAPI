using FastPackForShare.Bases.Generics;

namespace WebAPI.Domain.Entities.Others;

public class Log : GenericEntityModel
{
    public long Id { get; set; }
    public string Class { get; set; }
    public string Method { get; set; }
    public string MessageError { get; set; }
    public DateTime UpdateTime { get; set; }
    public string Object { get; set; }
}

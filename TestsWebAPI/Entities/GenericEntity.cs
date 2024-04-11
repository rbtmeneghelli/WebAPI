namespace TestsWebAPI.Entities;

public abstract class GenericEntity
{
    public long Id { get; set; }
    public DateTime? Data { get; set; }
    public TimeSpan? HoraInicial { get; set; }
    public TimeSpan? HoraFinal { get; set; }
}

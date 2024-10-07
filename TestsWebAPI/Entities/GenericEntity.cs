namespace TestsWebAPI.Entities;

public abstract class GenericEntity
{
    public long Id { get; set; }
    public DateTime? Data { get; set; }
    public TimeSpan? InitialHour { get; set; }
    public TimeSpan? FinalHour { get; set; }
}

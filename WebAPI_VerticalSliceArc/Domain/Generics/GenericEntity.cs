using System.Text.Json;

namespace WebAPI_VerticalSliceArc.Domain.Generics;

public abstract class GenericEntity
{
    public long? Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize($"Objeto em formato JSON: {this}");
    }
}

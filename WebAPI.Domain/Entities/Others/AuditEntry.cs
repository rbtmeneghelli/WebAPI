using FastPackForShare.Extensions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;

namespace WebAPI.Domain.Entities.Others;

public class AuditEntry : GenericEntityModel
{
    // Expression Body Constructor
    public AuditEntry(EntityEntry entry) => Entry = entry;

    public EntityEntry Entry { get; }
    public string TableName { get; set; }
    public string ActionName { get; set; }
    public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
    public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
    public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
    public List<PropertyEntry> TemporaryProperties { get; } = new List<PropertyEntry>();

    public bool HasTemporaryProperties => TemporaryProperties?.Count() > 0;

    public Audit ToAudit()
    {
        return new Audit()
        {
            TableName = TableName,
            ActionName = ActionName,
            CreatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil(),
            KeyValues = JsonSerializer.Serialize(KeyValues),
            OldValues = OldValues.Count == 0 ? null : JsonSerializer.Serialize(OldValues),
            NewValues = NewValues.Count == 0 ? null : JsonSerializer.Serialize(NewValues),
        };
    }
}

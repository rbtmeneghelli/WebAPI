using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using WebAPI.Domain.ExtensionMethods;

namespace WebAPI.Domain.Entities.Others;

public class AuditEntry
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
            CreateDate = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(),
            KeyValues = JsonConvert.SerializeObject(KeyValues),
            OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues),
            NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues),
        };
    }
}

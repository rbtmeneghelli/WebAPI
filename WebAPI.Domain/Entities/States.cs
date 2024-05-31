using WebAPI.Domain.Generic;
using Newtonsoft.Json;
using System.Diagnostics;

namespace WebAPI.Domain.Entities;

[DebuggerDisplay("IdRegião: {RegionId}, Nome: {Name}, Sigla: {Initials}")]
public class States : GenericEntity
{
    [JsonProperty("Sigla")]
    public string Initials { get; set; }
    [JsonProperty("Nome")]
    public string Name { get; set; }
    [JsonProperty("Regiao")]
    public Region Region { get; set; }
    public long RegionId { get; set; }
    public virtual IEnumerable<ValueObject.AddressData> Ceps { get; set; }
    public virtual IEnumerable<City> City { get; set; }
}

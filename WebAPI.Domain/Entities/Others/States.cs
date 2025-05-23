﻿using System.Diagnostics;
using FastPackForShare.Default;

namespace WebAPI.Domain.Entities.Others;

[DebuggerDisplay("IdRegião: {RegionId}, Nome: {Name}, Sigla: {Initials}")]
public class States : BaseEntityModel
{
    [JsonPropertyName("Sigla")]
    public string Initials { get; set; }
    [JsonPropertyName("Nome")]
    public string Name { get; set; }
    [JsonPropertyName("Regiao")]
    public Region Region { get; set; }
    public long RegionId { get; set; }
    public virtual IEnumerable<ValueObject.AddressData> Ceps { get; set; }
    public virtual IEnumerable<City> City { get; set; }

    protected override void CreateEntityIsValid()
    {
        throw new NotImplementedException();
    }

    protected override void UpdateEntityIsValid()
    {
        throw new NotImplementedException();
    }
}

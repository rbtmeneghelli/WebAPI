using System.Diagnostics;
using WebAPI.Domain.DTO.Others;
using FastPackForShare.Default;

namespace WebAPI.Domain.Entities.Others;

[DebuggerDisplay("Id: {Id}, Nome: {Name}, Sigla: {Initials}")]
public class Region : BaseEntityModel
{
    [JsonPropertyName("Nome")]
    public string Name { get; set; }
    [JsonPropertyName("Sigla")]
    public string Initials { get; set; }
    public IEnumerable<States> States { get; set; }

    protected override void CreateEntityIsValid()
    {
        throw new NotImplementedException();
    }

    protected override void UpdateEntityIsValid()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Faz a conversão implicita do objeto Region para RegionDto, ao passar a entidade
    /// O explicit você precisa efetuar um cast antes de mandar o parametro
    /// </summary>
    /// <param name="region"></param>
    public static implicit operator RegionResponseDTO(Region region)
    {
        return new()
        {
            Name = region.Name,
            Initials = region.Initials
        };
    }

    public static implicit operator string(Region region)
    {
        return $"Nome da região {region.Name}, Iniciais da região {region.Initials}";
    }
}

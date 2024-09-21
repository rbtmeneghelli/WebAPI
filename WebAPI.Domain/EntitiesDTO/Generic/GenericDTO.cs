using System.ComponentModel.DataAnnotations;
using WebAPI.Domain.Constants;

namespace WebAPI.Domain.EntitiesDTO.Generic;

public abstract record GenericDTO
{
    public long? Id { get; set; }

    [Display(Name = "Ativo")]
    public bool IsActive { get; set; }

    public long? GetId() => Id.HasValue ? Id > 0 ? Id : null : null;

    public string GetStatus() => IsActive ? FixConstants.STATUS_ACTIVE : FixConstants.STATUS_INACTIVE;

    /// <summary>
    /// Vai Copiar o objeto e suas propriedades, porém a unica propriedade alterada no objeto novo criado será o campo IsActive
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public virtual GenericDTO ChangeStatusToDeactive<T>(GenericDTO obj)
    {
        return obj with { IsActive = false };
    }

    /// <summary>
    /// Vai Copiar o objeto e suas propriedades, porém a unica propriedade alterada no objeto novo criado será o campo IsActive
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public virtual GenericDTO ChangeStatusToActive<T>(GenericDTO obj)
    {
        return obj with { IsActive = true };
    }
}

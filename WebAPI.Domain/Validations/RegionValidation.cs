using FluentValidation;
using WebAPI.Domain.Entities;

namespace WebAPI.Domain.Validations;

/// <summary>
/// Usar a biblioteca >> FluentValidation.AspNetCore
/// </summary>
public class RegionValidation : AbstractValidator<Region>
{
    public RegionValidation()
    {
        // Id deve ser maior que 0
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("O valor '{PropertyValue}' para '{PropertyName}' é inválido.");

        // Nome - MinLength 8, MaxLength 100
        RuleFor(x => x.Name)
            .MinimumLength(8)
            .WithMessage("O '{PropertyName}' deve ter no mínimo {MinLength} caracteres.")
            .MaximumLength(100)
            .WithMessage("O '{PropertyName}' deve ter no máximo {MaxLength} caracteres.");

        RuleFor(x => x.Initials)
            .MinimumLength(2)
            .WithMessage("O '{PropertyName}' deve ter no entre {MinLength} e {MaxLength} caracteres, porém foi inserido {TotalLength} caracteres")
            .MaximumLength(3)
            .WithMessage("O '{PropertyName}' deve ter no entre {MinLength} e {MaxLength} caracteres, porém foi inserido {TotalLength} caracteres");

        //Tratamento com Coleção
        RuleFor(x => x.States)
            .NotNull()
            .WithMessage("A coleção '{PropertyName}' deve ter no mínimo 5 cursos.")
            .Must((region, states, builder) => states.Count() >= 5)
            .WithMessage("A coleção '{PropertyName}' deve ter no mínimo 5 cursos.");
    }
}

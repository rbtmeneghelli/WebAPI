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
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Id é inválido.");

        RuleFor(x => x.Name)
            .MinimumLength(2)
            .WithMessage("O 'Nome' deve ter no mínimo 8 caracteres.")
            .MaximumLength(10)
            .WithMessage("O 'Nome' deve ter no máximo 10 caracteres.");

        //Tratamento com Coleção
        RuleFor(x => x.States)
            .NotNull()
            .WithMessage("A coleção 'Cursos' deve ter no mínimo 5 cursos.")
            .Must((region, states, builder) => states.Count() >= 5)
            .WithMessage("A coleção 'Cursos' deve ter no mínimo 5 cursos.");
    }
}

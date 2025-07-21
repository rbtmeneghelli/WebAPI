using FluentValidation;
using WebMinimalAPI._2._Application.DTOS;

namespace WebMinimalAPI._2._Application.Validators;

public sealed class ProductDTOValidator : AbstractValidator<ProductDTO>
{
    public ProductDTOValidator()
    {
        RuleFor(x => x.Name)
        .NotEmpty().WithMessage("Nome é obrigatório.")
        .MinimumLength(3).WithMessage("Nome deve ter pelo menos 3 caracteres.");
    }
}

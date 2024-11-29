using FluentResults;
using MediatR;
using WebAPI_VerticalSliceArc.Domain.Entities;

namespace WebAPI_VerticalSliceArc.Features.Products.Commands;

public record CreateProductCommand(string Name, decimal Price) : IRequest<Result<long?>>;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<long?>>
{
    private readonly IProductRepository _iprodutoRepository;

    public CreateProductCommandHandler(IProductRepository iprodutoRepository)
    {
        _iprodutoRepository = iprodutoRepository;
    }

    public async Task<Result<long?>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new ProductEntity(command.Name, command.Price);
        await _iprodutoRepository.CreateProductAsync(product);
        return Result.Ok(product.Id);
    }
}

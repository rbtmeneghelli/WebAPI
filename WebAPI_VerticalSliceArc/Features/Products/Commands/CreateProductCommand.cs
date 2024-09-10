using FluentResults;
using MediatR;
using WebAPI_VerticalSlice.Features.Products;
using WebAPI_VerticalSliceArc.Domain.Entities;

namespace WebAPI_VerticalSliceArc.Features.Products.Commands;

public record CreateProductCommand(string Name, decimal Price) : IRequest<Result<long?>>;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<long?>>
{
    private readonly ProdutoRepository _produtoRepository;

    public CreateProductCommandHandler(ProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<Result<long?>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new ProductEntity(command.Name, command.Price);
        await _produtoRepository.CreateProductAsync(product);
        return Result.Ok(product.Id);
    }
}

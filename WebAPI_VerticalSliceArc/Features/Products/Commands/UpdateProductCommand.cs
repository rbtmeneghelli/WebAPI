using FluentResults;
using MediatR;

namespace WebAPI_VerticalSliceArc.Features.Products.Commands;

public record UpdateProductCommand(long? Id, string Name, decimal Price) : IRequest<Result>;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result>
{
    private readonly IProdutoRepository _iprodutoRepository;

    public UpdateProductCommandHandler(IProdutoRepository iprodutoRepository)
    {
        _iprodutoRepository = iprodutoRepository;
    }

    public async Task<Result> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _iprodutoRepository.GetProductByIdAsync(command.Id.Value);
        
        if (product is null)
            return Result.Fail("Produto não encontrado!");

        product.Update(command.Name, command.Price);
        await _iprodutoRepository.UpdateProductAsync(product);
        return Result.Ok();
    }
}

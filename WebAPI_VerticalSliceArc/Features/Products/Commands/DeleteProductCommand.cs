using FluentResults;
using MediatR;

namespace WebAPI_VerticalSliceArc.Features.Products.Commands;

public record DeleteProductCommand(long? Id, bool IsLogicDelete = true) : IRequest<Result>;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result>
{
    private readonly IProdutoRepository _iprodutoRepository;

    public DeleteProductCommandHandler(IProdutoRepository iprodutoRepository)
    {
        _iprodutoRepository = iprodutoRepository;
    }

    public async Task<Result> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _iprodutoRepository.GetProductByIdAsync(command.Id.Value);

        if (product is null)
            return Result.Fail("Produto não encontrado!");

        if (command.IsLogicDelete)
        {
            product.Delete();
            await _iprodutoRepository.UpdateProductAsync(product);
        }
        else
        {
            await _iprodutoRepository.DeleteProductAsync(product);
        }

        return Result.Ok();
    }
}

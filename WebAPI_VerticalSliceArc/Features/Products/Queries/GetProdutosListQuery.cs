using FluentResults;
using MediatR;
using WebAPI_VerticalSliceArc.Domain.Entities;

namespace WebAPI_VerticalSliceArc.Features.Products.Queries;

public record GetProdutosListQuery : IRequest<Result<IEnumerable<ProductEntity>>>;

public class GetProdutosListQueryHandler : IRequestHandler<GetProdutosListQuery, Result<IEnumerable<ProductEntity>>>
{
    private readonly IProductRepository _iprodutoRepository;

    public GetProdutosListQueryHandler(IProductRepository iprodutoRepository)
    {
        _iprodutoRepository = iprodutoRepository;
    }

    public async Task<Result<IEnumerable<ProductEntity>>> Handle(GetProdutosListQuery query, CancellationToken cancellationToken)
    {
        var products = await _iprodutoRepository.GetAllProductsAsync();
        return Result.Ok(products);
    }
}

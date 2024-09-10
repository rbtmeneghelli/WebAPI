using FluentResults;
using MediatR;
using WebAPI_VerticalSlice.Features.Products;
using WebAPI_VerticalSliceArc.Domain.Entities;

namespace WebAPI_VerticalSliceArc.Features.Products.Queries;

public record GetProdutosListQuery : IRequest<Result<IEnumerable<ProductEntity>>>;

public class GetProdutosListQueryHandler : IRequestHandler<GetProdutosListQuery, Result<IEnumerable<ProductEntity>>>
{
    private readonly ProdutoRepository _produtoRepository;

    public GetProdutosListQueryHandler(ProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<Result<IEnumerable<ProductEntity>>> Handle(GetProdutosListQuery query, CancellationToken cancellationToken)
    {
        var products = await _produtoRepository.GetAllProductsAsync();
        return Result.Ok(products);
    }
}

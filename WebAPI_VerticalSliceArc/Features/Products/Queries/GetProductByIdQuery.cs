using FluentResults;
using MediatR;
using WebAPI_VerticalSlice.Features.Products;
using WebAPI_VerticalSliceArc.Domain.Entities;

namespace WebAPI_VerticalSliceArc.Features.Products.Queries;

public record GetProductByIdQuery(long Id) : IRequest<Result<ProductEntity>>;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Result<ProductEntity>>
{
    private readonly ProdutoRepository _produtoRepository;

    public GetProductByIdQueryHandler(ProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<Result<ProductEntity>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await _produtoRepository.GetProductByIdAsync(query.Id);
        return Result.Ok(product);
    }
}

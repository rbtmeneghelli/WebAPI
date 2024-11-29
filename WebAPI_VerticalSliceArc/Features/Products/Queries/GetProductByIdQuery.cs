using FluentResults;
using MediatR;
using WebAPI_VerticalSliceArc.Domain.Entities;

namespace WebAPI_VerticalSliceArc.Features.Products.Queries;

public record GetProductByIdQuery(long Id) : IRequest<Result<ProductEntity>>;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Result<ProductEntity>>
{
    private readonly IProductRepository _iprodutoRepository;

    public GetProductByIdQueryHandler(IProductRepository iprodutoRepository)
    {
        _iprodutoRepository = iprodutoRepository;
    }

    public async Task<Result<ProductEntity>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await _iprodutoRepository.GetProductByIdAsync(query.Id);
        return Result.Ok(product);
    }
}

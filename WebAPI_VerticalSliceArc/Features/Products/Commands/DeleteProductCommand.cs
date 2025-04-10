﻿using FluentResults;
using MediatR;
using WebAPI_VerticalSlice.Features.Products;

namespace WebAPI_VerticalSliceArc.Features.Products.Commands;

public record DeleteProductCommand(long? Id, bool IsLogicDelete = true) : IRequest<Result>;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result>
{
    private readonly IProductRepository _iprodutoRepository;

    public DeleteProductCommandHandler(IProductRepository iprodutoRepository)
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

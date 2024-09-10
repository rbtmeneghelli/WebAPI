using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI_VerticalSliceArc.Domain.Generics;
using WebAPI_VerticalSliceArc.Features.Products.Commands;
using WebAPI_VerticalSliceArc.Features.Products.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebAPI_VerticalSliceArc.Features.Products.Controllers;

public sealed class ProductController : GenericController
{
    public ProductController(IMediator iMediator) : base(iMediator)
    {

    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        var result = await _iMediator.Send(command);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Errors);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(long id, [FromBody] UpdateProductCommand command)
    {
        if (id != command.Id)
            return BadRequest("ID mismatch");

        var result = await _iMediator.Send(command);
        return result.IsSuccess ? NoContent() : NotFound(result.Errors);
    }

    [HttpPut("deleteLogic/{id}")]
    public async Task<IActionResult> DeleteLogicProduct(long id, [FromBody] DeleteProductCommand command)
    {
        var result = await _iMediator.Send(command);
        return result.IsSuccess ? NoContent() : NotFound(result.Errors);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePhysicalProduct(long id)
    {
        var result = await _iMediator.Send(new DeleteProductCommand(id, false));
        return result.IsSuccess ? NoContent() : NotFound(result.Errors);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(long id)
    {
        var result = await _iMediator.Send(new GetProductByIdQuery(id));
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Errors);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var result = await _iMediator.Send(new GetProdutosListQuery());
        return Ok(result.Value);
    }
}

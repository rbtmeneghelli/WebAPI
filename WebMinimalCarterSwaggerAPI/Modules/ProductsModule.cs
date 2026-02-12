using Carter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net;
using WebMinimalCarterSwaggerAPI.DTO;
using WebMinimalCarterSwaggerAPI.Entities;
using WebMinimalCarterSwaggerAPI.Mappings;
using WebMinimalCarterSwaggerAPI.Repository.Interfaces;

namespace WebMinimalCarterSwaggerAPI.Modules;

public sealed class ProductsModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var produtos = app.MapGroup("/Produtos").WithTags("Produtos");
        produtos.MapPost("criar", CreateProduct).WithSummary("Criar Produto").WithDescription("Endpoint responsável por adicionar novos produtos").RequireAuthorization();
        produtos.MapGet("", GetAllProducts).WithSummary("Obter Produtos").WithDescription("Endpoint responsável por obter os produtos da base de dados").CacheOutput("listMethods");
        produtos.MapGet("{id:int}", GetProductById).WithSummary("Obter Produto").WithDescription("Endpoint responsável por obter o produto existente pelo ID");
        produtos.MapPut("{id:int}", UpdateProduct).WithSummary("Atualizar Produto").WithDescription("Endpoint responsável por atualizar produto existente pelo ID").RequireAuthorization();
        produtos.MapDelete("{id:int}", DeleteProduct).WithSummary("Deletar Produto").WithDescription("Endpoint responsável por deletar produto existente pelo ID").RequireAuthorization();
    }

    [ProducesResponseType((int)HttpStatusCode.OK, Description = "Produtos obtidos com sucesso", Type = typeof(IEnumerable<Product>))]
    private IResult GetAllProducts([FromServices] IProductRepository productsRepo)
    {
        var products = productsRepo.GetProducts();
        return Results.Ok(products);
    }

    [ProducesResponseType((int)HttpStatusCode.Created, Description = "Produto criado com sucesso")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Description = "Não foi possivel criar o produto com o payload informado")]
    private IResult CreateProduct([FromBody, Required] ProductCreateDTO productCreateDTO, [FromServices] IProductRepository productsRepo, IOutputCacheStore outputCacheStore)
    {
        var product = ProductMapping.TransformToEntity(productCreateDTO);
        var productValidation = product.ValidateProductCreation();
        if (productValidation.Count() > 0) return Results.BadRequest(string.Join(",", productValidation));
        productsRepo.CreateProduct(product);
        outputCacheStore.EvictByTagAsync("produtos", CancellationToken.None);
        return Results.StatusCode((int)HttpStatusCode.Created);
    }

    [ProducesResponseType((int)HttpStatusCode.OK, Description = "Produto obtido com sucesso")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Description = "Produto não encontrado para o ID informado")]
    private IResult GetProductById([FromRoute, Description("ID do produto"), Required] int id, [FromServices] IProductRepository productsRepo)
    {
        if (id <= 0) return Results.BadRequest();
        return Results.Ok(productsRepo.GetProductById(id));
    }

    [ProducesResponseType((int)HttpStatusCode.OK, Description = "Produto atualizado com sucesso")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Description = "Não foi possivel atualizar o produto com o payload informado")]
    private IResult UpdateProduct([FromRoute, Description("ID do produto"), Required] int id, [FromBody, Required] ProductUpdateDTO productUpdateDTO, [FromServices] IProductRepository productRepo, IOutputCacheStore outputCacheStore)
    {
        var product = ProductMapping.TransformToEntity(productUpdateDTO);
        var productValidation = product.ValidateProductUpdate();
        if (productValidation.Count() > 0) return Results.BadRequest(string.Join(",", productValidation));
        productRepo.UpdateProduct(id, product);
        outputCacheStore.EvictByTagAsync("produtos", CancellationToken.None);
        return Results.Ok();
    }

    [ProducesResponseType((int)HttpStatusCode.OK, Description = "Produto excluido com sucesso", Type = typeof(bool))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Description = "Não foi possivel deletar o produto para o ID informado", Type = typeof(bool))]
    private bool DeleteProduct([FromRoute, Description("ID do produto"), Required] int id, [FromServices] IProductRepository productsRepo, IOutputCacheStore outputCacheStore)
    {
        if (id <= 0) return false;
        var result = productsRepo.DeleteProduct(id);
        outputCacheStore.EvictByTagAsync("produtos", CancellationToken.None);
        return result;
    }
}
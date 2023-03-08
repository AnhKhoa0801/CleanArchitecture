using Application.Products.Commands;
using Application.Products.Queries;
using Domain.Entities;
using MediatR;
using Newtonsoft.Json;

namespace WebApi.Controller;

public static class ProductRoute
{
    public static WebApplication MapRouteProductEndpoint(this WebApplication app)
    {

        app.MapGet("/product/{id}", async (int id,ISender sender) =>
        {
            var products = await sender.Send(new GetProductByIdQuery(id));

            return Results.Ok(products);
        });

        app.MapGet("/product/all", async (ISender sender) =>
        {
            var products = await sender.Send(new GetAllProductQuery());

            return Results.Ok(products);
        });

        app.MapPost("/product", async (CreateProductRequest request, ISender sender) =>
        {
            var command = new CreateProductCommand(request.Name, request.Price, request.Tags);
            var product = await sender.Send(command);
            return Results.Ok(product);
        });

        return app;
    }
}

public record CreateProductRequest(
    string Name,
    decimal Price,
    List<string> Tags);

using Application.Products.Commands;
using Application.Products.Queries;
using MediatR;

namespace WebApi.Controller;

public static class ProductController
{
    public static WebApplication MapRouteProductEndpoint(this WebApplication app)
    {
        app.MapGet("/product/{id}", async (int id, ISender sender) =>
        {
            var products = await sender.Send(new GetProductByIdQuery(id));

            if(products is null)
            {
                return Results.BadRequest($"Product Id {id} is not found");
            }

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

public sealed record CreateProductRequest(
    string Name,
    decimal Price,
    List<string> Tags);
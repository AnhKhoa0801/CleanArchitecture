using Domain.CQRS;
using Domain.Entities;

namespace Application.Products.Commands;

public sealed record CreateProductCommand(string Name,
    decimal Price, 
    List<string> Tags): ICommand<Product>;
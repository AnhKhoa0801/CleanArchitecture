using Domain.Entities;
using MediatR;

namespace Application.Products.Commands;

public sealed record CreateProductCommand(string Name,
    decimal Price, 
    List<string> Tags):IRequest<Product>;
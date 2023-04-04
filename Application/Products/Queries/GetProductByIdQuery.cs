using Domain.CQRS;
using Domain.Entities;

namespace Application.Products.Queries;

public sealed record GetProductByIdQuery(int Id): IQuery<Product>;
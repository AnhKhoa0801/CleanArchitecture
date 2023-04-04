using Domain.CQRS;
using Domain.Entities;

namespace Application.Products.Queries;

public sealed record GetAllProductQuery :IQuery<List<Product>>;

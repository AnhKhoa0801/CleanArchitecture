using Domain.Entities;
using MediatR;

namespace Application.Products.Queries;

public sealed record GetAllProductQuery :IRequest<List<Product>>;

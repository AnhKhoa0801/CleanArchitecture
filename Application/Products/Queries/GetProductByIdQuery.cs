using Domain.Entities;
using MediatR;

namespace Application.Products.Queries;

public sealed record GetProductByIdQuery(int Id): IRequest<Product>;

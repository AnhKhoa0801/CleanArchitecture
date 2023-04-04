using Domain.CQRS;
using Domain.Entities;
using Domain.Interface;

namespace Application.Products.Queries;

public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, Product>
{
    private readonly IProductRepository _repository;
    public GetProductByIdQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }
    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetById(request.Id);
    }
}
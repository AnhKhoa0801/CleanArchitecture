﻿using Domain.CQRS;
using Domain.Entities;
using Domain.Interface;

namespace Application.Products.Queries;

public class GetAllProductQueryHandler : IQueryHandler<GetAllProductQuery, List<Product>>
{
    private readonly IProductRepository _repository;
    public GetAllProductQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        return (await _repository.GetAll()).ToList();
    }
}
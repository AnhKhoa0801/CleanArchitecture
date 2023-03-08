﻿using Domain.Entities;
using Domain.Interface;
using MediatR;

namespace Application.Products.Queries;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
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
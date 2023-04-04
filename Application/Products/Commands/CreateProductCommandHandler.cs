using Domain.CQRS;
using Domain.Entities;
using Domain.Interface;
using Marten;

namespace Application.Products.Commands;

public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Product>
{
    private readonly IDocumentSession _session;
    private IDatabaseContext _context;
    public CreateProductCommandHandler(IDocumentSession session)
    {
        _session = session;
    }
    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Price = request.Price,
            Tags = request.Tags,
        };
        // mapper 1:1 database
        _session.Store(product);

        await _session.SaveChangesAsync();

        return product;
    }
}
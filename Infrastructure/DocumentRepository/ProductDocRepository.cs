using Azure.Core;
using Domain.Entities;
using Domain.Interface;
using Marten;
using System.Threading;

namespace Infrastructure.DocumentRepository;

public class ProductDocRepository : IProductRepository
{
    private readonly IDocumentSession _session;
    public ProductDocRepository(IDocumentSession session)
    {
        _session = session;
    }
    public async Task<Product> Add(Product product)
    {
        _session.Store(product);

        await _session.SaveChangesAsync();

        return product;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        IReadOnlyList<Product> products = await _session
            .Query<Product>()
            .Select(p => new Product()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Tags = p.Tags,
            })
            .ToListAsync();

        return products.ToList();
    }

    public async Task<Product> GetById(int id)
    {
        var product = await _session
            .Query<Product>()
            .FirstOrDefaultAsync(x => x.Id == id);

        return product;
    }
}
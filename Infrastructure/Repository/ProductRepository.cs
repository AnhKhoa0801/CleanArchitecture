using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ProductRepository : IProductRepository
{
    private readonly DatabaseContext _context;
    public ProductRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Product> Add(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetById(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
    }
}
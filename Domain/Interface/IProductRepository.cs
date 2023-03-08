using Domain.Entities;

namespace Domain.Interface;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAll();
    Task<Product> GetById(int id);
    Task<Product> Add(Product product);
}

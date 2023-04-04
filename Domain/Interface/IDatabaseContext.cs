using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interface;

public interface IDatabaseContext
{
    DbSet<Product> Products { get; set; }
}

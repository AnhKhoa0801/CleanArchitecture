using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class DatabaseContext :DbContext
{
    public DbSet<Product> Products { get; set; }
    public DatabaseContext(DbContextOptions dbContextOptions):
        base(dbContextOptions)
    {
    }
}
